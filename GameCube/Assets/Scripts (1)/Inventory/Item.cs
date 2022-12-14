using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject {
	public static List<int> same = new List<int>(){ 1 };

	new public string name = "New Item";	// Name of the item
	public Sprite icon = null;              // Item icon
	public int id = 0;
	public bool showInInventory = true;

	public static bool opened = false;

	[TextArea()] public string text;

	// Called when the item is pressed in the inventory
	public virtual void Use ()
	{
		if(same[same.Count - 1] != id)
		{
			if(!DialogSystem.started && !opened)
			{
				DialogSystem.message.Add($"{text}");
				DialogSystem.printText = true;
			}
		}
	}

	// Call this method to remove the item from inventory
	public void RemoveFromInventory ()
	{
		Inventory.instance.Remove(this);
	}

}
