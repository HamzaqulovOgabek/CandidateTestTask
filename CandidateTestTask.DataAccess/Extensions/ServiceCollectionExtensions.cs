using CandidateTestTask.DataAccess.Context;
using CandidateTestTask.DataAccess.Repositories.CandidateRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateTestTask.DataAccess.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataAccess(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Candidates"));
        });

        services.AddScoped<ICandidateRepository, CandidateRepository>();

        return services;
    }
}
