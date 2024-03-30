using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using System.Web.Script.Serialization;
[Serializable]
public class LineChartData
{
    private int v1;
    private double destruction_2018;
    private int v2;

    public LineChartData(int v1, double destruction_2018, int v2)
    {
        this.v1 = v1;
        this.destruction_2018 = destruction_2018;
        this.v2 = v2;
    }

    public LineChartData(double xval, double yvalue1, double yvalue2, double yvalue3)
    {
        this.Xvalue = xval;
        this.YValue1 = yvalue1;
        this.YValue2 = yvalue2;
        this.YValue3 = yvalue3;
    }
    public double Xvalue
    {
        get;
        set;
    }
    public double YValue1
    {
        get;
        set;
    }
    public double YValue2
    {
        get;
        set;
    }
    public double YValue3
    {
        get;
        set;
    }
   

}