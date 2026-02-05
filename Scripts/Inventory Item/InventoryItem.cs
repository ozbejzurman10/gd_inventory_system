using Godot;
using System;

[GlobalClass]
public abstract partial class InventoryItem : Resource, IUsable
{
	[Export]
	public string Name { get; set; }

	[Export]
	public Texture2D Texture { get; set; }

    // Se ni v uporabi
    [Export]
	public int MaxStack { get; set; } = 99;

    [Export]
    public Rarity rarity { get; set; }
    public enum Rarity
    {
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
    public InventoryItem()
    {
        TotalItemsCreated++;
    }

    public InventoryItem(string name)
    {
        Name = name;
        TotalItemsCreated++;
    }

    // Prazno. Vsak subclass implementira svojo verzijo
    public abstract void Use();
    public abstract string GetUseDescription();
    //GD.Print($"You used the item {Name}, Rairty: {rarity}");


    // Prikaz preobleganja operatorjev. Naredi novi item ki zdruzi imeni obeh itemov
    // TODO: Uporabi v igri (sistem za zdruzevanje itemov?)
    // PRESTAVI V COMBINABLE ITEM TU SE NE DA UPORABITI SAJ JE TA CLASS ZDAJ ABSTRACT
    /*
    public static InventoryItem operator +(InventoryItem a, InventoryItem b)
    {
        return new InventoryItem(a.Name + " & " + b.Name);
    }
    */

    // Redko uporabljeno v godotu zaradi garbage collectiona
    ~InventoryItem()
    {
        GD.Print($"{Name} destroyed!");
    }
}
