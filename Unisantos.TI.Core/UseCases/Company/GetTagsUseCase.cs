using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Company;

namespace Unisantos.TI.Core.UseCases.Company;

public class GetTagsUseCase : IUseCase<GetTagsInputDTO, TagsSectionResponseDTO[]>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public GetTagsUseCase(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public Task<TagsSectionResponseDTO[]> Execute(GetTagsInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var query = from tagsSection in _applicationDbContext.TagsSections
            select new TagsSectionResponseDTO
            {
                Title = tagsSection.Title,
                Tags = tagsSection.Tags.Select(tag => new TagResponseDTO
                {
                    Id = tag.Id,
                    Name = tag.Name
                }).ToArray()
            };

        return query.ToArrayAsync(cancellationToken);
    }
}