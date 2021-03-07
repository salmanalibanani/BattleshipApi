using Battleship.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Domain.Handlers
{
    public class AttackRequest : IRequest<bool>
    {
        public Guid BoardId { get; set; }
        public Board Board { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class AttackRequestHandler : IRequestHandler<AttackRequest, bool>
    {
        public async Task<bool> Handle(AttackRequest request, CancellationToken cancellationToken)
        {
            return request.Board.AttackCell(request.X, request.Y);
        }
    }
}
