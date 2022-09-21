using System;
using System.Collections.Generic;
using UnityEngine;

namespace RGames.WallSystem
{
    public class WallsManager : MonoBehaviour
    {
        private float _screenWidth;
        private float _screenHeight;

        [SerializeField] private Camera _camera;

        [SerializeField] private RectTransform _walls;
        [SerializeField] private RectTransform _topWall;
        [SerializeField] private RectTransform _leftWall;
        [SerializeField] private RectTransform _rightWall;
        [SerializeField] private RectTransform _bottomWall;

        private void Awake()
        {
            _screenWidth = _camera.orthographicSize * Screen.width / Screen.height * 2f;
            _screenHeight = _camera.orthographicSize * 2;
        }

        private void Start()
        {
            SetWalls();
        }

        private void SetWalls()
        {
            _walls.sizeDelta = new Vector2(_screenWidth, _screenHeight);
            _leftWall.localScale = new Vector2(0.5f, _screenHeight);
            _rightWall.localScale = new Vector2(0.5f, _screenHeight);
            _topWall.localScale = new Vector2(_screenWidth + 1, 0.5f);
            _bottomWall.localScale = new Vector2(_screenWidth + 1, 0.5f);

            _leftWall.localPosition = new Vector2(-_screenWidth * 0.5f - _leftWall.localScale.x * 0.5f, 0);
            _rightWall.localPosition = new Vector2(_screenWidth * 0.5f + _rightWall.localScale.x * 0.5f, 0);
            _topWall.localPosition = new Vector2(0, _camera.orthographicSize + (_topWall.localScale.y * 0.5f));
            _bottomWall.localPosition = new Vector2(0, -_camera.orthographicSize - (_bottomWall.localScale.y * 0.5f));
        }
    }
}
