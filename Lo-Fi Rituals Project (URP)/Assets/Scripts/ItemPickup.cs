using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    void Start()
    {
        
    }

    #region Item Pickup

    [Header ("Item Pickup Controlls")]

    /// <summary>
    /// Reference to scriptable items.
    /// </summary>
    public Item item;


    /// <summary>
    /// Overrides the Interact void in Interactable script.
    /// </summary>
    public override void Interact ()
    {
        base.Interact ();

        PickingUpItem ();
    }


    /// <summary>
    /// The function in charge of letting the player pick the item up.
    /// </summary>
    public void PickingUpItem ()
    {
        bool wasPickedUp = Inventory.instance.AddItem (item);

        if (wasPickedUp)
        {
            Destroy (gameObject);
        }
    }

    #endregion Item Pickup

    void Update()
    {
        
    }
}