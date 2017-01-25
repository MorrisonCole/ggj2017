using System.Collections;
using UnityEngine;

namespace Undercurrent.Scripts.Audio
{
    public class RandomAudioClipBehaviour : MonoBehaviour
    {
        public AudioClip[] AudioClips;
        public AudioSource AudioSource;
        public float MinimumWait = 1f;
        public float MaximumWait = 15f;

        private void Start()
        {
            StartCoroutine(PlayRandomAudio());
        }

        private IEnumerator PlayRandomAudio()
        {
            while (true)
            {
                if (!AudioSource.isPlaying)
                {
                    AudioSource.clip = AudioClips[Random.Range(0, AudioClips.Length)];
                    AudioSource.Play();
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(MinimumWait, MaximumWait));
                }
            }
        }
    }
}
