using Godot;
using System;

[GlobalClass]
public partial class Inventory : Resource
{
    [Export] // Vedno empty array kot default, da ne dobimo null reference exceptiona
    public InventorySlot[] ItemSlots { get; set; } = Array.Empty<InventorySlot>();

    // INDEKSER Inventory[0] namesto Inventory.ItemSlots[0]

    /// <summary>
    /// Vrne inventory slot na podanem indeksu ali null, ce je indeks neveljaven.
    /// </summary>
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
    }

    /// <summary>
    /// Doda predmet v prvi prosti slot inventarja.
    /// Izpise napako, ce je inventar poln.
    /// </summary>
    public void AddItem(InventoryItem item, int amount)
    {
        // Dodaj item v prvi prosti slot
        for (int i = 0; i < ItemSlots.Length; i++)
        {
            // Ce je slot prazen dodaj item
            if (ItemSlots[i].item == null)
            {
                ItemSlots[i].item = item;
                ItemSlots[i].amount = amount;

                GD.Print($"Added {amount} of item {item.Name} to slot {i}");
                return;
            }
        }
        GD.PrintErr("Inventory FULL! No free slot available to add the item!");
    }

    /// <summary>
    /// Doda predmet v tocno dolocen slot, ce je ta prazen.
    /// Pred dodajanjem preveri veljavnost indeksa.
    /// </summary>
    public void AddItemToSlot(InventoryItem item, int amount, int index)
    {
        if (index < 0 || index >= ItemSlots.Length)
        {
            GD.PrintErr("Invalid Inventory Index!");
            return;
        }
        if (ItemSlots[index].item == null)
        {
            ItemSlots[index].item = item;
            ItemSlots[index].amount = amount;
            GD.Print($"Added {amount} of item {item.Name} to slot {index}");
        }
        else
        {
           GD.PrintErr($"Slot {index} is already occupied! Cannot add item {item.Name}.");
        }
    }

    /// <summary>
    /// Pocisti izbran slot, odstrani predmet in kolicino ponastavi na nic.
    /// </summary>
    public void ClearItemFromSlot(int index)
    {
        if (index < 0 || index >= ItemSlots.Length)
        {
            GD.PrintErr("Invalid Inventory Index!");
            return;
        }
        ItemSlots[index].item = null;
        ItemSlots[index].amount = 0;
        GD.Print($"Cleared item from slot {index}");
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
