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

    public class PositionView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                CardView cardView = eventData.pointerDrag.GetComponent<CardView>();
                CardTypes cardType = cardView.Type;
                Card card = cardView.Card;

                _parent.ChildHovered(this, card, cardType);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            CardView cardView = eventData.pointerDrag.GetComponent<CardView>();
            CardTypes cardType = cardView.Type;
            Card card = cardView.Card;

            _parent.ChildDrop(this, card, cardType);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.dragging)
            {
                CardView cardView = eventData.pointerDrag.GetComponent<CardView>();
                CardTypes cardType = cardView.Type;
                Card card = cardView.Card;

                _parent.ChildEndHovered(this, card, cardType);
            }
        }
    }
}
