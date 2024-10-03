using CandidateTestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateTestTask.DataAccess.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Candidate>(options =>
        {
            options.HasIndex(c => c.Email)
            .IsUnique();

            options.HasIndex(c => new {c.FirstName, c.LastName})
            .IsUnique();
        });
    }
}
