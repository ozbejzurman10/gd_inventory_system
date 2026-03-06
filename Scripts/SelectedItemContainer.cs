using Godot;
using System;

public partial class SelectedItemContainer : Control
{
    public InventoryItem selectedItem;
    private Sprite2D icon;

    public override void _Ready()
    {
        icon = GetNode<Sprite2D>("Icon");
    }
    public void UpdateSelectedItem(InventoryItem newItem)
    {
        selectedItem = newItem;
        icon.Texture = selectedItem.Texture;
        GD.Print("Selected item updated: " + selectedItem.Name);
    }

    public void ClearSelectedItem()
    {
        selectedItem = null;
        icon.Texture = null;
        GD.Print("Selected item cleared.");
    }

    // Make the item follow the mouse position

    public override void _Process(double delta)
    {
        if (selectedItem != null)
        {
            Position = GetGlobalMousePosition();
        }
    }

}
