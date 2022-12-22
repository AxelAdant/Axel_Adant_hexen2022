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

        public Engine(Board<TPiece> board)
        {
            _board = board;
        }

        public bool Move(Position fromPosition, Position toPosition)
        {
            return true;
        }
    }
}
