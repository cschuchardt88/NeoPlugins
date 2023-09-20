// Copyright (C) 2015-2023 neo-restful-plugin.
//
// The RestServer.Tests is free software distributed under the MIT software
// license, see the accompanying file LICENSE in the main directory of
// the project or http://www.opensource.org/licenses/mit-license.php
// for more details.
//
// Redistribution and use in source and binary forms with or without
// modifications are permitted.

using Neo;
using Neo.Plugins.RestServer;
using Newtonsoft.Json;
using System.Numerics;

namespace RestServer.Tests.Json.Converters
{
    public class UT_BigDecimalJsonConverter
    {
        private readonly JsonSerializerSettings jsonSettings;

        public UT_BigDecimalJsonConverter()
        {
            jsonSettings = RestServerSettings.Default.JsonSerializerSettings;
        }

        [Fact]
        public void Test_BigDecimal_Write_And_Read_JsonConverter()
        {
            BigDecimal bd = new((BigInteger)0_10000000, 8);

            var json = JsonConvert.SerializeObject(bd, jsonSettings);
            var bgObject = JsonConvert.DeserializeObject<BigDecimal>(json, jsonSettings);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
            Assert.Equal("{\"value\":10000000,\"decimals\":8}", json);
            Assert.Equal(bd, bgObject);
        }
    }
}
