using System.Text.Json.Serialization;

namespace CustomWindow
{
    internal class SoftwareConfigEntity
    {
        [JsonPropertyName("x")]
        public int X {  get; set; }

        [JsonPropertyName("y")]
        public int Y { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("fileName")]
        public string FileName { get; set; }

        [JsonPropertyName("modifyWidth")]
        public int ModifyWidth { get; set; }

        [JsonPropertyName("modifyHeight")]
        public int ModifyHeight { get; set; }

        [JsonPropertyName("useAPI")]
        public int UseAPI { get; set; } = 0;


        [JsonPropertyName("withStartModify")]
        public bool WithStartModify { get; set; }

        [JsonPropertyName("autoExit")]
        public bool AutoExit { get; set; }

        [JsonPropertyName("centerScreen")]
        public bool CenterScreen { get; set; }
    }
}
