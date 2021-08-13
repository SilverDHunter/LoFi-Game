using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    void Start()
    {
        playerModels = new List<GameObject> ();
    }

    #region Player Spawner

    [Header ("Player Spawner Controlls")]

    /// <summary>
    /// A list of available models to use.
    /// </summary>
    public List <GameObject> playerModels;

    /// <summary>
    /// The gameobject that holds the charecters.
    /// </summary>
    public GameObject playerRoster;

    /// <summary>
    /// The spawnpoint.
    /// </summary>
    public GameObject spawnPoint;

    /// <summary>
    /// The default selection index for the charecter selection screen.
    /// </summary>
    public int playerSelectionIndex = 0;

    #endregion Player Spawner

    void Update()
    {
        foreach (Transform t in playerRoster.transform)
        {
            playerModels.Add(t.gameObject);
            t.gameObject.SetActive(false);
        }

        playerSelectionIndex = PlayerPrefs.GetInt("CharecterSelected");
        playerModels[playerSelectionIndex].SetActive(true);
    }
}