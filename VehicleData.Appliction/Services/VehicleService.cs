using VehicleData.Application.Interfaces;
using VehicleData.Application.ViewModels;
using VehicleData.Domain.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using VehicleData.Domain.Models;

namespace VehicleData.Application.Services
{
    public class VehicleService : IVehicleService
    {
        public IVehicleRepository _vehicleRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Vehicle Service
        /// </summary>
        /// <param name="vehicleRepository"> Vehicle repo</param>
        /// <param name="mapper">Mapper</param>
        public VehicleService(IVehicleRepository vehicleRepository,
            IMapper mapper)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        /// <summary>
        /// Get the vehicle based on the filters
        /// </summary>
        /// <param name="year">Vehicle year</param>
        /// <param name="make">Vehicle make</param>
        /// <param name="model">Vehicle model</param>
        /// <returns>List of vehicles</returns>
        public IEnumerable<VehicleViewModel> GetVehicles(string make, string model, int? year)
        {
            return _mapper.Map<IEnumerable<VehicleViewModel>>(_vehicleRepository.GetVehicles(make, model, year));
        }

        /// <summary>
        /// Get a vehichle by id
        /// </summary>
        /// <param name="id">Vehichle id</param>
        /// <returns>Vehichle matching Id</returns>
        public async Task<VehicleViewModel> GetVehicleAsync(int id)
        {
            var response = await _vehicleRepository.GetVehicleAsync(id);
            return _mapper.Map<VehicleViewModel>(response);
        }

        /// <summary>
        /// Add a new vehichle
        /// </summary>
        /// <param name="vehicleData">Vehicle data to insert</param>
        /// <returns>vehicle that was added</returns>
        public async Task<VehicleViewModel> AddVehicleAsync(VehicleViewModel vehicleData)
        {
            var response = await _vehicleRepository.AddVehicleAsync(_mapper.Map<Vehicle>(vehicleData));
            return _mapper.Map<VehicleViewModel>(response);
        }

        /// <summary>
        /// Update the vehicle details
        /// </summary>
        /// <param name="vehicle">vehicle data to update</param>
        /// <returns>True or False</returns>
        public bool UpdateVehicle(VehicleViewModel vehicle)
        {
            return _vehicleRepository.UpdateVehicle(_mapper.Map<Vehicle>(vehicle));
        }

        /// <summary>
        /// Delete the vehicle based on vehicle id
        /// </summary>
        /// <param name="id">vehichle id</param>
        /// <returns>True or False</returns>
        public bool DeleteVehicle(int id)
        {
            return _vehicleRepository.DeleteVehicle(id);
        }
    }
}
