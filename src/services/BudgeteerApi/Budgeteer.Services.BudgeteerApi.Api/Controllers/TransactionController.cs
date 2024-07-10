using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Domain.Transactions;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Documents;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Transactions;
using Budgeteer.Services.BudgeteerApi.Services.Transactions;
using Budgeteer.Services.BudgeteerApi.Shared.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Budgeteer.Services.BudgeteerApi.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(
            ITransactionService transactionService
        )
        {
            _transactionService = transactionService;
        }

        [HttpPut("{id}")]
        public async Task UpdateAsync(
            int id,
            [FromBody] TransactionRequest.Update request,
            CancellationToken cancellationToken = default!
        )
        {
            Transaction transaction = new(
                request.Model.Name,
                request.Model.Amount,
                request.Model.DateOfTransaction
            );

            await _transactionService
                .UpdateAsync(
                    id,
                    transaction,
                    cancellationToken
                );
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(
            int id,
            CancellationToken cancellationToken = default!
        )
        {
            await _transactionService
                .DeleteAsync(
                    id,
                    cancellationToken
                );
        }

        [HttpPost("{id}/document")]
        public async Task CreateEnclosedDocumentAsync(
            int id,
            [FromBody] TransactionRequest.CreateEnclosedDocument request,
            CancellationToken cancellationToken = default!
        )
        {
            Document document = request
                .Model
                .ToDomain();

            await _transactionService
                .CreateEnclosedDocumentAsync(
                    id,
                    document,
                    cancellationToken
                );
        }
    }
}
