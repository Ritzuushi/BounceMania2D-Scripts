using System;
using System.Collections.Generic;
using UnityEngine;
using RGUtils.RVariables;

namespace RGames
{
    public class TestRVars : MonoBehaviour
    {
        [SerializeField] private RString _name;
        [SerializeField] private RInt _health;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _health.Set(_health.Value + 5);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _health.Set(_health.Value - 5);
            }
        }

        public void Test(int i)
        {
            Debug.Log(i);
        }

        public void Test(string s)
        {
            Debug.Log(s);
        }
    }
}
