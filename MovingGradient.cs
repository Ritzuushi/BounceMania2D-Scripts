using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RGames
{
    public class MovingGradient : MonoBehaviour
    {
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private Image _image;
        private WaitForSeconds _interval;

        private void Awake()
        {
            _interval = new WaitForSeconds(0.5f);
            StartCoroutine("DoAnimation");
        }

        private IEnumerator DoAnimation()
        {
            while (true)
            {
                for (int i = 0; i < _sprites.Length; i++)
                {
                    _image.sprite = _sprites[i];
                    yield return _interval;
                }
            }
        }
    }
}
