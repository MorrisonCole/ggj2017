using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

namespace Undercurrent.Scripts.Mexican_Wave
{
    public class MexicanWave : MonoBehaviour
    {
        public float WaveSpeedMultiplier;
        public float WaveBeginTime;
        public AudioSource AudioSource;
        public SpawnWave SpawnWave;
        public GameObject Countdown;
        public Text CountdownText;

        [YarnCommand("start")]
        public void PlayerReadyForWave()
        {
            StartCoroutine(CountdownToWave());
        }

        private IEnumerator CountdownToWave()
        {
            Countdown.SetActive(true);
            var countdown = 3;
            while (countdown > 0)
            {
                CountdownText.text = countdown.ToString();
                yield return new WaitForSeconds(1f);
                countdown--;
            }
            Countdown.SetActive(false);

            StartCoroutine(BeginWaitForWave());
        }

        private IEnumerator BeginWaitForWave()
        {
            AudioSource.PlayOneShot(AudioSource.clip);
            yield return new WaitForSeconds(WaveBeginTime / WaveSpeedMultiplier);
            SpawnWave.StartWave(OnWaveEnd);
        }

        private void OnWaveEnd(float timeOffset)
        {

        }
    }
}
