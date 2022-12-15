using HexenSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameSystem.Views
{
    class CardView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private readonly CardTypes _type = CardTypes.Slash;
        public CardTypes Type
        {
            get
            {
                return _type;
            }
        }

        private Vector3 _initialPosition;

        //public CardView(CardTypes type)
        //{
        //    _type = type;
        //}

        private void OnEnable()
        {
            _initialPosition = transform.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = _initialPosition;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Image draggedCardImage = GetComponent<Image>();

            draggedCardImage.raycastTarget = false;
        }
    }
}
