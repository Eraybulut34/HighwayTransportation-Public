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
    public class CompanyProvider : ProviderBase<CompanyService, Company>
    {
        IMapper _mapper;
        CompanyService _companyService;

        public CompanyProvider(CompanyService companyService, IMapper mapper) : base(companyService)
        {
            _mapper = mapper;
            _companyService = companyService;
        }

        public async Task<List<GetCompanyListDto>> GetCompanys()
        {
            //IsDeleted == false
            var companys = await _companyService.GetAllAsync();
            return _mapper.Map<List<GetCompanyListDto>>(companys.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Company> CreateCompany(CreateCompanyDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            await _companyService.AddAsync(companyEntity);
            return companyEntity;
            
        }

        public async Task<GetCompanyDetailDto> GetCompanyDetail(int id)
        {
            var company = await _companyService.GetByIdAsync(id);
            if (company == null || company.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetCompanyDetailDto>(company);
        }

        public async Task<GetCompanyDetailDto> UpdateCompany(int id, UpdateCompanyDto company)
        {
            var companyEntity = _companyService.GetByIdAsync(id).Result;
            companyEntity.Name = company.Name;
            companyEntity.TaxNumber = company.TaxNumber;
            companyEntity.PhoneNumber = company.PhoneNumber;
            companyEntity.Email = company.Email;
            await _companyService.UpdateAsync(companyEntity);
            return _mapper.Map<GetCompanyDetailDto>(companyEntity);
        }

        public async Task DeleteCompany(int id)
        {
            var companyEntity = _companyService.GetByIdAsync(id).Result;
            companyEntity.IsDeleted = true;
            await _companyService.UpdateAsync(companyEntity);
        }
    }
}