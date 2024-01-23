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
    public class DeliveryProvider : ProviderBase<DeliveryService, Delivery>
    {
        IMapper _mapper;
        DeliveryService _deliveryService;

        public DeliveryProvider(DeliveryService deliveryService, IMapper mapper) : base(deliveryService)
        {
            _mapper = mapper;
            _deliveryService = deliveryService;
        }

        public async Task<List<GetDeliveryListDto>> GetDeliverys()
        {
            //IsDeleted == false
            var deliverys = await _deliveryService.GetAllAsync();
            return _mapper.Map<List<GetDeliveryListDto>>(deliverys.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Delivery> CreateDelivery(CreateDeliveryDto delivery)
        {
            var deliveryEntity = _mapper.Map<Delivery>(delivery);
            await _deliveryService.AddAsync(deliveryEntity);
            return deliveryEntity;

        }

        public async Task<GetDeliveryDetailDto> GetDeliveryDetail(int id)
        {
            var delivery = await _deliveryService.GetByIdAsync(id);
            if (delivery == null || delivery.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetDeliveryDetailDto>(delivery);
        }

        public async Task<GetDeliveryDetailDto> UpdateDelivery(int id, UpdateDeliveryDto delivery)
        {
            var deliveryEntity = _deliveryService.GetByIdAsync(id).Result;
            deliveryEntity = _mapper.Map<Delivery>(delivery);
            await _deliveryService.UpdateAsync(deliveryEntity);
            return _mapper.Map<GetDeliveryDetailDto>(deliveryEntity);
        }

        public async Task DeleteDelivery(int id)
        {
            var deliveryEntity = _deliveryService.GetByIdAsync(id).Result;
            deliveryEntity.IsDeleted = true;
            await _deliveryService.UpdateAsync(deliveryEntity);
        }
    }
}