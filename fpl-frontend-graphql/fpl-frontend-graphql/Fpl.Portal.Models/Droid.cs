using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Models
{
    public record Droid(
    Guid Id,
    string Name,
    string PrimaryFunction,
    TimeSpan ChargePeriod,
    DateTimeOffset Manufactured,
    DateTimeOffset Created,
    DateTimeOffset Modified
) : Character(Id, Name, Created, Modified)
    { }
}
