using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIIFDownloader.IIIF
{
    [Serializable]
    class Canvas
    {
        [JsonProperty("@id")]
        public string Id;

        [JsonProperty("@type")]
        public string Type;

        [JsonProperty("label")]
        public string Label;

        [JsonProperty("height")]
        public int Height;

        [JsonProperty("width")]
        public int Width;

        [JsonProperty("images")]
        public List<Image> Images = new List<Image>();

    }
}
