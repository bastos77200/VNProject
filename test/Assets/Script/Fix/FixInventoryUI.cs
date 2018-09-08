using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

/* This object manages the inventory UI. */

public class FixInventoryUI : MonoBehaviour {

	public GameObject inventoryUI;	// The entire UI
	public Transform itemsParent;	// The parent object of all the items

	FixInventory inventory;	// Our current inventory

	void Start ()
	{
		inventory = FixInventory.instance;
        if (inventory == null) Debug.Log("No Inventory found !!!");
		inventory.onItemChangedCallback += UpdateUI;
	}


	// Update the inventory UI by:
	//		- Adding items
	// This is called using a delegate on the Inventory.
	public void UpdateUI ()
	{
        Debug.Log("Updating UI");
		FixInventorySlot[] slots = GetComponentsInChildren<FixInventorySlot>();

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItem(inventory.items[i]);
			} else
			{
				slots[i].ClearSlot();
			}
		}
	}

}
