namespace HW4IAC
{
    /*
    Создать структуру "Координата", определяющую 3D координаты некоторого объекта(положительные числа).
    Определить интерфейс IFlyable с методами FlyTo(новая точка), GetFlyTime(новая точка). 
    Создать классы "Птица", "Самолет", "Дрон", реализующие данный интерфейс и содержащие как миминум поле "Текущее положение". 
    Использовать следующие предположения:
    птица летит все расстояние с постоянной скоростью в диапазоне 0-20 км/ч(заданной случайно),    
    самолет увеличивает скорость на 10 км/ч каждые 10 км полета от начальной скорости 200 км/ч.,   
    дрон зависает в воздухе каждые 10 минут полета на 1 минуту.
    Исходя из задачи, ввести дополнительные ограничения(например, невозможность полета дрона на дальность более чем на 1000 км).
    Методы и введенные ограничения описать в комментариях.
    
     Формулы скорости, расстояния и времени:
     V = S / T;   S = V* T; T = S / V;
     где V - скорость, S - расстояние, T - время
    */
    interface IFlyable
    {
        public void FlyTo(Coordinate point);
        public double GetFlyTime(Coordinate point);
    }
    public struct Coordinate // структура координат X,Y,Z
    {
        public int x; // координата x
        public int y; // координата y
        public int z; // координата z
        public Coordinate(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }
    }
    //Птица летит все расстояние с постоянной скоростью в диапазоне 0-20 км/ч(заданной случайно),
    class Bird : IFlyable //реализация интерфейса в классе Птица
    {
        public Coordinate CurrentPoint = new();//текущее положение
        double Speed = 40;

        public Bird(double Speed)
        {
            this.Speed = Speed;
        }
        public void FlyTo(Coordinate point)
        {
            if (FlyUtils.CalculateDistance(CurrentPoint, point) > 300) // Дополнительное ограничение мах. дальность полета птицы "Почтовый голубь" км. 
            {
                Console.WriteLine("Дальность полета, ограничена этим видом птиц!");
                return;
            }
            //fly
            CurrentPoint = point;
        }
        public double GetFlyTime(Coordinate point)
        {
            double dist = FlyUtils.CalculateDistance(CurrentPoint, point);
            double time = dist / Speed;
            return time;
        }
    }
    //Cамолет увеличивает скорость на 10 км/ч каждые 10 км полета от начальной скорости 200 км/ч.,
    class Aircraft : IFlyable
    {
        public Coordinate CurrentPoint = new();
        double StartSpeed = 200; //нач. скорость взлета
        double IncSpeed = 10; //увеличение скорости на 10 км/ч
        double IncDist = 10; // дистанция через которую увеличиваем скорость

        public Aircraft()
        {
        }
        public Aircraft(double StartSpeed, double IncSpeed, double IncDist)
        {
            this.StartSpeed = StartSpeed;
            this.IncSpeed = IncSpeed;
            this.IncDist = IncDist;

        }

        public void FlyTo(Coordinate point) //летим к заданной точке 
        {
            if (FlyUtils.CalculateDistance(CurrentPoint, point) < 10) // Дополнительное ограничение, по минимальной дальности полета в км.
            {
                Console.WriteLine("Необходим более длинный маршрут полета");
                return;
            }
            // fly
            CurrentPoint = point;
        }
        public double GetFlyTime(Coordinate point) //В методе получаем время преодоляемой дистанции
        {

            double dist = FlyUtils.CalculateDistance(CurrentPoint, point);

            double time = 0;
            double Speed = StartSpeed;
            double q = dist / IncDist;

            if (dist == 0)
            {
                return 0;
            }

            for (int i = 0; q >= i; i++)
            {
                time = time + 10 / Speed;
                Speed = Speed + IncSpeed;

            }
            if (dist % IncDist > 0)
            {
                time = time + (dist % IncDist) / Speed;
            }


            return time * 60;
        }
    }
    //Дрон зависает в воздухе каждые 10 минут полета на 1 минуту.
    class Drone : IFlyable
    {
        public Coordinate CurrentPoint = new();
        double Speed = 40;
        double Hovering = 1;
        double AfterM = 10;

        public Drone(double speed, double hovering, double afterM)
        {
            this.Speed = speed;
            this.Hovering = hovering;
            this.AfterM = afterM;
        }

        public void FlyTo(Coordinate point)
        {
            if (FlyUtils.CalculateDistance(CurrentPoint, point) > 1000) // Дополнительное ограничение полета дрона на дальность более чем на 1000 км
            {
                Console.WriteLine("Указанная дистанция ограниченна дальностью полета дрона!");
                return;
            }
            // fly
            CurrentPoint = point;
        }

        public double GetFlyTime(Coordinate point)
        {
            double dist = FlyUtils.CalculateDistance(CurrentPoint, point);
            double time = (dist / Speed) * 60;
            double PauseCount = time / AfterM;
            double TotalTime = time + PauseCount * Hovering;

            if (time % AfterM == 0)
            {
                TotalTime = TotalTime - 1;
            }
            return TotalTime;
        }
    }
    class FlyUtils
    {
        public static double CalculateDistance(Coordinate CurrentPoint, Coordinate DestinationPoint)
        {
            double Dist = Math.Sqrt( //извлечение квадратного корня
            Math.Pow(CurrentPoint.x - DestinationPoint.x, 2) + //возведение чисел в степень
            Math.Pow(CurrentPoint.y - DestinationPoint.y, 2) +
            Math.Pow(CurrentPoint.z - DestinationPoint.z, 2)
                 );

            return Dist;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Aircraft aircraft = new();
           // Aircraft aircraft2 = new(250, 10, 10);
            Drone dron = new(50, 1, 10);
            Bird bird = new(50);

            Coordinate coordinate = new(200, 200, 200);
            Coordinate coordinate2 = new(89, 80, 81);
            Coordinate coordinate3 = new(40, 40, 40);

            Console.WriteLine("distance aircraft = " + FlyUtils.CalculateDistance(aircraft.CurrentPoint, coordinate));
           // Console.WriteLine("distance aircraft 2 = " + FlyUtils.CalculateDistance(aircraft2.CurrentPoint, coordinate));
            Console.WriteLine("distance dron = " + FlyUtils.CalculateDistance(dron.CurrentPoint, coordinate2));
            Console.WriteLine("distance bird = " + FlyUtils.CalculateDistance(bird.CurrentPoint, coordinate3));

           /*
            aircraft.FlyTo(coordinate);
            Console.WriteLine(aircraft.CurrentPoint.x);
            Console.WriteLine(aircraft.CurrentPoint.y);
            Console.WriteLine(aircraft.CurrentPoint.z);

            dron.FlyTo(coordinate2);
            Console.WriteLine(dron.CurrentPoint.x);
            Console.WriteLine(dron.CurrentPoint.y);
            Console.WriteLine(dron.CurrentPoint.z);

            bird.FlyTo(coordinate3);
            Console.WriteLine(bird.CurrentPoint.x);
            Console.WriteLine(bird.CurrentPoint.y);
            Console.WriteLine(bird.CurrentPoint.z);
            */


            double time = aircraft.GetFlyTime(coordinate);
            //double time2 = aircraft2.GetFlyTime(coordinate);
            double time3 = dron.GetFlyTime(coordinate2);
            double time4 = bird.GetFlyTime(coordinate3);

            Console.WriteLine("time aircraft  = " + time);
           // Console.WriteLine("time aircraft 2 = " + time2);
            Console.WriteLine("time dron = " + time3);
            Console.WriteLine("time bird = " + time4);

        }
    }
}
