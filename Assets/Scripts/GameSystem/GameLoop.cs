using BoardSystem;
using GameSystem.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using GameSystem.Views;
using HexenSystem;

namespace GameSystem
{
    public class GameLoop : MonoBehaviour
    {
        private BoardView _boardView;
        private Board<PieceView> _board;


        private void Start()
        {
            _boardView = FindObjectOfType<BoardView>();
            _boardView.PositionClicked += OnPositionClicked;

            _board = new Board<PieceView>(PositionHelper._boardRadius);
            _board.PieceMoved += (s, e) => e.Piece.MoveTo(PositionHelper.WorldPosition(e.ToPosition));
            _board.PieceTaken += (s, e) => e.Piece.Taken();
            _board.PiecePlaced += (s, e) => e.Piece.Placed(PositionHelper.WorldPosition(e.ToPosition));

            PieceView[] pieceViews = FindObjectsOfType<PieceView>();
            foreach (PieceView pieceView in pieceViews)
                _board.Place(new Position(0, 0), pieceView);
        }

        private Position _currentPosition = new Position(0, 0);
        private void OnPositionClicked(object sender, PositionEventArgs e)
        {
            if (e.Type == CardTypes.Teleport)
            {
                _board.Move(_currentPosition, e.Position);
                _currentPosition = e.Position;
            }

            Debug.Log(e.Position);
        }
    }
}
