using System;

namespace SocietyApi.DTO
{
    public interface IBaseDTO
    {
        string Token { get; set; }
        Int64 ClientID { get; set; }
        Int64 CompanyID { get; set; }
        string UserID { get; set; }
        Int64 PersonID { get; set; }
        Int64 ProjectID { get; set; }

    }
}
