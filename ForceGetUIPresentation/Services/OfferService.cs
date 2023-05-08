using ForceGetUIPresentation.Models;
using System.Net.Http;
using System;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace ForceGetUIPresentation.Services
{
    public class OfferService : IOfferService
    {
        HttpClient _httpClient;
        IConfiguration configuration;
        private string offerServiceBaseUrl;
        public OfferService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            this.configuration = configuration;
            offerServiceBaseUrl = this.configuration.GetValue<string>("OfferServiceBaseUrl");
        }

        public async Task<List<OfferModel>> GetOfferList()
        {
            var serviceUrl = offerServiceBaseUrl + "GetOfferList";

            var response = await _httpClient.GetAsync(serviceUrl);

            if (response.IsSuccessStatusCode)
            {
                var content =  response.Content.ReadAsStringAsync().Result;
                if(content != null)
                {
                    var responseModel = JsonConvert.DeserializeObject<List<OfferModel>>(content);
                    return responseModel;
                }
                else
                {
                    return new List<OfferModel>();
                }
            }
            else
            {
                throw new Exception("An error has occurred");
            }
        }

        public async Task<int> SaveOffer(OfferModel offerModel)
        {
            var serviceUrl = offerServiceBaseUrl + "SaveOffer";
            var response = await _httpClient.PostAsJsonAsync(serviceUrl, offerModel);

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync();

                return (int)response.StatusCode;
            }
            else
            {
                return (int)response.StatusCode;
            }
        }

        //public async Task<OfferModel> GetOfferById(int id)
        //{

        //    var serviceUrl = offerServiceBaseUrl + "GetOfferDetails?id="+id;

        //    var response = await _httpClient.GetAsync(serviceUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = response.Content.ReadAsStringAsync().Result;
        //        if (content != null)
        //        {
        //            var responseModel = JsonConvert.DeserializeObject<OfferModel>(content);
        //            return responseModel;
        //        }
        //        else
        //        {
        //            return new OfferModel();
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("An error has occurred");
        //    }
        //}
    }
}
