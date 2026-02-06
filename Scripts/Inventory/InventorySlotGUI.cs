using Godot;
using System;

public partial class InventorySlotGUI : Button
{
    // Predstavlja en "prostor" ali SLOT v inventoriju ki lahko drži enega ali vec itemov iste vrste.

    private TextureRect icon;
    private Panel background;
    public InventorySlot inventorySlot = new InventorySlot();
    private ShaderMaterial rainbowMat;

    [Signal]
    public delegate void SlotSelectedEventHandler(InventorySlotGUI slot);

    public override void _Ready()
    {
        // node refrences
        icon = GetNode<TextureRect>("Icon");
        background = GetNode<Panel>("Background");

        // rainbow background shader effect
        var shader = GD.Load<Shader>("res://Shaders/rainbow_bg.gdshader");
        rainbowMat = new ShaderMaterial();
        rainbowMat.Shader = shader;


        // Povezi signal za klik na slot
        Pressed += OnPressed;

        ClearSlot();
    }

    // Dodaj item v ta slotGUI
    public void InsertItem(InventoryItem newItem, int newAmount)
    {
        // Dodaj item v InventorySlot resource
        inventorySlot.item = newItem;
        inventorySlot.amount = newAmount;
        
        if (inventorySlot.item == null)
        {
            ClearSlot();
            return;
        }

        // Nastavi texture in bg color glede na rarity itema
        icon.Texture = inventorySlot.item.Texture;
        SetRarityColor(inventorySlot.item.rarity);
    }

    // Resetira slot, odstrani texture, item in resetira bg color
    public void ClearSlot()
    {
        inventorySlot.item = null;
        icon.Texture = null;

        SetRarityColor(InventoryItem.Rarity.None);
    }

    // Nastavi barvo ozadja glede na rarity itema
    private void SetRarityColor(InventoryItem.Rarity rarity)
    {
        if (rarity == InventoryItem.Rarity.None)
        {
            background.Material = null;
            background.AddThemeStyleboxOverride("panel", new StyleBoxFlat { BgColor = Colors.Transparent });
            return;
        }

        // ce je rarity ultralegendary, nastavi shader material za rainbow efekt
        if (rarity == InventoryItem.Rarity.UltraLegendary)
        {
            background.Material = rainbowMat;
            return;
        }

        // resetiramo bg material in dodamo pravilno barvo glede na rarity
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


    // Poklici UseItem metodo ko zaznamo klic onPressed signala
    private void OnPressed()
    {
        // Poslji signal da je bil ta slot izbran
        EmitSignal(SignalName.SlotSelected, this);
    }
}
