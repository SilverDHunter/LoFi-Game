using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        
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
                playerAgent.SetDestination (cameraHit.point);
            }
        }
    }

    #endregion NavMesh Navigation

    #region NavMesh Interaction

    [Header ("NavMesh Interaction Controlls")]
    [Space (10f)]

    /// <summary>
    /// Reference to the layer mask that controls interactivity.
    /// </summary>
    public LayerMask interactionMask;

    /// <summary>
    /// Controls everything related to interacting with objects within the NavMesh.
    /// </summary>
    public void NavMeshInteraction ()
    {
        Ray cameraRay;
        RaycastHit cameraHit;

        if (Input.GetMouseButtonDown (1))
        {

            cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out cameraHit, movementMask))
            {
                playerAnimator.SetBool ("IsWalking", true);
            }
        }
    }

    #endregion NavMesh Interaction

    #region Walking Animation

    [Header ("Walking Animation Controlls")]
    [Space (10f)]

    /// <summary>
    /// Reference to the player animator.
    /// </summary>
    public Animator playerAnimator;

    #endregion Walking Animation

    void Update()
    {
        NavMeshNavigation ();
        NavMeshInteraction (); 
    }
}