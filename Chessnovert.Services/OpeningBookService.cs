using Chessnovert.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chessnovert.Services
{
    public class OpeningBookService
    {
        public string Parent = Path.GetDirectoryName(Directory.GetParent(Directory.GetCurrentDirectory()).FullName) + @"/Chessnovert/Shared/chess-openings/dist/";
        List<Opening> openings = new List<Opening>();

        private void readTsv()
        {
            List<string> files = new List<string>() { "a.tsv", "b.tsv", "c.tsv", "d.tsv", "e.tsv" };
            int rowCount = 0;
            foreach (string file in files)
            {
                string absolutePath = Parent + file;
                StreamReader reader = new StreamReader(absolutePath);
                string? line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tsv = line.Split(new char[] { '\t' }).ToArray();
                    //remove any end spaces from data
                    tsv = tsv.Select(x => x.Trim()).ToArray();

                    if (rowCount == 0)
                    {
                        foreach (string colName in tsv)
                        {
                            Console.WriteLine(colName, typeof(string));
                        }
                        rowCount++;
                    }
                    else
                    {
                        rowCount++;
                        var ECO = tsv[0];
                        var Name = tsv[1];
                        var PGN = tsv[2];
                        var UCI = tsv[3];
                        var EPD = tsv[4];
                        openings.Add(new Opening( ECO, Name, PGN, UCI, EPD));
                    }

                }
            }

        }
        private void ReadFileParallel()
        {
            List<string> files = new List<string>() { "a.tsv", "b.tsv", "c.tsv", "d.tsv", "e.tsv" };
            int rowCount = 0;
            Parallel.ForEach(files, (file =>
            {
                string absolutePath = Parent + file;
                StreamReader reader = new StreamReader(absolutePath);
                string? line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tsv = line.Split(new char[] { '\t' }).ToArray();
                    //remove any end spaces from data
                    tsv = tsv.Select(x => x.Trim()).ToArray();

                    if (rowCount == 0)
                    {
                        foreach (string colName in tsv)
                        {
                            Console.WriteLine(colName, typeof(string));
                        }
                        rowCount++;
                    }
                    else
                    {
                        rowCount++;
                        var ECO = tsv[0];
                        var Name = tsv[1];
                        var PGN = tsv[2];
                        var UCI = tsv[3];
                        var EPD = tsv[4];
                        //  dt.Add(new Opening(Id, ECO, Name, PGN, UCI, EPD));
                        lock (openings)
                        {
                            openings.Add(new Opening(ECO, Name, PGN, UCI, EPD));
                        }
                    }

                }
            }));

        }
        public OpeningBookService()
        {
            ReadFileParallel();
        }
        public Opening? GetFromUCI(string uci)
        {
            //return dic[uci];
            return openings.FirstOrDefault(o => o.UCI == uci);
        }
    }
}
