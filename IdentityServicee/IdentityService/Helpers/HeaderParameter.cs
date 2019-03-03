using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
namespace IdentityService
{
    public class HeaderParameter : IParameter
    {
        public string Type { get; set; }
        public string Description { get; set; }
        public Dictionary<string, object> Extensions { get { return new Dictionary<string, object> { { "test", true } }; } }
        public string In { get; set; }
        public string Name { get; set; }
        public bool Required { get; set; }
    }
}
