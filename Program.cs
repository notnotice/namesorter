using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using NameSorter.Sorter;
namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddSingleton<INameSorter, LastNameSorter>()
                .BuildServiceProvider();

            //define filenames for unsorted-names-list and sorted-names-list
            string unsortedFileName = Path.GetFullPath("unsorted-names-list.txt");
            string sortedFileName = Path.GetFullPath("sorted-names-list.txt");

            //Extract names from text file
            var names = File.ReadAllLines(unsortedFileName);

            //access static SortNameHelper to Convert to model
            var nameModels = UtilityHelper.ConvertToNameModels(names);

            //From Dependency Injection
            var sorter = serviceProvider.GetService<INameSorter>();
            var nameSorted = sorter.SortName(nameModels);

            // access static SortNameHelper WriteSortedName to create sorted-names-list.txt if filename does not exist
            // Overwrited sorted-names-list.txt if filename exist
            UtilityHelper.WriteSortedName(sortedFileName, nameSorted);

            //wait for any action to exit
            Console.ReadLine();
        }
    }
}
