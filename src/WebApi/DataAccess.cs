


using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi;

public class DataAccess : DbContext{
    private readonly string _dbString;
    public DbSet<Proposition> Propositions {get;set;}
    public DbSet<Opinion> Opinion {get;set;}

    public DataAccess()
    {
        _dbString = Environment.GetEnvironmentVariable("DB_STRING")
            ?? throw new Exception("DB_STRING not set in environment");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        // example: @"Host=myserver;Username=mylogin;Password=mypass;Database=mydatabase"
        => options.UseNpgsql(_dbString);

}