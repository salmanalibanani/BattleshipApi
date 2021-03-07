using Battleship.Domain.Data;
using Battleship.Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Battleship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipController : Controller
    {
        private readonly ISender _sender;
        private readonly IMemoryCache _memoryCache;

        public ShipController(ISender sender, IMemoryCache memoryCache)
        {
            _sender = sender;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<ActionResult<Board>> Post(AddShipRequest request)
        {
            Board board;
            var success = _memoryCache.TryGetValue(request.BoardId, out board);

            if (!success)
                return new NotFoundResult();

            request.Board = board;

            var result = await _sender.Send(request);

            if (result)
                return Ok(board);
            else
                return new BadRequestResult();

        }
    }
}
