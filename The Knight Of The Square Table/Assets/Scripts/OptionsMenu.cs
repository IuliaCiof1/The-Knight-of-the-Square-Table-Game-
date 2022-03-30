using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public Slider musicSlider;
    public AudioMixer audioMixer;
    float value;

    private void Start() //set music volume from preveous game (save)
    {
        audioMixer.GetFloat("Music", out value);
        musicSlider.value = value;
    }

    public void SetMusic()
    {
        audioMixer.SetFloat("Music", musicSlider.value);
    }
}
