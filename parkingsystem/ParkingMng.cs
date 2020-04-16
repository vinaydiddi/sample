using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parkingsystem
{
    class ParkingMng
    {
        public static int small = 50;
        public static int medium = 30;
        public static int large = 20;
        public static int vehiclequeue = default;
        public static int availableslot = 0;
        static void Main(string[] args)
        {
            try
            {
                string tocontinue = "";
                do
                {
                    Console.WriteLine("Welcome to parking management system");
                    Console.WriteLine("The available parking lots are" + "\n" + "small-" + small + "\n" + "medium-" + medium + "\n" + "large-" + large);
                    Console.WriteLine("\n");
                    managementsys managementsys = new managementsys();
                    managementsys.AlotParking();
                    Console.WriteLine("\n");
                    Console.WriteLine("Do you want to continue press Y and N to exit?");
                    tocontinue = Console.ReadLine().ToUpper();
                } while (!string.IsNullOrEmpty(tocontinue) && tocontinue.Contains("Y"));
                if (!string.IsNullOrEmpty(tocontinue) && tocontinue.Contains("N"))
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException);
            }
        }       
    }

    class managementsys:ParkingMng
    {
        public enum parkingsize
        {
            small,
            medium,
            large
        }
        public void AlotParking()
        {
            try
            {
                CarTypes car = new CarTypes();
                Console.WriteLine("Wait at security gate for alotment");
                if (vehiclequeue > 1)
                {
                    Console.WriteLine("Other Vehicle is in process");
                }
                else
                {
                    Console.WriteLine("Please enter the vehicle type");
                    string readvehicletype = Console.ReadLine().ToLower();
                    ParkingLotType(car, readvehicletype);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace + "\n" + ex.InnerException);
            }
        }

        private void ParkingLotType(CarTypes car,string readvehicletype)
        {
            
            List<int> nos = new List<int>();
            try
            {
                if (car != null || !string.IsNullOrWhiteSpace(readvehicletype))
                {
                    switch (readvehicletype)
                    {
                        case "hatchback":
                            Console.WriteLine("Type-" + car.hatchback);
                            Console.WriteLine("provided parking space is" +  parkingsize.small);
                            small = small - 1;
                            Console.WriteLine("The available parking total lots are" + "\n" + "small-" + small + "\n" + "medium-" + medium + "\n" + "large-" + large);
                            vehiclequeue = vehiclequeue + 1;
                            availableslot=availableslot + 1;
                            //nos.Add(availableslot+1);
                            checkremainingslot(availableslot);
                            if (small == 0)
                            {
                                Console.WriteLine("provided parking space is" +  parkingsize.medium);
                                medium = medium - 1;
                                availableslot = availableslot + 1;
                                Console.WriteLine("The available parking total lots are" + "\n" + "small-" + small + "\n" + "medium-" + medium + "\n" + "large-" + large);
                                vehiclequeue = vehiclequeue + 1;
                            }
                            else if (medium == 0)
                            {
                                Console.WriteLine("parking space for hatchback is full");
                            }
                            break;

                        case "sedan":
                            Console.WriteLine("Type-" + car.sedan);
                            Console.WriteLine("provided parking space is" +  parkingsize.medium);
                            medium = medium - 1;
                            Console.WriteLine("The available parking total lots are" + "\n" + "small-" + small + "\n" + "medium-" + medium + "\n" + "large-" + large);
                            vehiclequeue = vehiclequeue + 1;
                            availableslot = availableslot + 1;
                            if (medium == 0)
                            {
                                Console.WriteLine("provided parking space is" + parkingsize.large);
                                medium = medium - 1;
                                availableslot = availableslot + 1;
                                Console.WriteLine("The available parking total lots are" + "\n" + "small-" + small + "\n" + "medium-" + medium + "\n" + "large-" + large);
                                vehiclequeue = vehiclequeue + 1;
                            }
                            else if (large == 0)
                            {
                                Console.WriteLine("parking space for sedan is full");
                            }
                            break;

                        case "suv":
                            Console.WriteLine("Type-" + car.suv);
                            Console.WriteLine("provided parking space is" + parkingsize.large);
                            large = large - 1;
                            availableslot = availableslot + 1;
                            Console.WriteLine("The available parking total lots are" + "\n" + "small-" + small + "\n" + "medium-" + medium + "\n" + "large-" + large);
                            vehiclequeue = vehiclequeue + 1;
                            if (large == 0)
                            {
                                Console.WriteLine("parking space for suv is full");
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message+ "\n" + ex.StackTrace+ "\n" + ex.InnerException);
            }
            
        }

        private void checkremainingslot(int availableslot)
        {
            List<int> nos = new List<int>();
            nos.Add(availableslot);
            //Console.WriteLine("Available slots"+nos.Count);
            foreach (var item in nos)
            {
                Console.WriteLine("Nos of slots used"+item);
            }
            if (nos.Exists(x=>x==availableslot))
            {
                Console.WriteLine("It is already alloted");
            }
        }
    }
}
