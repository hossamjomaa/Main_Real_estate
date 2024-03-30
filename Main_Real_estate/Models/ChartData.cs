using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Main_Real_estate.Models
{
    public class ChartData
    {
        //public ChartData(double xval, Double yvalue)
        //{
        //    this.Xvalue = xval;
        //    this.YValue1 = yvalue;

        //}
        //public double Xvalue
        //{
        //    get;
        //    set;
        //}
        //public Double YValue1
        //{
        //    get;
        //    set;
        //}

        public ChartData(string xval, Double yvalue)
        {
            this.Xvalue = xval;
            this.YValue1 = yvalue;

        }
        public string Xvalue
        {
            get;
            set;
        }
        public Double YValue1
        {
            get;
            set;
        }

    }
}