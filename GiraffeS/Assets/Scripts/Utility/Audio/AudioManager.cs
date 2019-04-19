using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioFile[] audioFiles;

    private float timeToReset;

    private bool timerIsSet = false;

    private string tmpName;

    private float tmpVol;

    private bool isLowered = false;

    private bool fadeOut = false;

    private bool fadeIn = false;

    private string fadeInUsedString;

    public AudioMixer Mixer; 

    private string fadeOutUsedString;

    void Awake()
    {
        if (instance == null)
        {

            instance = this;

        }

        else if (instance != this)
        {

            Destroy(gameObject);

        }

        DontDestroyOnLoad(gameObject);

        foreach (var s in audioFiles)
        {

            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.audioClip;

            s.source.volume = s.volume;

            s.source.loop = s.isLooping;

            if (s.playOnAwake)
            {
                s.source.Play();
            }

        }
    }
    public void Play(string name)
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null)
        {

            Debug.LogError("Sound name" + name + "not found!");

            return;

        }

        else
        {

            s.source.Play();

        }

    }

    public void StopMusic(string name)
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null)
        {

            Debug.LogError("Sound name" + name + "not found!");

            return;

        }

        else
        {

            s.source.Stop();

        }

    }

    public void PauseMusic(string name)
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null)
        {

            Debug.LogError("Sound name" + name + "not found!");

            return;

        }

        else
        {

            s.source.Pause();

        }

    }

    public void UnPauseMusic(string name)
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null)
        {

            Debug.LogError("Sound name" + name + "not found!");

            return;

        }

        else
        {

            s.source.UnPause();

        }

    }

    public void LowerVolume(string name, float _duration)
    {

        if (instance.isLowered == false)
        {

            AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

            if (s == null)
            {

                Debug.LogError("Sound name" + name + "not found!");

                return;

            }

            else
            {

                instance.tmpName = name;

                instance.tmpVol = s.volume;

                instance.timeToReset = Time.time + _duration;

                instance.timerIsSet = true;

                s.source.volume = s.source.volume / 3;

            }

            instance.isLowered = true;

        }
    }

    public static void FadeOut(string name, float duration)
    {

        instance.StartCoroutine(instance.IFadeOut(name, duration));

    }

    public static void FadeIn(string name, float targetVolume, float duration)
    {

        instance.StartCoroutine(instance.IFadeIn(name, targetVolume, duration));

    }

    //not for use ??
    private IEnumerator IFadeOut(string name, float duration)
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null)
        {

            Debug.LogError("Sound name" + name + "not found!");
            yield return null;

        }

        else
        {

            if (fadeOut == false)
            {

                fadeOut = true;

                float startVol = s.source.volume;

                fadeOutUsedString = name;

                while (s.source.volume > 0)
                {

                    s.source.volume -= startVol * Time.deltaTime / duration;
                    yield return null;

                }

                s.source.Stop();

                yield return new WaitForSeconds(duration);

                fadeOut = false;

            }

            else
            {

                Debug.LogError("Could not handle two fade outs at once : " + name + " , " + fadeOutUsedString + "! Stopped the music " + name);

                StopMusic(name);

            }

        }

    }

    private IEnumerator IFadeIn(string name, float targetVolume, float duration)
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == name);

        if (s == null)
        {

            Debug.LogError("Sound name" + name + "not found!");
            yield return null;

        }

        else
        {

            if (fadeIn == false)
            {

                fadeIn = true;

                instance.fadeInUsedString = name;

                s.source.volume = 0f;

                s.source.Play();

                while (s.source.volume < targetVolume)
                {

                    s.source.volume += Time.deltaTime / duration;
                    yield return null;

                }

                yield return new WaitForSeconds(duration);

                fadeIn = false;

            }

            else
            {

                Debug.LogError("Could not handle two fade ins at once : " + name + " , " + fadeInUsedString + "! Played the music " + name);

                StopMusic(fadeInUsedString);

                Play(name);

            }

        }

    }

    void ResetVol()
    {

        AudioFile s = Array.Find(instance.audioFiles, AudioFile => AudioFile.audioName == tmpName);

        s.source.volume = tmpVol;

        isLowered = false;

    }

    private void Update()
    {

        if(Time.time >= timeToReset && timerIsSet)
        {

            ResetVol();

            timerIsSet = false;

        }

    }


}