using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Services;
using Microsoft.AspNetCore.Mvc;
using HighwayTransportation.Providers;
using Microsoft.OpenApi.Any;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;
using Microsoft.AspNetCore.Authorization;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CompanyController : ControllerBase
    {

        private readonly CompanyProvider _companyProvider;

        public CompanyController(CompanyProvider companyProvider)
        {
            _companyProvider = companyProvider;
        }

        [HttpGet]
        [HttpGet]
        public async Task<ActionResult<List<GetCompanyListDto>>> GetCompanys()
        {
            var companys = await _companyProvider.GetCompanys();
            return Ok(companys);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> CreateCompany(CreateCompanyDto company)
        {
            var createdCompany = await _companyProvider.CreateCompany(company);
            return CreatedAtAction(nameof(GetCompanys), new { id = createdCompany.Id }, createdCompany);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompanyDetailDto>> GetCompany(int id)
        {
            var company = await _companyProvider.GetCompanyDetail(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(int id, UpdateCompanyDto company)
        {
            var companyEntity = await _companyProvider.UpdateCompany(id, company);
            return Ok(companyEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyProvider.DeleteCompany(id);
            return Ok();
        }
    }
}
