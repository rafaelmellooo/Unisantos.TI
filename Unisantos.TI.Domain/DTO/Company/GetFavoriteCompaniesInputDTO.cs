namespace Unisantos.TI.Domain.DTO.Company;

public record GetFavoriteCompaniesInputDTO
{
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public double Distance { get; set; }
}