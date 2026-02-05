using Godot;
using System;

public partial class InventorySlotGUI : Button
{
    // Predstavlja en "prostor" ali SLOT v inventoriju ki lahko drži enega ali vec itemov iste vrste.

    private TextureRect icon;
    private Panel background;
    private InventorySlot inventorySlot = new InventorySlot();
    private ShaderMaterial rainbowMat;


    public override void _Ready()
    {
        icon = GetNode<TextureRect>("Icon");
        background = GetNode<Panel>("Background");

        var shader = GD.Load<Shader>("res://Shaders/rainbow_bg.gdshader");
        rainbowMat = new ShaderMaterial();
        rainbowMat.Shader = shader;

        Pressed += OnPressed;
        //ClearSlot();
    }


    public void InsertItem(InventoryItem newItem, int newAmount)
    {

        inventorySlot.item = newItem;
        inventorySlot.amount = newAmount;
        /*
        if (inventorySlot.item == null)
        {
            ClearSlot();
            return;
        }
        */

        icon.Texture = inventorySlot.item.Texture;
        SetRarityColor(inventorySlot.item.rarity);
    }

    public void ClearSlot()
    {
        inventorySlot.item = null;
        icon.Texture = null;

        SetRarityColor(InventoryItem.Rarity.Common);
    }

    private void SetRarityColor(InventoryItem.Rarity rarity)
    {

        if (rarity == InventoryItem.Rarity.UltraLegendary)
        {
            background.Material = rainbowMat;
            background.RemoveThemeStyleboxOverride("panel");
            return;
        }

        background.Material = null;

        var style = new StyleBoxFlat
        {
            BgColor = rarity switch
            {
                InventoryItem.Rarity.Common => new Color("#9E9E9E"),
                InventoryItem.Rarity.Uncommon => new Color("#4CAF50"),
                InventoryItem.Rarity.Rare => new Color("#2196F3"),
                InventoryItem.Rarity.Epic => new Color("#9C27B0"),
                InventoryItem.Rarity.Legendary => new Color("#FF9800"),
                _ => Colors.White
            }
        };

        background.AddThemeStyleboxOverride("panel", style);
    }



    private void OnPressed()
    {
        UseItem();
    }

    public void UseItem()
    {
        if (inventorySlot.item != null)
        {
            inventorySlot.item.UseItem();
        }
        else
        {
            GD.Print("No item in this slot to use!");
        }
    }
}
