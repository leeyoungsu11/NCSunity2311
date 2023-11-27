using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] allSoundSource_BGM;
    public AudioClip[] allSoundSource_Effect;

    public AudioSource BGM;
    public AudioSource[] Effects;

    public void SetSoundBGM(int songNum, Vector3 vec)
    {
        BGM.clip = allSoundSource_BGM[songNum];
        BGM.transform.position = vec;
        BGM.gameObject.SetActive(true);
        BGM.Play();
    }
    public void StopSound()
    {
        BGM.Stop();
    }
    public void Pause(bool ison)
    {
        if(ison)
        {
            BGM.Pause();
        }
        else
        {
            BGM.UnPause();
        }
    }
    public void SetSoundEffect(int songNum, Vector3 vec)
    {
        if(Effects[0].isPlaying)
        {
            Effects[1].transform.position = vec;
            Effects[1].gameObject.SetActive(true);
            Effects[1].PlayOneShot(allSoundSource_Effect[songNum]);
        }
        else
        {
            Effects[0].transform.position = vec;
            Effects[0].gameObject.SetActive(true);
            Effects[0].PlayOneShot(allSoundSource_Effect[songNum]);
        }
        
    }
}
