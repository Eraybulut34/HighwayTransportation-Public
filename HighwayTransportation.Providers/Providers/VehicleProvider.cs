using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;
using HighwayTransportation.Domain;


namespace HighwayTransportation.Providers
{
    public class VehicleProvider
    {
        IMapper _mapper;
        VehicleService _vehicleService;

        AppDbContext _context;

        public VehicleProvider(AppDbContext appDbContext,IMapper mapper)
        {
            _mapper = mapper;
            _context = appDbContext;
        }

        public async Task<List<GetVehicleListDto>> GetVehicles()
        {

            var vehicles = _context.Vehicles.Where(x => x.IsDeleted == false).ToList();
            return _mapper.Map<List<GetVehicleListDto>>(vehicles);
        }

        public async Task<Vehicle> CreateVehicle(CreateVehicleDto vehicle)
        {
            var vehicleEntity = _mapper.Map<Vehicle>(vehicle);
            _context.Vehicles.Add(vehicleEntity);
            await _context.SaveChangesAsync();
            return vehicleEntity;
        }

        public async Task<GetVehicleDetailDto> GetVehicleDetail(int id)
        {
            var vehicle = _context.Vehicles.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if(vehicle == null)
            {
                return null;
            }
            return _mapper.Map<GetVehicleDetailDto>(vehicle);
        }

        public async Task<GetVehicleDetailDto> UpdateVehicle(int id, UpdateVehicleDto vehicle)
        {
            var vehicleEntity = _context.Vehicles.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if(vehicleEntity == null)
            {
                return null;
            }
            vehicleEntity.Name = vehicle.Name;
            vehicleEntity.Plate = vehicle.Plate;
            vehicleEntity.LicenseNumber = vehicle.LicenseNumber;
            vehicleEntity.ModelYear = vehicle.ModelYear;
            vehicleEntity.TraficLicenseDate = vehicle.TraficLicenseDate;
            await _context.SaveChangesAsync();
            return _mapper.Map<GetVehicleDetailDto>(vehicleEntity);
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicleEntity = _context.Vehicles.Where(x => x.Id == id && x.IsDeleted == false).FirstOrDefault();
            if(vehicleEntity == null)
            {
                return;
            }
            vehicleEntity.IsDeleted = true;
            await _context.SaveChangesAsync();
            return;
        }
    }
}