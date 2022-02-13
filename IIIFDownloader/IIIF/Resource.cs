using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Resource
    {
        [JsonProperty("@id")]
        public string Id;

        [JsonProperty("@type")]
        public string Type;

        [JsonProperty("format")]
        public string Format;

        [JsonProperty("height")]
        public int Height;

        [JsonProperty("width")]
        public int Width;

        [JsonProperty("dc:identifier")]
        public string dcIdentifier;

        [JsonProperty("service")]
        public Service Service;
    }
}
