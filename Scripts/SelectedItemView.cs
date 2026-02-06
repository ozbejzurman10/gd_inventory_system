using Godot;
using System;

public partial class SelectedItemView : Control
{
    private InventorySlotGUI previewGuiSlot;
    private Button useItemButton;
    private InventoryItem selectedItem;
    private Label itemNameLabel;
    public override void _Ready()
    {
        previewGuiSlot = GetNode<InventorySlotGUI>("Preview Slot");
        useItemButton = GetNode<Button>("Use Item Button");
        itemNameLabel = GetNode<Label>("Item Name Label");

        useItemButton.Pressed += UseSelectedItem;
    }

    public void UpdateDisplay(InventoryItem item, int amount)
    {
        previewGuiSlot.InsertItem(item, amount);
        selectedItem = item;

        if (item != null)
        {
            itemNameLabel.Text = item.Name;
        }

        else itemNameLabel.Text = "No Item";
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
