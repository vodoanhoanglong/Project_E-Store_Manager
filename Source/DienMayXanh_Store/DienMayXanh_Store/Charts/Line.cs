﻿using Guna.Charts.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienMayXanh_Store.Charts
{
    class Line
    {
        public static void loadChart(Guna.Charts.WinForms.GunaChart chart, List<decimal> revenue)
        {
            List<string> date = new List<string>();
            int index = 30;
            while (index >= 0)
                date.Add(DateTime.Today.AddDays(-index--).Date.ToString("dd/MM"));

            //Chart configuration 
            chart.YAxes.GridLines.Display = false;

            //Create a new dataset 
            var datasetRevenue = new GunaLineDataset();
            datasetRevenue.PointRadius = 3;
            datasetRevenue.FillColor = Color.Red;
            datasetRevenue.BorderColor = Color.Red;
            datasetRevenue.Label = "Tổng thu";
            datasetRevenue.PointStyle = PointStyle.Circle;
            var r = new Random();
            for (int i = 0; i < date.Count; i++)
            {
                //random number
                int num = r.Next(10, 1000);

                datasetRevenue.DataPoints.Add(date[i], (double)revenue[i]);
            }

          
            //Add a new dataset to a chart.Datasets
            chart.Datasets.Add(datasetRevenue);

            //An update was made to re-render the chart
            chart.Update();
        }
    }
}
