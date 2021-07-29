using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class PauseMenuController : MonoBehaviour
{
    #region Pause Menu

    [Header ("Pause Menu Controlls")]

    public GameObject pauseMenuCanvas;


    /// <summary>
    /// Allows the play button to start the game and the begining cinematic.
    /// </summary>
    public void ResumeGame()
    {
        
    }


    /// <summary>
    /// Allows the quit buttons to quit the game.
    /// </summary>
    public void QuitGame()
    {
        Debug.Log ("Quit works.");
        Application.Quit ();
    }

    #endregion Pause Menu
}
