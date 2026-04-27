using server.models;

namespace server.services
{
    public interface IPurchaseService
    {
        Task<Purchase?> AddPurchase(int userId, int giftId);
        Task DeletePurchase(int userId, int giftId);
        Task<IEnumerable<object>>? GetAllDetails();
        Task<IEnumerable<User>>? GetDetails(int giftId);
        Task<IEnumerable<object>?> GetPurchasesByUser(int userId);
        Task updatePurchase(int userId, int giftId);
    }
}