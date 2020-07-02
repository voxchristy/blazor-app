using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDapperCRUD.Data
{
    public class Video
    {
        public int VIDEO_ID { get; set; }
        public string TITLE { get; set; }
        public DateTime DATE_PUBLISHED { get; set; }
        public bool IS_ACTIVE { get; set; }
    }
}
