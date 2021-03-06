﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Appacitive.Sdk.Realtime;


namespace Appacitive.Sdk.Services
{
    public class SendPushNotificationRequest : PostOperation<SendPushNotificationResponse>
    {
        public SendPushNotificationRequest() :
            this(AppacitiveContext.ApiKey, AppacitiveContext.SessionToken, AppacitiveContext.Environment, AppacitiveContext.UserToken, AppacitiveContext.UserLocation, AppacitiveContext.EnableDebugging, AppacitiveContext.Verbosity)
        {   
        }

        public SendPushNotificationRequest(string apiKey, string sessionToken, Environment environment, string userToken = null, Geocode location = null, bool enableDebugging = false, Verbosity verbosity = Verbosity.Info) :
            base(apiKey, sessionToken, environment, userToken, location, enableDebugging, verbosity)
        {   
        }

        public PushNotification Push { get; set; }

        public override byte[] ToBytes()
        {
            var serializer = ObjectFactory.Build<IJsonSerializer>();
            return serializer.Serialize(this.Push);
        }

        protected override string GetUrl()
        {
            return Urls.For.SendPushNotification(this.CurrentLocation, this.DebugEnabled, this.Verbosity, this.Fields);
        }
    }
}
