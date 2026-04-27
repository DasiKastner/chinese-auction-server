using server.DTO;
using server.models;
using server.repositories;

namespace server.services
{
    public class LotteryService : ILotteryService
    {
        private readonly ILotteryRepository _lotteryRepository;
        public LotteryService(ILotteryRepository lotteryRepository)
        {
            _lotteryRepository = lotteryRepository;
        }
        public async Task<User?> drow(int giftId)
        {
            try
            {
                return await _lotteryRepository.drow(giftId);
            }
            catch (Exception ex)
            {
                throw ex;
                //כאן תהיה הדפסה ללוגר
            }
        }
        public async Task<IEnumerable<LotteryDTO>> getWinners()
        {
            try
            {
                return await _lotteryRepository.getWinners();
            }
            catch (Exception ex)
            {
                throw ex;
                //כאן תהיה הדפסה ללוגר
            }
        }
        public async Task<int> totalPay()
        {
            try
            {
                return await _lotteryRepository.totalPay();
            }
            catch (Exception ex)
            {
                return -1;
                //כאן תהיה הדפסה ללוגר
            }
        }
    }
}
