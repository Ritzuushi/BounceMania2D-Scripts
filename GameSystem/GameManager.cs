using UnityEngine;
using RGUtils.State;

namespace RGames.GameSystem
{
    [CreateAssetMenu]
    public class GameManager : ScriptableObject
    {
        [SerializeField] private StateMachine _gameSM;

        public void Play()
        {
            _gameSM.SetState("Playing");
        }

        public void Pause()
        {
            _gameSM.SetState("Paused");
        }

        public void Resume()
        {
            _gameSM.SetState("Playing");
        }

        public void Replay()
        {
            _gameSM.SetState("Replay");
            _gameSM.SetState("Playing");
        }

        public void Lose()
        {
            _gameSM.SetState("Over");
        }

        public void MainMenu()
        {
            _gameSM.SetState("Idle");
        }

        public void Exit()
        {

        }
    }
}
