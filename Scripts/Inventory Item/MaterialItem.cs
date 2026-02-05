using Godot;
using System;

public partial class MaterialItem : InventoryItem
{
    public override void Use()
    {
        GD.Print($"You used the material item {Name}, Rairty: {rarity}");
    }

    public override string GetUseDescription()
    {
        return $"This is a material item.";
    }
}
