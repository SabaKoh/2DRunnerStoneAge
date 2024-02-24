using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private List<AudioHandler> audioHandlers;

    public void StopAudio(string name)
    {
        var audio = audioHandlers.FirstOrDefault(x => x.name == name);

        if (audio == null)
        {
            Debug.LogWarning("Can Not Find Audio");
            return;
        }

        if (!audio.Source.isPlaying) return;
        audio.Source.Stop();
    }

    public void PlayAudio(string name)
    {
        var audio = audioHandlers.FirstOrDefault(x => x.name == name);

        if (audio == null)
        {
            Debug.LogWarning("Can Not Find Audio");
            return;
        }

        if (audio.Source.isPlaying) return;
        audio.Source.clip = audio.Clip;
        audio.Source.Play();
    }

    [System.Serializable]
    public class AudioHandler
    {
        public string name;
        public AudioClip Clip;
        public AudioSource Source;
    }
}
