using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class UISettings : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioMixer audioMixer;
    public Slider volumeSlider;

    [Header("Resolution Settings")]
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] resolutions;

    [Header("Quality Settings")]
    public TMP_Dropdown qualityDropdown;

    private void Start()
    {
        InitializeAudioSettings();
        //InitializeResolutionSettings();
        //InitializeQualitySettings();
    }

    private void InitializeAudioSettings()
    {
        if (audioMixer == null || volumeSlider == null)
        {
            Debug.LogError("AudioMixer or Volume Slider is not assigned!");
            return;
        }

        // Set the initial volume based on the saved settings or a default value
        float savedVolume;
        if (PlayerPrefs.HasKey("Volume"))
        {
            savedVolume = PlayerPrefs.GetFloat("Volume");
        }
        else
        {
            savedVolume = 0.75f; // Default volume level
            PlayerPrefs.SetFloat("Volume", savedVolume);
        }

        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);
    }


    public void SetVolume(float volume)
    {
        if (audioMixer != null)
        {
            audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("Volume", volume); // Save volume level
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogError("AudioMixer is not assigned!");
        }
    }

    /*private void InitializeResolutionSettings()
    {
        if (resolutionDropdown == null)
        {
            Debug.LogError("Resolution Dropdown is not assigned!");
            return;
        }

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;
        string[] options = new string[resolutions.Length];
        for (int i = 0; i(options)) ;
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }*/

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    /*private void InitializeQualitySettings()
    {
        if (qualityDropdown == null)
        {
            Debug.LogError("Quality Dropdown is not assigned!");
            return;
        }

        qualityDropdown.ClearOptions();

        string[] qualityNames = QualitySettings.names;
        qualityDropdown.AddOptions(new System.Collections.Generic.List(qualityNames));
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }*/

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}