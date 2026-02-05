using Godot;
using System;

[GlobalClass]
public partial class Inventory : Resource
{
    [Export] // Vedno empty array kot default, da ne dobimo null reference exceptiona
    public InventorySlot[] ItemSlots { get; set; } = Array.Empty<InventorySlot>();

    // INDEKSER Inventory[0] namesto Inventory.ItemSlots[0]
    public InventorySlot this[int index]
    {
        get
        {
            if (index >= 0 && index < ItemSlots.Length) return ItemSlots[index];
            else
            {
                GD.PrintErr("Invalid Inventory Index!");
                return null;
            }
        }
        // set ni potreben
    }

    // Doda item v inventory resource. Najde prvi prosti slot
    public void AddItem(InventoryItem item, int amount)
    {
        // Dodaj item v prvi prosti slot
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            // Ce je slot prazen dodaj item
            if (ItemSlots[i] == null)
            {
                ItemSlots[i].item = item;
                ItemSlots[i].amount = amount;

                GD.Print($"Added {amount} of item {item.Name} to slot {i}");
                return;
            }
        }
        GD.PrintErr("Inventory FULL! No free slot available to add the item!");
    }

    // BRISI
    /*
    public void UseItem(int index)
    {
        // Uporabi item na dolocenem indexu
        if (index < 0 || index >= ItemSlots.Length)
        {
            GD.Print("Invalid index!");
            return;
        }

        InventoryItem item = ItemSlots[index].item;
        if (item != null)
        {
            item.UseItem();
        }
        else
        {
            GD.Print("No item in the selected slot to use!");
        }
    }
    

    public void PrintAllItems()
    {
        // Izpisi vse iteme v inventoriju
        for (int i = 0; i < Items.Length; i++)
        {
            if (Items[i] != null)
            {
                GD.Print($"Item {i}: {Items[i].Name}");
            }

            else
            {
                GD.Print($"Item {i}: none");
            }
        }
    }
    */
}
