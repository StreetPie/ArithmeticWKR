using System;
using System.Text;
using System.Windows.Forms;
using Arithmetic.Interfaces;
using Arithmetic.Models;
using Arithmetic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Forms
{
    public partial class ClassWorkForm : Form
    {
        public interface IChapterService
        {
            Task<List<Chapter>> GetAllAsync();
        }

        public interface IParagraphService
        {
            Task<List<Paragraph>> GetAllAsync();
        }

        public interface ICompletionService
        {
            Task<List<int>> GetCompletedChapterIdsAsync(int userId);
            Task<List<int>> GetCompletedParagraphIdsAsync(int userId);
        }

        private readonly IFormFactory<IndependentWorkForm> _independentWorkFactory;

        private readonly UserSessionService _sessionService;
        private User CurrentUser => _sessionService.CurrentUser;
        private readonly IChapterService _chapterService;
        private readonly IParagraphService _paragraphService;
        private readonly ICompletionService _completionService;
        private readonly IServiceScopeFactory _scopeFactory;
        private RichTextBox richTextChapters;

        public ClassWorkForm(
   UserSessionService sessionService,
   IFormFactory<IndependentWorkForm> independentWorkFactory,
   IServiceScopeFactory scopeFactory)
        {
            _sessionService = sessionService;
            _independentWorkFactory = independentWorkFactory;
            _scopeFactory = scopeFactory;

            InitializeComponent();
            //BlurService.EnableBlur(this);
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;

            _ = LoadChaptersAndParagraphsAsync();
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            labelName.Text = $"Имя: {CurrentUser.FirstName}";
            labelSurname.Text = $"Фамилия: {CurrentUser.LastName}";
            labelClass.Text = $"Класс: {CurrentUser.Class?.Name ?? "Не указан"}";
        }

        private async Task LoadChaptersAndParagraphsAsync()
        {
    
            
                using var scope = _scopeFactory.CreateScope();
                var chapterService = scope.ServiceProvider.GetRequiredService<IChapterService>();
                var paragraphService = scope.ServiceProvider.GetRequiredService<IParagraphService>();
                var completionService = scope.ServiceProvider.GetRequiredService<ICompletionService>();

                var chapters = await chapterService.GetAllAsync();
                var paragraphs = await paragraphService.GetAllAsync();
                var completedChapters = await completionService.GetCompletedChapterIdsAsync(CurrentUser.Id);
                var completedParagraphs = await completionService.GetCompletedParagraphIdsAsync(CurrentUser.Id);

                var sb = new StringBuilder();
                int chapterNum = 1;

                foreach (var chapter in chapters)
                {
                    bool chapterDone = completedChapters.Contains(chapter.Id);
                    sb.AppendLine($"{chapterNum}. {chapter.Name} {(chapterDone ? "✅" : "")}");

                    var chapterParagraphs = paragraphs.Where(p => p.ChapterId == chapter.Id);
                    foreach (var para in chapterParagraphs)
                    {
                        bool paraDone = completedParagraphs.Contains(para.Id);
                        sb.AppendLine($"   - {para.Name} {(paraDone ? "✅" : "")}");
                    }

                    sb.AppendLine();
                    chapterNum++;
                }

                richTextChapters.Text = sb.ToString();
            }

        




        private void buttonBack_Click(object sender, EventArgs e)
        {
            var factory = Program.AppHost.Services.GetRequiredService<IFormFactory<MainForm>>();
            var form = factory.Create();
            form.Show();
            this.Close();

        }


        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonHoverColor;
        }

        private void buttonBack_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = RedButtonColor;
        }
    }
}
