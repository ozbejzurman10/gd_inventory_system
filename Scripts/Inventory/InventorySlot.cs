using Godot;
using System;

[GlobalClass]
public partial class InventorySlot : Resource
{
    [Export]
    public InventoryItem item { get; set; }
    public int amount = 1;

    public InventorySlot()
    {
        item = null;
        amount = 0;
    }
}
