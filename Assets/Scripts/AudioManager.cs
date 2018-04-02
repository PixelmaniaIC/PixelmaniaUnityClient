using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public List<Sound> sounds;

	void Awake()
    {
        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
        }
    }

    public void Play(string name)
    {
        Sound sound = sounds.Find(s => s.name == name);

        if (sound == null)
        {
            Debug.Log("Audio file wasn't found");
            return;
        }

        sound.source.Play();
    }
}
