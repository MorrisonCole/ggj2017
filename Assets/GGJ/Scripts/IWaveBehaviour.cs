using System;

public interface IWaveBehaviour
{
    void Wave(Action<float> onWaveEnd);
}