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
using HighwayTransportation.Domain.Enums;

namespace HighwayTransportation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {

        private readonly ExpenseProvider _expenseProvider;

        public ExpenseController(ExpenseProvider expenseProvider)
        {
            _expenseProvider = expenseProvider;
        }

        [HttpGet]
        // [HttpGet]
        //fromQuery'den projectId, companyId, employeeId, vehicleId, type alıyoruz
        // public async Task<ActionResult<List<GetExpenseListDto>>> GetExpenses()
        // {
        //     var expenses = await _expenseProvider.GetExpenses();
        //     return Ok(expenses);
        // }

        [HttpGet]
        public async Task<ActionResult<List<GetExpenseListDto>>> GetExpenses([FromQuery] int? projectId, [FromQuery] int? companyId, [FromQuery] int? employeeId, [FromQuery] int? vehicleId, [FromQuery] ExpenseTypeEnum type)
        {
            var expenses = await _expenseProvider.GetExpenses(projectId, companyId, employeeId, vehicleId, type);
            return Ok(expenses);
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> CreateExpense(CreateExpenseDto expense)
        {
            var createdExpense = await _expenseProvider.CreateExpense(expense);
            return CreatedAtAction(nameof(GetExpenses), new { id = createdExpense.Id }, createdExpense);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetExpenseDetailDto>> GetExpense(int id)
        {
            var expense = await _expenseProvider.GetExpenseDetail(id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExpense(int id, UpdateExpenseDto expense)
        {
            var expenseEntity = await _expenseProvider.UpdateExpense(id, expense);
            return Ok(expenseEntity);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expenseProvider.DeleteExpense(id);
            return Ok();
        }
    }
}
