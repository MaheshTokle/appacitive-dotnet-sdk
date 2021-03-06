﻿using Appacitive.Sdk.Realtime;
using Appacitive.Sdk.Internal;
using Appacitive.Sdk.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appacitive.Sdk.Tests
{
    [TestClass]
    public class SerializationFixture
    {
        [TestMethod]
        public void ArticleSerializerSelectionTest()
        {
            ArticleConverter converter = new ArticleConverter();
            Assert.IsTrue( converter.CanConvert(typeof(Article)));
            Assert.IsTrue( converter.CanConvert(typeof(ObjectArticle)));
        }

        [TestMethod]
        public void SerializeRealTimeMessageTest()
        {
            var serializer = ObjectFactory.Build<IJsonSerializer>();
            var msg1 = new ObjectUpdatedMessage
            {
                ObjectId = "123",
                ObjectType = "type",
                EventType = EventType.ArticleCreate
            };
            var msg2 = new TypeUpdatedMessage
            {
                ObjectId = "123",
                ObjectType = "type",
                EventType = EventType.ArticleCreate
            };
            var msg3 = new NewNotificationMessage
            {
                Sender = "123",
                Payload = new JsonObject( new { a = "valuea", b = "valueb" } )
            };
            
            Console.WriteLine(Encoding.UTF8.GetString(serializer.Serialize(msg1)));
            Console.WriteLine(Encoding.UTF8.GetString(serializer.Serialize(msg2)));
            Console.WriteLine(Encoding.UTF8.GetString(serializer.Serialize(msg3)));

            var msg4 = serializer.Deserialize<NewNotificationMessage>(serializer.Serialize(msg3));

        }
    }

    public class ObjectArticle : Article
    {
        public ObjectArticle() : base("object")
        {
        }
    }
}
