using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HexenSystem
{
    public class Card : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        private CardTypes _type = CardTypes.Teleport;

        [SerializeField]
        private LayerMask _hexLayer;

        private Vector3 _initialPosition;

        //public Card(CardTypes type)
        //{
        //    _type = type;
        //}

        private void OnEnable()
        {
            _initialPosition = transform.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log(_type);
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 1000, _hexLayer))
            {
                if (hit.collider.TryGetComponent<IHex>(out IHex hex))
                    hex.UsedCardHere = _type;

                Destroy(gameObject);
            }
            else
            {
                transform.position = _initialPosition;
            }
        }
    }
}
