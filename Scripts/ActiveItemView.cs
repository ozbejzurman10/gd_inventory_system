using Godot;
using System;

public partial class ActiveItemView : Control
{
    [Export]
    private InventorySlotGUI activeItemSlot;

    [Export]
    private InventoryGui activeItemInvGui;

    private Button useItemButton;
    private InventoryItem activeItem;
    private Label itemNameLabel;
    private Label itemDescLabel;
    public override void _Ready()
    {
        useItemButton = GetNode<Button>("Use Item Button");
        itemNameLabel = GetNode<Label>("Item Name Label");
        itemDescLabel = GetNode<Label>("Item Desc Label");

        useItemButton.Pressed += UseSelectedItem;

        activeItemSlot.ItemInsertedIntoSlot += ItemInserted;
        activeItemSlot.ItemRemovedFromSlot += ClearActiveItem;

    }

    public void ItemInserted(InventorySlotGUI slot)
    {
        GD.Print("Updating active item display...");

        //activeItemSlot.InsertItem(slot.inventorySlot.item, slot.inventorySlot.amount);
        activeItem = slot.inventorySlot.item;

        if (slot.inventorySlot.item != null)
        {
            itemNameLabel.Text = slot.inventorySlot.item.Name;

            itemDescLabel.Text = $"Description:\n{slot.inventorySlot.item.Description}\n" +
                                 $"Rarity:\n{slot.inventorySlot.item.rarity}\n";
        }

        else 
        {
            itemNameLabel.Text = "";
            itemDescLabel.Text = "";
        }
    }

    public void ClearActiveItem(InventorySlotGUI slot)
    {
        activeItem = null;
        itemNameLabel.Text = "";
        itemDescLabel.Text = "";
    }

    public void UseSelectedItem()
    {

        if (activeItem == null)
        {
            GD.Print("No item selected to use!");
            return;
        }

        activeItem.Use();

        if (activeItem is ConsumableItem)
        {
            activeItemInvGui.TakeFromSlot(0);
        }

    }
}
