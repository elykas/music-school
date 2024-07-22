using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchool.Service
{
    internal static class PracticeClass
    {
        public static Func<List<string>, bool> StartWithA = (list) =>
        {
            return list.Any(s => s.StartsWith("a"));
        };


        public static Func<List<string>, bool> IsEmptyStr = (list) =>
        {
            return list.Any(string.IsNullOrEmpty);

        };

        public static Func<List<string>, bool> ConntainsA = (list) => 
         list.All(c => c.ToLower().Contains("A"));

        public static Func<List<string>,List<string>> UpCase = (list) =>
        list.Select(c => c.ToUpper()).ToList();

        
        public static Func<List<string>, List<string>> UpCaseQuery = (list) =>
            (from c in list
             select c.ToUpper()).ToList();
       
        

        public static Func<List<string>,List<string>> Grater3 = (list) =>
        list.Where(c => c.Length > 3).ToList();

       
        public static Func<List<string>, List<string>> Grater3Query = (list) =>
         (
            from c in list
            where c.Length > 3
            select c).ToList();

        public static Func<List<string>,string> oneString= (list) =>
        list.Aggregate(string.Empty,(a, b) =>$"{a} {b}");

        public static Func<List<string>,int> ListLength = (list) =>
        list.Aggregate(0,(a,b) => a + b.Length);

        public static Func<List<string>, List<string>> Grate3 = (list) =>
        list.Aggregate(new List<string>(), (a, b) => b.Length > 3 ? [..a,b] : a);

        public static Func<List<string>, List<int>> SelectLength = (list) =>
        list.Aggregate(new List<int>(),(acc,n) => [..acc,n.Length]);

    }
}