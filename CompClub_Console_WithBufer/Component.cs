namespace CompClub_Console
{
    /// Ингредиент или часть блюда.
    public class Component
    {
        //Название компонента
        public string Name { get; set; } = "";

        //Количество (единицы/граммы и т.п.)
        public double Quantity { get; set; }

        //Единицы измерения
        public string Unit { get; set; } = "шт";

        public override string ToString()
        {
            return $"{Name} - {Quantity} {Unit}";
        }

        public string Category { get; set; }
        public double Price { get; set; }
    }
}