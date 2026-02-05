using Godot;
using System;

[GlobalClass]
public partial class ConsumableItem : InventoryItem
{
	// Nova vrsta inv itema ki ima durgačno UseItem metodo.
	// TODO: DODAJ SE VEC VRST

	[Export]
	public float HealthIncrease { get; set; }

    private const float MaxHealthRestore = 500;

    public override void Use()
	{
		if (HealthIncrease > MaxHealthRestore)
		{
			HealthIncrease = MaxHealthRestore;
        }

        GD.Print($"You consumed the item {Name}, +{HealthIncrease} HP, Rairty: {rarity}");
    }

    public override string GetUseDescription()
    {
        return $"Restores {HealthIncrease} HP";
    }
}
