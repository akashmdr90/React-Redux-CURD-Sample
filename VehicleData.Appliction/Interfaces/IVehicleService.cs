using VehicleData.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VehicleData.Application.Interfaces
{
    public interface IVehicleService
    {
        /// <summary>
        /// Get the vehicle based on the filters
        /// </summary>
        /// <param name="year">Vehicle year</param>
        /// <param name="make">Vehicle make</param>
        /// <param name="model">Vehicle model</param>
        /// <returns>List of vehicles</returns>
        IEnumerable<VehicleViewModel> GetVehicles(string make, string model, int? year);

        /// <summary>
        /// Get a vehichle by id
        /// </summary>
        /// <param name="id">Vehichle id</param>
        /// <returns>Vehichle matching Id</returns>
        Task<VehicleViewModel> GetVehicleAsync(int id);

        /// <summary>
        /// Add a new vehichle
        /// </summary>
        /// <param name="vehicleData">Vehicle data to insert</param>
        /// <returns>vehicle that was added</returns>
        Task<VehicleViewModel> AddVehicleAsync(VehicleViewModel vehicleData);

        /// <summary>
        /// Update the vehicle details
        /// </summary>
        /// <param name="vehicle">vehicle data to update</param>
        /// <returns>True or False</returns>
        bool UpdateVehicle(VehicleViewModel vehicle);

        /// <summary>
        /// Delete the vehicle based on vehicle id
        /// </summary>
        /// <param name="id">vehichle id</param>
        /// <returns>True or False</returns>
        bool DeleteVehicle(int id);
    }
}
