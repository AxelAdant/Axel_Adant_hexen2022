using BoardSystem;
using GameSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    class SwipeCard : Card
    {
        List<Position> _positions = new List<Position>();
        private bool canExecute;

        public override List<Position> ValidPositions(Position playerPosition, Position hoverPosition, Board<PieceView> board)
        {
            _positions.Add(new Position(playerPosition.Q + 1, playerPosition.R + 0));
            _positions.Add(new Position(playerPosition.Q + 0, playerPosition.R + 1));
            _positions.Add(new Position(playerPosition.Q + 0, playerPosition.R - 1));
            _positions.Add(new Position(playerPosition.Q - 1, playerPosition.R + 0));
            _positions.Add(new Position(playerPosition.Q + 1, playerPosition.R - 1));
            _positions.Add(new Position(playerPosition.Q - 1, playerPosition.R + 1));

            canExecute = true;

            foreach(Position position in _positions)
            {
                if(hoverPosition.Equals(position))
                {
                    _positions.Clear();
                    _positions.Add(hoverPosition);

                    if (hoverPosition.Q - playerPosition.Q == 0) 
                    {
                        _positions.Add(new Position(playerPosition.Q + (1 * Math.Sign(hoverPosition.R)), playerPosition.R));
                        _positions.Add(new Position(playerPosition.Q - (1 * Math.Sign(hoverPosition.R)), hoverPosition.R));
                    }
                    if (hoverPosition.R - playerPosition.R == 0)
                    {
                        _positions.Add(new Position(hoverPosition.Q, playerPosition.R - (1 * Math.Sign(hoverPosition.Q))));
                        _positions.Add(new Position(playerPosition.Q, playerPosition.R + (1 * Math.Sign(hoverPosition.Q))));
                    }
                    if (hoverPosition.S - playerPosition.S == 0)
                    {
                        _positions.Add(new Position(playerPosition.Q + (1 * Math.Sign(hoverPosition.Q)), playerPosition.R));
                        _positions.Add(new Position(playerPosition.Q, playerPosition.R - (1 * Math.Sign(hoverPosition.Q))));
                    }

                    return _positions;
                }
            }

            canExecute = false;

            return _positions;
        }

        public override void Execute(Position playerPosition, Position hoverPosition, Board<PieceView> board)
        {
            if (canExecute)
            {
                foreach (Position position in _positions)
                {
                    if (board.TryGetPieceAt(position, out PieceView piece))
                    {
                        piece.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
