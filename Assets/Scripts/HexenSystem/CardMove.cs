using BoardSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HexenSystem
{
    public delegate List<Position> Collector<TPiece>(Board<TPiece> board, Position playerPosition, Position pointedPosition);

    public class CardMove<TPiece>
    {
        private Collector<TPiece> _collector;
        private Board<TPiece> _board;

        public CardMove(Board<TPiece> board, Collector<TPiece> collector)
        {
            _collector = collector;
            _board = board;
        }

        public List<Position> Positions(Position playerPosition, Position pointedPosition)
        {
            return _collector(_board, playerPosition, pointedPosition);
        }
        public virtual bool Execute(Position playerPosition, Position hoverPosition)
        {
            
            return _board.Move(playerPosition, hoverPosition);
        }
    }
}
