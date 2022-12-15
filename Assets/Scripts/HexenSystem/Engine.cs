using BoardSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexenSystem
{
    public class Engine<TPiece>
    {
        public Position PlayerPosition = new Position(0, 0);

        private readonly Board<TPiece> _board;
        private readonly CardMovesCollection<TPiece> _cardMoves;
        public CardMovesCollection<TPiece> CardMoves { get { return _cardMoves; } }

        public Engine(Board<TPiece> board)
        {
            _board = board;
            _cardMoves = new CardMovesCollection<TPiece>(board);
        }

        public bool Move(Position fromPosition, Position toPosition)
        {
            //must execute cardmove here

            return true;
        }
    }
}
