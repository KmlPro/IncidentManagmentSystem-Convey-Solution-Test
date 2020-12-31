using System;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    public class MarkAsReadyToPost : ICommand
    {
        public Guid Id { get; }

        public MarkAsReadyToPost(Guid id)
        {
            Id = id;
        }
    }
}