using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    void Start()
    {
        
    }

    #region Interactable

    [Header ("Interaction Controlls")]

    /// <summary>
    /// The distance required for the player to interact with the object.
    /// </summary>
    public float interactRadius;

    /// <summary>
    /// Determines if the object is close enough to be interacted with. By default, its false.
    /// </summary>
    public bool isFocused = false;

    /// <summary>
    /// Checks if the object is being interacted with. False by default.
    /// </summary>
    public bool hasInteracted = false;

    /// <summary>
    /// The transform from which the item is interactable with.
    /// </summary>
    public Transform interactionTransform;

    /// <summary>
    /// The transform of the player.
    /// </summary>
    private Transform player;


    /// <summary>
    /// Draws gismos to visualize the values here.
    /// </summary>
    public void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (interactionTransform.position, interactRadius);

        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }
    }


    /// <summary>
    /// Determines if the object is being focuesd by the player.
    /// </summary>
    /// <param name = "playersTransform"> The players transform coordinates. </param>
    public void OnFocused (Transform playersTransform)
    {
        isFocused = true;
        player = playersTransform;
        hasInteracted = false;
    }


    /// <summary>
    /// Determines if the object has been defocused by the player.
    /// </summary>
    public void OnDefocused ()
    {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }


    /// <summary>
    /// This method is meant to be overwriten with the actual code of each individual interactive object.
    /// </summary>
    public virtual void Interact ()
    {
        Debug.Log ("Interactive with " + transform.name);
    }

    #endregion Interactable

    void Update()
    {
        if (isFocused && !hasInteracted)
        {
            float distance = Vector3.Distance (player.position, interactionTransform.position);

            if (distance <= interactRadius)
            {
                Interact ();
                hasInteracted = true;
            }
        }
    }
}
