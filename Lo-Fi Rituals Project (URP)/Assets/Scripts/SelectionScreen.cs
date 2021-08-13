using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour
{
    void Start ()
    {
        models = new List<GameObject>();

        foreach (Transform t in charectersRoster.transform)
        {
            models.Add(t.gameObject);
            t.gameObject.SetActive (false);
        }

        models[selectionIndex].SetActive(true);

        voidIndex = 0;
    }

    #region Selection Screen

    [Header ("Selection Screen Controlls")]

    /// <summary>
    /// A list of available models to use.
    /// </summary>
    public List<GameObject> models;

    /// <summary>
    /// The default selection index for the charecter selection screen.
    /// </summary>
    public int selectionIndex = 0;

    /// <summary>
    /// The universal index for both voids to use.
    /// </summary>
    public int voidIndex;

    /// <summary>
    /// The gameobject that holds the charecters.
    /// </summary>
    public GameObject charectersRoster;


    /// <summary>
    /// Shows the next charecter.
    /// </summary>
    public void NextCharecter ()
    {
        voidIndex += 1;

        if (voidIndex == selectionIndex)
        {
            return;
        }

        if (voidIndex < 0)
        {
            return;
        }

        if (voidIndex >= models.Count)
        {
            voidIndex = models.Count;
        }

        models [selectionIndex].SetActive(false);
        selectionIndex = voidIndex;
        models[selectionIndex].SetActive(true);
    }


    /// <summary>
    /// Shows the previous charecter.
    /// </summary>
    public void PreviousCharecter ()
    {
        voidIndex -= 1;

        if (voidIndex == selectionIndex)
        {
            return;
        }

        if (voidIndex < 0)
        {
            return;
        }

        if (voidIndex >= models.Count)
        {
            voidIndex = models.Count;
        }

        models[selectionIndex].SetActive(false);
        selectionIndex = voidIndex;
        models[selectionIndex].SetActive(true);
    }


    /// <summary>
    /// Confirms the prefab to be used.
    /// </summary>
    public void ConfirmSelection ()
    {
        PlayerPrefs.SetInt("CharecterSelected", voidIndex);
    }

    #endregion Selection Screen

    void Update()
    {
        
    }
}