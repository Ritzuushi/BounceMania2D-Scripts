using System;
using System.Collections;
using UnityEngine;

namespace RGUtils.State
{
    [CreateAssetMenu(fileName = "State", menuName = "RGUtils/State/State")]
    public class State : ScriptableObject
    {
        public bool Active;

        public event Action Left;
        public event Action Staying;
        public event Action Entered;

        public void Leave()
        {
            Active = false;
            Left?.Invoke();
        }

        public IEnumerator Stay()
        {
            if (Staying == null) yield break;

            while (Active)
            {
                Staying?.Invoke();
                yield return null;
            }
        }

        public void Enter()
        {
            Active = true;
            Entered?.Invoke();
        }
    }
}
