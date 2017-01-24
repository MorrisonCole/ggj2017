using System;
using UnityEngine;

public class WaveBehaviour : MonoBehaviour, IWaveBehaviour
{
    public int WavePower = 215;

    public void Wave(Action<float> onWaveEnd)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * WavePower);
    }
}