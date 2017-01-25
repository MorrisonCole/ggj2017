using System;
using UnityEngine;

namespace Undercurrent.Scripts.Mexican_Wave
{
    public class WaveBehaviour : MonoBehaviour, IWaveBehaviour
    {
        public int WavePower = 215;

        public void Wave(Action<float> onWaveEnd)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * WavePower);
        }
    }
}