using Unisantos.TI.Domain.Entities.Address;
using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Domain.Entities.Company;

public class CompanyEntity
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required string Phone { get; set; }

    public string? Instagram { get; set; }

    public string? Facebook { get; set; }
    
    public float? Rating { get; set; }

    public required string ImageUrl { get; set; }

    public required string ImagePreviewUrl { get; set; }

    public Guid AddressId { get; set; }

    public AddressEntity? Address { get; set; }

    public ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();

    public Guid AdminId { get; set; }

    public UserEntity? Admin { get; set; }

    public ICollection<FavoriteEntity> Favorites { get; set; } = new List<FavoriteEntity>();

    public ICollection<BusinessHoursEntity> BusinessHours { get; set; } = new List<BusinessHoursEntity>();

    public ICollection<RateEntity> Rates { get; set; } = new List<RateEntity>();

    public ICollection<ProductSectionEntity> ProductSections { get; set; } = new List<ProductSectionEntity>();
}