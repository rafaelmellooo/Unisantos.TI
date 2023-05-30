namespace Unisantos.TI.Domain.Exceptions.Company;

public class CompanyNotFoundException : Exception
{
    public CompanyNotFoundException() : base("Empresa não encontrada ou você não tem permissão para acessá-la")
    {
    }
}