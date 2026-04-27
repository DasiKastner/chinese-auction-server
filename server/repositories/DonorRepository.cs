using server.DTO;
using server.models;

namespace server.repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly ChineseSaleDbContext _context;
        public DonorRepository(ChineseSaleDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Donor> getAllDonors()
        {
            return _context.Donor.ToList();
        }
        public Donor createDonor(Donor donor)
        {
            _context.Add(donor);
            _context.SaveChanges();
            return donor;
        }
        public Donor? updateDonor(Donor donor)
        {
            _context.Donor.Update(donor);
            _context.SaveChanges();
            return getDonorById(donor.Id);
        }
        public void deleteDonor(int id)
        {
            IEnumerable<GiftDTO> donorGifts = getDonorGifts(id);
            if(!donorGifts.Any())
            { 
            Donor ? donor = getDonorById(id);
            if (donor != null)
            {
                List<Gift> gifts = _context.Gift.Where(g => g.DonorId == id).ToList();
                if (gifts.Any())
                {
                    foreach (var item in gifts)
                    {
                        _context.Gift.Remove(item);
                        _context.SaveChanges();
                    }
                }
                _context.Donor.Remove(donor);
                _context.SaveChanges();
            }
            }

        }
        public Donor? getDonorById(int id)
        {
            Donor? donor = _context.Donor.FirstOrDefault(d => d.Id == id);
            return donor;
        }
        public List<GiftDTO> getDonorGifts(int id)
        {
            return _context.Gift.Join(_context.Donor, g => g.DonorId, d => d.Id,
                (g, d) => new { g, d }).Where(gt => gt.g.DonorId == gt.d.Id).Join(_context.Category, g => g.g.CategoryId, c => c.Id, (g, c) => new { g, c }).Where(gc => gc.g.g.CategoryId == gc.c.Id).Where(w => w.g.g.DonorId == id)
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
    }
}
