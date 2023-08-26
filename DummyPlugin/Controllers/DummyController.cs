using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo.Network.P2P.Payloads;
using Neo.Plugins.Exceptions;
using Neo.Plugins.Models;
using Neo.SmartContract.Native;
using System.Net.Mime;

namespace Neo.Plugins.DummyPlugin.Controllers
{
    [Route("/api/v1")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly NeoSystem _neosystem;

        public DummyController()
        {
            _neosystem = DummyPlugin.NeoSystem;
        }

        [HttpGet("contract/{hash:required}/sayHello", Name = "GetSayHello")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EmptyErrorModel))]
        public IActionResult GetSayHello(
            [FromRoute(Name = "hash")]
            UInt160 scripthash)
        {
            return Ok($"Hello, {scripthash}");
        }

        [HttpGet("ledger/block/{hash:required}", Name = "GetBlockByHash")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Block))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EmptyErrorModel))]
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
