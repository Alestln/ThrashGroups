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
    public async Task<IActionResult> GetStudentAcademicGroups(int studentId)
    {
        var result = await _context.StudentGroups
            .Where(s => s.StudentId == studentId && s.Type == GroupType.AcademicGroup)
            .Select(s => s.Group.Title)
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudentAdditionalStudyGroups(int studentId)
    {
        var result = await _context.StudentGroups
            .Where(s => s.StudentId == studentId && s.Type == GroupType.AdditionalStudyGroup)
            .Select(s => s.Group.Title)
            .ToListAsync();
        
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudentUnderGroups(int studentId)
    {
        var result = await _context.Students
            .Where(s => s.Id == studentId)
            .SelectMany(s => s.StudentUnderGroups.Select(g => g.UnderGroup.Title))
            .ToListAsync();
        
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentsAcademicGroup(int groupId)
    {
        var result = await _context.StudentGroups
            .Where(s => s.GroupId == groupId && s.Type == GroupType.AcademicGroup)
            .Select(s => s.Student.Lastname)
            .ToListAsync();

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudentsAdditionalStudyGroup(int groupId)
    {
        var result = await _context.StudentGroups
            .Where(s => s.GroupId == groupId && s.Type == GroupType.AdditionalStudyGroup)
            .Select(s => s.Student.Lastname)
            .ToListAsync();

        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetStudentsUnderGroup(int groupId)
    {
        var result = await _context.StudentUnderGroups
            .Where(u => u.UnderGroupId == groupId)
            .Select(u => u.Student.Lastname)
            .ToListAsync();

        return Ok(result);
    }
}