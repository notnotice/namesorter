using System.Collections.Generic;
using NameSorter.Models;

namespace NameSorter.Sorter
{
    public interface INameSorter
    {
        IEnumerable<Name> SortName(IEnumerable<Name> names, bool isAscending = true);
    }
}
