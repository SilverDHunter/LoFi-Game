using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerUsername : MonoBehaviour
{
    void Start ()
    {
        DontDestroyOnLoad (this); // Prevents the script from getting eliminated, and thus will always be present.
        usernameHackInstance = this;

        userName = System.Environment.UserName; //
    }

    #region Accessing Username

    /// <summary>
    /// Reference to this code that can be used everywhere.
    /// </summary>
    public static GetPlayerUsername usernameHackInstance;

    /// <summary>
    /// The username of the player.
    /// </summary>
    public string userName;

    #endregion Accessing Username

    void Update ()
    {
        
    }
}
