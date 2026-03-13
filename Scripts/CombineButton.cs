using Godot;
using System;

public partial class CombineButton : Button
{
    [Export]
    public InventoryGui inventoryGui { get; set; }

    [Export]
    public InventoryGui outPutInvGui { get; set; }

    [Export]
    public InventoryItem drink { get; set; }

    [Export]
    public CombineRecipe[] Recipes { get; set; }

    public override void _Ready()
    {
        if (inventoryGui == null)
        {
            GD.PrintErr("InventoryGui is not assigned to CombineButton!");
            return;
        }
        this.Pressed += OnCombinePressed;
    }

    private void OnCombinePressed()
    {
        InventoryItem[] inventoryItems = inventoryGui.GetInventoryItems();

        if (inventoryItems.Length < 2)
        {
            GD.Print("Not enough items to combine.");
            return;
        }

        foreach (CombineRecipe recipe in Recipes)
        {
            if (RecipeMatches(recipe, inventoryItems))
            {
                outPutInvGui.AddItemToInventory(recipe.Result, 1);

                foreach (var slot in inventoryGui.guiSlots)
                {
                    inventoryGui.TakeFromSlot(slot.inventorySlot.Index);
                }

                GD.Print("Recipe combined!");
                return;
            }
        }

        GD.Print("These items cannot be combined.");
    }

    private bool RecipeMatches(CombineRecipe recipe, InventoryItem[] items)
    {
        if (items.Length != recipe.Ingredients.Length)
            return false;

        foreach (InventoryItem ingredient in recipe.Ingredients)
        {
            bool found = false;

            foreach (InventoryItem item in items)
            {
                if (item == ingredient)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                return false;
        }

        return true;
    }
}
