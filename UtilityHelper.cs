using System.IO;
using System.Collections.Generic;
using System.Linq;
using System;
using NameSorter.Models;
namespace NameSorter
{
    public static class UtilityHelper
    {
        public static IEnumerable<Name> ConvertToNameModels(this string[] source)
        {
            var nameModeList = source.Select(names =>
            {
                //Split each unsorted name using space
                var objArray = names.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                return new Name
                {
                    //Get the lastname by getting the last string on the splitted character
                    LastName = objArray[objArray.Length - 1],
                    //Get the firstname and skipped the lastname
                    FirstName = string.Join(" ", objArray.Take(objArray.Length - 1).ToArray()),
                };
            });

            return nameModeList;
        }
        public static void WriteSortedName(string newFile, IEnumerable<Name> sortedname)
        {
            FileStream stream = new FileStream(newFile, FileMode.OpenOrCreate);

            // Create the SortedName filename using StreamWriter
            using (StreamWriter writer = new StreamWriter(stream))
            {
                foreach (var name in sortedname)
                {
                    // display the sorted name in the screen
                    Console.WriteLine($"{ name.FullName}");
                    // log the sorted name in the sorted-names-list.txt 
                    writer.WriteLine($"{ name.FullName}");
                }
            }
        }
    }
}