using AppProjekt.Constants;
using AppProjekt.Models;
using AppProjekt.Repository;
using MonkeyCache.SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TinyIoC;
using Xamarin.Essentials;

namespace AppProjekt.Services
{
    public class MeasurementService : IMeasurementService
    {
        private readonly IGenericRepository _repo;
        public MeasurementService()
        {
            _repo = TinyIoCContainer.Current.Resolve<IGenericRepository>();
        }

        public async Task<Measurement> GetMeasurementsAsync()
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.ReadEndpoint + ApiConstants.Feeds,
                Query = $"api_key={ApiConstants.Read_API_Key}&results=500"
            };

            string url = builder.Path;

            if (Connectivity.NetworkAccess == NetworkAccess.None)
            {
                return Barrel.Current.Get<Measurement>(key: url);
            }
            if (!Barrel.Current.IsExpired(key: url))
            {
                return Barrel.Current.Get<Measurement>(key: url);
            }

            //Thread.Sleep(3000); // Simulerer 3 sekunders forsinkelte
            return await _repo.GetAsync<Measurement>(builder.ToString());
        }


        public async Task<bool> PostOpenDoorAsync(int door)
        {
            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.WriteEndpoint,
                Query = $"api_key={ApiConstants.Read_API_Key}&field3={door}"
            };


            //Thread.Sleep(3000); // Simulerer 3 sekunders forsinkelte

            if(door == await _repo.PostAsync(builder.ToString(), door))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //public async Task<Measurement> GetSingleMeasurement(int id)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.ThingspeakEndpoint}/{id}"
        //    };
        //    return await _repo.GetAsync<Measurement>(builder.ToString());
        //}

        public async Task<bool> Exists(int id)
        {
            return false;
        }

        #region Add
        //public async Task<bool> AddMeasurementAsync(Measurement measurement)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = ApiConstants.ThingspeakEndpoint,
        //        Query = $"api_key={ApiConstants.Write_API_Key}"
        //    };
        //    await _repo.PostAsync(builder.ToString(), measurement);
        //    return true;
        //}
        #endregion

        #region Delete
        //public async Task<bool> DeleteTemperatureAsync(int id)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.ThingspeakEndpoint}",
        //        Query = $"api_key={ApiConstants.Write_API_Key}&field1={id}"
        //    };
        //    await _repo.DeleteAsync(builder.ToString());
        //    return true;
        //}

        //public async Task<bool> DeleteHumidityAsync(int id)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.ThingspeakEndpoint}",
        //        Query = $"api_key={ApiConstants.Write_API_Key}&field2={id}"
        //    };
        //    await _repo.DeleteAsync(builder.ToString());
        //    return true;
        //}
        #endregion

        #region Update
        //public async Task<bool> UpdateMeasurementAsync(Measurement measurement)
        //{
        //    UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
        //    {
        //        Path = $"{ApiConstants.ThingspeakEndpoint}"
        //    };
        //    await _repo.PutAsync(builder.ToString(), measurement);
        //    return true;
        //}
        #endregion
    }
}
