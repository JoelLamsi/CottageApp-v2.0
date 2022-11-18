namespace CottageApp.Models;

public interface ICottageItemRepository
{
    CottageItem FindById(int id);
    IEnumerable<CottageItem> Get();
}