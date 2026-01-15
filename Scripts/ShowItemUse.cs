using Godot;

public partial class ItemUsageDemo : Node
{
	public override void _Ready()
	{
		// Naredi iteme v scriptu
		InventoryItem sword = new InventoryItem
		sword.Name = "Sword";

		InventoryItem potion = new ConsumableItem
		potion.Name = "Health Potion"

		UseInventoryItem(sword);
		UseInventoryItem(potion);
	}

	private void UseInventoryItem(InventoryItem item)
	{
		item.UseItem();
	}
}
