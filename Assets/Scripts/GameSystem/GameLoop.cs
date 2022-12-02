using BoardSystem;
using GameSystem.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using GameSystem.Views;

namespace GameSystem
{
    public class GameLoop : MonoBehaviour
    {
        private BoardView _boardView;

        private void Start()
        {
            _boardView = FindObjectOfType<BoardView>();

            _boardView.PositionClicked += OnPositionClicked;
        }

        private void OnPositionClicked(object sender, PositionEventArgs e)
        {
            Debug.Log($"Clicked {e.Position}");
        }
    }
}
