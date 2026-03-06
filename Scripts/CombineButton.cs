using Godot;
using System;

public partial class CombineButton : Button
{
    [Export]
    public InventoryGui inventoryGui { get; set; }

    [Export]
    public InventoryGui outPutInvGui { get; set; }

    [Export]
    public InventoryItem battle_axe { get; set; }

    public override void _Ready()
    {
        if (inventoryGui == null)
        {
            GD.PrintErr("InventoryGui is not assigned to CombineButton!");
            return;
        }
        this.Pressed += OnCombinePressed;
    }

    private void OnCombinePressed() {
        InventoryItem[] inventoryItems = inventoryGui.GetInventoryItems();

        // simple combine check 
        if (inventoryItems.Length >= 2) {
            InventoryItem item1 = inventoryItems[0];
            InventoryItem item2 = inventoryItems[1];

            if ((item1.Name == "Empty Potion" && item2.Name == "Empty Potion")) {
                outPutInvGui.AddItemToInventory(battle_axe, 1);
            } 
            else {
                GD.Print("These items cannot be combined.");
            }
        } 
        else {
            GD.Print("Not enough items to combine.");
        }
    }
}
