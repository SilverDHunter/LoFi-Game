using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class CharecterSelectionScreen : MonoBehaviour
{
    void Awake ()
    {
        director.played += DirectorPlayed;
    }

    #region Character Selection Screen

    [Header ("Charecter Selection Screen Controlls")]

    /// <summary>
    /// An array containing all charecter prefabs.
    /// </summary>
    public GameObject [] characters;

    /// <summary>
    /// An int used to indicate which prefab was selected.
    /// </summary>
    public int selectedCharacter = 0;


    /// <summary>
    /// Moves the UI to the next charecter.
    /// </summary>
    public void NextCharacter ()
    {
        characters [selectedCharacter].SetActive (false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters [selectedCharacter].SetActive (true);
    }


    /// <summary>
    /// Moves the UI to the previous charecter.
    /// </summary>
    public void PreviousCharacter ()
    {
        characters [selectedCharacter].SetActive (false);
        selectedCharacter--;

        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }

        characters [selectedCharacter].SetActive (true);
    }

    #endregion Character Selection Screen

    #region Starting Game

    [Header ("Game Start Controlls")]
    [Space (10f)]

    /// <summary>
    /// A reference to the playable director
    /// </summary>
    public PlayableDirector director;

    /// <summary>
    /// A reference to the Main Menu UI Canvas.
    /// </summary>
    public GameObject mainMenuCanvas;


    /// <summary>
    /// Allows the play button to start the game and the begining cinematic.
    /// </summary>
    public void PlayGame()
    {
        PlayerPrefs.SetInt ("selectedCharacter", selectedCharacter);
        StartTimeline();
    }


    /// <summary>
    /// Function that starts the opening cinematic.
    /// </summary>
    public void StartTimeline()
    {
        director.Play();
    }


    /// <summary>
    /// Turns off the main menu when the intro cinematic plays.
    /// </summary>
    /// <param name = "obj"> The playable director responsible for the intro cinematic. </param>
    private void DirectorPlayed (PlayableDirector obj)
    {
        mainMenuCanvas.SetActive (false);
    }

    #endregion Starting Game
}