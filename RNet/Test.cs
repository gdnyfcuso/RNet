using RDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNet
{
    public static class Test
    {
        public static void Birth_of_age(this REngine engine)
        {
            var numVer = engine.CreateNumericVector(new double[] { 11, 30, 39, 20 });

            var charVer = engine.CreateCharacterVector(new string[] { "70后", "80后", "90后", "00后" });
            engine.SetSymbol("x", numVer);
            engine.SetSymbol("labels", charVer);
            engine.Evaluate("png(file = 'birth_of_age.jpg')");
            engine.Evaluate("pie(x,labels)");
            engine.Evaluate("dev.off()");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="engine"></param>
        public static void Age_title_colours(this REngine engine)
        {
            //# Create data for the graph.
            //            x < -c(11, 30, 39, 20)
            //labels < -c("70后", "80后", "90后", "00后")

            //# Give the chart file a name.
            //png(file = "age_title_colours.jpg")

            //# Plot the chart with title and rainbow color pallet.
            //pie(x, labels, main = "出生年龄段 - 饼状图", col = rainbow(length(x)))

            //# Save the file.
            //dev.off()

            var numVer = engine.CreateNumericVector(new double[] { 11, 30, 39, 20 });

            var charVer = engine.CreateCharacterVector(new string[] { "70后", "80后", "90后", "00后" });

            var mainChar = engine.CreateCharacter("出生年龄段 - 饼状图");

            engine.SetSymbol("x", numVer);
            engine.SetSymbol("labels", charVer);
            engine.SetSymbol("main", mainChar);

            var length = engine.Evaluate("rainbow(length(x))");

            engine.SetSymbol("col", length);

            engine.Evaluate("png(file = 'age_title_colours.jpg')");
            engine.Evaluate("pie(x,labels,main=main,col = col)");
            engine.Evaluate("dev.off()");


        }

        public static void Barchart(this REngine engine)
        {
            //            H < -c(7, 12, 28, 3, 41)

            //# Give the chart file a name.
            //png(file = "barchart.png")

            //# Plot the bar chart.
            //barplot(H)

            //# Save the file.
            //dev.off()
            var numVer = engine.CreateNumericVector(new double[] { 11, 30, 39, 20 });

            var charVer = engine.CreateCharacterVector(new string[] { "70后", "80后", "90后", "00后" });

            var mainChar = engine.CreateCharacter("出生年龄段 - 饼状图");

            engine.SetSymbol("H", numVer);

            engine.Evaluate("png(file = 'barchart.jpg')");
            engine.Evaluate("barplot(H)");
            engine.Evaluate("dev.off()");

        }

        public static void barchart_months_revenue(this REngine engine)
        {
            //# Create the data for the chart.
            //            H < -c(7, 12, 28, 3, 41)
            //M < -c("一月", "二月", "三月", "四月", "五月")

            //# Give the chart file a name.
            //png(file = "barchart_months_revenue.png")

            //# Plot the bar chart.
            //barplot(H, names.arg = M, xlab = "月份", ylab = "收入量", col = "blue",
            //main = "收入图表", border = "red")

            //# Save the file.
            //dev.off()
            var numVer = engine.CreateNumericVector(new double[] { 110, 300, 390, 200 });

            var charVer = engine.CreateCharacterVector(new string[] { "一月", "二月", "三用", "四月" });

            var mainChar = engine.CreateCharacter("收入图表");

            engine.SetSymbol("H", numVer);

            engine.SetSymbol("M", charVer);

            engine.SetSymbol("name", mainChar);

            engine.Evaluate("png(file = 'barchart_months_revenue.jpg')");
            engine.Evaluate("barplot(H,names.arg=M,xlab='月份',ylab='收入量',col='blue',main=name,border='red')");
            engine.Evaluate("dev.off()");

        }

        public static void Barchart_stacked(this REngine engine)
        {
            //setwd("F:/worksp/R")
            //# Create the input vectors.
            //colors < -c("green", "orange", "brown")
            //months < -c("一月", "二月", "三月", "四月", "五月")
            //regions < -c("东部地区", "西部地区", "南部地区")

            //# Create the matrix of the values.
            //Values < -matrix(c(2, 9, 3, 11, 9, 4, 8, 7, 3, 12, 5, 2, 8, 10, 11), nrow = 3, ncol = 5, byrow = TRUE)

            //# Give the chart file a name.
            //png(file = "barchart_stacked.png")

            //# Create the bar chart.
            //barplot(Values, main = "总收入", names.arg = months, xlab = "月份", ylab = "收入",
            //   col = colors)

            //# Add the legend to the chart.
            //legend("topleft", regions, cex = 1.3, fill = colors)

            //# Save the file.
            //dev.off()
            //var numVer = engine.CreateNumericVector(new double[] { 110, 300, 390, 200 });

            var colors = engine.CreateCharacterVector(new string[] { "green", "orange", "brown" });
            engine.SetSymbol("colors", colors);
            var regions = engine.CreateCharacterVector(new string[] { "东", "西", "南" });
            engine.SetSymbol("regions", regions);
            var months = engine.CreateCharacterVector(new string[] { "一月", "二月", "三用", "四月" });
            engine.SetSymbol("months", months);
            var va = engine.CreateNumericVector(new double[] { 2, 9, 3, 11, 9, 4, 8, 7, 3, 12, 5, 2, 8, 10, 11 });
            engine.SetSymbol("mat", va);
            var values = engine.Evaluate("matrix(mat,nrow=3,ncol=4)");
            engine.SetSymbol("values", values);
            engine.Evaluate("png(file = 'barchart_stacked.jpg')");
            engine.Evaluate("barplot(values,names.arg=months,xlab='月份',ylab='收入',main='总收入',col=colors)");
            engine.Evaluate("legend('topleft',regions,cex=1.3,fill=colors)");
            engine.Evaluate("dev.off()");
        }

    }
}
