// Copyright (C) 2015-2023 neo-restful-plugin.
//
// The RestServer.Tests is free software distributed under the MIT software
// license, see the accompanying file LICENSE in the main directory of
// the project or http://www.opensource.org/licenses/mit-license.php
// for more details.
//
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

using Neo.Plugins.RestServer;
using Newtonsoft.Json;

namespace RestServer.Tests.Json.Converters
{
    public class UT_GuidJsonConverter
    {
        private readonly JsonSerializerSettings jsonSettings;

        public UT_GuidJsonConverter()
        {
            jsonSettings = RestServerSettings.Default.JsonSerializerSettings;
        }

        [Fact]
        public void Test_Guid_Write_And_Read_JsonConverter()
        {
            Guid g1 = Guid.Parse("{402E5A50-A527-4F45-A7D1-DF0363509B33}");

            string json = JsonConvert.SerializeObject(g1, jsonSettings);
            var g2 = JsonConvert.DeserializeObject<Guid>(json, jsonSettings);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
            Assert.Equal("\"402e5a50a5274f45a7d1df0363509b33\"", json);
            Assert.NotEqual(g1, Guid.Empty);
            Assert.NotEqual(g2, Guid.Empty);
            Assert.Equal(g1, g2);
        }
    }
}
