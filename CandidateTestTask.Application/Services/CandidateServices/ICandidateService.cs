using CandidateTestTask.Domain.Models;
using Market.Auth.Application.Dto;

namespace CandidateTestTask.Application.Services.CandidateServices;

public interface ICandidateService
{
    Task<int> AddOrUpdateCandidateAsync(CandidateCreateDto dto);
    IQueryable<Candidate> GetAllCandidates(BaseSortFilterDto options);
    Task<Candidate> GetCandidate(int id);
    Task<int> UpdateCandidateAsync(CandidateUpdateDto dto);
}