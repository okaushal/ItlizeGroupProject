using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JOOLE.DAL
{
    public class Product : IProduct
    {
        public Product(string productName, string productImage, decimal price, string model, string series, int modelYear, string modelInformation, string techSpecs)
        {

            this.productName = productName;
            this.productImage = productImage;
            this.price = price;
            this.model = model;
            this.series = series;
            this.modelYear = modelYear;
            this.modelInformation = modelInformation;
            this.techSpecs = techSpecs;
        }

        public int productID { get; private set; }
        public int subCategoryID { get; set; }
        public int supplierID { get; set; }
        public int manufacturerID { get; set; }
        public string productName { get; set; }
        public string productImage { get; set; }
        public decimal price { get; set; }
        public string model { get; set; }
        public string series { get; set; }
        public int modelYear { get; set; }
        public string modelInformation { get; set; }
        public string techSpecs { get; set; }


        public string getDifference(Product A, Product B)
        {
            if (A.Equals(B))
            {
                return "No Difference";
            }
            else
            {
                return "Difference";
            }
           
        }

       
    }

}