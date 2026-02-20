using System;
using System.Xml.Linq;
using Godot;
using static InventoryItem;

public partial class CombinableItem : InventoryItem
{
    public override void Use()
    {
        GD.Print($"You used a Combinable Item!");
    }

    public override string GetUseDescription()
    {
        return $"Can be used to combine two items!";
    }

    public CombinableItem(string name) : base(name)
    {

    }

    // Prikaz preobleganja operatorjev. Naredi novi item ki zdruzi imeni obeh itemov
    // TODO: Uporabi v programu (sistem za zdruzevanje itemov)
    public static CombinableItem operator +(CombinableItem a, CombinableItem b)
    {
        return new CombinableItem(a.Name + " & " + b.Name);
    }
    
}
