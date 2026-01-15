using Godot;
using System;

[GlobalClass]
public partial class InventoryItem : Resource
{
	[Export]
	public string Name { get; set; }

	// Se ni v uporabi
	[Export]
	public Texture2D Texture { get; set; }

    // Se ni v uporabi
    [Export]
	public int MaxStack { get; set; } = 99;

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

    public virtual void UseItem()
	{
		GD.Print($"You used the item {Name}");
	}

    // Prikaz preobleganja operatorjev. Naredi novi item ki zdruzi imeni obeh itemov
    public static InventoryItem operator +(InventoryItem a, InventoryItem b)
    {
        return new InventoryItem(a.Name + " & " + b.Name);
    }


    ~InventoryItem()
    {
        GD.Print($"{Name} destroyed!");
    }
}
