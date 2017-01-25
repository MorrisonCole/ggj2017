using System;

namespace Undercurrent.Scripts.Mexican_Wave
{
    public interface IWaveBehaviour
    {
        void Wave(Action<float> onWaveEnd);
    }
}