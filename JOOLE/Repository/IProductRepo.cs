using JOOLE.DAL;
using JOOLE.Models;

namespace JOOLE.Repository
{
    public interface IProductRepo:IGenericRepo<Product>
    {
        JooleEntity context { get; set; }
    }
}