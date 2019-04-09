using System; 

namespace SocietyApi.DTO
{
    public class DesignationMasterDTO : BaseModelDTO
    {
        public Int64 DesignationMasterID { get; set; }
        public string DesignationKey { get; set; }
        public string DesignationValue { get; set; }
        public string DesignationHin { get; set; }
        public string DesignationMar { get; set; }
        public string DesignationDetails { get; set; }
    }
}
