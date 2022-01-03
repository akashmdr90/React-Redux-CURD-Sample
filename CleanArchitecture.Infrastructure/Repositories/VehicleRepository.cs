using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using VehicleData.Domain.Models;
using VehicleData.Domain.Interfaces;
using VehicleData.Infrastructure.Context;

namespace VehicleData.Infrastructure.Repositories
{
    /// <summary>
    /// Vehicle repository class
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        public VehicleStoreDbContext _context;

        /// <summary>
        /// Vehicle repository class
        /// </summary>
        /// <param name="context">The db context</param>
        public VehicleRepository(VehicleStoreDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get the vehicle based on the filters
        /// </summary>
        /// <param name="year">Vehicle year</param>
        /// <param name="make">Vehicle make</param>
        /// <param name="model">Vehicle model</param>
        /// <returns>List of vehicles</returns>
        public IEnumerable<Vehicle> GetVehicles(string make, string model, int? year)
        {
            return _context.Vehicles;
        }

        /// <summary>
        /// Get a vehichle by id
        /// </summary>
        /// <param name="id">Vehichle id</param>
        /// <returns>Vehichle matching Id</returns>
        public async Task<Vehicle> GetVehicleAsync(int id)
        {
            return await _context.Vehicles.FindAsync(id);
        }

        /// <summary>
        /// Add a new vehichle
        /// </summary>
        /// <param name="vehicleData">Vehicle data to insert</param>
        /// <returns>vehicle that was added</returns>
        public async Task<Vehicle> AddVehicleAsync(Vehicle vehicleData)
        {
            var response = await _context.Vehicles.AddAsync(vehicleData);
            _context.SaveChanges();
            return response.Entity;
        }

        /// <summary>
        /// Update the vehicle details
        /// </summary>
        /// <param name="updateVehicle">vehicle data to update</param>
        /// <returns>True or False</returns>
        public bool UpdateVehicle(Vehicle updateVehicle)
        {
            var record = _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id.Equals(updateVehicle.Id));
            if (record != null)
            {
                record.Make = updateVehicle.Make;
            record.Model = updateVehicle.Model;
            record.Year = updateVehicle.Year;
            _context.SaveChanges();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Delete the vehicle based on vehicle id
        /// </summary>
        /// <param name="id">vehichle id</param>
        /// <returns>True or False</returns>
        public bool DeleteVehicle(int id)
        {
            var record = _context.Vehicles.FirstOrDefault(vehicle => vehicle.Id.Equals(id));
            if (record != null)
            {
                _context.Remove(record);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
