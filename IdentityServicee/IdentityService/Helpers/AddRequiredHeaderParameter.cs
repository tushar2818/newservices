﻿using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace IdentityService
{
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        void IOperationFilter.Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new HeaderParameter() { Name = "ApplicationId", In = "header", Required = false, Type = "string", Description = "Web Application Id" });
            operation.Parameters.Add(new HeaderParameter() { Name = "ApplicationToken", In = "header", Required = false, Type = "string", Description = "Web Application Token" });
            operation.Parameters.Add(new HeaderParameter() { Name = "UserID", In = "header", Required = false, Type = "string", Description = "User ID" });
        }
    }
}
