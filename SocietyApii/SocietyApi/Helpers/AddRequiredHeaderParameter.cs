using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace SocietyApi
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        void IOperationFilter.Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter() { Name = "Token", In = "header", Required = true, Type = "string", Description = "Application Token" });
            operation.Parameters.Add(new HeaderParameter() { Name = "ClientID", In = "header", Required = false, Type = "string", Description = "Client ID" });
            operation.Parameters.Add(new HeaderParameter() { Name = "CompanyID", In = "header", Required = false, Type = "string", Description = "Company ID" });
            operation.Parameters.Add(new HeaderParameter() { Name = "UserID", In = "header", Required = false, Type = "string", Description = "User ID" });
            operation.Parameters.Add(new HeaderParameter() { Name = "PersonID", In = "header", Required = false, Type = "string", Description = "Person ID" });
            operation.Parameters.Add(new HeaderParameter() { Name = "ProjectID", In = "header", Required = false, Type = "string", Description = "Project ID" });
        }
    }
}
