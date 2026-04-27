using server.DTO;
using server.models;

namespace server.services
{
    public interface IDonorService
    {
        Donor createDonor(Donor donor);
        void deleteDonor(int id);
        IEnumerable<Donor>? getAllDonors();
        Donor? getDonorById(int id);
        List<GiftDTO> getDonorGifts(int id);
        Donor? updateDonor(Donor donor);
    }
}