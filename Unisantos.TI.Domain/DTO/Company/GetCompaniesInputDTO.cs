using System.ComponentModel;

namespace Unisantos.TI.Domain.DTO.Company;

public class GetCompaniesInputDTO
{
    public double Latitude { get; set; }

    public double Longitude { get; set; }

    [Description("Distância de busca em quilômetros")]
    public double Distance { get; set; }

    public ICollection<int> Tags { get; set; } = new List<int>();
}