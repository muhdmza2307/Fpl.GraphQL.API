using Fpl.Portal.Models;
using GreenDonut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fpl.Portal.GraphQL.DataLoaders
{
    public interface IDroidDataLoader : IDataLoader<Guid, Droid>
    {
    }
}
