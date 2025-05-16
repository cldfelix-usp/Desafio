using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
	private readonly RepositoryContext _repositoryContext;
	private readonly Lazy<ICompanyRepository> _companyRepository;
	private readonly Lazy<IEmployeeRepository> _employeeRepository;
	private readonly Lazy<ITituloRepository> _tituloRepository;
	private readonly Lazy<IParcelaRepository> _parcelaRepository;

	public RepositoryManager(RepositoryContext repositoryContext)
	{
		_repositoryContext = repositoryContext;
		_tituloRepository = new Lazy<ITituloRepository>(() => new TituloRepository(repositoryContext));
		_parcelaRepository = new Lazy<IParcelaRepository>(() => new ParcelaRepository(repositoryContext));
		_companyRepository = new Lazy<ICompanyRepository>(() => new CompanyRepository(repositoryContext));
		_employeeRepository = new Lazy<IEmployeeRepository>(() => new EmployeeRepository(repositoryContext));
	}

	public ICompanyRepository Company => _companyRepository.Value;
	public IEmployeeRepository Employee => _employeeRepository.Value;
	public ITituloRepository Titulo => _tituloRepository.Value;
	public IParcelaRepository Parcela => _parcelaRepository.Value;


	public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
