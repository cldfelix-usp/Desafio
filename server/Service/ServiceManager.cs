using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IEmployeeService> _employeeService;
    private readonly Lazy<ITituloService> _tituloService;
    private readonly Lazy<IParcelaService> _parcelaService;
    
    private readonly Lazy<IAuthenticationService> _authenticationService;

    public ServiceManager(IRepositoryManager repositoryManager,
        ILoggerManager logger,
        IMapper mapper, IEmployeeLinks employeeLinks,
        UserManager<User> userManager,
        IOptions<JwtConfiguration> configuration)
    {
        _companyService = new Lazy<ICompanyService>(() =>
            new CompanyService(repositoryManager, logger, mapper));
        _employeeService = new Lazy<IEmployeeService>(() =>
            new EmployeeService(repositoryManager, logger, mapper, employeeLinks));
        _tituloService = new Lazy<ITituloService>(() =>
            new TituloService(repositoryManager, logger, mapper));
        _parcelaService = new Lazy<IParcelaService>(() =>
            new ParcelaService(repositoryManager, logger, mapper));
        _authenticationService = new Lazy<IAuthenticationService>(() =>
            new AuthenticationService(logger, mapper, userManager, configuration));
        
    }

    public ICompanyService CompanyService => _companyService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
    public ITituloService TituloService => _tituloService.Value;
    public IParcelaService ParcelaService => _parcelaService.Value;
    public IAuthenticationService AuthenticationService => _authenticationService.Value;
}
