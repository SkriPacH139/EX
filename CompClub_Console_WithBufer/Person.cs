namespace CompClub_Console
{    
    /// Базовый класс для человека (гость, клиент).   
    public abstract class Person
    {
        /// Имя
        public string Name { get; set; } = "Неизвестно";

        /// VIP-статус
        public bool IsVIP { get; set; } = false;
    }
}