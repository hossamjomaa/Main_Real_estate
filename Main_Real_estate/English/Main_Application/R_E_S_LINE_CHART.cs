﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel;
using System.Web.Script.Serialization;
[Serializable]
public class E_R_S_LINE_CHART
{
    public E_R_S_LINE_CHART(double xval, double yvalue1, double yvalue2)
    {
        this.Xvalue = xval;
        this.YValue1 = yvalue1;
        this.YValue2 = yvalue2;
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
}