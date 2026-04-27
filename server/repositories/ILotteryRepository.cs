using server.DTO;
using server.models;

namespace server.repositories
{
    public interface ILotteryRepository
    {
        Task<User?> drow(int giftId);
        Task<User> GetWinner(int winnerCard);
        Task<IEnumerable<LotteryDTO>> getWinners();
        int random(List<int> newList);
        Task setWinnerName(int giftId, User u);
        Task<int> totalPay();
    }
}