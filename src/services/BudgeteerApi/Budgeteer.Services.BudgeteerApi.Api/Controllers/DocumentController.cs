using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Documents;
using Budgeteer.Services.BudgeteerApi.Services.Documents;
using Budgeteer.Services.BudgeteerApi.Shared.Documents;
using Microsoft.AspNetCore.Mvc;

namespace Budgeteer.Services.BudgeteerApi.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;

    public DocumentController(
        IDocumentService documentService
    )
    {
        _documentService = documentService;
    }

    [HttpPut("{id}")]
    public async Task UpdateAsync(
        int id,
        [FromBody] DocumentRequest.Update request,
        CancellationToken cancellationToken = default!
    )
    {
        Document document = request
            .Model
            .ToDomain();

        await _documentService.UpdateAsync(
            id,
            document,
            cancellationToken
        );
    }

    [HttpDelete("{id}")]
    public async Task DeleteAsync(
        int id,
        CancellationToken cancellationToken = default!
    )
    {
        await _documentService.DeleteAsync(
            id,
            cancellationToken
        );
    }
}
