using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace neihanshe
{
    public class Article
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        [JsonProperty(PropertyName ="pic_url")]
        public string PicUrl { get; set; }
        public int Up { get; set; }
        public int Dn { get; set; }
        public int Cmt { get; set; }
    }
}
