using Azure.Core;
using Business.Interfaces;
using Core.GlobalModels.Offer;
using DataAccess;
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class OfferService : IOfferService
    {
        private ForceGetContext forceGetContext;

        public OfferService(ForceGetContext forceGetContext)
        {
            this.forceGetContext = forceGetContext;
        }

        public OfferModel GetOfferDetails(int id)
        {
            var entity = forceGetContext.Offer.FirstOrDefault(x => x.Id == id);

            var offerModel = new OfferModel
            {
                Currency = entity.Currency,
                Incoterm = entity.Incoterm,
                Mode = entity.Mode,
                MovementType = entity.MovementType,
                CountriesCities = entity.CountriesCities,
                PackageType = entity.PackageType,
                Unit1 = entity.Unit1,
                Unit2 = entity.Unit2
            };
           

            return offerModel;
        }

        public List<OfferModel> GetOfferList()
        {
            var entityList = forceGetContext.Offer.Select(x=> new OfferModel
            {
                Id = x.Id,
                Currency = x.Currency,
                Incoterm = x.Incoterm,
                Mode = x.Mode,
                MovementType = x.MovementType,
                CountriesCities = x.CountriesCities,
                PackageType = x.PackageType,
                Unit1 = x.Unit1,
                Unit2 = x.Unit2
            }).ToList();

            return entityList;
        }

        public async Task<bool> SaveOffer(OfferModel request)
        {
            try
            {
                var entity = new Offer()
                {
                    Currency = request.Currency,
                    Incoterm = request.Incoterm,
                    Mode = request.Mode,
                    MovementType = request.MovementType,
                    CountriesCities = request.CountriesCities,
                    PackageType = request.PackageType,
                    Unit1 = request.Unit1,
                    Unit2 = request.Unit2
                };
                forceGetContext.Offer.Add(entity);

                await forceGetContext.SaveChangesAsync();


                return true;
            }
            catch (Exception ex)
            {
                //log ex
                return false;
            }
          
        }

        public List<int> GetOfferIdList()
        {
            var idList = forceGetContext.Offer.Select(x => x.Id).ToList();

            return idList;
        }

    }
}
