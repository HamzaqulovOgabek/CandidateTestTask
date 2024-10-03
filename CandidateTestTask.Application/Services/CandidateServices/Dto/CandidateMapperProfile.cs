using AutoMapper;
using CandidateTestTask.Domain.Models;

namespace CandidateTestTask.Application.Services.CandidateServices;

public class CandidateMapperProfile : Profile
{
    public CandidateMapperProfile()
    {
        CreateMap<CandidateCreateDto, Candidate>();
    }
}
