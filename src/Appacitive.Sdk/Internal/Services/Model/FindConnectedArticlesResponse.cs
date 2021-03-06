﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Appacitive.Sdk.Realtime;

namespace Appacitive.Sdk.Services
{
    public class FindConnectedArticlesResponse : ApiResponse
    {
        [JsonProperty("paginginfo")]
        public PagingInfo PagingInfo { get; set; }

        [JsonProperty("connections")]
        public List<Connection> Connections { get; set; }
    }
}
