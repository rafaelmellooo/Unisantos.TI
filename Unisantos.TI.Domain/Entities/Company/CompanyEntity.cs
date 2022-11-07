using Unisantos.TI.Domain.Entities.Address;
using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Domain.Entities.Company;

public class CompanyEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public string Phone { get; set; }
    
    public string Instagram { get; set; }
    
    public string Facebook { get; set; }
    
    public string ImageUrl { get; set; }
    
    public string ImagePreviewUrl { get; set; }

    public Guid AddressId { get; set; }

    public AddressEntity Address { get; set; }

    public ICollection<TagEntity> Tags { get; set; } = new List<TagEntity>();

    public Guid AdminId { get; set; }

    public UserEntity Admin { get; set; }

    public ICollection<FavoriteEntity> Favorites { get; set; } = new List<FavoriteEntity>();

    public ICollection<BusinessHoursEntity> BusinessHours { get; set; } = new List<BusinessHoursEntity>();
    
    public ICollection<RateEntity> Rates { get; set; } = new List<RateEntity>();
    
    public ICollection<ProductsSectionEntity> ProductsSections { get; set; } = new List<ProductsSectionEntity>();
}