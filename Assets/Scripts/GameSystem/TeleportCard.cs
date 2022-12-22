using BoardSystem;
using GameSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    class TeleportCard : Card
    {
        public override List<Position> ValidPositions(Position playerPosition, Position hoverPosition, Board<PieceView> board)
        {
            List<Position> positions = new List<Position>();

            if (!board.TryGetPieceAt(hoverPosition, out PieceView piece))
                positions.Add(hoverPosition);

            return positions;
        }

        public override void Execute(Position playerPosition, Position hoverPosition, Board<PieceView> board)
        {
            if (!board.TryGetPieceAt(hoverPosition, out PieceView piece))
                board.Move(playerPosition, hoverPosition, true);
        }
    }
}
