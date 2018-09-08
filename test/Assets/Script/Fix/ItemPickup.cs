using UnityEngine;

public class ItemPickup : MonoBehaviour
{

	public FixItem item;	// Item to put in the inventory if picked up

    private void OnMouseDown()
    {
        PickUp();
    }

    // Pick up the item
    void PickUp ()
	{
		Debug.Log("Picking up " + item.name);
		bool added = FixInventory.instance.Add(item);	// Add to inventory
        if(added) Destroy(gameObject);	// Destroy item from scene
	}

}
