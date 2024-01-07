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
            var vehicles = await _vehicleService.GetAllAsync();
            return Task.FromResult(_mapper.Map<List<GetVehicleListDto>>(vehicles)).Result;
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
            return _mapper.Map<GetVehicleDetailDto>(vehicle);
        }
    }
}