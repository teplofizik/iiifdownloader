using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Service
    {
        [JsonProperty("@context")]
        public string Context;

        [JsonProperty("@id")]
        public string Id;

        [JsonProperty("profile")]
        public string Profile;
    }
}
