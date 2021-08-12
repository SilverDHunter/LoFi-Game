using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Playables;

public class MainMenuController : MonoBehaviour
{
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
}
