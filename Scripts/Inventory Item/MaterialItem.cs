using Godot;
using System;

[GlobalClass]
public partial class MaterialItem : InventoryItem
{
    public override void Use()
    {
        GD.Print($"This item has no use!");
    }

    public override string GetUseDescription()
    {
        return $"This is a material item.";
    }
}
