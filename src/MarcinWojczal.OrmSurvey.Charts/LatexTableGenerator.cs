using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcinWojczal.OrmSurvey.Charts
{
    public sealed class LatexTableGenerator
    {
        //public string GenerateRows(string directoryPath)
        //{
        //    if (Directory.Exists(directoryPath))
        //    {
        //        foreach (var file in Directory.EnumerateFiles(directoryPath))
        //        {
        //            try
        //            {
        //                if (Path.GetExtension(file) == ".csv")
        //                {
        //                    Generate(file);
        //                }
        //            }
        //            catch (HeaderValidationException e)
        //            {
        //                Console.Error.WriteLine(e.Message);
        //            }
        //        }
        //    }
        //}
        //
        //private string GenerateRowForGetMethods(string directoryPath)
        //{
        //    foreach (var file in Directory.EnumerateFiles(directoryPath))
        //    {
        //        var rows = new List<StringBuilder>();
        //        //var latexRow = "\\multirow{3}{*}{1}";
        //        if (Path.GetExtension(file) == ".csv" && Path.GetFileName(file).Contains("GetOrder"))
        //        {
        //            try
        //            {
        //                IReadOnlyList<BenchmarkResultWithNumberOfRecords> records;
        //                using (var reader = new StreamReader(file))
        //                {
        //                    using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
        //                    records = csv.GetRecords<BenchmarkResultWithNumberOfRecords>().ToList();
        //                }
        //                records = records.OrderBy(x => x.NumberOfRecords).ToList();
        //
        //            }
        //            catch (HeaderValidationException e)
        //            {
        //
        //            }
        //        }
        //    }

            //IReadOnlyList<BenchmarkResultWithNumberOfRecords> records;
            //using (var reader = new StreamReader(csvFilePath))
            //{
            //    using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
            //    records = csv.GetRecords<BenchmarkResultWithNumberOfRecords>().ToList();
            //}
            //
            //var dapperRow = "\\multirow{3}{*}{1} & Dapper";


            //var methodsNames = new List<string>();
            //foreach (var record in records)
            //{
            //    if (!methodsNames.Contains(record.Method))
            //    {
            //        methodsNames.Add(record.Method);
            //    }
            //}
//        }
    }
}

//\multirow{3}{ *}
//{ 1}
//&Dapper & 85.05 & 7.26 & 731.6 & 19.95 & 1 & 1 & 1 & 1 \\
//       &EF & 143.47 & 12.45 & 979.8 & 402.03 & 1 & 1 & 1 & 1 \\
//       &NHibernate & 322.69 & 55.92 & 549.9 & 356.88 & 1 & 1 & 1 & 1 \\ 