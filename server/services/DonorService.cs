using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using server.DTO;
using server.models;
using server.repositories;

namespace server.services
{
    public class DonorService : IDonorService
    {
        public readonly IDonorRepository _donorRepository;
        private readonly ILogger<Donor> _logger;
        public DonorService(IDonorRepository donorRepository, ILogger<Donor> logger)
        {
            _donorRepository = donorRepository;
            _logger = logger;
        }
        public IEnumerable<Donor>? getAllDonors()
        {
            try
            {
                return _donorRepository.getAllDonors();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public Donor? getDonorById(int id)
        {
            try
            {
                return _donorRepository.getDonorById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public Donor createDonor(Donor donor)
        {
            try
            {
                return _donorRepository.createDonor(donor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public void deleteDonor(int id)
        {
            try
            {
                _donorRepository.deleteDonor(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
        public Donor? updateDonor(Donor donor)
        {
            try
            {
                return _donorRepository.updateDonor(donor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }
        public List<GiftDTO> getDonorGifts(int id)
        {
            try
            {
                return _donorRepository.getDonorGifts(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return null;
            }
        }


    }
} 
