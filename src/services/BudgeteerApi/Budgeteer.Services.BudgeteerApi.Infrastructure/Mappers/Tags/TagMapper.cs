using Budgeteer.Services.BudgeteerApi.Domain.Tags;
using Budgeteer.Services.BudgeteerApi.Shared.Tags;

namespace Budgeteer.Services.BudgeteerApi.Infrastructure.Mappers.Tags;

public static class TagMapper
{
    public static Tag ToDomain(
        this TagDto.Mutate model
    )
    {
        Tag tag = new(
            model.Name
        );

        return tag;
    }

    public static TagDto.Index ToIndex(
        this Tag tag
    )
    {
        TagDto.Index dto = new(
            tag.Id,
            tag.Name
        );

        return dto;
    }
}
