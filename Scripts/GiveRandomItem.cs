using Godot;
using System;

public partial class GiveRandomItem : Button
{
    [Export]
    public InventoryGui outputInv { get; set; }

    private RandomNumberGenerator rng = new RandomNumberGenerator();

    /// <summary>
    /// Inicializira gumb in generator nakljucnih stevil.
    /// </summary>
    public override void _Ready()
    {
        Pressed += OnPressed;
        rng.Randomize();
    }

    /// <summary>
    /// Izbere nakljucen predmet iz mape virov in ga doda v izhodni inventar.
    /// </summary>
    private void OnPressed()
    {
        string folderPath = "res://Resources/Inventory Items/";

        var dir = DirAccess.Open(folderPath);

        if (dir == null)
        {
            GD.PrintErr("Failed to open directory!");
            return;
        }

        var files = new Godot.Collections.Array<string>();

        dir.ListDirBegin();
        string fileName = dir.GetNext();

        while (fileName != "")
        {
            if (!dir.CurrentIsDir() && fileName.EndsWith(".tres"))
            {
                files.Add(fileName);
            }

            fileName = dir.GetNext();
        }

        dir.ListDirEnd();

        if (files.Count == 0)
        {
            GD.Print("No .tres files found!");
            return;
        }

        int index = rng.RandiRange(0, files.Count - 1);
        string selectedFile = files[index];

        //GD.Print($"Selected file: {selectedFile}");

        if (outputInv == null)
        {
            GD.PrintErr("Output InventoryGui is not assigned!");
            return;
        }

        InventoryItem item = GD.Load<InventoryItem>($"{folderPath}/{selectedFile}");
        outputInv.AddItemToInventory(item, 1);

    }
}