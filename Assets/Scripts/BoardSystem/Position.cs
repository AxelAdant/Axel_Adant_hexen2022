using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoardSystem
{
    public struct Position
    {
        private readonly int _q;

        private readonly int _r;

        public int Q => _q;

        public int R => _r;

        public int S => -_q - _r;


        public Position(int q, int r)
        {
            _q = q;
            _r = r;
        }

        public override string ToString()
        {
            return $"Q: {_q} R: {_r} S: {S}";
        }
    }
}
