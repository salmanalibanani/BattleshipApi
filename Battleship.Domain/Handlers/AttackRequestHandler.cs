using Battleship.Domain.Data;
using MediatR;
using System.Text.Json.Serialization;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Domain.Handlers
{
    public class AttackRequest : IRequest<bool>
    {
        public Guid BoardId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        [JsonIgnore]
        public Board Board { get; set; }
    }
    public class AttackRequestHandler : IRequestHandler<AttackRequest, bool>
    {
        public Task<bool> Handle(AttackRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(request.Board.AttackCell(request.X, request.Y));
        }
    }
}
