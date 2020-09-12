using MediatR;

namespace Msi.Mediator.Abstractions
{
    public enum EventType : byte
    {
        Created,
        Updated,
        Deleted,
        Viewed,
        Accepted,
        Rejected,
        Submitted,
        Reviewed,
        Cancelled,
        Suspended,
        Withdrawn,
        Failed
    }
}
