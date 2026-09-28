class Program
{
    static void Main()
    {
        Console.WriteLine(@"  
             __  __           _                  ____              _    
            |  \/  |         | |                |  _ \            | |   
            | \  / | __ _  __| | ___ _   _ _ __ | |_) | __ _ _ __ | | __
            | |\/| |/ _` |/ _` |/ _ \ | | | '_ \|  _ < / _` | '_ \| |/ /
            | |  | | (_| | (_| |  __/ |_| | |_) | |_) | (_| | | | |   < 
            |___|_|_\__,_|\__,_|\___|\__,_| .__/|____/ \__,_|_| |_|_|\_\
                                          | |                           
                                          |_|            

                                 ┌───────────────────┐
                                 │     Välkommen     │
                                 │        Till       │
                                 │     MadeupBank    │
                                 └───────────────────┘     
                  
        ");
        logIn();
        Console.ReadKey();
    }

    static void logIn()
    {
        int userNumber;
        int userPin;

        for (int loginTries = 0; loginTries < 3; loginTries++)
        {
            Console.WriteLine("Skriv ditt användarnummer:");

            string userNumberInput = Console.ReadLine();

            while (userNumberInput.Length != 6 || !int.TryParse(userNumberInput, out userNumber))
            {
                Console.WriteLine("Skriv endast ett 6 siffrigt heltal:");
                userNumberInput = Console.ReadLine();
            }

            Console.WriteLine("Skriv din pinkod:");

            string userPinInput = Console.ReadLine();

            while (userPinInput.Length != 4 || !int.TryParse(userPinInput, out userPin))
            {
                Console.WriteLine("Skriv endast ett 4 siffrigt heltal:");
                userPinInput = Console.ReadLine();
            }

            if (CheckLogin(userNumber, userPin))
            {
                AccountInterface(userNumber);
                return;
            }

            Console.WriteLine("Fel användarnummer eller pinkod.");
        }

        Console.WriteLine("För många misslyckade inloggningsförsök. Programmet avslutas.");
        Console.ReadKey();
    }

    static bool CheckLogin(int userNumber, int userPin)
    {
        List<int> validUserNumbers = new List<int> { 123456, 789012 , 345678, 901234, 567890};

        if (validUserNumbers.Contains(userNumber))
        {
            switch (userNumber)
            {
                case 123456:
                    if (userPin == 1234)
                    {
                        return true;
                    }
                    break;
                case 789012:
                    if (userPin == 5678)
                    {
                        return true;
                    }
                    break;
                case 345678:
                    if (userPin == 9012)
                    {
                        return true;
                    }
                    break;
                case 901234:
                    if (userPin == 3456)
                    {
                        return true;
                    }
                    break;
                case 567890:
                    if (userPin == 7890)
                    {
                        return true;
                    }
                    break;
            }
        }
        return false;
    }

    static void AccountInterface(int userNumber)
    {
        
    }
    
}

