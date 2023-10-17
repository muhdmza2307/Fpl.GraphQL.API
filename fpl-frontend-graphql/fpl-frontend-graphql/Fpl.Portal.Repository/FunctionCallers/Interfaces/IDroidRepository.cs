using Fpl.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Repository.FunctionCallers.Interfaces
{
    public interface IDroidRepository
    {
        Task<IQueryable<Droid>> GetDroidsAsync(CancellationToken cancellationToken);
        Task<IEnumerable<Droid>> GetDroidsAsync(
            IEnumerable<Guid> ids,
            CancellationToken cancellationToken
        );
        Task<List<Character>> GetFriendsAsync(Droid droid, CancellationToken cancellationToken);
    }

}
