using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt ("selectedCharacter");
        GameObject prefab = characterPrefabs [selectedCharacter];
        GameObject clone = Instantiate (prefab, spawnPoint.position, Quaternion.identity);
    }

    #region Load Character

    [Header ("Character Loader Controlls")]

    /// <summary>
    /// An array of character prefabs.
    /// </summary>
    public GameObject [] characterPrefabs;

    /// <summary>
    /// The point in the scene where the character spawns.
    /// </summary>
    public Transform spawnPoint;

    #endregion Load Character
}