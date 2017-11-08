using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace wordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\Users\lesli\Desktop\paragraph.txt";

            var theString = "";

            using (var fs = new FileStream(filePath, FileMode.Open))
            using (var sr = new StreamReader(fs))
            {
                theString = sr.ReadToEnd();
            }

            GetWinningWords(theString);
        }

        private static void GetWinningWords(string theString)
        {
            string[] wordArr = theString.Split(new char[] {' ', '.', '"', ',', '-', '!'},
                StringSplitOptions.RemoveEmptyEntries);

            var winner = wordArr.GroupBy(x => x).Select(z => new
            {
                word = z.Key,
                count = z.Count()
            }).OrderByDescending(x => x.count);

            foreach (var s in winner)
            {
                Console.WriteLine($"{s.word}: {s.count}");
            }
        }
    }
}
