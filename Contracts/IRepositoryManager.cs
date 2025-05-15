namespace Contracts;

public interface IRepositoryManager
{
	ICompanyRepository Company { get; }
	IEmployeeRepository Employee { get; }
	ITituloRepository Titulo { get;}
	IParcelaRepository Parcela { get;}
	Task SaveAsync();
}
