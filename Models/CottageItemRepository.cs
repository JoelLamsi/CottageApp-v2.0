namespace CottageApp.Models;

public class CottageItemRepository : ICottageItemRepository
{
    private readonly CottageContext _context;

    public CottageItemRepository(CottageContext context)
    {
        _context = context;
    }

    public CottageItem FindById(int id)
    {
        var outputValue = _context.CottageItems.FirstOrDefault(i => i.Id == id);

        if (outputValue == null)
        {
            return CottageItem.NotFound;
        }

        return outputValue;
    }

    public IEnumerable<CottageItem> Get()
    {
        return _context.CottageItems.ToArray();
    }
}