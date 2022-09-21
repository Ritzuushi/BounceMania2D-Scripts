using UnityEditor;
using UnityEngine;

namespace RGUtils.State
{
    public class StateMachineManagerCreator
    {
        [MenuItem("GameObject/RGUtils/StateMachineManager", false, 0)]
        private static void CreateStateMachineManager()
        {
            if (GameObject.Find("StateMachineManager") != null) return;
            var gameObject = new GameObject("StateMachineManager");
            gameObject.AddComponent<StateMachineManager>();
            gameObject.isStatic = true;
        }
    }
}
