using Budgeteer.Services.BudgeteerApi.Domain.Documents;
using Budgeteer.Services.BudgeteerApi.Shared.Documents;

namespace Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Documents;

public static class DocumentMapper
{
    public static Document ToDomain(
        this DocumentDto.Mutate model
    )
    {
        Document document = new(
            model.Name,
            model.Url
        );

        return document;
    }

    public static DocumentDto.Index ToIndex(
        this Document document
    )
    {
        DocumentDto.Index dto = new(
            document.Id,
            document.Name,
            document.Url
        );

        return dto;
    }
}
