using Fpl.Portal.Models.Events;

namespace Fpl.Portal.Handlers.Events;

public interface IGetLatestEventHandler
{
    Task<EventResult> HandleAsync();
}