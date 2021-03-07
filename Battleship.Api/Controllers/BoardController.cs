using Battleship.Domain.Data;
using Battleship.Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class BoardController : Controller
    {
        private readonly ISender _sender;
        private readonly IMemoryCache _memoryCache;


        public BoardController(ISender sender, IMemoryCache memoryCache)
        {
            _sender = sender;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<ActionResult<Board>> Post(BoardCreationRequest boardInfo)
        {
            var result = await _sender.Send(boardInfo);
            _memoryCache.Set(result.BoardId, result);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<Board>> Get(Guid boardId)
        {
            Board board;
            var success = _memoryCache.TryGetValue(boardId, out board);

            if (success)
                return Ok(board);
            else
                return new NotFoundResult();
        }

        [HttpPost("attack")]
        public async Task<ActionResult<Board>> Attack(AttackRequest request)
        {
            Board board;
            var success = _memoryCache.TryGetValue(request.BoardId, out board);

            if (!success)
                return new NotFoundResult();

            request.Board = board;

            var result = await _sender.Send(request);
            return Ok(result);
        }
    }
}
