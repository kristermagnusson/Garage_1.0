namespace Garage_1._0
{
    public class GarageHandler : IGarageHandler
    {
        public int Capacity;
        private Garage<Vehicle> garage = null;                                                                  

        public GarageHandler(int capacity)
        {
            Capacity = capacity;
            garage = new Garage<Vehicle>(capacity);                                                     
            Console.WriteLine($"A Garage with {capacity} parkingslots have been created");
        }

        public void SeedData()
        {
            Console.WriteLine("Tries to park five vehicles");

            Park(new Boat("AAA002", "Black", 3, false));
            Park(new Bus("AAA001", "Yelow", 4, "diesel"));
            Park(new Boat("AAA003", "Black", 3, true));
            Park(new Car("AAA004", "White", 4, 4));
            Park(new Airplane("AAA005", "Silver", 3, 50));
        }

        public void Park(Vehicle vehicle)
        {
            vehicle.RegNumber = vehicle.RegNumber.ToUpper();
            if (CheckRegNr(vehicle.RegNumber) == false)
            {
                Console.WriteLine($"There is allready a vehicle with reg number {vehicle.RegNumber}");
                Console.WriteLine($"in the garage,parking denied");
                Console.WriteLine();
            }

            else if (garage.Park(vehicle))
            {
                Console.WriteLine($"Succesfully parked vehicle: {vehicle.RegNumber}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Unable to park vehicle: {vehicle.RegNumber}. Garage is full!");
                Console.WriteLine();
            }
        }




        public void FindByRegNr(string regnr)
        {
            regnr = regnr.ToUpper();
            var vehicle = garage.FirstOrDefault(v => v.RegNumber == regnr);
            Console.WriteLine(vehicle);
            if (vehicle == null) Console.WriteLine("Number doesnot exist");
            Console.WriteLine();
        }

        public void PrintAllVehicles()
        {
            if (FreePlaces() == Capacity)
            {
                Console.WriteLine("The Garage is empty!");
            }
            foreach (var vehicle in garage)
            { Console.WriteLine(vehicle); }
        }

        public bool CheckRegNr(string regnr)
        {
            regnr = regnr.ToUpper();
            var querry = garage.Where(v => v.RegNumber == regnr);                //Return false if RegNumber allready
            if (querry.Count() > 0) return false;                               // in Garage
            else return true;
        }

        public int FreePlaces()
        {

            return (Capacity - garage.Count());
        }



        public void UnPark(string regNumber)
        {
            regNumber = regNumber.ToUpper();
            if (CheckRegNr(regNumber) == false)
            {
                if (garage.Unpark(regNumber))

                {
                    Console.WriteLine($"The vehicle {regNumber} is unparked ");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine($"The vehicle {regNumber} vas not found in the garage");
                Console.WriteLine();
            }
            Helper.EndIt();

        }
        public void TypeAndNumber()                                                                        //Type and number of vehicles
        {
            int car = 0;
            int bus = 0;
            int motorcycle = 0;
            int airplane = 0;
            int boat = 0;

            foreach (var vehicle in garage)
            {
                if (vehicle is Car) car++;
                if (vehicle is Bus) bus++;
                if (vehicle is Motorcycle) motorcycle++;
                if (vehicle is Boat) boat++;
                if (vehicle is Airplane) airplane++;
            }
            Console.WriteLine($"Number of Cars: {car}  Busses: {bus}  Motorcycles: {motorcycle}  Boats: {boat}   Airplanes: {airplane}");


        }
        public void Query()
        {
            List<Vehicle> garageAsList = garage.ToList();

            Console.WriteLine("Input which type of vehicle you are searching on and press enter");
            Console.WriteLine("If you dont want to search on type of wehicle, press enter");
            string input1 = Console.ReadLine().ToUpper();

            switch (input1)                                                                             //Type of vehicle to search for 
            {
                case "CAR":
                    {
                        garageAsList = garage.Where(v => v is Car).ToList();
                        break;
                    }

                case "BUS":
                    {
                        garageAsList = garage.Where(v => v is Bus).ToList();
                        break;
                    }
                case "MOTORCYCLE":
                    {
                        garageAsList = garage.Where(v => v is Motorcycle).ToList();
                        break;
                    }
                case "BOAT":
                    {
                        garageAsList = garage.Where(v => v is Boat).ToList();
                        break;
                    }
                case "AIRPLANE":
                    {
                        garageAsList = garage.Where(v => v is Airplane).ToList();
                        break;
                    }

                default:
                    {
                        garageAsList = garage.ToList();
                        break;
                    }
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Input which Color of vehicle you are searching for and press enter");
            Console.WriteLine("If you dont want to search on color of wehicle, press enter");
            string color = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Input the number of wheels you are searching for and press enter");
            Console.WriteLine("If you dont want to search on number of wheels, press enter");
            Console.WriteLine();

            int numberOfWheels = 0;


            bool i = Int32.TryParse(Console.ReadLine(), out numberOfWheels);
            Search(garageAsList, numberOfWheels, color);
        }
        public void Search(List<Vehicle> VehicleList, int Wheels = 0, string GColors = "")                   //search for vehicle with nr of wheels and Color
        {
            bool findcar = false;
            if (GColors == "" && Wheels == 0)
            {
               
                foreach (var vehicle in VehicleList)
                {
                    Console.WriteLine(vehicle);
                    findcar = true;

                }
            }

            if ((GColors != "") && (Wheels == 0))
            {
                var query = VehicleList.Where(v => v.Color.ToUpper() == GColors.ToLower());

                foreach (var vehicle in query)
                {
                    Console.WriteLine(vehicle);
                    findcar = true;
                }
            }

            if (GColors == "" && Wheels != 0)
            {
                var query = VehicleList.Where(v => v.NumberOfWheels == Wheels);
                foreach (var vehicle in query)

                {
                    Console.WriteLine(vehicle);
                    findcar = true;

                }
            }

            if ((GColors != "") && (Wheels != 0))
            {
                var query = VehicleList.Where(v => (v.NumberOfWheels == Wheels) && (v.Color.ToLower() == GColors.ToLower()));
                foreach (var vehicle in query)
                {
                    Console.WriteLine(vehicle);
                    findcar = true;
                }
            }
            if (findcar == false ) 
            Console.WriteLine("Could not find any vehicles matching your description! ");
        }

        public void PutVehicle()                                                                                    // vehicle to park
        {
            string vehicletype;
            Console.Clear();
            Console.WriteLine("Please state what kind of wehicle you want to park");
            Console.WriteLine("1: Car");
            Console.WriteLine("2: Boat");
            Console.WriteLine("3: Bus");
            Console.WriteLine("4: Motorcycle");
            Console.WriteLine("5: Airplane");
            Console.WriteLine("Input your choice and press enter");
            vehicletype = Console.ReadLine();
           
            string regNr = Helper.GetRegNr();
            //regNr = regNr.ToUpper();
            Console.WriteLine("State the color of the vehile and press enter");
            string vehicleColor = Console.ReadLine().ToUpper();
            Console.WriteLine();
            int nrOfWheels;
            bool test = true;
            Console.WriteLine("Input the number of Wheels");

            nrOfWheels = Helper.TestIFInputIsInteger();

            int nrOfDoors;
            if (vehicletype == "1")
            {
                Console.WriteLine("Input the number of doors and press enter");
                nrOfDoors = Helper.TestIFInputIsInteger();
                Park(new Car(regNr, vehicleColor, nrOfWheels, nrOfDoors));
            }

            if (vehicletype == "2")
            {
                Console.WriteLine("Does the Boat float?");
                Console.WriteLine("Input y for yes and press enter ");
                Console.WriteLine("If the boat sinks , press enter");
                string doesFloat = Console.ReadLine();
                bool boatFloat = false;
                if ((doesFloat == "y") || (doesFloat == "Y"))
                    boatFloat = true;

                Park(new Boat(regNr, vehicleColor, nrOfWheels, boatFloat));
            }

            if (vehicletype == "3")
            {
                Console.WriteLine("Input the fueltype and press enter");
                string fType = Console.ReadLine();
                Park(new Bus(regNr, vehicleColor, nrOfWheels, fType));
            }

            if (vehicletype == "4")
            {
                int cylVol = 0;
                test = true;
                do
                {
                    Console.WriteLine("Input the Cylindervolume and press enter");
                    test = Int32.TryParse(Console.ReadLine(), out cylVol);
                    if (test == false)
                    {
                        Console.WriteLine("Wrong input, please try again");

                    }
                } while (test == false);

                Park(new Motorcycle(regNr, vehicleColor, nrOfWheels, cylVol));
            }

            if (vehicletype == "5")
            {
                int nrOfSeats = 0;
                test = true;
                Console.WriteLine("Input the number of seats and press enter");

                nrOfSeats = Helper.TestIFInputIsInteger();


                Park(new Airplane(regNr, vehicleColor, nrOfWheels, nrOfSeats));
            }
        }
    }
}
