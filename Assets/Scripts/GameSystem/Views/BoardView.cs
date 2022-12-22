using BoardSystem;
using HexenSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystem.Views
{
    public class PositionEventArgs : EventArgs
    {
        public Card Card { get; }

        public Position Position { get; }

        public CardTypes CardType { get; }

        public PositionEventArgs(Position position, Card card, CardTypes cardType)
        {
            Position = position;
            Card = card;
            CardType = cardType;
        }
    }

    class BoardView : MonoBehaviour
    {
        private List<Position> _activePositions = new List<Position>();

        public List<Position> ActivePosition
        {
            set
            {
                foreach (var position in _activePositions)
                    _positionViews[position].Deactivate();

                if(value == null)
                    _activePositions.Clear();
                else
                    _activePositions = value;

                foreach (var position in _activePositions)
                    _positionViews[position].Activate();
            }
        }

        public event EventHandler<PositionEventArgs> PositionEndHovered;
        public event EventHandler<PositionEventArgs> PositionHovered;
        public event EventHandler<PositionEventArgs> PositionEndedDrag;

        private Dictionary<Position, PositionView> _positionViews = new Dictionary<Position, PositionView>();

        private void OnEnable()
        {
            var positionViews = GetComponentsInChildren<PositionView>();
            foreach(var positionView in positionViews)
            {
                _positionViews.Add(positionView.GridPosition, positionView);
            }
        }

        internal void ChildHovered(PositionView positionView, Card card, CardTypes cardType)
        {
            OnPositionHovered(new PositionEventArgs(positionView.GridPosition, card, cardType));
        }

        protected virtual void OnPositionHovered(PositionEventArgs e)
        {
            var handler = PositionHovered;
            handler.Invoke(this, e);
        }

        internal void ChildEndHovered(PositionView positionView, Card card, CardTypes cardType)
        {
            OnPositionEndHovered(new PositionEventArgs(positionView.GridPosition, card, cardType));
        }

        private void OnPositionEndHovered(PositionEventArgs e)
        {
            var handler = PositionEndHovered;
            handler.Invoke(this, e);
        }

        internal void ChildDrop(PositionView positionView, Card card, CardTypes cardType)
        {
            OnPositionDrop(new PositionEventArgs(positionView.GridPosition, card, cardType));
        }

        private void OnPositionDrop(PositionEventArgs e)
        {
            var handler = PositionEndedDrag;
            handler.Invoke(this, e);
        }

        //protected virtual void OnPositionClicked(PositionEventArgs e)
        //{
        //    var handler = PositionClicked;
        //    handler.Invoke(this, e);
        //}

        //internal void ChildClicked(PositionView positionView)
        //{
        //    OnPositionClicked(new PositionEventArgs(positionView.GridPosition));
        //}

        public void SetActivePosition(List<Position> activePositions)
        {

        }
    }
}
