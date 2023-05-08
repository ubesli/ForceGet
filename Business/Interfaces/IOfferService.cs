using Core.GlobalModels.Offer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public  interface IOfferService
    {
        public  Task<bool> SaveOffer(OfferModel request);
        public List<OfferModel> GetOfferList();
        public OfferModel GetOfferDetails(int id);

    }
}
