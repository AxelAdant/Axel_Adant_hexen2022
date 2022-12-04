using BoardSystem;
using GameSystem.Helpers;
using HexenSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace GameSystem.Views
{
    [Serializable]
    public class ActivationChangeUnityEvent : UnityEvent<bool> { }

    public class PositionView : MonoBehaviour, IHex
    {
        [SerializeField]
        private UnityEvent OnActivate;

        [SerializeField]
        private UnityEvent OnDeactivate;

        [SerializeField]
        private ActivationChangeUnityEvent onActivationChange;

        public Position GridPosition => PositionHelper.GridPosition(transform.position);

        public CardTypes UsedCardHere
        {
            set
            {
                _parent.ChildClicked(this, value);
            }
        }

        private BoardView _parent;

        private void Start()
        {
            _parent = GetComponentInParent<BoardView>();
        }

        internal void Deactivate()
        {
            OnDeactivate?.Invoke();
            onActivationChange?.Invoke(false);
        }

        internal void Activate()
        {
            OnActivate?.Invoke();
            onActivationChange?.Invoke(true);
        }
    }
}
