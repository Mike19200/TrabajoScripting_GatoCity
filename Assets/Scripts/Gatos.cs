using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cat : MonoBehaviour
{
    public string Name { get; }
    public int Happiness { get; set; }
    public bool HasSpecialAbility { get; }
    public int SpecialAbilityValue { get; }
    public bool IsSpecialAbilityActive { get; private set; }

    public Cat(string name, bool hasSpecialAbility, int specialAbilityValue)
    {
        Name = name;
        Happiness = 0;
        HasSpecialAbility = hasSpecialAbility;
        SpecialAbilityValue = specialAbilityValue;
        IsSpecialAbilityActive = false;
    }

    public void UseSpecialAbility()
    {
        if (HasSpecialAbility && !IsSpecialAbilityActive)
        {
            // Activar la habilidad especial
            IsSpecialAbilityActive = true;
        }
    }
}

public class WhiteCat : Cat
{
    public void UseSpecialAbility(Player player)
    {
        if (HasSpecialAbility)
        {
            // Obtener el número de gatos blancos en posesión del jugador
            int whiteCatCount = player.Cats.FindAll(cat => cat is WhiteCat).Count;

            // Obtener las monedas correspondientes y agregarlas al saldo del jugador
            int coinsEarned = whiteCatCount * 10;
            player.Coins += coinsEarned;
        }
    }
}

public class GreyCat : Cat
{
    // Implementar habilidades especiales para gatos grises si es necesario
}

public class BlackCat : Cat
{
    private DateTime specialAbilityStartTime;

    public void UseSpecialAbility()
    {
        if (HasSpecialAbility)
        {
            // Verificar si la habilidad especial aún está activa
            if (DateTime.Now.Subtract(specialAbilityStartTime).TotalMinutes <= 5)
            {
                // Aplicar multiplicador x2 al oro obtenido
                GoldMultiplier.Multiplier = 2;
            }
            else
            {
                // Iniciar la habilidad especial
                GoldMultiplier.Multiplier = 1;
                specialAbilityStartTime = DateTime.Now;
            }
        }
    }
}

public class OrangeCat : Cat
{
    private List<Cat> catsInRoom;
    private System.Threading.Timer specialAbilityTimer;

    public OrangeCat()
    {
        catsInRoom = new List<Cat>();
        specialAbilityTimer = new System.Threading.Timer(ActivateSpecialAbility, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
    }

    public void UseSpecialAbility()
    {
        if (catsInRoom.Count(c => c is OrangeCat) >= 2)
        {
            IsSpecialAbilityActive = true;
            specialAbilityTimer.Change(TimeSpan.FromMinutes(5), TimeSpan.Zero);
        }
        else
        {
            IsSpecialAbilityActive = false;
            specialAbilityTimer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(5));
        }
    }

    private void ActivateSpecialAbility(object state)
    {
        IsSpecialAbilityActive = false;
        specialAbilityTimer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(5));
    }
}
