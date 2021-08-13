using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        motor = GetComponent <Motor> ();
        playerAnimator = GetComponentInChildren <Animator> ();
    }

    #region NavMesh Navigation

    [Header ("NavMesh Navigation Controlls")]

    /// <summary>
    /// A reference to the main camera.
    /// </summary>
    public Camera mainCamera;

    /// <summary>
    /// A value representing the porcentage of the max speed that the player is moving at.
    /// </summary>
    public float speedPercent;

    /// <summary>
    /// Used to smooth transitions of speed withing the animator.
    /// </summary>
    public float smoothAnimations = 0.1f;

    /// <summary>
    /// A reference to the player's NavMeshAgent.
    /// </summary>
    public NavMeshAgent playerAgent;

    /// <summary>
    /// Reference to the layer mask that controls movement.
    /// </summary>
    public LayerMask movementMask;

    /// <summary>
    /// Reference to the motor script.
    /// </summary>
    public Motor motor;


    /// <summary>
    /// Controls everything related to navigating the NavMesh.
    /// </summary>
    public void NavMeshNavigation ()
    {
        Ray cameraRay;
        RaycastHit cameraHit;

        speedPercent = playerAgent.velocity.magnitude / playerAgent.speed;
        playerAnimator.SetFloat ("playerSpeed", speedPercent, smoothAnimations, Time.deltaTime);

        if (Input.GetMouseButtonDown (0))
        {
            cameraRay = mainCamera.ScreenPointToRay (Input.mousePosition);

            if (Physics.Raycast (cameraRay, out cameraHit, 100f, movementMask))
            {
                motor.MoveToPoint (cameraHit.point);
                print("Navmesh hit");
                playerAnimator.SetBool("IsWalking", true);
                RemoveFocus ();
            }
        }
    }

    #endregion NavMesh Navigation

    #region Walking Animation

    [Header ("Walking Animation Controlls")]
    [Space (10f)]

    /// <summary>
    /// Reference to the player animator.
    /// </summary>
    public Animator playerAnimator;

    #endregion Walking Animation

    #region Object Interaction

    [Header ("Object Interaction Controlls")]
    [Space(10f)]

    /// <summary>
    /// Reference to the layer mask that controls interactivity.
    /// </summary>
    public LayerMask interactionMask;

    /// <summary>
    /// The current interactable object the player is focused on.
    /// </summary>
    public Interactable focus;


    /// <summary>
    /// Function that registers that a player is trying to interact with objects.
    /// </summary>
    public void ObjectInteraction ()
    {
        Ray cameraRay;
        RaycastHit cameraHit;

        if (Input.GetMouseButtonDown (1))
        {

            cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out cameraHit, 100f, interactionMask))
            {
                Interactable interactable = cameraHit.collider.GetComponent <Interactable> ();

                if (interactable != null)
                {
                    SetFocus (interactable);
                }
            }
        }
    }


    /// <summary>
    /// Function that changes the focus from one to another.
    /// </summary>
    /// <param name = "newFocus"> The new object that the player will focus on. </param>
    public void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused ();
            }

            focus.OnDefocused();
            focus = newFocus;
            motor.FollowTarget (newFocus);
        }

        newFocus.OnFocused (transform);
    }


    /// <summary>
    /// Sets the focus to null for movement.
    /// </summary>
    public void RemoveFocus ()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }

        focus = null;
        focus.OnDefocused ();
        motor.StopFollowingTarget ();
    }

    #endregion Object Interaction

    void Update()
    {
        NavMeshNavigation ();
        ObjectInteraction ();
    }
}