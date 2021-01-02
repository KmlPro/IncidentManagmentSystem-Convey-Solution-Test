using System;
using Convey.CQRS.Commands;

namespace IncidentReport.Application.Commands
{
    public class MarkAsReadyToPost : ICommand
    {
        public Guid DraftApplicationId { get; }

        public MarkAsReadyToPost(Guid draftApplicationId)
        {
            DraftApplicationId = draftApplicationId;
        }
    }
}