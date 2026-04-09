using Godot;
using System;

// Določa pogodbo: vsak razred, ki implementira ta vmesnik, MORA imeti metodo Use()
public interface IUsable
{
    /// <summary>
    /// Izvede uporabo predmeta.
    /// </summary>
    void Use();
    
    string GetUseDescription(); // Trenutno neuporabljeno. Dodaj da lahko prikazemo opis itema preden ga uporabimo
}
