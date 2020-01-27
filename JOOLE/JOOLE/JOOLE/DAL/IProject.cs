namespace JOOLE.DAL
{
    public interface IProject
    {
        int customerID { get; set; }
        string location { get; set; }
        int projectID { get; }
        string projectName { get; set; }
    }
}