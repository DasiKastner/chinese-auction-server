using Microsoft.EntityFrameworkCore;
using server.DTO;
using server.models;

using static server.repositories.PurchaseRepository;


namespace server.repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {

        private readonly ChineseSaleDbContext _context;
        public PurchaseRepository(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PurchaseDTO>> GetPurchasesByUser(int userId)
        {
            IEnumerable<PurchaseDTO> res = await _context.Purchase.Join(_context.Gift, p => p.GiftId, g => g.Id,
                (p, g) => new { p, g }).Where(pr => pr.p.UserId == userId && pr.p.Status == "draft").GroupBy(pr => pr.p.GiftId)
                .Select(pr => new PurchaseDTO
                {
                    Id = pr.Select(x => x.p.Id).FirstOrDefault(),
                    GiftName = pr.Select(x => x.g.GiftName).First(),
                    Image = pr.Select(x => x.g.Image).First(),
                    Price = pr.Select(x => x.g.Price).First() * pr.Count(),
                    QuantityOfPurchases = pr.Count(),
                    GiftId = pr.Select(x => x.g.Id).First()
                }).ToListAsync();
            return res;
        }

        public async Task<Purchase> AddPurchase(Purchase newPurchase)
        {
            Gift? gift = _context.Gift.FirstOrDefault(g => g.Id == newPurchase.GiftId);
            if (gift != null)
            {
                gift.QuantityOfPurchases++;
                await _context.SaveChangesAsync();
            }
            _context.Purchase.Add(newPurchase);
            await _context.SaveChangesAsync();
            return newPurchase;
        }
        public async Task updatePurchase(int userId, int giftId)
        {
            var p = await _context.Purchase.Where(p => p.UserId == userId && p.GiftId == giftId && p.Status == "draft").ToListAsync();
            foreach (var item in p)
            {
                item.Status = "purchased";
                _context.Purchase.Update(item);
            }
            await _context.SaveChangesAsync();
        }
        //public Purchase? GetPurchaseById()
        //{
        //    Purchase? p = _context.Purchase.FirstOrDefault();
        //    if (p != null)
        //        return p;
        //    return null;
        //}
        public async Task DeletePurchase(int userId, int giftId)
        {
            Console.WriteLine("hhhhhhhhhh");
            var allPurchases = _context.Purchase.Where(p => p.UserId == userId && p.GiftId == giftId && p.Status == "draft").ToList();
            Purchase p = allPurchases[0];
            Console.WriteLine(allPurchases[0].GiftId);
            Console.WriteLine("deleteeee");
            _context.Purchase.Remove(p);
            _context.SaveChanges();
        }
        //ניהול רכישות
        public async Task<IEnumerable<User>>? GetDetails(int giftId)
        {
            var purchases = await _context.Purchase.Where(p => p.Status == "purchased" && p.GiftId == giftId).ToListAsync();
            if (purchases.Any())
            {
                return purchases.Join(_context.User, p => p.UserId, u => u.Id,
                    (p, u) => new { p, u }).Where(pu => pu.p.UserId == pu.u.Id)
                    .Select(s => s.u).Distinct().ToList();
            }
            return null;
        }
        public async Task<IEnumerable<object>>? GetAllDetails()
        {
            var purchases = await _context.Purchase.Where(p => p.Status == "purchased").ToListAsync();
            if (purchases.Any())
            {
                return purchases.Join(_context.User, p => p.UserId, u => u.Id,
                    (p, u) => new { p, u }).Where(pu => pu.p.UserId == pu.u.Id)
                    .Select(s => s.u).Distinct().ToList();
            }
            return null;
        }
    }
}

