using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsMenu : MonoBehaviour {

    public Dropdown DropdownResolution; 

    //array named resolutions.
    Resolution[] resolutions;

    //all procedures within this function occur when application opens.
    private void Start()
    {
        resolutions = Screen.resolutions;

        DropdownResolution.ClearOptions();

        //create a new list of all possible resolutions needed.
        List<string> resOptions = new List<string>();
        int CurrentResolutionIndex = 0;

        //loop that allows players to change resolution as many times as possible.
        for (int i = 0; i < resolutions.Length; i++)
        {
            string resOption = resolutions[i].width + "x" + resolutions[i].height;
            resOptions.Add(resOption);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                CurrentResolutionIndex = i;
            }
        }

        //adds all possible resolutions to the dropdown bar.
        DropdownResolution.AddOptions(resOptions);
        //the value seen by the user on the dropdown bar = current resolution of game.
        DropdownResolution.value = CurrentResolutionIndex;
        //this updates the shown resolution when a change is made.
        DropdownResolution.RefreshShownValue();
    }

    //This function simply sets the resolution by calling upon the array Resolution[] which finds the current resolution index
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        //this draws the link between the resolutions in dropdown and the resolution index.
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);

    }



    //function that calls upon an Audiomixer names 'audioMixer'.
    public AudioMixer audioMixer;

    //Function that sets volume of music depending on float value of slider.
    public void SetVolume (float volume)
    {
        //This links the audioMixer to the float value and volume.
        audioMixer.SetFloat("volume", volume);
    }

    //allows user to change the detail/quality of game.
    public void ChangeQuality(int qualityIndex)
    {
        //changes quality index value depending on quality selected.
        //e.g. qualityindex(0) = low, quality index(3) = ultra.
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //bool value because it is either fullscreen or !fullscreen.
    public void SetFullscreen(bool isFullscreen)
    {
        //allows user to toggle from fullscreen to !fullscreen.
        Screen.fullScreen = isFullscreen;
    }
}
