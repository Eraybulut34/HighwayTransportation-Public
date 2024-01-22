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

        public ExpenseProvider(ExpenseService expenseService, IMapper mapper) : base(expenseService)
        {
            _mapper = mapper;
            _expenseService = expenseService;
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