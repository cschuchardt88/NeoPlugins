using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo.Plugins.Exceptions;
using Neo.SmartContract.Native;
using System.Net.Mime;

namespace Neo.Plugins.DummyPlugin.Controllers
{
    [Route("/api/v1")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly NeoSystem _neosystem;

        public DummyController()
        {
            _neosystem = DummyPlugin.NeoSystem;
        }

        // example: http://127.0.0.1:10339/api/v1/contract/0xfffdc93764dbaddd97c48f252a53ea4643faa3fd/sayHello
        // example: http://127.0.0.1:10339/api/v1/contract/NgiALPHzer4fMTBdkMvNVwHA4ApA5dp554/sayHello
        [HttpGet("contract/{hash:required}/sayHello", Name = "GetSayHello")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetSayHello(
            [FromRoute(Name = "hash")]
            UInt160 scripthash)
        {
            return Ok($"Hello, {scripthash}");
        }

        // example: http://127.0.0.1:10339/api/v1/ledger/block/0x5ef9d3db23a0ca07ed3373bf4e87c1b849cc0c808fa41ada47c1e328b5613e96
        [HttpGet("ledger/block/{hash:required}", Name = "GetBlockByHash")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetBlockByHash(
            [FromRoute(Name = "hash")]
            UInt256 blockhash)
        {
            var block = NativeContract.Ledger.GetBlock(_neosystem.StoreView, blockhash);
            if (block == null)
                throw new CustomException("block hash is invalid.");
            return Ok(block);
        }
    }
}
