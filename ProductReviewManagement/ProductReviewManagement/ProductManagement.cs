using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewManagement
{
    public class ProductManagement
    {
        //Method to Add Multiple Products in List
        public List<ProductReview> AddMultipleProductReviewInList()
        {
            List<ProductReview> products = new List<ProductReview>()
            {
                new ProductReview(){ ProductId=1,UserId=1,Review="good",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=2,UserId=2,Review="Average",Rating=2,IsLike=false },
                new ProductReview(){ ProductId=3,UserId=4,Review="bad",Rating=5,IsLike=true },
                new ProductReview(){ ProductId=4,UserId=6,Review="good",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=5,UserId=7,Review="good",Rating=1,IsLike=false },
                new ProductReview(){ ProductId=6,UserId=9,Review="bad",Rating=2,IsLike=false },
                new ProductReview(){ ProductId=7,UserId=12,Review="Average",Rating=5,IsLike=true },
                new ProductReview(){ ProductId=8,UserId=14,Review="good",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=9,UserId=16,Review="Average",Rating=1,IsLike=false },
                new ProductReview(){ ProductId=10,UserId=18,Review="bad",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=11,UserId=20,Review="Average",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=12,UserId=21,Review="good",Rating=2,IsLike=false},
                new ProductReview(){ ProductId=13,UserId=22,Review="good",Rating=3,IsLike=true },
                new ProductReview(){ ProductId=14,UserId=24,Review="Average",Rating=2,IsLike=false },
                new ProductReview(){ ProductId=15,UserId=26,Review="bad",Rating=5,IsLike=true },
                new ProductReview(){ ProductId=16,UserId=29,Review="good",Rating=5,IsLike=true },
                new ProductReview(){ ProductId=17,UserId=32,Review="Average",Rating=2,IsLike=false },
                new ProductReview(){ ProductId=18,UserId=33,Review="good",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=19,UserId=35,Review="bad",Rating=3,IsLike=false },
                new ProductReview(){ ProductId=20,UserId=38,Review="Average",Rating=3,IsLike=false },
                new ProductReview(){ ProductId=21,UserId=40,Review="bad",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=22,UserId=41,Review="Average",Rating=5,IsLike=true },
                new ProductReview(){ ProductId=23,UserId=42,Review="good",Rating=4,IsLike=true },
                new ProductReview(){ ProductId=24,UserId=43,Review="bad",Rating=1,IsLike=false },
                new ProductReview(){ ProductId=25,UserId=45,Review="bad",Rating=2,IsLike=true },
            };
            return products;
        }
        //Method to get all Product List
        public void IterateOverProductList(List<ProductReview> products)
        {
            foreach (ProductReview productReview in products)
            {
                Console.WriteLine("ProductId=" + productReview.ProductId + "\t" + "UserId:" + productReview.UserId + "\t" + "Review:" + productReview.Review + "\t" +
                                  "Rating:" + productReview.Rating + "\t" + "IsLike:" + productReview.IsLike);
            }
        }
        //Method to Retrieve Top 3 records
        public void RetrieveTop3Records(List<ProductReview> products)
        {
            try
            {
                //LINQ query
                var sortedRatings = (from product in products orderby product.Rating descending select product).ToList();
                Console.WriteLine("After Sorting list");
                IterateOverProductList(sortedRatings);
                var top3Records = sortedRatings.Take(3).ToList();
                Console.WriteLine();
                Console.WriteLine("Getting Top 3 Records");
                IterateOverProductList(top3Records);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Method to Retrieve records of products whose Rating is Greater than 3 and ProductId is 1,4 or 9
        public void GetRecordsAsPerRatingsAndProductId(List<ProductReview> list)
        {
            try
            {
                //LINQ query
                var res = list.Where(p => p.Rating > 3 && (p.ProductId == 1 || p.ProductId == 4 || p.ProductId == 9)).ToList();
                Console.WriteLine("Retrieve records of products whose Rating is Greater than 3 and ProductId is 1,4 or 9");
                IterateOverProductList(res);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Method to get count of records as per ProductId
        public void GetCountOfRecordsByProductId(List<ProductReview> list)
        {
            try
            {
                //LINQ query
                var CountsProductId = list.GroupBy(p => p.ProductId).Select(x => new { ProductId = x.Key, count = x.Count() }).ToList();
                Console.WriteLine("Count of Records as per ProductId");
                foreach (var product in CountsProductId)
                {
                    Console.WriteLine("ProductId:" + product.ProductId + "\t" + "Count:" + product.count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //Method to retrieve only productId and Review
        public void RetrieveRecordsByProductIdAndReview(List<ProductReview> list)
        {
            try
            {
                //LINQ query
                var CountsProductId = (list.Select(x => new { productId = x.ProductId, review = x.Review })).ToList();
                Console.WriteLine("Count of Records as per ProductId");
                foreach (var product in CountsProductId)
                {
                    Console.WriteLine("ProductId:" + product.productId + "\t" + "Review:" + product.review);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}