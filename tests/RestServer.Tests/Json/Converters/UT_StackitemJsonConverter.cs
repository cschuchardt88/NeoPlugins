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
using Neo.VM;
using Newtonsoft.Json;
using Array = Neo.VM.Types.Array;
using Buffer = Neo.VM.Types.Buffer;
using Map = Neo.VM.Types.Map;
using Pointer = Neo.VM.Types.Pointer;
using StackItem = Neo.VM.Types.StackItem;
using Struct = Neo.VM.Types.Struct;

namespace RestServer.Tests.Json.Converters
{
    public class UT_StackitemJsonConverter
    {
        private readonly JsonSerializerSettings jsonSettings;

        public UT_StackitemJsonConverter()
        {
            jsonSettings = RestServerSettings.Default.JsonSerializerSettings;
        }

        [Fact]
        public void Test_StackItem_Write_And_Read_JsonConverter()
        {
            ReferenceCounter counter = new();
            Array a = new()
            {
                1,
                true,
                "Hello World",
                new byte[] { 0, 1, 2, 3, 4, },
                null,
                new Buffer(new byte[] { 5, 6, 7, 8, }),
                new Pointer(null, 99),
                new Struct(new StackItem[] { 1, true, null, new byte[] { 9, 10, } }),
                new Map(counter)
                {
                    ["Hi"] = "developers",
                    [1] = 2,
                    [new byte[] { 11, 12, }] = new byte[] { 13, 14, },
                    [3] = null,
                    [true] = false
                }
            };

            var json = JsonConvert.SerializeObject(a, jsonSettings);
            var siObject = JsonConvert.DeserializeObject<StackItem>(json, jsonSettings);
            var json2 = JsonConvert.SerializeObject(siObject, jsonSettings);

            Assert.NotNull(json);
            Assert.NotEmpty(json);
            Assert.Equal("{\"type\":\"Array\",\"value\":[{\"type\":\"Integer\",\"value\":1},{\"type\":\"Boolean\",\"value\":true},{\"type\":\"ByteString\",\"value\":\"SGVsbG8gV29ybGQ=\"},{\"type\":\"ByteString\",\"value\":\"AAECAwQ=\"},{\"type\":\"Any\",\"value\":null},{\"type\":\"Buffer\",\"value\":\"BQYHCA==\"},{\"type\":\"Pointer\",\"value\":99},{\"type\":\"Struct\",\"value\":[{\"type\":\"Integer\",\"value\":1},{\"type\":\"Boolean\",\"value\":true},{\"type\":\"Any\",\"value\":null},{\"type\":\"ByteString\",\"value\":\"CQo=\"}]},{\"type\":\"Map\",\"value\":[{\"key\":{\"type\":\"ByteString\",\"value\":\"SGk=\"},\"value\":{\"type\":\"ByteString\",\"value\":\"ZGV2ZWxvcGVycw==\"}},{\"key\":{\"type\":\"Integer\",\"value\":1},\"value\":{\"type\":\"Integer\",\"value\":2}},{\"key\":{\"type\":\"ByteString\",\"value\":\"Cww=\"},\"value\":{\"type\":\"ByteString\",\"value\":\"DQ4=\"}},{\"key\":{\"type\":\"Integer\",\"value\":3},\"value\":{\"type\":\"Any\",\"value\":null}},{\"key\":{\"type\":\"Boolean\",\"value\":true},\"value\":{\"type\":\"Boolean\",\"value\":false}}]}]}", json);
            Assert.Equal(json, json2);
        }
    }
}
