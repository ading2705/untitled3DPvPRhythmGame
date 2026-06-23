using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioObject
{
    public AudioClip clip;
    public string name;
    public bool repeating;
}

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioObject[] audio;

    public void Play(string name)
    {
        foreach (AudioObject obj in audio)
        {
            if (obj.name == name)
            {
                if (!obj.repeating)
                {
                    source.PlayOneShot(obj.clip);
                    return;
                }
                else
                {
                    source.Stop();
                    source.clip = obj.clip;
                    source.Play();
                    source.loop = true;
                    return;
                }
            }
        }
        Debug.Log("Couldn't find audio " + name);
    }
}
