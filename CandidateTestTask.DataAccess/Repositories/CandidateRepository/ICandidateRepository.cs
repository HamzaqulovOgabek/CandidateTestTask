using CandidateTestTask.Domain.Models;

namespace CandidateTestTask.DataAccess.Repositories.CandidateRepository
{
    public interface ICandidateRepository
    {
        Task<int> AddCandidateAsync(Candidate candidate);
        IQueryable<Candidate> GetAllCandidates();
        Task<Candidate?> GetCandidateByEmail(string email);
        Task<Candidate?> GetCandidateByIdAsync(int id);
        Task<int> UpdateCandidateAsync(Candidate candidate);
    }
}