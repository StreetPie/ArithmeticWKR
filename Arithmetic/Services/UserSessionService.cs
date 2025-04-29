using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arithmetic.Models;
using Arithmetic.Database;

namespace Arithmetic.Services
{
    public class UserSessionService
    {
        public User CurrentUser { get; private set; }

        public List<Result> TestResults { get; private set; } = new();
        public List<TaskResult> TaskResults { get; private set; } = new();

        public List<int> CompletedParagraphIds { get; private set; } = new();
        public List<int> CompletedChapterIds { get; private set; } = new();

        public void SetUser(User user)
        {
            CurrentUser = user;
        }

        public void LoadProgress(AppDbContext context)
        {
            if (CurrentUser == null)
                return;

            var userId = CurrentUser.Id;

            TestResults = context.Results
                .Where(r => r.StudentId == userId)
                .ToList();

            TaskResults = context.TaskResults
                .Where(tr => tr.StudentId == userId)
                .ToList();

            // Предполагаем, что есть таблицы CompletedParagraphs и CompletedChapters
            CompletedParagraphIds = context.SchoolTasks
                .Where(t => t.ParagraphId != null &&
                            context.TaskResults
                                .Any(tr => tr.StudentId == userId && tr.TaskId == t.Id))
                .Select(t => t.ParagraphId.Value)
                .Distinct()
                .ToList();

            CompletedChapterIds = context.Paragraphs
                .Where(p => CompletedParagraphIds.Contains(p.Id))
                .Select(p => p.ChapterId)
                .Distinct()
                .ToList();
        }

        public void Clear()
        {
            CurrentUser = null;
            TestResults.Clear();
            TaskResults.Clear();
            CompletedParagraphIds.Clear();
            CompletedChapterIds.Clear();
        }

        public bool IsAuthenticated => CurrentUser != null;
    }


}
