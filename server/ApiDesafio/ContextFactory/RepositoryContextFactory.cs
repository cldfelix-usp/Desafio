using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Repository;


namespace ApiDesafio.ContextFactory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
	public RepositoryContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<RepositoryContext>()
			.UseSqlite(configuration.GetConnectionString("sqlConnection"),
			b => b.MigrationsAssembly("ApiDesafio"));

		return new RepositoryContext(builder.Options);
	}
}
