//OPP
//Практические задания 
//Для создания программы по управлению автопарком нужно реализовать следующие сущности в виде отдельных классов: 
//"Двигатель"(включает в себя поля мощность, объем, тип, серийный номер), 
//"Шасси"(количество колес, номер, допустимая нагрузка), 
//"Трансмиссия"(тип, количество передач, производитель).
//С использованием этих классов реализовать сущности "Легковой автомобиль", "Грузовик", "Автобус", "Скутер" (отличающиеся уникальными полями), 
//и обеспечить вывод полной информации об объектах этих типов.

namespace HW3
{
    class Uniqueness//Уникальность
    {
        public string movementOnWater; //Передвижение по воде (Машина-амфибия)
        public string hybridСar; // Использует для привода ведущих колёс более одного источника энергии
        public string сabriolet; // Легковой автомобиль с откидывающимся верхом
        public string attaching; //Возможность прикрепить серф доску

        public Uniqueness(string movementOnWater, string hybridСar, string сabriolet, string attaching)//конструктор класса
        {
            this.movementOnWater = movementOnWater;
            this.hybridСar = hybridСar;
            this.сabriolet = сabriolet;
            this.attaching = attaching;
        }
        public void Print() => Console.WriteLine($"Уникальные свойства:\n{movementOnWater}\n{hybridСar}\n{сabriolet}\n{attaching}\n ");

    }
    class Engine//Двигатель
    {
        public int power; //Мощность
        public double volume; //Объем
        public string typeOf; //Тип
        public string serialNumber; //Серийный номер

        public Engine(int power, double volume, string typeOf, string serialNumber)//конструктор класса
        {
            this.power = power;
            this.volume = volume;
            this.typeOf = typeOf;
            this.serialNumber = serialNumber;
        }
        public void Print() => Console.WriteLine($"\n Двигатель: \n Мощь: {power} л.с   \n Объем: {volume} л.  \n Тип: {typeOf}  \n Серийный номер: {serialNumber} ");

    }
    class Transmission//Трансмиссия 
    {

        public string typeOf; //Тип
        public int numberOfGears; //Количество передач
        public string manufacturer; //Производитель

        public void Print() => Console.WriteLine($"\n Трансмисия: \n Тип: {typeOf}   \n Количество передач: {numberOfGears}  \n Производитель: {manufacturer} ");


        public Transmission(string typeOf, int numberOfGears, string manufacturer)
        {
            this.numberOfGears = numberOfGears;
            this.manufacturer = manufacturer;
            this.typeOf = typeOf;
        }
    }
    class Chassis//Шасси
    {
        public int numberOfWheels; //Колличество колес
        public int number; //Номер
        public double permissibleLoad;//Допустимая нагрузка

        public Chassis(int numberOfWheels, int number, double permissibleLoad) //ссылаемся на созданные данные в куче = new 
        {
            this.numberOfWheels = numberOfWheels;
            this.number = number;
            this.permissibleLoad = permissibleLoad;
        }
        public void Print() => Console.WriteLine($"\n Шасси: \n Колличество колес: {numberOfWheels}  \n Номер: {number}  \n Допустимая нагрузка: {permissibleLoad} т\n ");
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uniqueness busUniqueness = new("Movement on Water", "", "", "");
            Uniqueness truckUniqueness = new("", "Hybrid Сar", "", "");
            Uniqueness passengeCarUniqueness = new("", "", "Cabriolet", "");
            Uniqueness scooterUniqueness = new("", "", "", "Attaching a surfboard");

            Engine busEngine = new(170, 3.0, "diesel", "SN100");
            Engine truckEngine = new(260, 7.0, "diesel", "SN200");
            Engine passengerCarEngine = new(140, 2.0, "gasoline", "SN300");
            Engine scooterEngine = new(30, 0.2, "gasoline", "SN400");

            Transmission busTransmission = new("automatic", 7, " FPT Industrial");
            Transmission truckTransmission = new("automatic", 8, " FPT Industrial");
            Transmission passengerCarTransmission = new("automatic", 5, "Shenzhen");
            Transmission scooterTransmission = new("automatic", 4, "Shenzhenl");

            Chassis busChassis = new(4, 1738, 15);
            Chassis truckChassis = new(8, 3454, 40);
            Chassis passengerCarChassis = new(4, 4534, 2);
            Chassis scooterChassis = new(2, 2343, 0.12);

            Console.WriteLine("Автобус:");
            busEngine.Print();
            busTransmission.Print();
            busChassis.Print();
            busUniqueness.Print();

            Console.WriteLine("Грузовик:");
            truckEngine.Print();
            truckTransmission.Print();
            truckChassis.Print();
            truckUniqueness.Print();

            Console.WriteLine("Легковой автомобиль:");
            passengerCarEngine.Print();
            passengerCarTransmission.Print();
            passengerCarChassis.Print();
            passengeCarUniqueness.Print();

            Console.WriteLine("Скутер:");
            scooterEngine.Print();
            scooterTransmission.Print();
            scooterChassis.Print();
            scooterUniqueness.Print();




        }

    }
}