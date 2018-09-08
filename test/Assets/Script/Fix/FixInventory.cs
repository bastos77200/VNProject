using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixInventory : MonoBehaviour {

	#region Singleton

	public static FixInventory instance;

	void Awake ()
	{
		instance = this;
	}

	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 5;	// Amount of item spaces

	// Our current list of items in the inventory
	public List<FixItem> items = new List<FixItem>();

	// Add a new item if enough room
	public bool Add (FixItem item)
	{
		if (item.showInInventory) {
			if (items.Count >= space) {
				Debug.Log ("Not enough room.");
				return false;
			}

			items.Add (item);

			if (onItemChangedCallback != null)
				onItemChangedCallback.Invoke ();
		}
        return true;
	}

	// Remove an item
	public void Remove (FixItem item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
