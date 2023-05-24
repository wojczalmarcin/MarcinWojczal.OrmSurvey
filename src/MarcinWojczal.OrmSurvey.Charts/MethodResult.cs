using OxyPlot;
using OxyPlot.Series;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MarcinWojczal.OrmSurvey.Charts
{
    internal class MethodResult
    {
        public MethodResult(IEnumerable<BenchmarkResultWithNumberOfRecords> benchmarkResuts, string methodName)
        {
            foreach (BenchmarkResultWithNumberOfRecords benchmarkResult in benchmarkResuts)
            {
                Mean ??= new LineSeries() { Title = methodName, MarkerType = MarkerType.Circle};
                Memory ??= new LineSeries() { Title = methodName, MarkerType = MarkerType.Circle };

                if (benchmarkResult.Method == methodName)
                {
                    this.MethodName = methodName;

                    if(benchmarkResult.Mean != "NA" && benchmarkResult.Mean !="-")
                    {
                        var numericMean = double.Parse(Regex.Replace(benchmarkResult.Mean, "[^0-9.]", ""), CultureInfo.InvariantCulture);
                        Mean.Points.Add(new DataPoint(benchmarkResult.NumberOfRecords, numericMean));
                    }
                    if (benchmarkResult.Allocated != "NA" && benchmarkResult.Allocated != "-")
                    {
                        var numericMemory = double.Parse(Regex.Replace(benchmarkResult.Allocated, "[^0-9.]", ""), CultureInfo.InvariantCulture);
                        Memory.Points.Add(new DataPoint(benchmarkResult.NumberOfRecords, numericMemory));
                    }
                }
            }
        }

        public string MethodName { get; set; }

        public LineSeries Mean { get; }

        public LineSeries Memory { get; }

    }
}
