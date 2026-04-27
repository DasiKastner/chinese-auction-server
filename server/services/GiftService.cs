using server.DTO;
using server.models;
using server.repositories;

namespace server.services
{
    public class GiftService : IGiftService
    {
        private readonly IGiftRepository _giftRepository;
        private readonly IDonorRepository _donorRepository;
        private readonly ILogger<GiftService> _logger;
        public GiftService(IGiftRepository giftRepository, IDonorRepository donorRepository, ILogger<GiftService> logger)
        {
            _giftRepository = giftRepository;
            _donorRepository = donorRepository;
            _logger = logger;
        }
        public IEnumerable<GiftDTO> getAllGift()
        {
            Console.WriteLine("aaa");
            try
            {
                return _giftRepository.getAllGifts();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed get the gifts", ex);
                return null;
            }
        }
        public Gift? getGiftById(int id)
        {
            try
            {
                return _giftRepository.getGiftById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed get the gift", ex);
                return null;
            }
        }
        public GiftDTO? createGift(GiftDTO gift)
        {
            try
            {
                return _giftRepository.createGift(gift);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed add the gift {gift.GiftName}", ex);
                return null;
            }
        }

        public GiftDTO? updateGift(GiftDTO gift)
        {

            try
            {
                return _giftRepository.updateGift(gift);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed update the gift {gift.GiftName}", ex);
                return null;
            }
        }
        public void deleteGift(int id)
        {
            try
            {
                _giftRepository.deleteGift(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed delete the gift", ex);
            }
        }
        public Gift? GetGiftByName(string giftName)
        {
            try
            {
                return _giftRepository.GetGiftByName(giftName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Gift> GetGiftsByDonor(string donorName)
        {
            try
            {
                return _giftRepository.GetGiftsByDonor(donorName);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}