using System;
using System.Collections;
using System.Collections.Generic;

namespace SocietyApi.DTO
{
    public class DesignationTypeMappingDTO : BaseModelDTO
    {
        public Int64 DesignationTypeMappingID { get; set; }

        public Int64 DesignationMasterID { get; set; }
        public DesignationMasterDTO DesignationMaster { get; set; }

        public Int64 DesignationTypeID { get; set; }
        public DesignationTypeDTO DesignationType { get; set; }
    } 
}
