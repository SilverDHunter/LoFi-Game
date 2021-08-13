using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    void Start()
    {
        SettingResolutionOptions ();
    }

    #region Presets

    /// <summary>
    /// Sets the quality preset that the game will run on.
    /// </summary>
    /// <param name = "qualityIndex"> The index of which quality level we want. </param>
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel (qualityIndex);
    }

    #endregion Presets

    #region Volume

    [Header ("Volume Controlls")]

    /// <summary>
    /// A reference to the master audio mixer.
    /// </summary>
    public AudioMixer masterMixer;

    /// <summary>
    /// A reference to the text in the menu that shows the porcentage of the audio.
    /// </summary>
    public TextMeshProUGUI audioLevelText;


    /// <summary>
    /// Controls the volume of the game.
    /// </summary>
    /// <param name = "volume"> The volume the slider will be set to. </param>
    public void SetVolume (float volume)
    {
        masterMixer.SetFloat("masterVolume", Mathf.Log (volume) * 20);
        audioLevelText.text = Mathf.FloorToInt (volume * 100) + "%";
    }

    #endregion Volume

    #region Render Resolution

    [Header ("Fullscreen Controlls")]
    [Space (10f)]

    /// <summary>
    /// An array of resolutions available to the player.
    /// </summary>
    public Resolution [] resolutions;

    /// <summary>
    /// A reference to the UI dropdown menu showing the available resolutions.
    /// </summary>
    public TMP_Dropdown resolutionsDropdown;


    /// <summary>
    /// Updates the resolutions dropdown with the currently available resolutions.
    /// </summary>
    public void SettingResolutionOptions ()
    {
        resolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List <string> resolutionOptions = new List<string> (); // A list of resolution options to be used by the resolutions array and asosciated dropdown.

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resolutionOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionsDropdown.AddOptions(resolutionOptions);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }


    /// <summary>
    /// Sets screen resolution to the selected option.
    /// </summary>
    /// <param name = "resolutionIndex"> The index for the selected screen resolution. </param>
    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions [resolutionIndex];
        Screen.SetResolution (resolution.width, resolution.height, Screen.fullScreen);
    }

    #endregion Render Resolution

    #region Fullscreen Toggle

    /// <summary>
    /// Controls if the game is in fullscreen or not.
    /// </summary>
    /// <param name = "isFullscreen"> Boolean that determines if fullscreen is true or not. </param>
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    #endregion Fullscreen Toggle

    #region Anti-Aliasing



    #endregion Anti-Aliasing

    void Update()
    {
        
    }
}