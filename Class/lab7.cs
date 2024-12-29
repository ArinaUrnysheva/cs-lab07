using System;

namespace lab7 
{
    // Объявление пользовательского атрибута MyAttribute, который наследует от класса Attribute.
    public class MyAttribute : Attribute
    {
        public string Comment { get; set; } // Свойство для хранения комментария.

        // Конструктор без параметров.
        public MyAttribute() { }

        // Конструктор с параметром, который инициализирует свойство Comment.
        public MyAttribute(string Comment)
        {
            this.Comment = Comment;
        }
    }

    // Объявление абстрактного класса Animal с атрибутом MyAttribute.
    [MyAttribute("Базовый класс Animal для всех животных")]
    public abstract class Animal
    {
        // Свойства класса Animal.
        public string Country { get; set; }
        public string HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public string WhatAnimal { get; set; }
        public string classification { get; set; }
        public string favourite_food { get; set; }

        // Конструктор класса Animal, инициализирующий свойства.
        public Animal(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food)
        {
            this.Country = Country;
            this.HideFromOtherAnimals = HideFromOtherAnimals;
            this.Name = Name;
            this.WhatAnimal = WhatAnimal;
            this.classification = classification.ToString();
            this.favourite_food = favourite_food.ToString();
        }

        // Метод для распаковки свойств Animal в отдельные переменные.
        public void Deconstruct(out string country, out string hideFromOtherAnimals, out string name, out string whatAnimal)
        {
            country = Country;
            hideFromOtherAnimals = HideFromOtherAnimals;
            name = Name;
            whatAnimal = WhatAnimal;
        }

        // Виртуальные методы, которые могут быть переопределены в производных классах.
        public virtual void GetClassificationAnimal() { }
        public virtual void GetFavouriteFood() { }
        public virtual void SayHello() { }
    }

    // Класс Cow (Корова), производный от Animal.
    [MyAttribute("Производный от Animal класс Cow")]
    public class Cow : Animal
    {
        // Конструктор класса Cow, вызывающий базовый конструктор Animal.
        public Cow(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food)
            : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classification, favourite_food) { }

        // Переопределение метода для вывода классификации животного.
        public override void GetClassificationAnimal()
        {
            Console.WriteLine($"{this.Name} классифицируется как {classification}");
        }

        // Переопределение метода для вывода любимой еды животного.
        public override void GetFavouriteFood()
        {
            Console.WriteLine($"У {this.Name} любимая еда - это {favourite_food}");
        }

        // Переопределение метода SayHello для издания звука коровы.
        public override void SayHello()
        {
            Console.WriteLine("муу");
        }
    }

    // Класс Lion (Лев), производный от Animal.
    [MyAttribute("Производный от Animal класс Lion")]
    public class Lion : Animal
    {
        // Конструктор класса Lion, вызывающий базовый конструктор Animal.
        public Lion(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food)
            : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classification, favourite_food) { }

        // Переопределение метода для вывода классификации животного.
        public override void GetClassificationAnimal()
        {
            Console.WriteLine($"{this.Name} классифицируется как {classification}");
        }

        // Переопределение метода для вывода любимой еды животного.
        public override void GetFavouriteFood()
        {
            Console.WriteLine($"У {this.Name} любимая еда - это {favourite_food}");
        }

        // Переопределение метода SayHello для издания звука льва.
        public override void SayHello()
        {
            Console.WriteLine("ррр");
        }
    }

    // Класс Pig (Свинья), производный от Animal.
    [MyAttribute("Производный от Animal класс Pig")]
    public class Pig : Animal
    {
        // Конструктор класса Pig, вызывающий базовый конструктор Animal.
        public Pig(string Country, string HideFromOtherAnimals, string Name, string WhatAnimal, eClassificationAnimal classification, eFavouriteFood favourite_food)
            : base(Country, HideFromOtherAnimals, Name, WhatAnimal, classification, favourite_food) { }

        // Переопределение метода для вывода классификации животного.
        public override void GetClassificationAnimal()
        {
            Console.WriteLine($"{this.Name} классифицируется как {classification}");
        }

        // Переопределение метода для вывода любимой еды животного.
        public override void GetFavouriteFood()
        {
            Console.WriteLine($"У {this.Name} любимая еда - это {favourite_food}");
        }

        // Переопределение метода SayHello для издания звука свиньи.
        public override void SayHello()
        {
            Console.WriteLine("хрю");
        }
    }

    // Перечисление eClassificationAnimal для классификаций животных.
    [MyAttribute("Перечисление классификаций животных")]
    public enum eClassificationAnimal
    {
        Herbivores, // Травоядные
        Carnivores, // Плотоядные
        Omnivores   // Всеядные
    }

    // Перечисление eFavouriteFood для любимой еды животных.
    [MyAttribute("Перечисление любимой еды животных")]
    public enum eFavouriteFood
    {
        Meat,   // Мясо
        Plants, // Растения
        Everything // Всё
    }
}
