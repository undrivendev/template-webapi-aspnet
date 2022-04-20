using WebApiTemplate.Core.Customers;
using WebApiTemplate.Infrastructure.Persistence;

namespace WebApiTemplate.IntegrationTests;

public static class Utils
{
    public static void SeedTestData(AppDbContext context)
    {
        context.Customers.Add(new Customer(1));
        context.SaveChanges();
    }
}