// CompletionService.cs
using Arithmetic.Database;
using Arithmetic.Interfaces;
using Microsoft.EntityFrameworkCore; // ← ВАЖНО

using static Arithmetic.Forms.ClassWorkForm;

public class CompletionService : ICompletionService
{
    private readonly AppDbContext _context;
    public CompletionService(AppDbContext context) => _context = context;

    public async Task<List<int>> GetCompletedChapterIdsAsync(int userId)
    {
        return await _context.CompletedChapters
            .Where(c => c.UserId == userId)
            .Select(c => c.ChapterId)
            .ToListAsync();
    }

    public async Task<List<int>> GetCompletedParagraphIdsAsync(int userId)
    {
        return await _context.CompletedParagraphs
            .Where(p => p.UserId == userId)
            .Select(p => p.ParagraphId)
            .ToListAsync();
    }
}
