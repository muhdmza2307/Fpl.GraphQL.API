using Fpl.Portal.Models;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using GraphQL.DataLoader;
using GreenDonut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fpl.Portal.GraphQL.DataLoaders
{
    public class DroidDataLoader : GreenDonut.BatchDataLoader<Guid, Droid>, IDroidDataLoader
    {
        private readonly IDroidRepository repository;
        public DroidDataLoader(
            IDroidRepository repository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options
        ) : base(batchScheduler, options) => 
            this.repository = repository;

        protected override async Task<IReadOnlyDictionary<Guid, Droid>> LoadBatchAsync(
            IReadOnlyList<Guid> keys,
            CancellationToken cancellationToken
        )
        {
            var droids = await this.repository
                .GetDroidsAsync(keys, cancellationToken)
                .ConfigureAwait(false);
            return droids.ToDictionary(x => x.Id);
        }
    }

}
