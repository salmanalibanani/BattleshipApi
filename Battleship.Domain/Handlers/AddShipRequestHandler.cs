using Battleship.Domain.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Battleship.Domain.Handlers
{
    public class AddShipRequest : IRequest<bool>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Length { get; set; }
        public Orientation Orientation { get; set; }

        public Guid BoardId { get; set; }
        public Board Board { get; set; }
    }
    public class AddShipRequestHandler : IRequestHandler<AddShipRequest, bool>
    {
        public async Task<bool> Handle(AddShipRequest request, CancellationToken cancellationToken)
        {
            var newShip = new Ship(request.X, request.Y, request.Length, request.Orientation);
            return request.Board.AddShip(newShip);
        }
    }
}
