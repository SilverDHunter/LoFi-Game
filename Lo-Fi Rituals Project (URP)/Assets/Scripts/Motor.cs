using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Motor : MonoBehaviour
{
    void Start()
    {
        navAgent = GetComponent <NavMeshAgent>();
    }

    #region Motor

    [Header ("Motor Controlls")]

    /// <summary>
    /// Reference to the NavMeshAgent.
    /// </summary>
    public NavMeshAgent navAgent;

    /// <summary>
    /// 
    /// </summary>
    public float followRadius = 0.8f;

    /// <summary>
    /// The target to follow.
    /// </summary>
    private Transform target;


    /// <summary>
    /// Directs the object through the NavMesh towards a destination.
    /// </summary>
    /// <param name = "destination" > The destination of the object. </param>
    public void MoveToPoint (Vector3 destination)
    {
        navAgent.SetDestination (destination);
    }


    /// <summary>
    /// Asigns a target to follow.
    /// </summary>
    /// <param name = "newTarget" > The new target to follow. </param>
    public void FollowTarget (Interactable newTarget)
    {
        navAgent.stoppingDistance = newTarget.interactRadius * followRadius;
        navAgent.updateRotation = false;

        target = newTarget.interactionTransform;
    }


    /// <summary>
    /// Sets target to null.
    /// </summary>
    public void StopFollowingTarget ()
    {
        navAgent.stoppingDistance = 0f;
        navAgent.updateRotation = true;

        target = null;
    }


    /// <summary>
    /// Makes sure that the player is facing the target correctly.
    /// </summary>
    public void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    #endregion Motor

    void Update()
    {
        if (target != null)
        {
            navAgent.SetDestination(target.position);
            FaceTarget ();
        }
    }
}