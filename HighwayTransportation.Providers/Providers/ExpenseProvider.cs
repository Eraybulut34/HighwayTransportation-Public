using System.Collections.Generic;
using System.Linq;
using MapsterMapper;
using HighwayTransportation.Providers;
using HighwayTransportation.Domain.Entities;
using HighwayTransportation.Core;
using HighwayTransportation.Core.Dtos;
using HighwayTransportation.Domain.Enums;
using System.Text.Json;
using HighwayTransportation.Domain;
using Microsoft.EntityFrameworkCore;



namespace HighwayTransportation.Providers
{
    public class ExpenseProvider
    {
        IMapper _mapper;
        AppDbContext _context;

        public ExpenseProvider(
        AppDbContext context,
         IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<GetExpenseListDto>> GetExpenses(int? projectId, int? companyId, int? employeeId, int? vehicleId, ExpenseTypeEnum type)
        {
            IQueryable<Expense> expenses = _context.Expenses.Where(x => !x.IsDeleted);

            if (projectId != null)
            {
                expenses = expenses.Where(x => x.ProjectId == projectId);
            }
            if (companyId != null)
            {
                expenses = expenses.Where(x => x.CompanyId == companyId);
            }
            if (employeeId != null)
            {
                expenses = expenses.Where(x => x.EmployeeId == employeeId);
            }
            if (vehicleId != null)
            {
                expenses = expenses.Where(x => x.VehicleId == vehicleId);
            }
            if (type != null)
            {
                expenses = expenses.Where(x => x.Type == type);
            }

            var filteredExpenses = await expenses.ToListAsync();
            return _mapper.Map<List<GetExpenseListDto>>(filteredExpenses);
        }


        public async Task<Expense> CreateExpense(CreateExpenseDto expense)
        {
            var expenseEntity = new Expense
            {
                Company = await _context.Companies.FindAsync(expense.CompanyId),
                Project = await _context.Projects.FindAsync(expense.ProjectId),
                Employee = await _context.Employees.FindAsync(expense.EmployeeId),
                Vehicle = await _context.Vehicles.FindAsync(expense.VehicleId),
                Type = expense.Type,
                Amount = expense.Amount,
                Description = expense.Description,
                Date = DateTime.UtcNow
            };

            await _context.Expenses.AddAsync(expenseEntity);
            await _context.SaveChangesAsync();
            return expenseEntity;
        }

        public async Task<GetExpenseDetailDto> GetExpenseDetail(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null || expense.IsDeleted == true)
            {
                return null;
            }
            return _mapper.Map<GetExpenseDetailDto>(expense);
        }

        public async Task<Expense> UpdateExpense(int id, UpdateExpenseDto expense)
        {
            var expenseEntity = _context.Expenses.FindAsync(id).Result;
            expenseEntity.Amount = expense.Amount;
            expenseEntity.Description = expense.Description;
            expenseEntity.Type = expense.Type;
            await _context.SaveChangesAsync();
            return expenseEntity;
        }

        public async Task DeleteExpense(int id)
        {
            var expenseEntity = _context.Expenses.FindAsync(id).Result;
            expenseEntity.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}