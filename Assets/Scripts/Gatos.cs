using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        public string Name { get; }
        public int Happiness { get; set; }
        public bool HasSpecialAbility { get; }
        public int SpecialAbilityValue { get; }
        public bool IsSpecialAbilityActive { get; private set; }


    }

    // Update is called once per frame
    void Update()
    {
        public Cat(string name, bool hasSpecialAbility, int specialAbilityValue)
        {
            Name = name;
            Happiness = 0;
            Energy = 100;
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

        class WhiteCat : Cat
        {
            void UseSpecialAbility(Player player)
            {
                if (HasSpecialAbility)
                {
                    // Obtener el número de gatos blancos en posesión del jugador
                    int whiteCatCount = player.Cats.Count(cat => cat.Color == "blanco");

                    // Obtener las monedas correspondientes y agregarlas al saldo del jugador
                    int coinsEarned = whiteCatCount * 10;
                    player.Coins += coinsEarned;
                }
            }


        }


        class GreyCat : Cat
        {

        }

        class BlackCat : Cat
        {
            void UseSpecialAbility()
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
        
        class OrangeCat : Cat
        {
            void UseSpecialAbility()
            {
                if (catsInRoom.Count(c => c.Color == "naranja") >= 2)
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

            void ActivateSpecialAbility(object state)
            {
                IsSpecialAbilityActive = false;
                specialAbilityTimer.Change(TimeSpan.Zero, TimeSpan.FromMinutes(5));
            }
        }
    }
}
