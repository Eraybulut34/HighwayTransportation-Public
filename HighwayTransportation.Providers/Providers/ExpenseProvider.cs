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
    public class ExpenseProvider : ProviderBase<ExpenseService, Expense>
    {
        IMapper _mapper;


        ExpenseService _expenseService;

        CompanyService _companyService;

        ProjectService _projectService;

        EmployeeService _employeeService;

        VehicleService _vehicleService;

        public ExpenseProvider(ExpenseService expenseService,
        CompanyService companyService,
        ProjectService projectService,
        EmployeeService employeeService,
        VehicleService vehicleService,
         IMapper mapper) : base(expenseService)
        {
            _mapper = mapper;
            _expenseService = expenseService;
            _companyService = companyService;
            _projectService = projectService;
            _employeeService = employeeService;
            _vehicleService = vehicleService;
        }

        public async Task<List<GetExpenseListDto>> GetExpenses()
        {
            //IsDeleted == false
            var expenses = await _expenseService.GetAllAsync();
            return _mapper.Map<List<GetExpenseListDto>>(expenses.Where(x => x.IsDeleted == false).ToList());
        }

        public async Task<Expense> CreateExpense(CreateExpenseDto expense)
        {
            var expenseEntity = _mapper.Map<Expense>(expense);
            expenseEntity.Company = await _companyService.GetByIdAsync(expense.CompanyId);
            expenseEntity.Project = await _projectService.GetByIdAsync(expense.ProjectId);
            expenseEntity.Employee = await _employeeService.GetByIdAsync(expense.EmployeeId);
            expenseEntity.Vehicle = await _vehicleService.GetByIdAsync(expense.VehicleId);
            await _expenseService.AddAsync(expenseEntity);
            return expenseEntity;

        }

        public async Task<GetExpenseDetailDto> GetExpenseDetail(int id)
        {
            var expense = await _expenseService.GetByIdAsync(id);
            if (expense == null || expense.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetExpenseDetailDto>(expense);
        }

        public async Task<GetExpenseDetailDto> UpdateExpense(int id, UpdateExpenseDto expense)
        {
            var expenseEntity = _expenseService.GetByIdAsync(id).Result;
            expenseEntity = _mapper.Map<Expense>(expense);
            await _expenseService.UpdateAsync(expenseEntity);
            return _mapper.Map<GetExpenseDetailDto>(expenseEntity);
        }

        public async Task DeleteExpense(int id)
        {
            var expenseEntity = _expenseService.GetByIdAsync(id).Result;
            expenseEntity.IsDeleted = true;
            await _expenseService.UpdateAsync(expenseEntity);
        }
    }
}