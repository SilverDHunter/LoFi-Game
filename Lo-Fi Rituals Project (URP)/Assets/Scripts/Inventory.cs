using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    void Start ()
    {
        
    }

    #region Singleton

    public static Inventory instance;


    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("There is more than one instance of the inventory script!");
            return;
        }

        instance = this;
    }

    #endregion Singleton

    #region Inventory

    [Header ("Inventory Controlls")]

    /// <summary>
    /// A list of items in the inventory.
    /// </summary>
    public List <Item> items = new List <Item> ();

    /// <summary>
    /// The amount of items that can be put into the inventory. By default, there are two items.
    /// </summary>
    public int space = 2;

    /// <summary>
    /// Delegate that tracks the flow of objects in the inventory.
    /// </summary>
    public delegate void OnItemChanged ();

    /// <summary>
    /// A callback to the OnItemChanged delegate.
    /// </summary>
    public OnItemChanged onItemChangedCallback;


    /// <summary>
    /// Adds an item to the items list. Doesnt add item if the inventory is full.
    /// </summary>
    /// <param name = "item"> The item to be added to list. </param>
    public bool AddItem (Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log ("Can't add item, inventory is full.");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallback != null)
            {
                onItemChangedCallback.Invoke();
            }
        }

        return true;
    }


    /// <summary>
    /// Removes item from the items list.
    /// </summary>
    /// <param name = "item"> The item to be removed form the list. </param>
    public void RemoveItem (Item item)
    {
        items.Remove (item);

        if (onItemChangedCallback != null)
        {
            onItemChangedCallback.Invoke();
        }
    }

    #endregion Inventory

    void Update ()
    {
        
    }
}