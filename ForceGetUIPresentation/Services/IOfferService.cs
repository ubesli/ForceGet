using ForceGetUIPresentation.Models;

namespace ForceGetUIPresentation.Services
{
    public interface IOfferService
    {
        public Task<int> SaveOffer(OfferModel offerModel);
        public Task<List<OfferModel>> GetOfferList();
        //public Task<OfferModel> GetOfferById(int id);

    }
}
