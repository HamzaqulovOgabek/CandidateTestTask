using CandidateTestTask.DataAccess.Context;
using CandidateTestTask.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateTestTask.DataAccess.Repositories.CandidateRepository;

public class CandidateRepository : ICandidateRepository
{
    private readonly AppDbContext _context;

    public CandidateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> AddCandidateAsync(Candidate candidate)
    {
        await _context.AddAsync(candidate);
        await _context.SaveChangesAsync();

        return candidate.Id;
    }
    public async Task<int> UpdateCandidateAsync(Candidate candidate)
    {
        _context.Update(candidate);
        await _context.SaveChangesAsync();

        return candidate.Id;
    }
    public async Task<Candidate?> GetCandidateByEmail(string email)
    {
        return await _context.Candidates.FirstOrDefaultAsync(c => c.Email == email);
    }
    public async Task<Candidate?> GetCandidateByIdAsync(int id)
    {
        return await _context.Candidates.FindAsync(id);
    }
    public IQueryable<Candidate> GetAllCandidates()
    {
        return _context.Candidates;
    }

}
