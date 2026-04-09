using Godot;
using System;

public partial class CombineButton : Button
{
    [Export]
    public InventoryGui combineSlotsInventoryGui { get; set; }

    [Export]
    public InventoryGui outputInvGui { get; set; }

    [Export]
    public CombineRecipe[] Recipes { get; set; }

    /// <summary>
    /// Inicializira gumb za kombiniranje in poveze signal ob kliku.
    /// </summary>
    public override void _Ready()
    {
        if (combineSlotsInventoryGui == null)
        {
            GD.PrintErr("InventoryGui is not assigned to CombineButton!");
            return;
        }
        this.Pressed += OnCombinePressed;
    }

    /// <summary>
    /// Ob kliku preveri recepte in ob uspesnem ujemanju izdela rezultat.
    /// </summary>
    private void OnCombinePressed()
    {
        if (outputInvGui.guiSlots[0].inventorySlot.item != null) return;

        InventoryItem[] inventoryItems = combineSlotsInventoryGui.GetInventoryItems();

        if (inventoryItems.Length < 2)
        {
            GD.Print("Not enough items to combine!");
            return;
        }

        foreach (CombineRecipe recipe in Recipes)
        {
            if (RecipeMatches(recipe, inventoryItems))
            {
                outputInvGui.AddItemToInventory(recipe.Result, 1);

                foreach (var slot in combineSlotsInventoryGui.guiSlots)
                {
                    combineSlotsInventoryGui.TakeFromSlot(slot.inventorySlot.Index);
                }

                GD.Print("Items combined!");
                return;
            }
        }

        GD.Print("These items cannot be combined.");
    }

    /// <summary>
    /// Preveri, ali podani predmeti ustrezajo sestavinam izbranega recepta.
    /// </summary>
    private bool RecipeMatches(CombineRecipe recipe, InventoryItem[] items)
    {
        if (items.Length != recipe.Ingredients.Length)
            return false;

        foreach (InventoryItem item in items)
        {
            if (item == null)
                return false;
        }

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
