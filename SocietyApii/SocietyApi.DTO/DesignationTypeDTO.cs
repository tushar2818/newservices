using System; 

namespace SocietyApi.DTO
{
    public class DesignationTypeDTO : BaseModelDTO
    {
        public Int64 DesignationTypeID { get; set; } 
        public string DesignationTypeKey { get; set; } 
        public string DesignationTypeValue { get; set; }  
    }
}
