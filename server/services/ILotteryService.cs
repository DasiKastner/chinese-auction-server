using server.DTO;
using server.models;

namespace server.services
{
    public interface ILotteryService
    {
        Task<User?> drow(int giftId);
        Task<IEnumerable<LotteryDTO>> getWinners();
        Task<int> totalPay();
    }
}