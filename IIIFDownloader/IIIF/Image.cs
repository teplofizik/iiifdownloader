using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Image
    {
        [JsonProperty("@id")]
        public string Id;

        [JsonProperty("@type")]
        public string Type;

        [JsonProperty("motivation")]
        public string Motivation;

        [JsonProperty("on")]
        public string On;

        [JsonProperty("resource")]
        public Resource Resource;
    }
}
