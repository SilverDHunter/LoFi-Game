using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidWobble : MonoBehaviour
{
    void Start()
    {
        rend = GetComponent <Renderer>();
    }

    #region Wobble

    /// <summary>
    /// Reference to the renderer.
    /// </summary>
    public Renderer rend;

    /// <summary>
    /// The maximum the liquid can wobble.
    /// </summary>
    [Range (0f, 1f)]
    public float maxWobble = 0.3f;

    /// <summary>
    /// The speed of the wobble.
    /// </summary>
    public float wobbleSpeed = 1f;

    /// <summary>
    /// 
    /// </summary>
    public float recovery = 1f;

    /// <summary>
    /// 
    /// </summary>
    public float time = 0.5f;

    /// <summary>
    /// 
    /// </summary>
    private Vector3 lastPos;

    /// <summary>
    /// 
    /// </summary>
    private Vector3 velocity;

    /// <summary>
    /// 
    /// </summary>
    private Vector3 lastRot;

    /// <summary>
    /// 
    /// </summary>
    private Vector3 angularVelocity;

    /// <summary>
    /// 
    /// </summary>
    private float wobbleAmountX;

    /// <summary>
    /// 
    /// </summary>
    private float wobbleAmountZ;

    /// <summary>
    /// 
    /// </summary>
    private float wobbleAmountToAddX;

    /// <summary>
    /// 
    /// </summary>
    private float wobbleAmountToAddZ;

    /// <summary>
    /// 
    /// </summary>
    private float pulse;


    /// <summary>
    /// Function that makes the liquid within a container wobble.
    /// </summary>
    public void Wobble ()
    {
        time += Time.deltaTime;

        // decrease wobble over time
        wobbleAmountToAddX = Mathf.Lerp (wobbleAmountToAddX, 0, Time.deltaTime * (recovery));
        wobbleAmountToAddZ = Mathf.Lerp (wobbleAmountToAddZ, 0, Time.deltaTime * (recovery));

        // make a sine wave of the decreasing wobble
        pulse = 2 * Mathf.PI * wobbleSpeed;
        wobbleAmountX = wobbleAmountToAddX * Mathf.Sin(pulse * time);
        wobbleAmountZ = wobbleAmountToAddZ * Mathf.Sin(pulse * time);

        // send it to the shader
        rend.material.SetFloat ("_WobbleX", wobbleAmountX);
        rend.material.SetFloat ("_WobbleZ", wobbleAmountZ);

        // velocity
        velocity = (lastPos - transform.position) / Time.deltaTime;
        angularVelocity = transform.rotation.eulerAngles - lastRot;


        // add clamped velocity to wobble
        wobbleAmountToAddX += Mathf.Clamp((velocity.x + (angularVelocity.z * 0.2f)) * maxWobble, -maxWobble, maxWobble);
        wobbleAmountToAddZ += Mathf.Clamp((velocity.z + (angularVelocity.x * 0.2f)) * maxWobble, -maxWobble, maxWobble);

        // keep last position
        lastPos = transform.position;
        lastRot = transform.rotation.eulerAngles;
    }

    #endregion Wobble

    void Update()
    {
        Wobble ();
    }
}