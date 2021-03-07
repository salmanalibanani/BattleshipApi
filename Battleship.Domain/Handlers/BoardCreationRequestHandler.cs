using Battleship.Domain.Data;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Domain.Handlers
{
    public class BoardCreationRequest : IRequest<Board>
    {
       public int Width { get; set; }
       public int Height { get; set; }
    }

    public class BoardCreationRequestHandler : IRequestHandler<BoardCreationRequest, Board>
    {
        public Task<Board> Handle(BoardCreationRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Board(request.Width, request.Width));
        }
    }
}
