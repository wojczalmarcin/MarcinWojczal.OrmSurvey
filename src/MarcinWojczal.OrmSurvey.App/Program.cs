using BenchmarkDotNet.Running;
using MarcinWojczal.OrmSurvey.App.Benchmarks.PosgreSql;
using MarcinWojczal.OrmSurvey.App.Benchmarks.SqlServer;
using MarcinWojczal.OrmSurvey.Charts;

BenchmarkRunner.Run<GetOrderByIdSqlServer>();
BenchmarkRunner.Run<GetOrderWithDetailsByIdSqlServer>();
BenchmarkRunner.Run<GetOrdersSqlServer>();
BenchmarkRunner.Run<GetOrdersWithDetailsSqlServer>();
BenchmarkRunner.Run<InsertOrdersWithDetailsSqlServer>();
BenchmarkRunner.Run<UpdateOrdersWithDetailsSqlServer>();
BenchmarkRunner.Run<GetAndUpdateOrdersWithDetailsSqlServer>();
BenchmarkRunner.Run<DeleteOrdersWithDetailsSqlServer>();
BenchmarkRunner.Run<GetAndDeleteOrdersWithDetailsSqlServer>();

BenchmarkRunner.Run<GetOrderByIdPosgreSql>();
BenchmarkRunner.Run<GetOrderWithDetailsByIdPosgreSql>();
BenchmarkRunner.Run<GetOrdersPosgreSql>();
BenchmarkRunner.Run<GetOrdersWithDetailsPosgreSql>();
BenchmarkRunner.Run<InsertOrdersWithDetailsPosgreSql>();
BenchmarkRunner.Run<UpdateOrdersWithDetailsPosgreSql>();
BenchmarkRunner.Run<GetAndUpdateOrdersWithDetailsPosgreSql>();
BenchmarkRunner.Run<DeleteOrdersWithDetailsPosgreSql>();
BenchmarkRunner.Run<GetAndDeleteOrdersWithDetailsPosgreSql>();

var t = new Thread(() => { 
    ChartGenerator.GenerateAll(Path.GetFullPath("\\BenchmarkDotNet.Artifacts\\results")); 

});
t.SetApartmentState(ApartmentState.STA);

t.Start();