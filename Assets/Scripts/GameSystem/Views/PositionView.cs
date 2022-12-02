using BoardSystem;
using GameSystem.Helpers;
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

    public class PositionView : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private UnityEvent OnActivate;

        [SerializeField]
        private UnityEvent OnDeactivate;

        [SerializeField]
        private ActivationChangeUnityEvent onActivationChange;

        public Position GridPosition => PositionHelper.GridPosition(transform.position);

        private BoardView _parent;

        private void Start()
        {
            _parent = GetComponentInParent<BoardView>();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _parent.ChildClicked(this);
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
