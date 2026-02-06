using Godot;
using System;

public partial class SelectedItemView : Control
{
    private InventorySlotGUI previewGuiSlot;
    private Button useItemButton;
    private InventoryItem selectedItem;
    public override void _Ready()
    {
        previewGuiSlot = GetNode<InventorySlotGUI>("Preview Slot");
        useItemButton = GetNode<Button>("Use Item Button");

        useItemButton.Pressed += UseSelectedItem;
    }

    public void UpdateDisplay(InventoryItem item, int amount)
    {
        previewGuiSlot.InsertItem(item, amount);
        selectedItem = item;
    }

    public void UseSelectedItem()
    {
        if (selectedItem == null)
        {
            GD.Print("No item selected to use!");
            return;
        }

        selectedItem.Use();
    }
}
