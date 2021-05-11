using System;

namespace FitnesBL.Model
{
    [Serializable]
    public class User
    {
        #region Свойства
        public string Name { get; }
        public Gender Gender { get; }
        public DateTime BirthDate { get; }
        public double Weight { get; set; }
        public double Height { get; set; }
        #endregion
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("Имя не может быть пустым или null.", nameof(name));
            if (gender == null)
                throw new ArgumentNullException("Пол не может быть равен null.", nameof(gender));
            if (birthDate < DateTime.Parse("01.01.1900") || birthDate > DateTime.Now)
                throw new ArgumentException("Невозможное значение даты рождения.", nameof(birthDate));
            if (weight <= 0)
                throw new ArgumentException("Вес не может быть меньше или равен 0.", nameof(weight));
            if (height <= 0)
                throw new ArgumentException("Рост не может быть меньше или равен 0.", nameof(height));
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return $"{Name}"; 
        }
    }
}
