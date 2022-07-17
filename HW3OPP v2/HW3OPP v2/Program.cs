/*OPP
Практические задания 
Для создания программы по управлению автопарком нужно реализовать следующие сущности в виде отдельных классов: 
1."Двигатель"(включает в себя поля мощность, объем, тип, серийный номер), 
2."Шасси"(количество колес, номер, допустимая нагрузка), 
3."Трансмиссия"(тип, количество передач, производитель).
4.С использованием этих классов реализовать сущности "Легковой автомобиль", "Грузовик", "Автобус", "Скутер" (отличающиеся уникальными полями), 
и обеспечить вывод полной информации об объектах этих типов.

Collections
Практические задания 
Заполнить единую коллекцию, содержащую объекты типа "Грузовик", "Легковой автомобиль", "Автобус", "Скутер" (из предыдущего задания по ООП ↑ ) с различными значениями полей.
Записать в соответствующие XML файлы следующую информацию:
1.Полную информацию о всех транспортных средствах, обьем двигателя которых больше чем 1.5 литров;
2.Тип двигателя, серийный номер и его мощность для всех автобусов и грузовиков;
3.Полную информацию о всех транспортных средствах, сгруппированную по типу трансмиссии.
*/
using System.Xml.Linq;

namespace HW3
{
    public class Uniqueness//Уникальность
    {

        public string UniquenessProperty { get; set; }

        public Uniqueness(string uniquenessProperty)
        {
            this.UniquenessProperty = uniquenessProperty;
        }
        public void Print() => Console.WriteLine($"Уникальные свойства:\n{UniquenessProperty}\n");
    }

    public class Engine//Двигатель
    {
        public int Power { get; set; }
        public double Volume { get; set; }
        public string TypeOf { get; set; }
        public string SerialNumber { get; set; }

        public Engine() { }
          public Engine(int power, double volume, string typeOf, string serialNumber)
        {
            this.Power = power;
            this.Volume = volume;
            this.TypeOf = typeOf;
            this.SerialNumber = serialNumber;
        }
        public void Print() => Console.WriteLine($"\n Двигатель: \n Мощь: {Power} л.с   \n Объем: {Volume} л.  \n Тип: {TypeOf}  \n Серийный номер: {SerialNumber} ");

    }

    public class Transmission//Трансмиссия 
    {
        public string TypeOf { get; set; }
        public int NumberOfGears { get; set; }
        public string Manufacturer { get; set; }

        public void Print() => Console.WriteLine($"\n Трансмисия: \n Тип: {TypeOf}   \n Количество передач: {NumberOfGears}  \n Производитель: {Manufacturer} ");


        public Transmission(string typeOf, int numberOfGears, string manufacturer)
        {
            this.NumberOfGears = numberOfGears;
            this.Manufacturer = manufacturer;
            this.TypeOf = typeOf;
        }
    }

    public class Chassis//Шасси
    {
        public int NumberOfWheels { get; set; }
        public int Number { get; set; }
        public double PermissibleLoad { get; set; }

        public Chassis(int numberOfWheels, int number, double permissibleLoad) //ссылаемся на созданные данные в куче = new 
        {
            this.NumberOfWheels = numberOfWheels;
            this.Number = number;
            this.PermissibleLoad = permissibleLoad;
        }
        public void Print() => Console.WriteLine($"\n Шасси: \n Колличество колес: {NumberOfWheels}  \n Номер: {Number}  \n Допустимая нагрузка: {PermissibleLoad} т\n ");
    }

    public class Vehicle
    {
        public VehicleType Type { get; set; }
        public Chassis Chassis { get; set; }
        public Transmission Transmission { get; set; }
        public Engine Engine { get; set; }
        public Uniqueness Uniqueness { get; set; }

        public Vehicle(VehicleType type, Chassis chassis, Transmission transmission, Engine engine, Uniqueness uniqueness)
        {
            Chassis = chassis;
            Transmission = transmission;
            Engine = engine;
            Uniqueness = uniqueness;
            Type = type;
        }

        public void Print()
        {
            Console.WriteLine($"{Type.ToString()}:");
            Chassis.Print();
            Transmission.Print();
            Engine.Print();
            Uniqueness.Print();
        }

    }
    public class VehiclesGroupByTypeTransmission
    {
        public string TypeOfTransmission { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }

    public enum VehicleType 
    {
        Bus = 1,
        Truck,
        passengerCar,
        Scooter
    }

    class Program
    {
        static void Main(string[] args)
        {
            Uniqueness busUniqueness = new("Movement on Water");
            Uniqueness truckUniqueness = new("Hybrid Сar");
            Uniqueness passengeCarUniqueness = new("Cabriolet");
            Uniqueness scooterUniqueness = new("Attaching a surfboard");

            Engine busEngine = new(170, 3.0, "diesel", "SN100");
            Engine truckEngine = new(260, 7.0, "diesel", "SN200");
            Engine passengerCarEngine = new(140, 2.0, "gasoline", "SN300");
            Engine scooterEngine = new(30, 0.2, "gasoline", "SN400");

            Transmission busTransmission = new("automatic", 7, " FPT Industrial");
            Transmission truckTransmission = new("mechanical", 8, " FPT Industrial");
            Transmission passengerCarTransmission = new("mechanical", 5, "Shenzhen");
            Transmission scooterTransmission = new("automatic", 4, "Shenzhenl");

            Chassis busChassis = new(4, 1738, 15);
            Chassis truckChassis = new(8, 3454, 40);
            Chassis passengerCarChassis = new(4, 4534, 2);
            Chassis scooterChassis = new(2, 2343, 0.12);
           

            List<Vehicle> vehicles = new List<Vehicle>();

            //Автобус
            Vehicle bus = new(VehicleType.Bus, busChassis, busTransmission, busEngine, busUniqueness);
            vehicles.Add(bus);

            //Грузовик
            Vehicle truck = new(VehicleType.Truck, truckChassis, truckTransmission, truckEngine, truckUniqueness);
            vehicles.Add(truck);

            //Легковой автомобиль
            Vehicle car = new(VehicleType.passengerCar, passengerCarChassis, passengerCarTransmission, passengerCarEngine, passengeCarUniqueness);
            vehicles.Add(car);

            //Скутер
            Vehicle scooter = new(VehicleType.Scooter, scooterChassis, scooterTransmission, scooterEngine, scooterUniqueness);
            vehicles.Add(scooter);


            //Print
            vehicles.ForEach(v => v.Print());

            //XML
            //1. Полную информацию о всех транспортных средствах, обьем двигателя которых больше чем 1.5 литров:
            var list = vehicles.Where(v => v.Engine.Volume > 1.5).ToList();
            SerializeVehicleToXml(list, filename: "XMLFileAllInf_1.5.xml");


            //2. Тип двигателя, серийный номер и его мощность для всех автобусов и грузовиков:
            var engines = vehicles.Where(v => v.Type == VehicleType.Bus || v.Type == VehicleType.Truck).Select(v => v.Engine).ToList();
            SerializEengineToXml(engines, filename: "XMLFileEngineTruckBus.xml");

            //3. Полную информацию о всех транспортных средствах, сгруппированную по типу трансмиссии.          
            var transmission = vehicles.GroupBy(v => v.Transmission.TypeOf).Select(g=> new VehiclesGroupByTypeTransmission
            {
                TypeOfTransmission=g.Key,
                Vehicles = g.Select(v=>v).ToList()
            }).ToList();

            SerializVehiclesGroupByTransmissionToXml(transmission, filename: "XMLFileTypeTransmission.xml");

        }

        static void  SerializeVehicleToXml(List<Vehicle> list, string filename)
        {
            XDocument xdoc = new XDocument();
            XElement carPark = new XElement("CarPark");

            foreach (Vehicle v in list)
            {
                XElement vehicle = new XElement("Vehicle");
                XAttribute NameAttr = new XAttribute(nameof(v.Type), v.Type.ToString());              
                XElement UniquenessElem = new XElement("Uniqueness", v.Uniqueness.UniquenessProperty);
                XElement EngineElem = new XElement("Engine");
                var power  = new XElement ("Power", v.Engine.Power.ToString());
                var volume = new XElement("Volume", v.Engine.Volume.ToString());
                var type = new XElement("Type", v.Engine.TypeOf.ToString());
                var serialNumber = new XElement("SerialNumber", v.Engine.SerialNumber.ToString());

                XElement TransmissionElem = new XElement("Transmission");
                var typeOf = new XElement("TypeOf", v.Transmission.TypeOf.ToString());
                var numberOfGears = new XElement("NumberOfGears", v.Transmission.NumberOfGears.ToString());
                var manufacturer = new XElement("Manufacturer", v.Transmission.Manufacturer.ToString());

                XElement ChassisElem = new XElement("Chassis");
                var numberOfWheels = new XElement("NumberOfWheels", v.Chassis.NumberOfWheels.ToString());
                var number = new XElement("Number", v.Chassis.Number.ToString());
                var permissibleLoad = new XElement("PermissibleLoad", v.Chassis.PermissibleLoad.ToString());

                EngineElem.Add(power);
                EngineElem.Add(volume);
                EngineElem.Add(type);
                EngineElem.Add(serialNumber);

                TransmissionElem.Add(typeOf);
                TransmissionElem.Add(numberOfGears);
                TransmissionElem.Add(manufacturer);

                ChassisElem.Add(numberOfWheels);
                ChassisElem.Add(number);
                ChassisElem.Add(permissibleLoad);

                vehicle.Add(NameAttr);
                vehicle.Add(UniquenessElem);
                vehicle.Add(EngineElem);
                vehicle.Add(TransmissionElem);
                vehicle.Add(ChassisElem);

                carPark.Add(vehicle);
            }     
            xdoc.Add(carPark);
            xdoc.Save(filename);          
        }

        static void SerializEengineToXml(List<Engine> engines, string filename)
        {
            XDocument xdoc = new XDocument();
            XElement engine = new XElement("EnginesBusTruck");

            foreach (Engine e in engines)
            {
                XElement EngineElem = new XElement("Engine");
                var power = new XElement("Power", e.Power.ToString());            
                var type = new XElement("Type", e.TypeOf.ToString());
                var serialNumber = new XElement("SerialNumber", e.SerialNumber.ToString());
              
                EngineElem.Add(power);
                EngineElem.Add(type);
                EngineElem.Add(serialNumber);            
                engine.Add(EngineElem);
            }                   
            xdoc.Add(engine);
            xdoc.Save(filename);
        }
        static void SerializVehiclesGroupByTransmissionToXml(List<VehiclesGroupByTypeTransmission> transmission, string filename)
        {
            XDocument xdoc = new XDocument();         
            XElement GrTransmissions = new XElement("Transmission");

            foreach (var t in transmission)
            {
                XElement transmissionElement = new XElement("Transmission");
                XAttribute NameTransmission = new XAttribute(nameof(t.TypeOfTransmission), t.TypeOfTransmission.ToString());
                transmissionElement.Add(NameTransmission);
                foreach (var v in t.Vehicles)
                {                     
                    XElement Vehicle = new XElement("Vehicle");
                    XAttribute NameAttr = new XAttribute(nameof(v.Type), v.Type.ToString());
                    XElement UniquenessElem = new XElement("Uniqueness", v.Uniqueness.UniquenessProperty);
                    XElement EngineElem = new XElement("Engine");
                    var power = new XElement("Power", v.Engine.Power.ToString());
                    var volume = new XElement("Volume", v.Engine.Volume.ToString());
                    var typeEngine = new XElement("Type", v.Engine.TypeOf.ToString());
                    var serialNumber = new XElement("SerialNumber", v.Engine.SerialNumber.ToString());

                    XElement transmissionElem = new XElement("Transmission");
                    var typeOf = new XElement("TypeOf", v.Transmission.TypeOf.ToString());
                    var numberOfGears = new XElement("NumberOfGears", v.Transmission.NumberOfGears.ToString());
                    var manufacturer = new XElement("Manufacturer", v.Transmission.Manufacturer.ToString());

                    XElement ChassisElem = new XElement("Chassis");
                    var numberOfWheels = new XElement("NumberOfWheels", v.Chassis.NumberOfWheels.ToString());
                    var number = new XElement("Number", v.Chassis.Number.ToString());
                    var permissibleLoad = new XElement("PermissibleLoad", v.Chassis.PermissibleLoad.ToString());

                    EngineElem.Add(power);
                    EngineElem.Add(volume);
                    EngineElem.Add(typeEngine);
                    EngineElem.Add(serialNumber);

                    transmissionElem.Add(typeOf);
                    transmissionElem.Add(numberOfGears);
                    transmissionElem.Add(manufacturer);

                    ChassisElem.Add(numberOfWheels);
                    ChassisElem.Add(number);
                    ChassisElem.Add(permissibleLoad);

                    Vehicle.Add(NameAttr);
                    Vehicle.Add(UniquenessElem);
                    Vehicle.Add(EngineElem);
                    Vehicle.Add(transmissionElem);
                    Vehicle.Add(ChassisElem);

                    transmissionElement.Add(Vehicle);
                }
                GrTransmissions.Add(transmissionElement);
            }            
            xdoc.Add(GrTransmissions);
            xdoc.Save(filename);
        }
    }
}