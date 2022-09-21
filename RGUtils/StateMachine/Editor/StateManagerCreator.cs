using UnityEditor;
using UnityEngine;

namespace RGUtils.State
{
    public class StateManagerCreator
    {
        [MenuItem("GameObject/RGUtils/StateManager", false, 0)]
        private static void CreateStateMachineManager()
        {
            if (GameObject.Find("StateManager") != null) return;
            var gameObject = new GameObject("StateManager");
            gameObject.AddComponent<StateManager>();
            gameObject.isStatic = true;
        }
    }
}
