using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Neo.Network.P2P.Payloads;
using Neo.Plugins.Exceptions;
using Neo.Plugins.Models;
using Neo.SmartContract.Native;
using System.Net.Mime;

namespace Neo.Plugins.DummyPlugin.Controllers
{
    [Route("/api/v1")] // <-- Route/Directory URL (cna be new or add to existing)
    [Produces(MediaTypeNames.Application.Json)] // <-- must have set to application/json. if you for get its not the end of the world.
    [Consumes(MediaTypeNames.Application.Json)] // <-- must have set to application/json. if you for get its not the end of the world.
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(EmptyErrorModel))] // <-- Must put this on each controller you have. So Swagger knows the default error type model.
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private readonly NeoSystem _neosystem;

        public DummyController()
        {
            _neosystem = DummyPlugin.NeoSystem;
        }

        /// <summary>
        /// Say Hello <!-- This is what the use see's in Swagger or Open API Clients-->
        /// </summary>
        /// <param name="scripthash" example="0xed7cc6f5f2dd842d384f254bc0c2d58fb69a4761">ScriptHash</param>
        /// <returns>string</returns>
        /// <response code="200">Successful</response>
        /// <response code="400">An error occurred. See Response for details.</response> <!--This line is key to what the users see's as an error message dont change it-->
        [HttpGet("contract/{hash:required}/sayHello", Name = "GetSayHello")] // <-- Name is the name of the method for Swagger or Open API client to generate. Note that path parameters are the same name for Swagger methods.
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))] // <-- Must put this on each controller method you have. So Swagger knows the default return type model.
        public IActionResult GetSayHello( // <-- You dont have to use IActionResult you can just return the type you would like. I like doing it this way so I am able to throw other responses.
            [FromRoute(Name = "hash")]
            UInt160 scripthash)
        {
            return Ok($"Hello, {scripthash}"); 
        }

        /// <summary>
        /// Get block by block hash <!-- This is what the use see's in Swagger or Open API Clients-->
        /// </summary>
        /// <param name="blockhash" example="0xad83d993ca2d9783ca86a000b39920c20508c8ccae7b7db11806646a4832bc50">Hash256</param>
        /// <returns>Block Object</returns>
        /// <response code="200">Successful</response>
        /// <response code="400">An error occurred. See Response for details.</response> <!--This line is key to what the users see's as an error message dont change it-->
        [HttpGet("ledger/block/{hash:required}", Name = "GetBlockByHash")] // <-- Name is the name of the method for Swagger or Open API client to generate. Note that path parameters are the same name for Swagger methods.
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Block))] // <-- Must put this on each controller method you have. So Swagger knows the default return type model.
        public IActionResult GetBlockByHash( // <-- You dont have to use IActionResult you can just return the type you would like. I like doing it this way so I am able to throw other responses.
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
