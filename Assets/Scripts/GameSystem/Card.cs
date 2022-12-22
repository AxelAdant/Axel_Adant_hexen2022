using BoardSystem;
using GameSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    public abstract class Card
    {
        public abstract List<Position> ValidPositions(Position playerPosition, Position hoverPosition, Board<PieceView> board);
        public abstract void Execute(Position playerPosition, Position hoverPosition, Board<PieceView> board);
    }
}