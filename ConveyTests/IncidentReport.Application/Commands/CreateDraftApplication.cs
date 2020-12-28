using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    public class CreateDraftApplication : ICommand
    {
        public string Content { get; }
        public string Title { get; }

        public CreateDraftApplication(string content, string title)
        {
            Content = content;
            Title = title;
        }
    }
}