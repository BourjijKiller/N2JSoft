using DomainServices;
using DomainServices.Validator;

using Repository;

using Services;

using WebApi.Services;

namespace WebApi.Infrastructure.Api;

internal static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddTransient<IExpenseRepository, ExpenseRepository>();
        services.AddTransient<IExpenseDomainService, ExpenseDomainService>();
        services.AddTransient<IExpenseService, ExpenseService>();

        services.AddSingleton<ExpenseValidator>();

        return services;
    }
}