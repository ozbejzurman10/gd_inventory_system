using Godot;
using System;

[GlobalClass]
public partial class ConsumableItem : InventoryItem
{
	[Export]
	public float HealthIncrease { get; set; }

    private const float MaxHealthRestore = 500;

    public override void UseItem()
	{
		if (HealthIncrease > MaxHealthRestore)
		{
			HealthIncrease = MaxHealthRestore;
        }

        GD.Print($"You consumed the item {Name}, +{HealthIncrease} HP, Rairty: {rarity}");

    }
}
