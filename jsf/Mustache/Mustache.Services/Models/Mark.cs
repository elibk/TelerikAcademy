using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mustache.Services.Models
{
   public class Mark
    {
       [JsonProperty("subject")]
       [JsonConverter(typeof(StringEnumConverter))]
       public SubjectName Subject { get; set; }

       [JsonProperty("score")]
       public int Score { get; set; }
    }
}
