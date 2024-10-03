using CandidateTestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateTestTask.DataAccess.Context;

public class AppDbContext : DbContext
{
    public DbSet<Candidate> Candidates { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Candidate>(options =>
        {
            options.HasIndex(c => c.Email)
            .IsUnique();
        });
    }
}
