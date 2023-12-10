using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] numberSounds; 
    private AudioSource audioSource;
    private int currentNumber = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayNextNumberSound()
    {
        if (currentNumber < numberSounds.Length)
        {
            audioSource.clip = numberSounds[currentNumber];
            audioSource.Play();
            currentNumber++;
        }
    }
}
