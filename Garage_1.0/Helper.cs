namespace Garage_1._0
{
    public static  class Helper
    {
      
        public static void EndIt()
        {
            Console.WriteLine();
            Console.WriteLine("Press enter to continue");    
            Console.ReadLine();
               }

        public static int TestIFInputIsInteger()            
        {
            bool test=true;
            int res;
            do
            {              
                test = int.TryParse(Console.ReadLine(), out res);
                if (test == false)
                {
                    Console.WriteLine("Wrong input, plese try again");
                }
            } while (test == false);
            return res;
        }

        public static string GetRegNr()
        {
            bool test;
            string regnr;
            do
         {
            Console.WriteLine();
            Console.WriteLine("Input the vehicles registration number and press enter");
            test = true;
            regnr = Console.ReadLine();
            if (String.IsNullOrEmpty(regnr))
            { 
                    test = false;
                Console.WriteLine("The vehicle must have a registration number, please try again");

            }
         } while (test == false);

            return regnr.ToUpper();
        }
    }
}
