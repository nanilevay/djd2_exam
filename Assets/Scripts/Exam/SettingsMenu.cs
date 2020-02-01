using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    void Start()
    {

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentRes = resolutions.Length-1;

        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;

            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentRes = i;
            }
        }

        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = currentRes;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetRes(int res)
    {
        Resolution resolution = resolutions[res];

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void SetFullScreen(bool isFullScren)
    {
        Screen.fullScreen = isFullScren;
    }
}
