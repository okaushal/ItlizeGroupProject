using JOOLE.DAL;
using JOOLE.Models;

namespace JOOLE.Repository
{
    public interface IProductRepo:IGenericRepo<Product>
    {
      

        string getDifference(Product A, Product B);

    }
}