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
        private Engine<PieceView> _engine;

        private void Start()
        {
            _boardView = FindObjectOfType<BoardView>();
            _boardView.PositionHovered += OnPositionHovered;
            _boardView.PositionEndHovered += OnPositionHoverEnded;
            _boardView.PositionEndedDrag += OnPositionEndedDrag;

            _board = new Board<PieceView>(PositionHelper._boardRadius);
            _board.PieceMoved += (s, e) => e.Piece.MoveTo(PositionHelper.WorldPosition(e.ToPosition));
            _board.PieceTaken += (s, e) => e.Piece.Taken();
            _board.PiecePlaced += (s, e) => e.Piece.Placed(PositionHelper.WorldPosition(e.ToPosition));

            _engine = new Engine<PieceView>(_board);

            PieceView[] pieceViews = FindObjectsOfType<PieceView>();
            foreach (PieceView pieceView in pieceViews)
                _board.Place(new Position(0, 0), pieceView);
        }

        private void OnPositionEndedDrag(object sender, PositionEventArgs e)
        {
            Debug.Log($"dropped a {e.CardType} card here : {e.Position}");
        }

        private void OnPositionHovered(object sender, PositionEventArgs e)
        {
            _boardView.ActivePosition = _engine.CardMoves.For(e.CardType).Positions(_engine.PlayerPosition, e.Position);
        }

        private void OnPositionHoverEnded(object sender, PositionEventArgs e)
        {
            _boardView.ActivePosition = null;
        }
    }
}
