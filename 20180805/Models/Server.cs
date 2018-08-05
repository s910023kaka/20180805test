using System;
using System.Collections.Generic;

namespace Application.Models
{
    public class Server
    {
        public int ServerID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Owner { get; set; }

        public ICollection<AppProfile> AppProfiles { get; set; }
    }
}