using Godot;
using System;
using System.Linq;

public partial class InventoryGui : Control
{
    [Export]
    public Inventory inv { get; set; }

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
        FillItems();

    }

    // Nastavilo stevilo SlotGUI NODOV glede na stevilo slotov v inventarju
    private void ResizeSlots(int count)
    {
        // ODSTRANI ODVEČNE SLOTE
        while (slotsContainer.GetChildCount() > count)
        {
            slotsContainer.GetChild(slotsContainer.GetChildCount() - 1).QueueFree();
        }

        // DODAJ MANJKAJOČE SLOTE
        while (slotsContainer.GetChildCount() < count)
        {
            // Ustvari nov slot in ga dodaj v GridContainer
            var slot = SlotScene.Instantiate<InventorySlotGUI>();
            slotsContainer.AddChild(slot);
        }

        // Napolni array
        guiSlots = new InventorySlotGUI[count];
        for (int i = 0; i < slotsContainer.GetChildCount(); i++)
        {
            guiSlots[i] = slotsContainer.GetChild<InventorySlotGUI>(i);
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

            if (inv[i] == null || inv[i].item == null)
            { 
                return; 
            }

            InventorySlot invSlot = inv[i];

            guiSlots[i].InsertItem(invSlot.item, invSlot.amount);
            GD.Print($"Added {invSlot.amount} of {invSlot.item.Name} to slot {i}");
        }
    }

}
