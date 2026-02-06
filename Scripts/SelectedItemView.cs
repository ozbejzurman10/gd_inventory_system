using Godot;
using System;

public partial class SelectedItemView : Control
{
    private InventorySlotGUI previewGuiSlot;
    public override void _Ready()
    {
        previewGuiSlot = GetNode<InventorySlotGUI>("Preview Slot");
    }

    public void UpdateDisplay(InventoryItem item, int amount)
    {
        previewGuiSlot.InsertItem(item, amount);
        //Visible = true;
    }
}
