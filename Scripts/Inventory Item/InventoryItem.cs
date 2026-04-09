using Godot;
using System;

[GlobalClass]
public abstract partial class InventoryItem : Resource, IUsable
{
	[Export]
	public string Name { get; set; }

    [Export]
    public string Description { get; set; } = "No description.";

    [Export]
	public Texture2D Texture { get; set; }

    // Se ni v uporabi
    [Export]
	public int MaxStack { get; set; } = 99;

    [Export]
    public Rarity rarity { get; set; }
    public enum Rarity
    {
        None,
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        UltraLegendary
    }

    // Staticna metoda ki hrani koliko itemov je bilo ustvarjenih
    public static int TotalItemsCreated = 0;

    // Konstruktorji
    /// <summary>
    /// Ustvari nov predmet in poveca stevec ustvarjenih predmetov.
    /// </summary>
    public InventoryItem()
    {
        TotalItemsCreated++;
    }

    /// <summary>
    /// Ustvari nov predmet z imenom in poveca stevec ustvarjenih predmetov.
    /// </summary>
    public InventoryItem(string name)
    {
        Name = name;
        TotalItemsCreated++;
    }

    // Prazno. Vsak subclass implementira svojo verzijo
    /// <summary>
    /// Izvede uporabo predmeta. Konkretno vedenje dolocijo podrazredi.
    /// </summary>
    public abstract void Use();
    public abstract string GetUseDescription();
    //GD.Print($"You used the item {Name}, Rairty: {rarity}");


    // Redko uporabljeno v godotu zaradi garbage collectiona
    ~InventoryItem()
    {
        GD.Print($"{Name} destroyed!");
    }

    /// <summary>
    /// Primerja dva predmeta po imenu in obravnava tudi null vrednosti.
    /// </summary>
    public static bool operator ==(InventoryItem a, InventoryItem b)
    {
        if (a is null && b is null) return true;
        if (a is null || b is null) return false;
        return a.Name == b.Name;
    }
    
    public static bool operator !=(InventoryItem a, InventoryItem b)
    {
        return !(a == b);
    }
}
