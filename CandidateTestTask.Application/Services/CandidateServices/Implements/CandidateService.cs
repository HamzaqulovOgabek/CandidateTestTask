using AutoMapper;
using CandidateTestTask.Application.Exceptions;
using CandidateTestTask.DataAccess.Repositories.CandidateRepository;
using CandidateTestTask.Domain.Models;
using Market.Auth.Application.Dto;
using Market.Auth.Application.Extensions;

namespace CandidateTestTask.Application.Services.CandidateServices;

public class CandidateService : ICandidateService
{
    private readonly ICandidateRepository _repository;
    private readonly IMapper _mapper;

    public CandidateService(ICandidateRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<int> AddOrUpdateCandidateAsync(CandidateCreateDto dto)
    {
        IsValidCandidate(dto);
        var candidate = await _repository.GetCandidateByEmail(dto.Email);

        if (candidate != null)
        {
            return await _repository.UpdateCandidateAsync(_mapper.Map<Candidate>(dto));
        }
        else
        {
            var newCandidate = _mapper.Map<Candidate>(dto);
            return await _repository.AddCandidateAsync(newCandidate);
        }
    }
    public async Task<int> UpdateCandidateAsync(CandidateUpdateDto dto)
    {
        var candidate = await GetCandidate(dto.Id);
        UpdateCandidate(dto, candidate);

        return await _repository.UpdateCandidateAsync(_mapper.Map<Candidate>(dto));
    }
    public async Task<Candidate> GetCandidate(int id)
    {
        var candidate = await _repository.GetCandidateByIdAsync(id);

        if (candidate == null)
            throw new CandidateNotFoundException("Candidate not found");

        return candidate;
    }
    public IQueryable<Candidate> GetAllCandidates(BaseSortFilterDto options)
    {
        return _repository.GetAllCandidates()
            .SortFilter(options);
    }

    private void IsValidCandidate(CandidateCreateDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FirstName) ||
            string.IsNullOrWhiteSpace(dto.LastName))
            throw new ArgumentException("First name and Last name are required");

    }
    private static void UpdateCandidate(CandidateUpdateDto dto, Candidate candidate)
    {
        candidate.Id = dto.Id;
        candidate.FirstName = dto.FirstName ?? candidate.FirstName;
        candidate.LastName = dto.LastName ?? candidate.LastName;
        candidate.PhoneNumber = dto.PhoneNumber ?? candidate.PhoneNumber;
        candidate.Email = dto.Email ?? candidate.Email;
    }
}
