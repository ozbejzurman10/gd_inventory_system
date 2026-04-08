using Godot;
using System;

public partial class ActiveItemView : Control
{
    private InventorySlotGUI activeItemSlot;
    private Button useItemButton;
    private InventoryItem activeItem;
    private Label itemNameLabel;
    public override void _Ready()
    {
        activeItemSlot = GetNode<InventorySlotGUI>("Active Slot");
        useItemButton = GetNode<Button>("Use Item Button");
        itemNameLabel = GetNode<Label>("Item Name Label");

        useItemButton.Pressed += UseSelectedItem;
    }

    public void UpdateDisplay(InventoryItem item, int amount)
    {
        activeItemSlot.InsertItem(item, amount);
        activeItem = item;

        if (item != null)
        {
            itemNameLabel.Text = item.Name;
        }

        else itemNameLabel.Text = "No Item";
    }

    public void UseSelectedItem()
    {
        if (activeItem == null)
        {
            GD.Print("No item selected to use!");
            return;
        }

        activeItem.Use();
    }
}
