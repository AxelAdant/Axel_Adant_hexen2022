using BoardSystem;
using GameSystem.Helpers;
using GameSystem.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    public class SlashCard : Card
    {
        private List<Position> _positions = new List<Position>();
        private bool canExecute;

        public override List<Position> ValidPositions(Position playerPosition, Position hoverPosition, Board<PieceView> board)
        {

            Position position = new Position(playerPosition.Q + 1, playerPosition.R);
            while (board.IsValid(position))
            {
                _positions.Add(position);

                position = new Position(position.Q + 1, position.R);
            }

            position = new Position(playerPosition.Q - 1, playerPosition.R);
            while (board.IsValid(position))
            {
                _positions.Add(position);

                position = new Position(position.Q - 1, position.R);
            }

            position = new Position(playerPosition.Q, playerPosition.R + 1);
            while (board.IsValid(position))
            {
                _positions.Add(position);

                position = new Position(position.Q, position.R + 1);
            }

            position = new Position(playerPosition.Q, playerPosition.R - 1);
            while (board.IsValid(position))
            {
                _positions.Add(position);

                position = new Position(position.Q, position.R - 1);
            }

            position = new Position(playerPosition.Q - 1, playerPosition.R + 1);
            while (board.IsValid(position))
            {
                _positions.Add(position);

                position = new Position(position.Q - 1, position.R + 1);
            }

            position = new Position(playerPosition.Q + 1, playerPosition.R - 1);
            while (board.IsValid(position))
            {
                _positions.Add(position);

                position = new Position(position.Q + 1, position.R - 1);
            }

            canExecute = true;

            foreach(Position position1 in _positions)
            {
                if (position1.Equals(hoverPosition))
                {
                    _positions.Clear();

                    if(hoverPosition.Q == playerPosition.Q)
                    {
                        position = new Position(playerPosition.Q, playerPosition.R + (Math.Sign(hoverPosition.R)));
                        while (board.IsValid(position))
                        {
                            _positions.Add(position);

                            position = new Position(position.Q, position.R + (Math.Sign(hoverPosition.R)));
                        }

                        return _positions;
                    }
                    if (hoverPosition.R == playerPosition.R)
                    {
                        position = new Position(playerPosition.Q + (Math.Sign(hoverPosition.Q)), playerPosition.R);
                        while (board.IsValid(position))
                        {
                            _positions.Add(position);

                            position = new Position(position.Q + (Math.Sign(hoverPosition.Q)), position.R);
                        }

                        return _positions;
                    }
                    if (hoverPosition.S == playerPosition.S)
                    {
                        position = new Position(playerPosition.Q + (Math.Sign(hoverPosition.Q)), playerPosition.R + (Math.Sign(hoverPosition.R)));
                        while (board.IsValid(position))
                        {
                            _positions.Add(position);

                            position = new Position(position.Q + (Math.Sign(hoverPosition.Q)), position.R + (Math.Sign(hoverPosition.R)));
                        }

                        return _positions;
                    }
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
