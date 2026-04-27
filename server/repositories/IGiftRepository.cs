using server.DTO;
using server.models;

namespace server.repositories
{
    public interface IGiftRepository
    {
        GiftDTO? createGift(GiftDTO gift);
        void deleteGift(int id);
        IEnumerable<GiftDTO> getAllGifts();
        Gift? getGiftById(int id);
        Gift? GetGiftByName(string giftName);
        List<Gift> GetGiftsByDonor(string donorName);
        GiftDTO? updateGift(GiftDTO gift);
    }
}