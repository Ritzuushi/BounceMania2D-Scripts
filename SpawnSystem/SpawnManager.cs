using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.Events;
using Random = UnityEngine.Random;

namespace RGames.SpawnSystem
{
    public class SpawnManager : MonoBehaviour
    {
        private Vector2 _screenBounds;

        private List<GameObject> _obstacles = new List<GameObject>();

        [SerializeField] private Camera _camera;

        [SerializeField] private GameObject _goal;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _obstacle;
        [SerializeField] private Transform _obstacleParent;

        [SerializeField] private SimpleEvent _playerScored;

        [Range(0.5f, 1f)][SerializeField] private float SpawnArea;
        [SerializeField] private int _obstacleCount;

        private void OnEnable()
        {
            _playerScored.AddListener(Respawn);
        }

        private void OnDisable()
        {
            _playerScored.RemoveListener(Respawn);
        }

        private void Awake()
        {
            _screenBounds = _camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, _camera.transform.position.z));

            CreateObstacles();
            SpawnObstacles();
            SpawnPlayer();
            SpawnGoal();
        }

        private void Respawn()
        {
            _goal.SetActive(false);
            foreach (var obstacle in _obstacles)
            {
                obstacle.SetActive(false);
            }

            SpawnObstacles();
            SpawnGoal();
        }

        private void SpawnGoal()
        {
            _goal.transform.position = GetRandomPosition(_goal.transform.localScale.x);
            _goal.SetActive(true);
        }

        private void SpawnPlayer()
        {
            _player.transform.position = GetRandomPosition(_player.transform.localScale.x);
            _player.SetActive(true);
        }

        private void SpawnObstacles()
        {
            foreach (var obstacle in _obstacles)
            {
                obstacle.transform.position = GetRandomPosition(_obstacle.transform.localScale.x);
                obstacle.SetActive(true);
            }
        }

        private void AddObstacle()
        {
            var obstacle = Instantiate(_obstacle, _obstacleParent);
            obstacle.SetActive(false);
            _obstacles.Add(obstacle);
        }

        private void CreateObstacles()
        {
            for (var i = 0; i < _obstacleCount; i++)
            {
                var obstacle = Instantiate(_obstacle, _obstacleParent);
                obstacle.SetActive(false);
                _obstacles.Add(obstacle);
            }
        }

        private Vector2 GetRandomPosition(float radius)
        {
            var randomPos = new Vector2(Random.Range(-_screenBounds.x + SpawnArea, _screenBounds.x - SpawnArea), Random.Range(-_screenBounds.y + SpawnArea, _screenBounds.y - SpawnArea));

            while (true)
            {
                if (Physics2D.OverlapCircle(randomPos, radius) == null) break;
                else
                {
                    randomPos = new Vector2(Random.Range(-_screenBounds.x + SpawnArea, _screenBounds.x - SpawnArea), Random.Range(-_screenBounds.y + SpawnArea, _screenBounds.y - SpawnArea));
                }
            }

            return randomPos;
        }
    }
}
