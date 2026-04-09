using Godot;
using System;

public partial class SelectedItemContainer : Control
{
    public InventoryItem selectedItem;
    private Sprite2D icon;

    /// <summary>
    /// Pridobi referenco na ikono izbranega predmeta.
    /// </summary>
    public override void _Ready()
    {
        icon = GetNode<Sprite2D>("Icon");
    }
    /// <summary>
    /// Nastavi trenutno izbran predmet in osvezi njegovo ikono.
    /// </summary>
    public void UpdateSelectedItem(InventoryItem newItem)
    {
        selectedItem = newItem;
        icon.Texture = selectedItem.Texture;
        GD.Print("Selected item updated: " + selectedItem.Name);
    }

    /// <summary>
    /// Pocisti trenutno izbran predmet in odstrani prikaz ikone.
    /// </summary>
    public void ClearSelectedItem()
    {
        selectedItem = null;
        icon.Texture = null;
        GD.Print("Selected item cleared.");
    }


    /// <summary>
    /// Med izvajanjem premika prikaz izbranega predmeta na polozaj miske.
    /// </summary>
    public override void _Process(double delta)
    {
        if (selectedItem != null)
        {
            Position = GetGlobalMousePosition();
        }
    }

}
