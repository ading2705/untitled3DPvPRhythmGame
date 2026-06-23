using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AudioType
{
    UIMusic,
    GameMusic,
    UIEffect,
    GameEffect
};

public class AudioController : MonoBehaviour
{
    private static AudioController _instance;
    public static AudioController Instance { get { return _instance; } }

    [SerializeField] AudioPlayer gameMusicAudio;
    [SerializeField] AudioPlayer UIBackgroundAudio;
    [SerializeField] AudioPlayer gameEffectAudio;
    [SerializeField] AudioPlayer UIEffectAudio;


    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PlayAudio(AudioType type, string name)
    {
        switch (type)
        {
            case AudioType.UIMusic:
                UIBackgroundAudio.Play(name);
                break;
            case AudioType.GameMusic:
                gameMusicAudio.Play(name);
                break;
            case AudioType.UIEffect:
                gameEffectAudio.Play(name);
                break;
            case AudioType.GameEffect:
                gameEffectAudio.Play(name);
                break;
            default:
                Debug.LogError("tried to play" + type + "clip " + name);
                break;
        }
    }
}
