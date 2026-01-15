using Godot;
using System;

public partial class Main : Node2D
{
    // Item narejen v editorju
    [Export]
    public InventoryItem editor_item;

    public override void _Ready()
    {
        // Naredi iteme v scriptu
        InventoryItem simpleitem = new InventoryItem();
        simpleitem.Name = "Simple Item";
        
        InventoryItem potion = new ConsumableItem();
        potion.Name = "Health Potion";
        
        UseInventoryItem(simpleitem);
        UseInventoryItem(potion);
        UseInventoryItem(editor_item);
    }

    private void UseInventoryItem(InventoryItem item)
    {
        item.UseItem();
    }
}
