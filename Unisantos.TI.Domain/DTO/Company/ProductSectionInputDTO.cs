﻿using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Company;

public class ProductSectionInputDTO
{
    public Guid? Id { get; set; }
    
    [Required(ErrorMessage = "O título da seção de produtos é obrigatório")]
    public required string Title { get; set; }

    public ICollection<ProductInputDTO> Products { get; set; } = new List<ProductInputDTO>();
}