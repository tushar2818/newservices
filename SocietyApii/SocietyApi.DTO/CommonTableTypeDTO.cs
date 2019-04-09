using System; 

namespace SocietyApi.DTO
{
    public class CommonTableTypeDTO : BaseModelDTO
    {
        //Building, Client, Company, Flat, Gate,Person, Project, Wing, Complaint

        public Int64 CommonTableTypeID { get; set; } 
        public string CommonTableTypeKey { get; set; } 
        public string CommonTableTypeValue { get; set; } 
    }
}
