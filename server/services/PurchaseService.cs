using server.models;
using server.repositories;

namespace server.services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        public PurchaseService(IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
        }
        public async Task<IEnumerable<object>?> GetPurchasesByUser(int userId)
        {
            try
            {
                return await _purchaseRepository.GetPurchasesByUser(userId);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public async Task<Purchase?> AddPurchase(int userId, int giftId)
        {
            try
            {
                Purchase newPurchase = new Purchase();
                newPurchase.UserId = userId;
                newPurchase.GiftId = giftId;
                newPurchase.Status = "draft";
                return await _purchaseRepository.AddPurchase(newPurchase);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task updatePurchase(int userId, int giftId)
        {
            try
            {
                await _purchaseRepository.updatePurchase(userId, giftId);
            }
            catch (Exception ex)
            {

            }

        }
        public async Task DeletePurchase(int userId, int giftId)
        {
            try
            {
                await _purchaseRepository.DeletePurchase(userId, giftId);
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<IEnumerable<User>>? GetDetails(int giftId)
        {
            try
            {
                return await _purchaseRepository.GetDetails(giftId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<object>>? GetAllDetails()
        {
            try
            {
                return await _purchaseRepository.GetAllDetails();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
