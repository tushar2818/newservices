using System;
using System.Collections.Generic;
using System.Text;

namespace SocietyApi.DTO
{
    public class LookupDetailDTO
    {
        public string LookupType { get; set; }
        public dynamic Data { get; set; }
        public List<LookupParameterDTO> Parameters { get; set; }
        public bool IsSuccess { get; set; }
        public List<ErrorMessageDTO> ErrorMessages { get; set; }
    }

    public class LookupParameterDTO
    {
        public string Key { get; set; }
        public string Value { get; set; }
    } 
}
