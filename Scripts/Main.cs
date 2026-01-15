using Godot;
using System;

public partial class Main : Node2D
{
    // Item narejen v editorju
    [Export]
    public InventoryItem editor_item;

    // Inventory narejen v editorju
    [Export]
    public Inventory editor_inv;

    public override void _Ready()
    {
        // Naredi iteme v scriptu
        InventoryItem simpleitem = new InventoryItem();
        simpleitem.Name = "Simple Item";
        
        InventoryItem potion = new ConsumableItem();
        potion.Name = "Health Potion";

        // Lahko uporabimo iteme direkt iz scripta ali pa v inventoriju (doli)

        /*
        UseInventoryItem(simpleitem);
        UseInventoryItem(potion);
        UseInventoryItem(editor_item);
        */

        // Preden dodamo iteme v kodi (izpise samo iteme ki so bili dodani v editorju)
        GD.Print(" --- Inventory before adding items in script:");
        editor_inv.PrintAllItems();

        // Dodamo iteme iz scripta
        editor_inv.AddItem(simpleitem);
        editor_inv.AddItem(potion); // Tu bo zmanjkalo prostora

        // Ko dodamo iteme v scriptu
        GD.Print(" --- Inventory after adding items in script:");
        editor_inv.PrintAllItems();

        // Uporabimo item iz inventorija
        GD.Print(" --- Using item at index 0, 1 and 2:");
        editor_inv.UseItem(0);
        editor_inv.UseItem(1);
        editor_inv.UseItem(2);

        // Preobleganje operatorjev
        GD.Print(" --- Combining two items:");
        InventoryItem combinedItem = simpleitem + potion;
        UseInventoryItem(combinedItem);

        GD.Print("Total Items Created: " + InventoryItem.TotalItemsCreated);
    }

    private void UseInventoryItem(InventoryItem item)
    {
        item.UseItem();
    }
}
