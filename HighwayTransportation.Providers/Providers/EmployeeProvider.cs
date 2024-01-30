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
    public class EmployeeProvider : ProviderBase<EmployeeService, Employee>
    {
        IMapper _mapper;
        EmployeeService _employeeService;

        public EmployeeProvider(EmployeeService employeeService, IMapper mapper) : base(employeeService)
        {
            _mapper = mapper;
            _employeeService = employeeService;
        }

        public async Task<List<GetEmployeeListDto>> GetEmployees()
        {
            //IsDeleted == false
            var employees = await _employeeService.GetAllAsync();
            return _mapper.Map<List<GetEmployeeListDto>>(employees.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Employee> CreateEmployee(CreateEmployeeDto employee)
        {
            var employeeEntity = _mapper.Map<Employee>(employee);
            await _employeeService.AddAsync(employeeEntity);
            return employeeEntity;

        }

        public async Task<GetEmployeeDetailDto> GetEmployeeDetail(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null || employee.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetEmployeeDetailDto>(employee);
        }

        public async Task<GetEmployeeDetailDto> UpdateEmployee(int id, UpdateEmployeeDto employee)
        {
            var employeeEntity = _employeeService.GetByIdAsync(id).Result;
            employeeEntity.Name = employee.Name;
            employeeEntity.SurName = employee.SurName;
            employeeEntity.BirthDate = employee.BirthDate;
            employeeEntity.LicenseTypes = employee.LicenseTypes;
            employeeEntity.BloodGroup = employee.BloodGroup;
            employeeEntity.Gender = employee.Gender;
            employeeEntity.WorkingType = employee.WorkingType;
            employeeEntity.IdentityNumber = employee.IdentityNumber;
            employeeEntity.PhoneNumber = employee.PhoneNumber;
            employeeEntity.Email = employee.Email;
            employeeEntity.StartDate = employee.StartDate;
            employeeEntity.EndDate = employee.EndDate;
            employeeEntity.EmployeeType = employee.EmployeeType;

            await _employeeService.UpdateAsync(employeeEntity);
            return _mapper.Map<GetEmployeeDetailDto>(employeeEntity);
        }

        public async Task DeleteEmployee(int id)
        {
            var employeeEntity = _employeeService.GetByIdAsync(id).Result;
            employeeEntity.IsDeleted = true;
            await _employeeService.UpdateAsync(employeeEntity);
        }
    }
}