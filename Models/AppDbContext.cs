using Microsoft.EntityFrameworkCore;

namespace Web.Models;

public class AppDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Purchase> Purchases { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionString = "server=painel.lucasjanczak.com.br;port=3306;database=cotemig;user=mysql;password=855be35b9fab607d8b93";
        //string connectionString = "mysql://mysql:855be35b9fab607d8b93@painel.lucasjanczak.com.br:3306/cotemig";

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        optionsBuilder.UseOpenIddict();
    }
}
