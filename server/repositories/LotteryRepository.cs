using Microsoft.EntityFrameworkCore;
using server.DTO;
using server.models;

namespace server.repositories
{
    public class LotteryRepository : ILotteryRepository
    {
        private readonly ChineseSaleDbContext _context;
        public LotteryRepository(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<User?> drow(int giftId)
        {

            List<int> usersId = await _context.Purchase.Where(p => p.GiftId == giftId && p.Status == "purchased").Select(p => p.UserId).ToListAsync();
            int userId = random(usersId);
            var winner = new Lottery
            {
                GiftId = giftId,
                UserId = userId
            };
            await _context.Lottery.AddAsync(winner);
            await _context.SaveChangesAsync();
            User? user = await GetWinner(userId);
            if (user != null)
            {
                try
                {
                    await setWinnerName(giftId, user);
                }
                catch (Exception ex)
                {
                    //כאן תהיה הדפסה ללוגר
                }
                return user;
            }
            return null;
        }
        public async Task<User> GetWinner(int winnerCard)
        {
            User? u = await _context.User.FirstOrDefaultAsync(u => u.Id == winnerCard);
            return u;
        }
        public int random(List<int> newList)
        {
            try
            {
                if (newList == null)
                    throw new BadHttpRequestException("לא נרכשו כרטיסים עבור מתנה זו");
                if (newList.Count() == 0)
                    throw new BadHttpRequestException("לא נרכשו כרטיסים עבור מתנה זו");
                Random random = new Random();
                int index = random.Next(0, newList.Count());
                int winnerCard = newList[index];
                return winnerCard;
            }
            catch (BadHttpRequestException ex)
            {
                throw ex;
            }

        }
        public async Task setWinnerName(int giftId, User u)
        {
            Gift? g = _context.Gift.FirstOrDefault(g => g.Id == giftId);
            if (g != null)
            {
                g.WinnerName = u.FullName;
                _context.Gift.Update(g);
                await _context.SaveChangesAsync();
            }
            else
            {
                //כאן תהיה הדפסה ללוגר
            }

        }
        public async Task<IEnumerable<LotteryDTO>> getWinners()
        {
            var winner = await _context.Gift.Join(_context.Lottery, g => g.Id, l => l.GiftId, (g, l) => new { g, l })
            .Where(gl => gl.g.Id == gl.l.GiftId).Join(_context.User, l => l.l.UserId, u => u.Id, (l, u) => new { l, u })
            .Where(lu => lu.l.l.UserId == lu.u.Id)
            .Select(s => new LotteryDTO
            {
                Id = s.l.l.Id,
                Giftname = s.l.g.GiftName,
                WinnerName = s.u.FullName,
                Image = s.l.g.Image,
                Email = s.u.Email,
                Phone = s.u.Phone,
                Address = s.u.Adress,
            }).ToListAsync();
            return winner;
        }
        public async Task<int> totalPay()
        {
            var count = -1;
            var a = await _context.Purchase.Where(x => x.Status == "purchased").Select(x => x.GiftId).FirstOrDefaultAsync();
            List<int> x = await _context.Gift.Select(x => x.QuantityOfPurchases * x.Price).ToListAsync();
            foreach (var item in x)
            {
                count = count + item;
            }
            return count;
        }

    }
}
