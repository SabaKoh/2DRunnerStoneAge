using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [SerializeField] private AudioClip Walkingclip;
    [SerializeField] private AudioClip Coinclip;

    public void StopWalkingSound()
    {
        if (!audioSource.isPlaying) return;
        
        audioSource.clip = Walkingclip;
        audioSource.Stop();
    }

    public void WalkingSound()
    {
        if (audioSource.isPlaying) return;

        audioSource.clip = Walkingclip;
        audioSource.Play();
    }

    public void CoinSound()
    {
        audioSource.clip = Coinclip;
        audioSource.Play();
    }
}
