using server.DTO;
using server.models;

namespace server.repositories
{
    public class GiftRepository : IGiftRepository
    {
        private readonly ChineseSaleDbContext _context;
        private readonly IDonorRepository _donorRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        public GiftRepository(ChineseSaleDbContext chineseSaleDbContext, IDonorRepository donorRepository, IPurchaseRepository purchaseRepository)
        {
            _context = chineseSaleDbContext;
            _donorRepository = donorRepository;
            _purchaseRepository = purchaseRepository;
        }
        public IEnumerable<GiftDTO> getAllGifts()
        {
            Console.WriteLine("bbbb");
            return _context.Gift.Join(_context.Donor, g => g.DonorId, d => d.Id,
                (g, d) => new { g, d }).Where(gt => gt.g.DonorId == gt.d.Id).Join(_context.Category, g => g.g.CategoryId, c => c.Id, (g, c) => new { g, c }).Where(gc => gc.g.g.CategoryId == gc.c.Id)
                .Select(gt => new GiftDTO
                {
                    Id = gt.g.g.Id,
                    Price = gt.g.g.Price,
                    Image = gt.g.g.Image,
                    DonorName = gt.g.d.FullName,
                    CategoryName = gt.c.CategoryName,
                    Description = gt.g.g.Description,
                    QuantityOfPurchases = gt.g.g.QuantityOfPurchases,
                    GiftName = gt.g.g.GiftName,
                    WinnerName = gt.g.g.WinnerName
                }).ToList();

        }
        public Gift? getGiftById(int id)
        {
            return _context.Gift.FirstOrDefault(g => g.Id == id);
        }
        public GiftDTO? createGift(GiftDTO gift)
        {
            Category? c = _context.Category.FirstOrDefault(c => c.CategoryName == gift.CategoryName);
            Donor? d = _context.Donor.FirstOrDefault(d => d.FullName == gift.DonorName);
            if (c != null && d != null)
            {
                Gift newGift = new Gift
                {
                    GiftName = gift.GiftName,
                    Price = gift.Price,
                    QuantityOfPurchases = gift.QuantityOfPurchases,
                    Description = gift.Description,
                    Image = gift.Image,
                    CategoryId = c.Id,
                    DonorId = d.Id,
                    WinnerName = gift.WinnerName
                };
                _context.Gift.Add(newGift);
                _context.SaveChanges();
                return gift;
            }
            return null;
        }
        public GiftDTO? updateGift(GiftDTO gift)
        {
            Category? c = _context.Category.FirstOrDefault(c => c.CategoryName == gift.CategoryName);
            Donor? d = _context.Donor.FirstOrDefault(d => d.FullName == gift.DonorName);
            if (c != null && d != null)
            {
                Gift newGift = new Gift
                {
                    Id = gift.Id,
                    GiftName = gift.GiftName,
                    Price = gift.Price,
                    QuantityOfPurchases = gift.QuantityOfPurchases,
                    Description = gift.Description,
                    Image = gift.Image,
                    CategoryId = c.Id,
                    DonorId = d.Id,
                    WinnerName = gift.WinnerName
                };
                _context.Gift.Update(newGift);
                _context.SaveChanges();
                return gift;
            }
            return null;

        }
        public void deleteGift(int id)
        {
            Purchase? purchase = _context.Purchase.FirstOrDefault(p => p.GiftId == id && p.Status == "purchased");
            if(purchase == null)
            { 
            Gift? gift = getGiftById(id);
            if (gift != null)
            {
                _context.Gift.Remove(gift);
                _context.SaveChanges();
            }
            }
        }
        public Gift? GetGiftByName(string giftName)
        {
            var gift = _context.Gift.FirstOrDefault(g => g.GiftName == giftName);
            if (gift != null)
                return gift;
            return null;
        }
        public List<Gift> GetGiftsByDonor(string donorName)
        {
            var donors = _context.Donor.Where(d => d.FullName == donorName).ToList();

            if (donors.Any())
            {
                var donorIds = donors.Select(d => d.Id).ToList();
                var gifts = _context.Gift.Where(g => donorIds.Contains(g.DonorId)).ToList();
                return gifts;
            }

            return new List<Gift>();
        }
    }
}
