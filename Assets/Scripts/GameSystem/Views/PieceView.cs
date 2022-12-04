using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameSystem.Views
{
    public class PieceView : MonoBehaviour
    {
        public Vector3 WorldPosition => transform.position;

        internal void MoveTo(Vector3 worldPosition)
        {
            transform.position = worldPosition;
        }

        internal void Taken()
        {
            gameObject.SetActive(false);
        }

        internal void Placed(Vector3 worldPosition)
        {
            transform.position = worldPosition;
            gameObject.SetActive(true);
        }
    }
}
