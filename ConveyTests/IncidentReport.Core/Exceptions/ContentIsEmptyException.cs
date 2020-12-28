namespace IncidentReport.Core.Exceptions
{
    public class ContentIsEmptyException : DomainException
    {
        public override string Code { get; } = "content_is_empty";
        
        public ContentIsEmptyException() : base("Content is empty.")
        {
        }
    }
}