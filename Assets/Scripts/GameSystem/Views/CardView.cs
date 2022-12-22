using BoardSystem;
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
        private Card _card;
        public Card Card => _card;

        private readonly CardTypes _type;
        public CardTypes Type
        {
            get                                            // type doesn't need to be passed in the positionview (and boardview and
            {                                              // gameloop) anymore. Use it only to determine what card type to put in "_card"
                return _type;
            }                                              
            
        }

        private Vector3 _initialPosition;
        private Board<PieceView> _board;

        private void OnEnable()
        {
            _initialPosition = transform.position;

            _card = new PushCard();
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = _initialPosition;

            Image draggedCardImage = GetComponent<Image>();

            draggedCardImage.raycastTarget = true;
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
