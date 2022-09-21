using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;
using UnityEngine.EventSystems;
using MoreMountains.Feedbacks;

namespace RGames.PlayerSystem
{
    public class PlayerFreezeManager : MonoBehaviour
    {
        private Touch _touch;
        private Camera _camera;
        private int _playerScoreCount;
        private EventSystem _eventSystem;

        [SerializeField] private Rigidbody2D _rb;

        [SerializeField] private PlayerMoveManager _playerMoveManager;

        [SerializeField] private SimpleEvent _playerFrozen;

        [SerializeField] private SimpleEvent _playerScored;

        [SerializeField] private SimpleEvent _playerStopped;

        [SerializeField] private MMF_Player _playerFrozenFeedbacks;

        [field: SerializeField] public int FreezeCount { get; private set; }

        public event Action FreezeCountChanged;

        private void Awake()
        {
            _camera = Camera.main;
            _eventSystem = EventSystem.current;
        }

        private void OnEnable()
        {
            _playerScored.AddListener(AddScoreCount);
        }

        private void OnDisable()
        {
            _playerScored.RemoveListener(AddScoreCount);
        }

        private void Start()
        {
            FreezeCountChanged?.Invoke();
        }

        private void Update() => Tap();

        private void Tap()
        {
            if (Input.touchCount == 0) return;

            _touch = Input.GetTouch(0);

            if (_touch.phase == TouchPhase.Began && !_playerMoveManager.IsIdle && !_playerMoveManager.IsTouchingWall)
            {
                if (_eventSystem.IsPointerOverGameObject(_touch.fingerId)) return;
                FreezePlayer();
            }
        }

        private void AddScoreCount()
        {
            _playerScoreCount++;

            if (_playerScoreCount % 7 == 0)
            {
                AddFreezeCount();
            }
        }

        private void AddFreezeCount()
        {
            FreezeCount++;

            FreezeCountChanged?.Invoke();
        }

        private void FreezePlayer()
        {
            if (FreezeCount == 0) return;
            _playerMoveManager.CurrentVelocity = Vector2.zero;
            _rb.velocity = Vector2.zero;
            FreezeCount--;
            _playerFrozenFeedbacks.PlayFeedbacks();
            _playerFrozen.Invoke();
            _playerStopped.Invoke();
            FreezeCountChanged?.Invoke();
        }
    }
}
