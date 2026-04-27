using server.DTO;
using server.models;

namespace server.services
{
    public interface IGiftService
    {
        GiftDTO? createGift(GiftDTO gift);
        void deleteGift(int id);
        IEnumerable<GiftDTO> getAllGift();
        Gift? getGiftById(int id);
        Gift? GetGiftByName(string giftName);
        List<Gift> GetGiftsByDonor(string donorName);
        GiftDTO? updateGift(GiftDTO gift);
    }
}