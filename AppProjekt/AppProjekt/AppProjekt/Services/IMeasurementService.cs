using AppProjekt.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppProjekt.Services
{
    public interface IMeasurementService
    {
        Task<Measurement> GetMeasurementsAsync();
        Task<bool> PostOpenDoorAsync(int door);

        #region Add
        //Task<bool> AddMeasurementAsync(Measurement measurement);
        #endregion
        #region Update
        //Task<bool> UpdateMeasurementAsync(Measurement measurement);
        #endregion
        #region Delete
        //Task<bool> DeleteTemperatureAsync(int id);
        //Task<bool> DeleteHumidityAsync(int id);
        #endregion

        Task<bool> Exists(int id);
    }
}
