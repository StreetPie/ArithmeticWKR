// ParagraphService.cs
using Arithmetic.Database;
using Arithmetic.Interfaces;
using Arithmetic.Models;
using Microsoft.EntityFrameworkCore; // ← ВАЖНО
using Arithmetic.Database;
using Arithmetic.Interfaces;
using static Arithmetic.Forms.ClassWorkForm;


public class ParagraphService : IParagraphService
{
    private readonly AppDbContext _context;
    public ParagraphService(AppDbContext context) => _context = context;

    public async Task<List<Paragraph>> GetAllAsync()
    {
        return await _context.Paragraphs.ToListAsync();
    }
}
