using Godot;
using System;

[GlobalClass]
public partial class InventoryItem : Resource
{
	[Export]
	public string Name { get; set; }

	[Export]
	public Texture2D Texture { get; set; }

	[Export]
	public int MaxStack { get; set; } = 99;

	public virtual void UseItem()
	{
		GD.Print($"You used the item {Name}");
	}
}
