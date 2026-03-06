using Godot;
using System;

[GlobalClass]
public partial class InventorySlot : Resource
{
    [Export]
    public InventoryItem item { get; set; }
    public int amount = 0;
    private int index = -1;
    public int Index {
        get { return index; }
        set {
            if (value >= 0)
            {
                index = value;
            }
            else GD.PrintErr("Trying to set an invalid index!");
        } 
    }

    public InventorySlot()
    {
        item = null;
        amount = 0;
    }
}
