using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardSystem
{
    public class PieceMovedEventArgs<TPiece> : EventArgs
    {
        public TPiece Piece { get; }
        public Position FromPosition { get; }
        public Position ToPosition { get; }

        public PieceMovedEventArgs(TPiece pieceView, Position fromPosition, Position toPosition)
        {
            Piece = pieceView;
            FromPosition = fromPosition;
            ToPosition = toPosition;
        }
    }

    public class PieceTakenEventArgs<TPiece> : EventArgs
    {
        public TPiece Piece { get; }
        public Position FromPosition { get; }

        public PieceTakenEventArgs(TPiece pieceView, Position fromPosition)
        {
            Piece = pieceView;
            FromPosition = fromPosition;
        }
    }

    public class PiecePlacedEventArgs<TPiece> : EventArgs
    {
        public TPiece Piece { get; }
        public Position ToPosition { get; }

        public PiecePlacedEventArgs(TPiece pieceView, Position fromPosition)
        {
            Piece = pieceView;
            ToPosition = fromPosition;
        }
    }

    public class Board<TPiece>
    {
        public event EventHandler<PieceMovedEventArgs<TPiece>> PieceMoved;
        public event EventHandler<PieceTakenEventArgs<TPiece>> PieceTaken;
        public event EventHandler<PiecePlacedEventArgs<TPiece>> PiecePlaced;

        private Dictionary<Position, TPiece> _pieces = new Dictionary<Position, TPiece>();

        private Position _playerPosition = new Position(0, 0);

        private readonly int _boardRadius;

        public Position PlayerPosition 
        {
            get
            {
                return _playerPosition;
            }
        }

        public Board(int boardRadius)
        {
            _boardRadius = boardRadius;
        }

        public bool TryGetPieceAt(Position position, out TPiece piece)
            => _pieces.TryGetValue(position, out piece);

        public bool IsValid(Position position)
        {
            return (Math.Abs(position.Q) <= _boardRadius && Math.Abs(position.R) <= _boardRadius && Math.Abs(position.S) <= _boardRadius);
        }

        public bool Place(Position position, TPiece piece)
        {
            if (piece == null)
                return false;

            if (!IsValid(position))
                return false;

            if (_pieces.ContainsKey(position))
                return false;

            if (_pieces.ContainsValue(piece))
                return false;

            _pieces[position] = piece;

            OnPiecePlaced(new PiecePlacedEventArgs<TPiece>(piece, position));

            return true;
        }

        public bool Move(Position fromPosition, Position toPosition, bool isPlayer)
        {
            if (!IsValid(toPosition))
                return false;

            if (_pieces.ContainsKey(toPosition))
                return false;

            if (!_pieces.TryGetValue(fromPosition, out var piece))
                return false;

            _pieces.Remove(fromPosition);
            _pieces[toPosition] = piece;

            if (isPlayer)
                _playerPosition = toPosition;

            OnPieceMoved(new PieceMovedEventArgs<TPiece>(piece, fromPosition, toPosition));

            return true;
        }

        public bool Take(Position fromPosition)
        {
            if (!IsValid(fromPosition))
                return false;

            if (!_pieces.ContainsKey(fromPosition))
                return false;

            if (!_pieces.TryGetValue(fromPosition, out var piece))
                return false;

            _pieces.Remove(fromPosition);

            OnPieceTaken(new PieceTakenEventArgs<TPiece>(piece, fromPosition));

            return true;
        }

        protected virtual void OnPieceMoved(PieceMovedEventArgs<TPiece> eventArgs)
        {
            var handler = PieceMoved;
            handler?.Invoke(this, eventArgs);
        }
        protected virtual void OnPieceTaken(PieceTakenEventArgs<TPiece> eventArgs)
        {
            var handler = PieceTaken;
            handler?.Invoke(this, eventArgs);
        }
        protected virtual void OnPiecePlaced(PiecePlacedEventArgs<TPiece> eventArgs)
        {
            var handler = PiecePlaced;
            handler?.Invoke(this, eventArgs);
        }
    }
}
