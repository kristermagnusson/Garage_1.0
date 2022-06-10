using Garage_1._0;


public class GarageManager
{

    private IGarageHandler garageHandler = null!;
    public void  InitiateGarage()

    {
        Console.SetWindowSize(150, 50);
        string startchoice = " ";
        int garagePlaces = 0;
        bool number = false;

        Console.WriteLine($"*******************************************************");
        Console.WriteLine($"**                                                   **");
        Console.WriteLine($"**                Garaget 1.0                        **");
        Console.WriteLine($"**                                                   **");
        Console.WriteLine($"*******************************************************");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("how many slots do you wish the garage to have?");

        while (number == false)
        {
                        startchoice = Console.ReadLine();
             
            number = int.TryParse(startchoice, out garagePlaces);                                        //test av inmatning
            if ((number == false) || (garagePlaces < 0))
            {
                Console.WriteLine("The input format was wrong, try again ");
                number = false;
            }
        }
        
        garageHandler = new GarageHandler(garagePlaces);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("If You want to put five preselected vehicles in the garage");
        Console.WriteLine("press y and enter, otherwise press enter");
        startchoice = Console.ReadLine();
        if (startchoice == "y")
        {
            garageHandler.SeedData();
            garageHandler.PrintAllVehicles();
           
        }
        Helper.EndIt();    }
 
    public void MainInterface()
    {
        bool TheEnd = false;
        bool UILoop = true;
        int Garagechoice;
        do
        {
            do
            {
                UILoop = false;
                Console.Clear();
                Console.WriteLine(" You have the following choices:");
                Console.WriteLine();
                Console.WriteLine("1  Remove a Vehicle from the garage");                   
                Console.WriteLine("2  Park A Vehicle");                                    
                Console.WriteLine("3  Search for a particular Registration number");        
                Console.WriteLine("4  Display the number of free slots in the garage");     
                Console.WriteLine("5  Display types and number of Vehicles");               
                Console.WriteLine("6  Advanced search for vehicles");                       
                Console.WriteLine("7  Show the vehicles presently in the garage");         
                Console.WriteLine("8  End this program");

               Garagechoice = Helper.TestIFInputIsInteger();

            } while (UILoop == true);

            switch (Garagechoice)
            {
                case 1:
                    {
                        Console.WriteLine("input the registration number for the vehicle to unpark and press enter");
                        string regnr = Console.ReadLine();
                        Console.WriteLine();
                        garageHandler.UnPark(regnr);
                        
                        break;
                    }
                case 2:
                    {
                        garageHandler.PutVehicle();
                        Helper.EndIt();
                        break;
                    }
                case 3:  
                    {
                        string regnr = Helper.GetRegNr();
                        
                        garageHandler.FindByRegNr(regnr );
                        Helper.EndIt();

                        break; 
                    }
                case 4: 
                    {
                        Console.WriteLine();
                        Console.WriteLine($" Number of free slots: {garageHandler.FreePlaces()} ");
                        Helper.EndIt();
                        break; 
                    }
                case 5: 
                    {
                        Console.WriteLine();
                        garageHandler.TypeAndNumber();
                        Helper.EndIt();
                        break; 
                    }
                case 6: 
                    {
                        Console.WriteLine();
                        garageHandler.Query();
                        //Query()
                        Helper.EndIt();
                        break; 
                    }
                case 7: 
                    {
                        garageHandler.PrintAllVehicles();
                        Helper.EndIt();
                        break; 
                    }
                case 8: 
                    {
                        TheEnd = true;
                        break;
                    }
                default:
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid input, please try again");
                        Helper.EndIt();
                        break;                    
                    }
            }
        } while (!TheEnd);
    }
    }
    




















