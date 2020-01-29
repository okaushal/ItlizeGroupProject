using Joole.Models;
using Joole.Repositories;

namespace JOOLE.Repository
{
    public interface ICustomerRepo : IGenericRepo<CUSTOMER>
    {

        bool checkUserExists(string uname, string pword);
    }
}