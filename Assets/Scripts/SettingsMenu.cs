using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public Dropdown dropdown;
    Resolution[] resolutions;

    public Slider sliderMusic;
    public Slider slidersound;

    private void Start()
    {
        audiomixer.GetFloat("MusicVolume", out float audiomusic);
        sliderMusic.value = audiomusic;
        audiomixer.GetFloat("SoundVolume", out float audiosound);
        slidersound.value = audiosound;
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width = resolution.width, height = resolution.height }).Distinct().ToArray();
        dropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "*" + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        dropdown.AddOptions(options);
        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    public void SetSoundVolume(float volume)
    {
        audiomixer.SetFloat("SoundVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audiomixer.SetFloat("MusicVolume", volume);
    }
    public void SetFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;
    }
    
    public void SetResolution(int resolutionindex)
    {
        Resolution resolution = resolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height , Screen.fullScreen);
    }

    public void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
   
}
