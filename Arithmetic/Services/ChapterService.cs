// 
using Arithmetic.Database;
using Arithmetic.Interfaces;
using Microsoft.EntityFrameworkCore; // ← ВАЖНО

using Arithmetic.Models;
using static Arithmetic.Forms.ClassWorkForm;

public class ChapterService : IChapterService
{
    private readonly AppDbContext _context;
    public ChapterService(AppDbContext context) => _context = context;

    public async Task<List<Chapter>> GetAllAsync()
    {
        return await _context.Chapters
            .Include(c => c.Paragraphs)
            .ToListAsync();
    }
}
