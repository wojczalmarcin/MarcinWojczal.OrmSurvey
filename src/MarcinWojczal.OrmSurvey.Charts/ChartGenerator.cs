using CsvHelper;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Legends;
using OxyPlot.Wpf;
using System.Globalization;

namespace MarcinWojczal.OrmSurvey.Charts
{
    public static class ChartGenerator
    {
        public static void GenerateAll(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                foreach(var file in Directory.EnumerateFiles(directoryPath))
                {
                    try
                    {
                        if (Path.GetExtension(file) == ".csv")
                        {
                            Generate(file);
                        }
                    }
                    catch (HeaderValidationException e)
                    {
                        Console.Error.WriteLine(e.Message);
                    }
                }
            }
        }
        public static void Generate(string csvFilePath)
        {
            IReadOnlyList<BenchmarkResultWithNumberOfRecords> records;
            using (var reader = new StreamReader(csvFilePath))
            {
                using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);
                records = csv.GetRecords<BenchmarkResultWithNumberOfRecords>().ToList();
            }

            var methodsNames = new List<string>();
            foreach(var record in records)
            {
                if(!methodsNames.Contains(record.Method))
                {
                    methodsNames.Add(record.Method);
                }
            }

            var methodResults = new List<MethodResult>();
            foreach (var method in methodsNames)
            {
                methodResults.Add(new MethodResult(records, method));
            }

            var meanPlot = new PlotModel() { DefaultFontSize = 25 };//{ Title = "Czas wykonania zapytania." }; //KB
            var memoryPlot = new PlotModel() { DefaultFontSize = 25 }; //{ Title = "Zużycie pamięci zapytania." }; //KB
            meanPlot.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Liczba rekordów" });
            meanPlot.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Czas wykonania [μs]" });
            memoryPlot.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Liczba rekordów" });
            memoryPlot.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Title = "Zużycie pamięci [KB]" });
            meanPlot.Legends.Add(new Legend
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
            });
            memoryPlot.Legends.Add(new Legend
            {
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
            });


            foreach (var method in methodResults)
            {
                meanPlot.Series.Add(method.Mean);
                memoryPlot.Series.Add(method.Memory);
            }

            var pngExporter = new PngExporter { Width = 1200, Height = 800 };
            pngExporter.ExportToFile(meanPlot, Path.GetDirectoryName(csvFilePath) + "\\" + Path.GetFileNameWithoutExtension(csvFilePath) + "-mean.png");
            pngExporter.ExportToFile(memoryPlot, Path.GetDirectoryName(csvFilePath) + "\\" + Path.GetFileNameWithoutExtension(csvFilePath) + "-memory.png");
        }
    }
}