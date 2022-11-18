using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CottageApp.Models;

namespace CottageApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ICottageItemRepository _cottageRepository;

    public HomeController(ILogger<HomeController> logger, ICottageItemRepository cottageRepository)
    {
        _logger = logger;
        _cottageRepository = cottageRepository;
    }

    public IActionResult Index()
    {
        var items = _cottageRepository.Get();
        return View(items);
    }

    [HttpGet("/api/Cottages")]
    public ActionResult<IEnumerable<CottageItem>> GetApi()
    {
        return Ok(_cottageRepository.Get());
    }

    [HttpGet("/api/Cottages/{whereNameStartsWith?}/{orderBy?}")]
    public ActionResult<IEnumerable<CottageItem>> GetApi(string? whereNameStartsWith, string? orderBy)
    {
        Func<CottageItem, string> orderByFunc = orderBy switch
        {
            "name" => item => item.Title,
            "description" => item => item.Description,
            _ => item => item.Title
        };

        if (string.IsNullOrEmpty(whereNameStartsWith))
        {
            return Ok(_cottageRepository.Get().ToArray().OrderBy(orderByFunc));
        }

        return Ok(_cottageRepository.Get()
            .Where(i => i.Title.StartsWith(whereNameStartsWith, true, null))
            .OrderBy(orderByFunc));
    }

    [HttpGet("/api/Cottages/{id:int}")]
    public ActionResult<CottageItem> FindItemApi(int id)
    {
        var item = _cottageRepository.FindById(id);
        if (item == CottageItem.NotFound) return NotFound();
        return Ok(item);
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
