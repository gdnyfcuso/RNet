using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNet
{
    class Program
    {
        static void Main(string[] args)
        {
            REngine.SetEnvironmentVariables();
            // There are several options to initialize the engine, but by default the following suffice:
            REngine engine = REngine.GetInstance();

            //engine.Birth_of_age();

            //engine.Age_title_colours();

            //engine.Barchart();
            //engine.barchart_months_revenue();
            //engine.Barchart_stacked();

            engine.SetWd();
            engine.GetWd();
            //engine.Print("开始安装exec组件");
            //engine.Evaluate("install.packages('xlsx')");
            //engine.Print("结束安装exec组件");


            engine.Print("读取文件开始");

            //var csvName = engine.ReadCsv("InputName.csv");

            //var param = new SymbolicExpressionParamList() { IsUseParamName = false };
            //param.Add(new SymbolicExpressionParam(csvName));
            //param.Add(new SymbolicExpressionParam(where: " as.Date(start_date) > as.Date('2014-01-01') "));
            ////param.Add(new SymbolicExpressionParam(where: "salary>600&dept=='IT'"));
            //var subset = engine.ExecFunction(param, "subset");

            //var paramA = new SymbolicExpressionParamList() { IsUseParamName = false };
            //paramA.Add(new SymbolicExpressionParam(subset.AsDataFrame()));
            //paramA.Add(new SymbolicExpressionParam(where: "'output1.csv'"));
            //paramA.Add(new SymbolicExpressionParam(where: "row.names = FALSE"));
            //engine.ExecFunction(paramA, "write.csv");
            //engine.ReadCsv("output1.csv");

            engine.Evaluate("library(xlsx) ");
            var paramA = new SymbolicExpressionParamList() { IsUseParamName = false };
            paramA.Add(new SymbolicExpressionParam(where: "'input.xlsx'"));
            paramA.Add(new SymbolicExpressionParam(engine.CreateNumeric(1), paramName: "sheetIndex"));
            engine.ExecFunction(paramA, "read.xlsx");
            //engine.ReadCsv("output1.csv");

            engine.Print("读取文件结束");

            engine.Dispose();

            Console.ReadKey();

        }
    }
}
