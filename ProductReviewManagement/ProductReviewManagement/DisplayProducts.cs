﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class DisplayProducts
    {
        public static void CreateDataTable()
        {
            //create obj of DataTable Class.
            DataTable table = new DataTable();
            //Add Columns in Table
            table.Columns.Add("Id");
            table.Columns.Add("ProductName");
            //Add Rows in Table
            table.Rows.Add(1, "Laptop");
            table.Rows.Add(2, "Desktop");
            table.Rows.Add(3, "Smartphone");
            GetDataFromDataTable(table);
        }
        /// <summary>
        /// Gets the data from data table
        /// </summary>
        /// <param name="table">The table.</param>
        public static void GetDataFromDataTable(DataTable table)
        {
            try
            {
                //Query syntax of LINQ
                var ProductNames = (from product in table.AsEnumerable() select product.Field<string>("ProductName"));
                //iterate loop to get ProductName
                foreach (string p in ProductNames)
                {
                    Console.WriteLine("Product Name:" + p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}