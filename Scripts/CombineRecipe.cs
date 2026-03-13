using Godot;
using System;

[GlobalClass]
public partial class CombineRecipe: Resource
{
    [Export]
    public InventoryItem[] Ingredients { get; set; }
    
    [Export]
    public InventoryItem Result { get; set; }

}
