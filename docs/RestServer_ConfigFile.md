### Default "Config.json" file
```json
{
  "PluginConfiguration": {
    "Network": 860833102,
    "BindAddress": "127.0.0.1",
    "Port": 10339,
    "KeepAliveTimeout": 2,
    "SslCertFile": "",
    "SslCertPassword": "",
    "TrustedAuthorities": [],
    "EnableBasicAuthentication": false,
    "RestUser": "",
    "RestPass": "",
    "EnableCors": false,
    "AllowOrigins": [],
    "DisableControllers": [ "WalletController" ],
    "EnableCompression": false,
    "CompressionLevel": "SmallestSize",
    "EnableForwardedHeaders": false,
    "EnableSwagger": false,
    "MaxPageSize": 50,
    "MaxConcurrentConnections": 40,
    "MaxTransactionFee": 10000000,
    "MaxInvokeGas": 20000000,
    "WalletTimeout": 2
  }
}
```

| Name | Type | Description |
|-----|-------|----------|
|**Network**|_uint32_|_The network you would like the rest server to be enabled on._|
|**BindAddress**|_string_|_The Ip address of the interface you want to bind too._|
|**Port**|_uint32_|_Port number to bind too._|
|**KeepAliveTimeout**|_uint32_|_The time to keep the request alive._|
|**SslCertFile**|_string_|_is the path and file name of a certificate file, relative to the directory that contains the node's executable files._|
|**SslCertPassword**|_string_|_is the password required to access the X.509 certificate data._|
|**TrustedAuthorities**|_StringArray_|_Tumbprints of the of the last certificate authority in the chain._|
|**EnableBasicAuthentication**|_boolean_|_enables basic authentication._|
|**RestUser**|_string_|_Basic authentication's username._|
|**RestPass**|_string_|_Basic authentication's password._|
|**EnableCors**|_boolean_|_Enables Cross-origin resource sharing (CORS). Note by default it enables any origin._|
|**AllowOrigins**|_StringArray_|_A list of the origins to allow. Note needs to add origins for basic auth to work with CORS._|
|**DisableControllers**|_StringArray_|_A list of controllers to be disabled. Requires restart of the node, if changed._|
|**EnableCompression**|_boolean_|_Enables response GZip data compression._|
|**CompressionLevel**|_enum_|_Type of compression level. Values can be "Fastest" or "Optimal" or "NoCompression" or "SmallestSize"_|
|**EnableForwardedHeaders**|_boolean_|_Enables response/request headers for proxy forwarding._|
|**EnableSwagger**|_boolean_|_Enables Swagger with Swagger UI for the rest services._|
|**MaxPageSize**|_uint32_|_Max page size for searches on Ledger/Contract routes._|
|**MaxConcurrentConnections**|_long64_|_Max allow concurrent HTTP connections._|
|**MaxTransactionFee**|_long64_|_Max transaction fee for wallet transfers._|
|**MaxInvokeGas**|_long64_|_Max gas to be invoked on the VM._|
|**WalletTimeout**|_int32_|_When wallet session expires. Note in minutes._|