using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Manifest
    {
        [JsonProperty("@context")]
        public string Content;

        [JsonProperty("@id")]
        public string Id;

        [JsonProperty("metadata")]
        public List<Metadata> Metadata = new List<Metadata>();

        [JsonProperty("label")]
        public string Label;

        [JsonProperty("attribution")]
        public string Attribution;

        [JsonProperty("license")]
        public string License;

        [JsonProperty("viewingDirection")]
        public string ViewingDirection;

        [JsonProperty("viewingHint")]
        public string ViewingHint;

        public List<Sequence> Sequences = new List<Sequence>();
    }
}
