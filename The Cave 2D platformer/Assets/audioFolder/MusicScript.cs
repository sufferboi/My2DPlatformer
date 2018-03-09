using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour {

    public Slider volume;
    public AudioSource backgroundMusic;

    void Update()
    {
        backgroundMusic.volume = volume.value;  
    }

}
