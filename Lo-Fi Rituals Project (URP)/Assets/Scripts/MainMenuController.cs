using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenuController : MonoBehaviour
{
    private void Awake ()
    {
        director.played += DirectorPlayed;
    }

    #region Main Menu

    // [Header ("Main Menu Controlls")]


    /// <summary>
    /// Allows the quit buttons to quit the game.
    /// </summary>
    public void QuitGame ()
    {
        Debug.Log ("Quit works.");
        Application.Quit ();
    }

    #endregion Main Menu

    #region Starting Game

    [Header("Game Start Controlls")]
    [Space(10f)]

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
    private void DirectorPlayed(PlayableDirector obj)
    {
        mainMenuCanvas.SetActive(false);
    }

    #endregion Starting Game
}
