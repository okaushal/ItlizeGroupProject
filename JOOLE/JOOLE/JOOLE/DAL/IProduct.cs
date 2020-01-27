namespace JOOLE.DAL
{
    public interface IProduct
    {
        int manufacturerID { get; set; }
        string model { get; set; }
        string modelInformation { get; set; }
        int modelYear { get; set; }
        decimal price { get; set; }
        int productID { get; }
        string productImage { get; set; }
        string productName { get; set; }
        string series { get; set; }
        int subCategoryID { get; set; }
        int supplierID { get; set; }
        string techSpecs { get; set; }

        string getDifference(Product A, Product B);

    }
}