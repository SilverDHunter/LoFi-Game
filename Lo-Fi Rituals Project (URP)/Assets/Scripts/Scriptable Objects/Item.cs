using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "New Item", menuName = "Interaction/Item")]
public class Item : ScriptableObject
{
    #region Item Scriptable Object

    [Header ("Object Components")]

    /// <summary>
    /// The name of the object
    /// </summary>
    new public string name = "New Item";

    /// <summary>
    /// The icon of the object.
    /// </summary>
    public Sprite icon = null;

    /// <summary>
    /// Indicates if the item is default equipment or not. False by default.
    /// </summary>
    public bool isDefaultItem = false;

    #endregion Item Scriptable Object
}