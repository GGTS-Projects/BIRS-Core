using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BIRS_api.Models
{
    public static class BlockExtension
    {
        public static string toJson(this Block block)
        {
            return JsonConvert.SerializeObject(block);
        }
    }
}
