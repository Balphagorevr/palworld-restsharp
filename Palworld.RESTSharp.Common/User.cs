using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Palworld.RESTSharp.Common
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public bool Enabled { get; set; }
        public string[] Roles { get; set; }
    }
}
