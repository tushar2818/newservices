using System; 

namespace SocietyApi.DTO
{
    public class BuildingMasterDTO : BaseModelDTO
    {
        public Int64 BuildingMasterID { get; set; } 

        public Int64 ProjectMasterID { get; set; }
        public ProjectMasterDTO ProjectMaster { get; set; }

        public string BuildingName { get; set; } 
        public string BuildingDetails { get; set; }  
    } 
}
