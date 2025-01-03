﻿using Google.FlatBuffers;
using Microsoft.AspNetCore.Mvc;
using NetGame;
using WebPacketLib;

namespace GameServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool Post([FromBody] MyWebRequest request)
        {
            try
            {
                if (request.Data == null)
                    return false;

                ByteBuffer bb = new ByteBuffer(request.Data);
                var obj = Test.GetRootAsTest(bb);

                Console.WriteLine($"Login Post Message : {obj.A}, {obj.B}, {obj.C}");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"{HttpContext.Request.Path} Exception: {e.Message}");
                return false;
            }
        }
    }
}
