using NameSorter.Models;
using System.Collections.Generic;
using System.Linq;

namespace NameSorter.Sorter
{
    public class LastNameSorter : INameSorter
    {
        public IEnumerable<Name> SortName(IEnumerable<Name> unsortedname, bool isAscending = true)
        {
            // sorted lastname,firstname based on criteria, default is ascending
            var sortedname = unsortedname.AsEnumerable();
            switch (isAscending)
            {
                case false:
                    {
                        sortedname = unsortedname.OrderByDescending(lname => lname.LastName)
                        .ThenByDescending(fname => fname.FirstName);
                    }
                    break;
                default:
                    {
                        sortedname = unsortedname.OrderBy(lname => lname.LastName)
                            .ThenBy(fname => fname.FirstName);
                    }
                    break;
            }

            return sortedname.ToList();
        }
    }
}
