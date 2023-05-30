using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetTagsUseCase : IUseCase<GetTagsInputDTO, TagSectionResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetTagsUseCase(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<TagSectionResponseDTO[]> Execute(GetTagsInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var query = from tagSection in _applicationDbContext.TagSections
            select new TagSectionResponseDTO
            {
                Title = tagSection.Title,
                Tags = tagSection.Tags.Select(tag => new TagResponseDTO
                {
                    Id = tag.Id,
                    Name = tag.Name
                }).ToArray()
            };

        return query.ToArrayAsync(cancellationToken);
    }
}