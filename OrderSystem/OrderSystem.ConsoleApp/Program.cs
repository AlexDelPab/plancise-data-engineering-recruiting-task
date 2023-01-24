using System.Security.Cryptography;
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
        var employees = new string[]
        {
            "Harriett Hensley",
            "Foster Stevenson",
            "Suarez McFadden",
            "Graham Alston",
            "Graham A.",
            "Brooke Powell",
            "5d9dd7ad-a643-4d31-ba76-fc21713e2709",
            "871a6ef0-b9cd-481e-9bad-1320322dc2e5",
            "Roberts Hendrix",
            "Leon Rivas",
            "Smith Frederick",
            "Freda Norton",
            "be6ec6a6-f75b-41a0-83b0-81c397d28859",
            "be6ec6a6-f75b-41a0-83b0-81c397d26f59",
            "63cfe6efdc51fe6ee2b21a29",
            "63cfe6ef1866dfbf1957ae8f",
            "Hardin Noble",
            "Hardin N.",
            "H.N.",
            "Toni Villarreal",
            "Stefan Ebelsberg",
            string.Empty,
            string.Empty,
            string.Empty,
            string.Empty
        };

        var rnd = new Random();
        while(true)
        {
            Thread.Sleep(2000);

            var nameIndex = rnd.Next(employees.Length - 1);
            var name = employees[nameIndex];
            
            var order = new OrderEntity
            {
                Id = Guid.NewGuid(),
                AssignedEmployee = name,
                Date = DateTime.Now,
                Notes = "Order due tomorrow",
                OrderedItem = Guid.NewGuid()
            };

            dbContext.Orders.Add(order);
                
            dbContext.SaveChanges();
        }
    }
}