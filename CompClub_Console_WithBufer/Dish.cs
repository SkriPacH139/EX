using System;
using System.Collections.Generic;

namespace CompClub_Console
{
    /// Блюдо, которое можно заказать в клубе.
    public class Dish
    {
        public string Name { get; set; } = "Блюдо";
        public double Price { get; set; }
        public List<Component> Components { get; set; } = new List<Component>();

        public List<Component> Ingredients
        {
            get => Components;
            set => Components = value;
        }

        public override string ToString()
        {
            return $"{Name} — {Price}₽, Состав: {Components.Count} ингредиентов";
        }

        public string Category { get; set; }

    }
}