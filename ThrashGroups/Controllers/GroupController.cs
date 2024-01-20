using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThrashGroups.Context;
using ThrashGroups.Entity;

namespace ThrashGroups.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class GroupController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GroupController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllStudentGroups(int studentId)
    {
        var result = await _context.Students
            .Where(s => s.Id == studentId)
            .Select(s => new
            {
                AcademicGroups = s.StudentGroups.Where(g => g.Type == GroupType.AcademicGroup)
                    .Select(g => g.Group.Title),
                AdditionalGroups = s.StudentGroups.Where(g => g.Type == GroupType.AdditionalStudyGroup)
                    .Select(g => g.Group.Title),
                UnderGroups = s.StudentUnderGroups.Select(g => g.UnderGroup.Title)
            })
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudentUnderGroups(int studentId)
    {
        var result = 1;
        
        return Ok(result);
    }
}