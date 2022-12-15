using BoardSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace HexenSystem
{
    class CardMoveHelper<TPiece>
    {
        private Position _playerPosition;
        private Position _hoverPosition;
        private Board<TPiece> _board;
        private List<Position> _positions = new List<Position>();

        public CardMoveHelper(Position playerPosition, Position hoverPosition, Board<TPiece> board)
        {
            _playerPosition = playerPosition;
            _hoverPosition = hoverPosition;
            _board = board;
        }

        internal List<Position> ValidPosition()
        {
            return _positions;
        }

        public CardMoveHelper<TPiece> GetQUp(int maxStep = int.MaxValue)
            => Collect(new Vector2Int(0, -1), maxStep);
        public CardMoveHelper<TPiece> GetQDown(int maxStep = int.MaxValue)
            => Collect(new Vector2Int(0, 1), maxStep);
        public CardMoveHelper<TPiece> GetRUp(int maxStep = int.MaxValue)
            => Collect(new Vector2Int(-1, 0), maxStep);
        public CardMoveHelper<TPiece> GetRDown(int maxStep = int.MaxValue)
            => Collect(new Vector2Int(1, 0), maxStep);
        public CardMoveHelper<TPiece> GetSUp(int maxStep = int.MaxValue)
            => Collect(new Vector2Int(-1, 1), maxStep);
        public CardMoveHelper<TPiece> GetSDown(int maxStep = int.MaxValue)
            => Collect(new Vector2Int(1, -1), maxStep);


        public CardMoveHelper<TPiece> Collect(Vector2Int direction, int MaxStep = int.MaxValue)
        {
            int currentStep = 0;
            Position position = new Position(direction.x + _playerPosition.Q, direction.y + _playerPosition.R);

            while(_board.IsValid(position) && currentStep < MaxStep)
            {
                _positions.Add(position);

                position = new Position(position.Q + direction.x, position.R + direction.y);

                currentStep++;
            }
            return this;
        }

        public CardMoveHelper<TPiece> CollectHover()
        {
            _positions.Add(_hoverPosition);
            return this;
        }
    }
}
