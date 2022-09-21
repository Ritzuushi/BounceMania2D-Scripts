using UnityEngine;
using UnityEngine.SceneManagement;
using RGUtils.State;
using SceneManager = UnityEngine.SceneManagement.SceneManager;

namespace RGames.SceneSystem
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private State _idleState;
        [SerializeField] private State _overState;
        [SerializeField] private State _pausedState;
        [SerializeField] private State _replayState;
        [SerializeField] private State _playingState;

        [SerializeField] private StateMachine _gameSM;

        private void OnEnable()
        {
            _playingState.Entered += EnteredPlayingState;
            _pausedState.Entered += EnteredPausedState;
            _overState.Entered += EnteredOverState;
            _idleState.Entered += EnteredIdleState;

            _playingState.Left += LeftPlayingState;
            _pausedState.Left += LeftPausedState;
            _overState.Left += LeftOverState;
            _idleState.Left += LeftIdleState;
        }

        private void OnDisable()
        {
            _playingState.Entered -= EnteredPlayingState;
            _pausedState.Entered -= EnteredPausedState;
            _overState.Entered -= EnteredOverState;
            _idleState.Entered -= EnteredIdleState;

            _playingState.Left -= LeftPlayingState;
            _pausedState.Left -= LeftPausedState;
            _overState.Left -= LeftOverState;
            _idleState.Left -= LeftIdleState;
        }

        private void EnteredIdleState()
        {
            SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive).completed += (handle) =>
            {
                SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Additive).completed += (handle) =>
                {
                    SceneManager.UnloadSceneAsync("Loading");
                };
            };
        }

        private void LeftIdleState()
        {
            SceneManager.UnloadSceneAsync("MainMenu");
        }

        private void EnteredPlayingState()
        {
            if (SceneManager.GetSceneByName("Game").isLoaded) return;

            SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive).completed += (handle) =>
            {
                SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive).completed += (handle) =>
                {
                    SceneManager.UnloadSceneAsync("Loading");
                };
            };
        }

        private void LeftPlayingState()
        {
            if (_gameSM.NewState == _pausedState) return;
            if (_gameSM.NewState == _overState) return;
            SceneManager.UnloadSceneAsync("Game");
        }

        private void EnteredPausedState()
        {
            SceneManager.LoadSceneAsync("PauseMenu", LoadSceneMode.Additive);
        }

        private void LeftPausedState()
        {
            SceneManager.UnloadSceneAsync("PauseMenu");

            if (_gameSM.NewState == _idleState)
            {
                SceneManager.UnloadSceneAsync("Game");
            }
            if (_gameSM.NewState == _replayState)
            {
                SceneManager.UnloadSceneAsync("Game");
            }
        }

        private void EnteredOverState()
        {
            SceneManager.LoadSceneAsync("Loading", LoadSceneMode.Additive).completed += (handle) =>
            {
                SceneManager.LoadSceneAsync("GameOver", LoadSceneMode.Additive).completed += (handle) =>
                {
                    SceneManager.UnloadSceneAsync("Loading");
                };
            };
        }

        private void LeftOverState()
        {
            SceneManager.UnloadSceneAsync("Game");
            SceneManager.UnloadSceneAsync("GameOver");
        }
    }
}
