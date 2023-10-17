using Fpl.Portal.GraphQL.DataLoaders;
using Fpl.Portal.Models;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using HotChocolate;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Fpl.Portal.GraphQL.Resolvers
{
    public class DroidResolver
    {
        public Task<Droid> GetDroidAsync(IDroidDataLoader droidDataLoader, Guid id, CancellationToken cancellationToken) => droidDataLoader.LoadAsync(id, cancellationToken); 
        public Task<List<Character>> GetFriendsAsync([Service] IDroidRepository droidRepository, 
            [Parent] Droid droid, 
            CancellationToken cancellationToken) => 
            droidRepository.GetFriendsAsync(droid, cancellationToken);
    }
}
