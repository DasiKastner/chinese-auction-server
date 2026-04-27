using server.DTO;
using server.models;

namespace server.repositories
{
    public interface IPurchaseRepository
    {
        Task<Purchase> AddPurchase(Purchase newPurchase);
        Task DeletePurchase(int userId, int giftId);
        Task<IEnumerable<object>>? GetAllDetails();
        Task<IEnumerable<User>>? GetDetails(int giftId);
        Task<IEnumerable<PurchaseDTO>> GetPurchasesByUser(int userId);
        Task updatePurchase(int userId, int giftId);
    }
}