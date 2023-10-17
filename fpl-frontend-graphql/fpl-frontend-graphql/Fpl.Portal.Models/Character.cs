using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Models
{
    public abstract record Character(
    Guid Id,
    string Name,
    DateTimeOffset Created,
    DateTimeOffset Modified
)
    {
        public List<Episode> AppearsIn { get; } = new List<Episode>();
        public List<Guid> Friends { get; } = new List<Guid>();
    }
}
