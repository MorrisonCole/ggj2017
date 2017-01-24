using UnityEngine;

public class PlaySoundClipOnButtonDown : MonoBehaviour
{
    public AudioSource AudioSource;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioSource.Play();
        }
    }
}
