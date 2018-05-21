using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNet
{
    public static class REngineExtension
    {
        /// <summary>
        /// 设置R语言的工作目录
        /// </summary>
        public static void SetWd(this REngine engine, Func<string> wdPath = null)
        {
            var path = wdPath != null ? (wdPath() ?? string.Empty) : AppDomain.CurrentDomain.BaseDirectory;
            var pathchar = engine.CreateCharacter(path);
            engine.ExecFunction(pathchar, "setwd");
        }

        /// <summary>
        /// 获取R语言的工作目录
        /// </summary>
        public static SymbolicExpression GetWd(this REngine engine)
        {
            return engine.Evaluate("getwd()");
        }

        /// <summary>
        /// 读取Csv文件
        /// </summary>
        public static SymbolicExpression ReadCsv(this REngine engine, string csvFileName)
        {
            var csvName = engine.CreateCharacter(csvFileName);
            return engine.ExecFunction(csvName, "read.csv");
        }

        /// <summary>
        /// 打印结果信息
        /// </summary>
        public static void Print(this REngine engine, SymbolicExpression symbolicExpression)
        {
            engine.ExecFunction(symbolicExpression, "print");
        }

        /// <summary>
        /// 打印字符串
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="content"></param>
        public static void Print(this REngine engine, string content)
        {
            engine.Print(engine.CreateCharacter(content));
        }

        public static void NCol(this REngine engine, SymbolicExpression symbolicExpression)
        {
            engine.ExecFunction(symbolicExpression, "ncol");
        }

        public static void NRow(this REngine engine, SymbolicExpression symbolicExpression)
        {
            engine.ExecFunction(symbolicExpression, "nrow");
        }

        /// <summary>
        /// 传入函数名称就可以执行函数
        /// </summary>
        /// <param name="engine"></param>
        /// <param name="symbolicExpression"></param>
        /// <param name="functionName"></param>
        /// <returns></returns>
        public static SymbolicExpression ExecFunction(this REngine engine, SymbolicExpression symbolicExpression, string functionName)
        {
            var expressionPar = new SymbolicExpressionParamList() { IsUseParamName = false, };
            var param = new SymbolicExpressionParam(symbolicExpression, "");
            expressionPar.Add(param);
            return engine.ExecFunction(expressionPar, functionName);
        }

        public static SymbolicExpression ExecFunction(this REngine engine, SymbolicExpressionParamList expressionParams, string functionName)
        {
            var paramValue = engine.GetFunction(expressionParams);
            var function = $"{functionName}({paramValue})";
            return engine.Evaluate(function);
        }

        private static string GetFunction(this REngine engine, SymbolicExpressionParamList expressionParams)
        {
            var paramValue = string.Empty;
            if (expressionParams != null && expressionParams.Count > 0)
            {
                var isUseName = expressionParams.IsUseParamName;
                var sb = new StringBuilder();
                var paramName = string.Empty;

                for (int i = 0; i < expressionParams.Count; i++)
                {
                    var item = expressionParams[i];
                    paramName = item.ParamName;

                    var paramIsNull = string.IsNullOrWhiteSpace(paramName);

                    if (isUseName)
                    {
                        if (paramIsNull) throw new Exception("参数名称不能为空,");

                        if (item.SymbolicExpression != null && string.IsNullOrWhiteSpace(item.Where))
                        {
                            sb.Append($"{paramName}={paramName},");
                        }

                        if (item.SymbolicExpression == null && !string.IsNullOrWhiteSpace(item.Where))
                        {
                            sb.Append($"{paramName}={item.Where},");
                        }
                    }
                    else
                    {
                        if (item.SymbolicExpression != null && string.IsNullOrWhiteSpace(item.Where))
                        {
                            if (paramIsNull) paramName = "x" + i;
                            sb.Append($"{paramName},");
                        }

                        if (item.SymbolicExpression == null && !string.IsNullOrWhiteSpace(item.Where))
                        {
                            sb.Append($"{item.Where},");
                        }

                    }
                    if (string.IsNullOrWhiteSpace(item.Where))
                        engine.SetSymbol(paramName, item.SymbolicExpression);
                }
                paramValue = sb.ToString().TrimEnd(',');
            }

            return paramValue;
        }
    }
}
