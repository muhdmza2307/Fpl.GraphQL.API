﻿using Fpl.Portal.Models;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.Repository.FunctionCallers
{
    public class DroidRepository : IDroidRepository
    {
        public Task<IQueryable<Droid>> GetDroidsAsync(CancellationToken cancellationToken) =>
            Task.FromResult(Database.Droids.AsQueryable());
        public Task<IEnumerable<Droid>> GetDroidsAsync(
            IEnumerable<Guid> ids,
            CancellationToken cancellationToken
        ) => Task.FromResult(Database.Droids.Where(x => ids.Contains(x.Id)));
        public Task<List<Character>> GetFriendsAsync(
            Droid droid,
            CancellationToken cancellationToken
        ) => Task.FromResult(Database.Characters!.Where(x => droid.Friends.Contains(x.Id)).ToList());
    }
}
