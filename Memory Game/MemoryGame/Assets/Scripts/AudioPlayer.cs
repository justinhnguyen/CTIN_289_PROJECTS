using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public float initialDelay = 15f;  // Delay before the first audio play
    public float delayBetweenPlays = 15f;

    private void Start()
    {
        // Start the coroutine with an initial delay
        StartCoroutine(PlayAudioAfterDelay());
    }

    private IEnumerator PlayAudioAfterDelay()
    {
        yield return new WaitForSeconds(initialDelay);

        // Start playing the audio every 15 seconds
        while (true)
        {
            // Play the audio
            audioSource.Play();

            // Wait for the specified delay before playing again
            yield return new WaitForSeconds(delayBetweenPlays);
        }
    }
}
