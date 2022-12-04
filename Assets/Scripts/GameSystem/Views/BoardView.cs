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
        public Position Position { get; }
        public CardTypes Type { get; }

        public PositionEventArgs(Position position, CardTypes type)
        {
            Position = position;
            Type = type;
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

                foreach (var position in value)
                    _positionViews[position].Activate();
            }
        }

        public event EventHandler<PositionEventArgs> PositionClicked;

        private Dictionary<Position, PositionView> _positionViews = new Dictionary<Position, PositionView>();

        private void OnEnable()
        {
            var positionViews = GetComponentsInChildren<PositionView>();
            foreach(var positionView in positionViews)
            {
                _positionViews.Add(positionView.GridPosition, positionView);
            }
        }

        protected virtual void OnPositionClicked(PositionEventArgs e)
        {
            var handler = PositionClicked;
            handler.Invoke(this, e);
        }

        internal void ChildClicked(PositionView positionView, CardTypes type)
        {
            OnPositionClicked(new PositionEventArgs(positionView.GridPosition, type));
        }

        public void SetActivePosition(List<Position> activePositions)
        {

        }
    }
}
