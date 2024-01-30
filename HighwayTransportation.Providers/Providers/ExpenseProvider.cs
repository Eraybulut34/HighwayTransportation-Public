using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Services;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;
using HighwayTransportation.Domain.Enums;
using System.Text.Json;


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
        public async Task<List<GetExpenseListDto>> GetExpenses(int? projectId, int? companyId, int? employeeId, int? vehicleId, ExpenseTypeEnum type)
        {
            //IsDeleted == false
            var expenses = await _expenseService.GetAllAsync();
            if (projectId != null)
            {
                expenses = expenses.Where(x => x.ProjectId == projectId).ToList();
            }
            if (companyId != null)
            {
                expenses = expenses.Where(x => x.CompanyId == companyId).ToList();
            }
            if (employeeId != null)
            {
                expenses = expenses.Where(x => x.EmployeeId == employeeId).ToList();
            }
            if (vehicleId != null)
            {
                expenses = expenses.Where(x => x.VehicleId == vehicleId).ToList();
            }
            if (type != null)
            {
                expenses = expenses.Where(x => x.Type == type).ToList();
            }
            var xxx = _mapper.Map<List<GetExpenseListDto>>(expenses.Where(x => x.IsDeleted == false).ToList());
            return xxx;
        }

        public async Task<Expense> CreateExpense(CreateExpenseDto expense)
        {
            var expenseEntity = new Expense
            {
                Company = await _companyService.GetByIdAsync(expense.CompanyId),
                Project = await _projectService.GetByIdAsync(expense.ProjectId),
                Employee = await _employeeService.GetByIdAsync(expense.EmployeeId),
                Vehicle = await _vehicleService.GetByIdAsync(expense.VehicleId),
                Type = expense.Type,
                Amount = expense.Amount,
                Description = expense.Description,
                Date = DateTime.UtcNow
            };
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