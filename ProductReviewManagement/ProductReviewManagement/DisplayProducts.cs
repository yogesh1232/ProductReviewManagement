using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class DisplayProducts
    {
        public static DataTable table = new DataTable();
        /// Creates the data table.
        public static void CreateDataTable()
        {
            //Add Columns in Table
            table.Columns.Add("ProductId");
            table.Columns.Add("UserId");
            table.Columns.Add("Rating");
            table.Columns.Add("Review");
            table.Columns.Add("IsLike");
            //Add Rows in Table
            table.Rows.Add(1, 1, 9, "bad", "false");
            table.Rows.Add(2, 7, 6, "good", "true");
            table.Rows.Add(4, 9, 5, "good", "false");
            table.Rows.Add(7, 4, 4, "nice", "true");
            table.Rows.Add(5, 7, 1, "bad", "false");
            table.Rows.Add(7, 12, 5, "nice", "true");
            table.Rows.Add(3, 5, 8, "good", "false");
            table.Rows.Add(3, 14, 4, "bad", "false");
            table.Rows.Add(9, 10, 1, "bad", "true");
            table.Rows.Add(9, 11, 3, "bad", "false");
            table.Rows.Add(3, 10, 10, "good", "false");
            table.Rows.Add(2, 9, 9, "good", "true");
        }
        /// Gets the data from data table.
        public static void GetDataFromDataTable()
        {
            try
            {
                //Query syntax of LINQ
                var ProductNames = from product in table.AsEnumerable() select product;
                //iterate loop to get ProductName.
                foreach (var data in ProductNames)
                {
                    Console.WriteLine("ProductID: " + data.Field<string>("ProductId") + ", UserID: " + data.Field<string>("UserId") + ", Ratings: " + data.Field<string>("Rating") + " , Review: " + data.Field<string>("Review") + " , IsLike: " + data.Field<string>("IsLike"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public static void GetAllIsLikedReviews()
        {
            var Table = from product in table.AsEnumerable()
                        where (string)product["IsLike"] == "true"
                        select product;

            Console.WriteLine("\n");
            foreach (var list in Table)
            {
                Console.WriteLine("ProductID: " + list.Field<string>("ProductId") + ", UserID: " + list.Field<string>("UserId") + ", Rating: " + list.Field<string>("Rating") + " , Review: " + list.Field<string>("Review") + " , IsLike: " + list.Field<string>("IsLike"));
            }
        }

        //get average rating of each product ID
        public static void AverageRatingOfEachProductId(List<ProductReview> ProductReview)
        {
            var data = from productReviews in ProductReview
                       group productReviews by productReviews.ProductId into g
                       select new
                       {
                           ProductID = g.Key,
                           AverageRating = g.Average(x => x.Rating)
                       };
            Console.WriteLine("\n");
            Console.WriteLine("\nProductID with AverageRating");
            foreach (var a in data)
            {
                Console.WriteLine(a.ProductID + " ----------- " + a.AverageRating);
            }
        }
        //Method tp get all records with nice review
        public static void RecordWithNiceReview(List<ProductReview> ProductReview)
        {
            var data = from productReviews in ProductReview
                       where (productReviews.Review == "nice")
                       select productReviews;
            Console.WriteLine("\n");
            foreach (var list in data)
            {
                Console.WriteLine("ProductID: " + list.ProductId + " UserID: " + list.UserId + " Rating: " + list.Rating + " Review: " + list.Review + " isLike: " + list.IsLike);
            }
        }
    }
}