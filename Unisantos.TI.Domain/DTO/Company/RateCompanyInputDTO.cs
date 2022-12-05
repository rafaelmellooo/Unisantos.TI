using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Company;

public class RateCompanyBodyInputDTO
{
    [Required(ErrorMessage = "A nota é obrigatória")]
    [Range(0, 5, ErrorMessage = "O valor da nota deve ser entre 0 e 5")]
    public float Rate { get; set; }

    [Required(ErrorMessage = "O comentário é obrigatório")]
    public string Comment { get; set; }
}

public class RateCompanyInputDTO : RateCompanyBodyInputDTO
{
    public Guid CompanyId { get; set; }
}