using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyApi.DTO
{
    public class ParentChildIdDTO
    {
        public Int64 ParentID { get; set; }
        public List<Int64> ChildID { get; set; }
    }
}
