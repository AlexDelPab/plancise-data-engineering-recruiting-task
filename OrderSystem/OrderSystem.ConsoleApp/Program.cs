using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderSystem.ConsoleApp.Data.Context;
using OrderSystem.ConsoleApp.Data.Models;

namespace OrderSystem.ConsoleApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        AddDatabaseContext(builder.Services);
        
        var app = builder.Build();
        
        var dbContext = (OrderSystemDbContext?)app.Services.GetService(typeof(OrderSystemDbContext));
        dbContext!.Database.EnsureCreated();

        Populate(dbContext);
    }

    private static void AddDatabaseContext(IServiceCollection services)
    {
        var builder = new DbContextOptionsBuilder<OrderSystemDbContext>();
        builder.UseSqlServer("Server=localhost,1435;Database=OrderSystemDB;User Id=sa;Password=Pass@Word;TrustServerCertificate=true;");

        services.AddTransient(_ => new OrderSystemDbContext(builder.Options));
    }

    private static void Populate(OrderSystemDbContext dbContext)
    {
        while(true)
        {
            Thread.Sleep(2000);
            var order = new OrderEntity
            {
                Id = Guid.NewGuid(),
                AssignedEmployee = "Stefan M.",
                Date = DateTime.Now,
                Notes = "Order due tomorrow",
                OrderedItem = Guid.NewGuid()
            };

            dbContext.Orders.Add(order);
                
            dbContext.SaveChanges();
        }
    }
}