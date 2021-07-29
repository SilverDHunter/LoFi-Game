using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        
    }

    #region Switching Cameras

    [Header ("Switching Cameras Controls")]

    /// <summary>
    /// Reference to the cinemachine brain.
    /// </summary>
    public CinemachineBrain cameraBrain;


    /// <summary>
    /// Detects when the player has crossed a camera collider and switches from prior camera to the new one.
    /// </summary>
    /// <param name = "other"></param>
    void OnTriggerEnter (Collider other)
    {
        print ("reEEEEE");

        if (other.gameObject.tag == "Player")
        {
            CinemachineVirtualCamera colliderCamera = gameObject.GetComponentInParent <CinemachineVirtualCamera>();
            colliderCamera.Priority = 20;
            print ("Has entered new camera field " + colliderCamera);
        }
    }

    /// <summary>
    /// Detects when the player has crossed a camera collider and switches from prior camera to the new one.
    /// </summary>
    /// <param name = "other"></param>
    void OnTriggerExit (Collider other)
    {
        print ("Reee-");

        if (other.gameObject.tag == "Player")
        {
            CinemachineVirtualCamera colliderCamera = gameObject.GetComponentInParent <CinemachineVirtualCamera>();
            colliderCamera.Priority = 10;
            print ("Has exited new camera field " + colliderCamera);
        }
    }

    #endregion Switching Cameras

    void Update()
    {
        
    }
}