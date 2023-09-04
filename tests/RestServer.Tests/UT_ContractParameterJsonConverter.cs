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
using Neo.SmartContract;
using Newtonsoft.Json;

namespace RestServer.Tests
{
    public class UT_ContractParameterJsonConverter
    {
        [Fact]
        public void Test_ContractParameter_Write_JsonConverter()
        {
            ContractParameter cp = new()
            {
                Type = ContractParameterType.Hash160,
                Value = UInt160.Zero,
            };

            var json = JsonConvert.SerializeObject(cp, RestServerSettings.Default.JsonSerializerSettings);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
            Assert.Equal("{\"type\":\"Hash160\",\"value\":\"0x0000000000000000000000000000000000000000\"}", json);
        }
    }
}
