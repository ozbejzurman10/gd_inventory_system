using Godot;
using System;

[GlobalClass]
public partial class ConsumableItem : InventoryItem
{
	[Export]
	public float HealthIncrease { get; set; }
	
	public override void UseItem()
	{
		GD.Print($"You consumed the item {Name}, +{HealthIncrease} HP");
	}
}
