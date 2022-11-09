namespace Unisantos.TI.Domain.DTO.Company;

public class CompanyResponseDTO
{
    public string Name { get; set; }
    
    public double Latitude { get; set; }
    
    public double Longitude { get; set; }
    
    public string ImagePreviewUrl { get; set; }
    
    public ICollection<string> Tags { get; set; } = new List<string>();
}