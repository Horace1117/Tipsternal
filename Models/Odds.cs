using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tipsternal.Models
{   
    [Serializable]
    public class Odds:List<Object>
    {
        public string title { get; set; }
        public string bet_url { get; set; }
        public float win_rate { get; set; }
        public float draw_rate { get; set; }
        public float lose_rate { get; set; }
        public string match_date { get; set; }
    }
}