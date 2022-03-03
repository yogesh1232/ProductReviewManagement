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
            ProductManagementData();
            //DisplayProducts.CreateDataTable();
            Console.ReadLine();
        }
        public static void ProductManagementData()
        {
            ProductManagement p = new ProductManagement();
            var product = p.AddMultipleProductReviewInList();
            //p.IterateOverProductList(product);
            //p.RetrieveTop3Records(product);
            //p.GetRecordsAsPerRatingsAndProductId(product);
            //p.GetCountOfRecordsByProductId(product);
            //p.RetrieveRecordsByProductIdAndReview(product);
            //p.SkipTop5Records(product);
            Console.WriteLine("Data table\n");
            DisplayProducts.CreateDataTable();
            DisplayProducts.GetDataFromDataTable();
            DisplayProducts.GetAllIsLikedReviews();
            DisplayProducts.AverageRatingOfEachProductId(product);
            DisplayProducts.RecordWithNiceReview(product);
            DisplayProducts.RetrieveRecordsWithUserId10(product);
        }
    }
}