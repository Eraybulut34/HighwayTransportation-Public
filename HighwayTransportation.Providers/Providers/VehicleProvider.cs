using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;


namespace HighwayTransportation.Providers
{
    public class VehicleProvider : ProviderBase<VehicleService, Vehicle>
    {
        IMapper _mapper;
        VehicleService _vehicleService;

        public VehicleProvider(VehicleService vehicleService, IMapper mapper) : base(vehicleService)
        {
            _mapper = mapper;
            _vehicleService = vehicleService;
        }

        public async Task<List<GetVehicleListDto>> GetVehicles()
        {
            //IsDeleted == false
            var vehicles = await _vehicleService.GetAllAsync();
            return _mapper.Map<List<GetVehicleListDto>>(vehicles.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Vehicle> CreateVehicle(CreateVehicleDto vehicle)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(vehicle);
            await _vehicleService.AddAsync(vehicleEntity);
            return vehicleEntity;
        }

        public async Task<GetVehicleDetailDto> GetVehicleDetail(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);
            if(vehicle == null || vehicle.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetVehicleDetailDto>(vehicle); 
        }

        public async Task<GetVehicleDetailDto> UpdateVehicle(int id, UpdateVehicleDto vehicle)
        {
            var vehicleEntity = _vehicleService.GetByIdAsync(id).Result;
            vehicleEntity.Name = vehicle.Name;
            vehicleEntity.Plate = vehicle.Plate;
            vehicleEntity.LicenseNumber = vehicle.LicenseNumber;
            vehicleEntity.ModelYear = vehicle.ModelYear;
            vehicleEntity.TraficLicenseDate = vehicle.TraficLicenseDate;
            await _vehicleService.UpdateAsync(vehicleEntity);
            return _mapper.Map<GetVehicleDetailDto>(vehicleEntity);
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicleEntity = _vehicleService.GetByIdAsync(id).Result;
            vehicleEntity.IsDeleted = true;
            await _vehicleService.UpdateAsync(vehicleEntity);
        }
    }
}