﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Appacitive.Sdk.Realtime;

namespace Appacitive.Sdk.Services
{
    public class FindAllConnectionsResponse : ApiResponse
    {
        [JsonProperty("connections")]
        public List<Connection> Connections { get; set; }

        [JsonProperty("paginginfo")]
        public PagingInfo PagingInfo { get; set; }
    }

    
}
