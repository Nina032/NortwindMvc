using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Shared;

public static class NorthwindContextExtensions
{
    //Lägger till NorthwindContext
    //till den specificerade IServiceCollection.
    //Använder SqlServer databas provider

    public static IServiceCollection AddNorthwindContext(
        this IServiceCollection services, 
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;" +
    "Integrated Security=true;MultipleActiveResultsets=true;Encrypt=false")
    {
        services.AddDbContext<NorthwindLexContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.LogTo(Console.WriteLine,
                    new[] {Microsoft.EntityFrameworkCore
                    .Diagnostics.RelationalEventId.CommandExecuting});
        });
        return services;
    }

}
