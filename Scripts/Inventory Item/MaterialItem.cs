using Godot;
using System;

[GlobalClass]
public partial class MaterialItem : InventoryItem
{
    public override void Use()
    {
        GD.Print($"This item has to use!");
    }

    public override string GetUseDescription()
    {
        return $"This is a material item.";
    }
}
