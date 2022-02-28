using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management program");
            //ProductManagementData();
            DisplayProducts.CreateDataTable();
            Console.ReadLine();
        }
        public static void ProductManagementData()
        {
            ProductManagement.AddMultipleProductReviewInList();
        }
    }
}
