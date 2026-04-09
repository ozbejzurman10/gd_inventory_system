using Godot;
using System;

[GlobalClass]
public partial class ConsumableItem : InventoryItem
{
	[Export]
	public float HealthIncrease { get; set; }

    private const float MaxHealthRestore = 500;

    /// <summary>
    /// Uporabi potrosni predmet in omeji obnovitev zivljenja na najvisjo dovoljeno vrednost.
    /// </summary>
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
