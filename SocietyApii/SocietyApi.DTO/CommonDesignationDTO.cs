using System; 

namespace SocietyApi.DTO
{
    public class CommonDesignationDTO: BaseModelDTO
    {
        //Building Designation, Client Designation, Company Designation, 
        //Flat Designation, Gate Designation, Project Designation, Wing Designation,
        public Int64 CommonDesignationID { get; set; }

        public Int64 CommonTableTypeID { get; set; }
        public CommonTableTypeDTO CommonTableType { get; set; }

        public Int64 SourceID { get; set; }

        public Int64 PersonID { get; set; }
        public PersonMasterDTO PersonMaster { get; set; }

        public Int64 DesignationMasterID { get; set; }
        public DesignationMasterDTO DesignationMaster { get; set; }

        public Int64 FromDate { get; set; }
        public Int64 ToDate { get; set; }
    }
}
