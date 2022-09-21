using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RGames
{
    public class RateGame : MonoBehaviour
    {
        public void Rate()
        {
            Application.OpenURL("market://details?id=" + Application.identifier);
        }
    }
}
