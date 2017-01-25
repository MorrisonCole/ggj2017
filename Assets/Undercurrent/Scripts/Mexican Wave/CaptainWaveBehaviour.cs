using System;
using UnityEngine;

namespace Undercurrent.Scripts.Mexican_Wave
{
    public class CaptainWaveBehaviour : MonoBehaviour, IWaveBehaviour
    {
        public int WavePower = 215;

        private bool canWave;

        private void OnEnable()
        {
            canWave = true;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PerformWave();
                canWave = false;
            }
        }

        public void Wave(Action<float> onWaveEnd)
        {
        }

        private void PerformWave()
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * WavePower);
        }
    }
}
