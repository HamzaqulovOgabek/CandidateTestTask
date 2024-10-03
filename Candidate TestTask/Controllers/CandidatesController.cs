using CandidateTestTask.Application.Services.CandidateServices;
using CandidateTestTask.Domain.Models;
using Market.Auth.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Candidate_TestTask.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class CandidatesController : ControllerBase
{
    private readonly ICandidateService _service;

    public CandidatesController(ICandidateService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CandidateCreateDto dto)
    {
        return Ok(await _service.AddOrUpdateCandidateAsync(dto));
    }
    [HttpPost]
    public async Task<IActionResult> UpdateAsync(CandidateUpdateDto dto)
    {
        return Ok(await _service.UpdateCandidateAsync(dto));
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _service.GetCandidate(id));
    }
    [HttpPost]
    public IActionResult GetList(BaseSortFilterDto options)
    {
        return Ok(_service.GetAllCandidates(options));
    }

}
