using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centerstone
{
    public interface IHIFDataStore<T>
    {
      Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
