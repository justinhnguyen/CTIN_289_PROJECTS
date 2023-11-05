using UnityEngine;
using System.Collections; // Add this line

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public float delayBetweenPlays = 15f;

    private void Start()
    {
        // Start the coroutine to play the audio every 15 seconds
        StartCoroutine(PlayAudioRepeatedly());
    }

    private IEnumerator PlayAudioRepeatedly()
    {
        while (true)
        {
            // Play the audio
            audioSource.Play();

            // Wait for the specified delay before playing again
            yield return new WaitForSeconds(delayBetweenPlays);
        }
    }
}
