using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNet
{
    public class SymbolicExpressionParam
    {
        /// <summary>
        /// 变量表达式
        /// </summary>
        public SymbolicExpression SymbolicExpression { get; set; }

        /// <summary>
        /// 变量名称
        /// </summary>
        public string ParamName { get; set; }

        public string Where { get; set; }

        public SymbolicExpressionParam(SymbolicExpression symbolicExpression=null, string paramName = null,string where=null)
        {
            this.SymbolicExpression = symbolicExpression;
            this.ParamName = paramName;
            this.Where = where;
        }
    }

    public class SymbolicExpressionParamList : List<SymbolicExpressionParam>
    {
        /// <summary>
        /// 是否强制使用参数名传入
        /// 例如:pie(filename='123.png')
        /// 如果:不强制则pie('123.png');参数的排列顺序与加入集合的顺序相同
        /// </summary>
        public bool IsUseParamName { get; set; } = true;
    }
}
