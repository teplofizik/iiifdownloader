using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Metadata
    {
        [JsonProperty("label")]
        public string Label;
        
        [JsonProperty("value")]
        public string Value;
    }
}
