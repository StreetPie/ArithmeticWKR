using System;
using System.Collections.Generic;
using System.Linq;
using Arithmetic.Models;
using Arithmetic.Database;
using Microsoft.EntityFrameworkCore;

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

            // Загружаем результаты тестов
            TestResults = context.Results
                .Where(r => r.StudentId == userId)
                .ToList();

            // Загружаем TaskResults через Result.StudentId
            TaskResults = context.TaskResults
                .Include(tr => tr.Result)
                .Where(tr => tr.Result.StudentId == userId)
                .ToList();

            // Загружаем завершённые параграфы и главы
            CompletedParagraphIds = context.CompletedParagraphs
                .Where(cp => cp.UserId == userId)
                .Select(cp => cp.ParagraphId)
                .ToList();

            CompletedChapterIds = context.CompletedChapters
                .Where(cc => cc.UserId == userId)
                .Select(cc => cc.ChapterId)
                .ToList();
        }

        public void SaveTestResult(AppDbContext context, Result result)
        {
            if (CurrentUser == null)
                return;

            result.StudentId = CurrentUser.Id;
            context.Results.Add(result);
            context.SaveChanges();
        }

        public void SaveTaskResult(AppDbContext context, TaskResult taskResult)
        {
            context.TaskResults.Add(taskResult);
            context.SaveChanges();
        }

        public void MarkParagraphCompleted(AppDbContext context, int paragraphId)
        {
            if (CurrentUser == null) return;

            if (!CompletedParagraphIds.Contains(paragraphId))
            {
                context.CompletedParagraphs.Add(new CompletedParagraph
                {
                    UserId = CurrentUser.Id,
                    ParagraphId = paragraphId
                });
                context.SaveChanges();

                CompletedParagraphIds.Add(paragraphId); // обновляем локально
            }

            // Проверка: завершены ли все параграфы главы
            var chapterId = context.Paragraphs
                .Where(p => p.Id == paragraphId)
                .Select(p => p.ChapterId)
                .FirstOrDefault();

            if (chapterId != 0)
            {
                var allParagraphsInChapter = context.Paragraphs
                    .Where(p => p.ChapterId == chapterId)
                    .Select(p => p.Id)
                    .ToList();

                var completedAll = allParagraphsInChapter.All(id => CompletedParagraphIds.Contains(id));

                if (completedAll && !CompletedChapterIds.Contains(chapterId))
                {
                    context.CompletedChapters.Add(new CompletedChapter
                    {
                        UserId = CurrentUser.Id,
                        ChapterId = chapterId
                    });
                    context.SaveChanges();

                    CompletedChapterIds.Add(chapterId); // обновляем локально
                }
            }
        }





        public bool IsParagraphCompleted(int paragraphId) =>
            CompletedParagraphIds.Contains(paragraphId);

        public bool IsChapterCompleted(int chapterId) =>
            CompletedChapterIds.Contains(chapterId);
    }
}
