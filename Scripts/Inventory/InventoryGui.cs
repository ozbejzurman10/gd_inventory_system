using Godot;
using System;
using System.Linq;

public partial class InventoryGui : Control
{
    [Export]
    public Inventory inv { get; set; }

    [Export]
    public SelectedItemView selectedItemView { get; set; }

    [Export]
    public SelectedItemContainer selectedItemContainer { get; set; }


    private GridContainer slotsContainer;
    private InventorySlotGUI[] guiSlots;
    private int slotCount;

    [Export]
    public PackedScene SlotScene; // Kaze na invslotgui scene
    
    public override void _Ready()
    {
        // Najdi GridContainer ki bo parent vseh slotov
        slotsContainer = GetNode<GridContainer>("SlotContainer");

        if (inv == null)
        {
            GD.PrintErr("Inventory is not assigned!");
            return;
        }

        // Nastavi stevilo slotov glede na velikost inventorija
        slotCount = inv.ItemSlots.Length;

        ResizeSlots(slotCount);
        SetSlotIndexes();
        FillItems();

    }

    // Nastavilo stevilo SlotGUI NODOV glede na stevilo slotov v inventarju
    private void ResizeSlots(int count)
    {
        int currentChildCount = slotsContainer.GetChildCount();

        // ODSTRANI ODVEČNE SLOTE
        while (currentChildCount > count)
        {
            var child = slotsContainer.GetChild(currentChildCount - 1);

            slotsContainer.RemoveChild(child);

            child.QueueFree();
            currentChildCount--;
        }

        // DODAJ MANJKAJOČE SLOTE
        while (currentChildCount < count)
        {
            // Ustvari nov slot in ga dodaj v GridContainer
            var slot = SlotScene.Instantiate<InventorySlotGUI>();
            slotsContainer.AddChild(slot);
            currentChildCount++;
        }

        // Napolni array
        guiSlots = new InventorySlotGUI[count];
        for (int i = 0; i < count; i++)
        {
            guiSlots[i] = slotsContainer.GetChild<InventorySlotGUI>(i);
            // POVEŽI SIGNAL Ko slot odda SlotSelected, poklici metodo
            guiSlots[i].SlotSelected += SlotSelected;
        }
    }

    private void SetSlotIndexes()
    {
        for (int i = 0; i < guiSlots.Length; i++)
        {
            guiSlots[i].inventorySlot.Index = i;
            //GD.Print($"Set slot {i} index to {guiSlots[i].inventorySlot.Index}");
        }
    }

    private void SlotSelected(InventorySlotGUI slot)
    {
        // Poslji informacije o izbranem slotu v SelectedItemView
        //selectedItemView.UpdateDisplay(slot.inventorySlot.item, slot.inventorySlot.amount);
        
        
        if (selectedItemContainer.selectedItem == null) {
            SelectItem(slot.inventorySlot.item);
            TakeFromSlot(slot.inventorySlot.Index);
        }

        else if (selectedItemContainer.selectedItem != null && slot.inventorySlot.item == null)
        {
            InsertItemToSlot(slot.inventorySlot.Index, selectedItemContainer.selectedItem);
            SelectItem(null);
        }

        else if (selectedItemContainer.selectedItem != null && slot.inventorySlot.item != null)
        {
            SwapSelectedItem(slot);
        }
    }

    private void TakeFromSlot(int index)
    {
        if (index >= 0 && index < guiSlots.Length)
        {
            guiSlots[index].ClearSlot();
            inv.ClearItemFromSlot(index);
        }
    }

    private void InsertItemToSlot(int index, InventoryItem item)
    {
        if (index >= 0 && index < guiSlots.Length)
        {
            inv.AddItemToSlot(item, 1, index);
            FillItems();
        }
    }

    private void SwapSelectedItem(InventorySlotGUI slot)
    {
        InventoryItem tempItem = slot.inventorySlot.item;
        TakeFromSlot(slot.inventorySlot.Index);
        InsertItemToSlot(slot.inventorySlot.Index, selectedItemContainer.selectedItem);
        
        if (tempItem != null)
        {
            SelectItem(tempItem);
        }
        else
        {
            SelectItem(null);
        }
    }

    private void SelectItem(InventoryItem item)
    {
        if (item != null)
        {
            selectedItemContainer.UpdateSelectedItem(item);
        }

        if (item == null)
        {
            selectedItemContainer.ClearSelectedItem();
        }
    }


    // Napolni inventory slote z itemi iz inventarja
    private void FillItems()
    {
        // Najprej pocisti vse slote nato dodaj nove iteme
        for (int i = 0; i < guiSlots.Length; i++)
        {
            guiSlots[i].ClearSlot();
        }

        // Dodaj iteme v slote
        for (int i = 0; i < inv.ItemSlots.Length && i < guiSlots.Length; i++)
        {
            // Ce je slot prazen preskoci
            if (inv[i] == null || inv[i].item == null)
            { 
                continue;
            }

            InventorySlot invSlot = inv[i];

            guiSlots[i].InsertItem(invSlot.item, invSlot.amount);
            GD.Print($"Added {invSlot.amount} of {invSlot.item.Name} to slot {i}");
        }
    }

    public InventoryItem[] GetInventoryItems() {
        InventoryItem[] items = new InventoryItem[guiSlots.Length];
        for (int i = 0; i < guiSlots.Length; i++)
        {
            items[i] = guiSlots[i].inventorySlot.item;
            GD.Print($"Slot {i} contains: {(items[i] != null ? items[i].Name : "Empty")}");
        }
        return items;
    }

    public void AddItemToInventory(InventoryItem item, int amount)
    {
        inv.AddItem(item, amount);
        FillItems();
    }
}
