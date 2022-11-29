namespace Unisantos.TI.Domain.DTO.Company;

public record GetCompaniesInputDTO
{
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public double Distance { get; set; }

    public ICollection<int> Tags { get; set; } = new List<int>();
}