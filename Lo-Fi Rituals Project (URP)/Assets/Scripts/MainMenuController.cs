using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenuController : MonoBehaviour
{
    void Awake()
    {
        director.played += DirectorPlayed;
    }

    #region Main Menu

    [Header ("Main Menu Controlls")]

    public GameObject mainMenuCanvas;
    
    /// <summary>
    /// A reference to the playable director
    /// </summary>
    public PlayableDirector director;


    /// <summary>
    /// Allows the play button to start the game and the begining cinematic.
    /// </summary>
    public void PlayGame ()
    {
        StartTimeline ();
    }


    /// <summary>
    /// Function that starts the opening cinematic.
    /// </summary>
    public void StartTimeline ()
    {
        director.Play ();
    }


    /// <summary>
    /// Allows the quit buttons to quit the game.
    /// </summary>
    public void QuitGame ()
    {
        Debug.Log ("Quit works.");
        Application.Quit ();
    }


    private void DirectorPlayed (PlayableDirector obj)
    {
        mainMenuCanvas.SetActive (false);
    }

    #endregion Main Menu
}
