using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Sequence
    {
        [JsonProperty("@id")]
        public string Id;

        [JsonProperty("@type")]
        public string Type;

        [JsonProperty("canvases")]
        public List<Canvas> Canvases = new List<Canvas>();

    }
}
