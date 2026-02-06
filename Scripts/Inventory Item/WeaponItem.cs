using Godot;
using System;

[GlobalClass]

public partial class WeaponItem : InventoryItem
{
    [Export]
    public int Damage { get; set; }
    public override void Use()
    {
        GD.Print($"You used the weapon item {Name}, Damage: {Damage}, Rairty: {rarity}");
    }
    public override string GetUseDescription()
    {
        return $"This is a weapon item that deals {Damage} damage.";
    }
}
