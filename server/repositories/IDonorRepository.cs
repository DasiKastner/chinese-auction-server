using server.DTO;
using server.models;

namespace server.repositories
{
    public interface IDonorRepository
    {
        Donor createDonor(Donor donor);
        void deleteDonor(int id);
        IEnumerable<Donor> getAllDonors();
        Donor? getDonorById(int id);
        List<GiftDTO> getDonorGifts(int id);
        Donor? updateDonor(Donor donor);
    }
}