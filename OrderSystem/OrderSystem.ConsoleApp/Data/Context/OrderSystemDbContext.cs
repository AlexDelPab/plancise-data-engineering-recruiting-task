using Microsoft.EntityFrameworkCore;
using OrderSystem.ConsoleApp.Data.Models;

namespace OrderSystem.ConsoleApp.Data.Context;

public class OrderSystemDbContext : DbContext
{
    public OrderSystemDbContext(DbContextOptions<OrderSystemDbContext> options)
        : base(options)
    {
    }

    public DbSet<OrderEntity> Orders { get; set; }
}