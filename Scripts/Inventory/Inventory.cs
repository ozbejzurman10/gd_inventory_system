using Godot;
using System;

[GlobalClass]
public partial class Inventory : Resource
{
    // vedno empty array kot default, da ne dobimo null reference exceptiona
    [Export]
    public InventoryItem[] Items { get; set; } = Array.Empty<InventoryItem>();


    public void AddItem(InventoryItem item)
    {
        // Dodaj item v prvi prosti slot
        for (int i = 0; i < Items.Length; i++)
        {
            // Ce je slot prazen, dodaj item
            if (Items[i] == null)
            {
                Items[i] = item;
                GD.Print($"Added item {item.Name} to slot {i}");
                return;
            }
        }
        GD.Print("No free slot available to add the item!");
    }

    public void UseItem(int index)
    {
        // Uporabi item na dolocenem indexu
        if (index < 0 || index >= Items.Length)
        {
            GD.Print("Invalid index!");
            return;
        }

        InventoryItem item = Items[index];
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
}
