class Program
{
    static Dictionary<int, Dictionary<string, string>> Users = new Dictionary<int, Dictionary<string, string>>
    {
        { 123456, new Dictionary<string, string>
            {
                { "pin", "1234" },
                { "name", "Alice" }
            }
        },

        { 789012, new Dictionary<string, string>
            {
                { "pin", "5678" },
                { "name", "Bob" }
            }
        },
        
        { 345678, new Dictionary<string, string>
            {
                { "pin", "9012" },
                { "name", "Anna" }
            }
        },
        { 901234, new Dictionary<string, string>
            {
                { "pin", "3456" },
                { "name", "Frank" }
            }
        },
        { 567890, new Dictionary<string, string>
            {
                { "pin", "7890" },
                { "name", "Christopher" }
            }
            
        }
    };

    private static Dictionary<int, Dictionary<string, string>> Accounts = new Dictionary<int, Dictionary<string, string>>
    {
        {
            1001, new Dictionary<string, string>
            {
                { "balance", "1000" },
                { "accountName", "Savings" }
            }
        },
        {
            1002, new Dictionary<string, string>
            {
                { "balance", "2000" },
                { "accountName", "Checking" }
            }
        },
        {
            1003, new Dictionary<string, string>
            {
                { "balance", "3000" },
                { "accountName", "Savings" }
            }
        },
        {
            1004, new Dictionary<string, string>
            {
                { "balance", "4000" },
                { "accountName", "Checking" }
            }
        },
        {
            1005, new Dictionary<string, string>
            {
                { "balance", "5000" },
                { "accountName", "Savings" }
            }
        }
    };
    
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

            if (Users.ContainsKey(userNumber))
            {
                if (Users[userNumber]["pin"] == userPin.ToString())
                {
                    AccountMenu(userNumber);
                    return;
                }
            }

            Console.WriteLine("Fel användarnummer eller pinkod.");
        }

        Console.WriteLine("För många misslyckade inloggningsförsök. Programmet avslutas.");
        Console.ReadKey();
    }

    static void AccountMenu(int userNumber)
    {
        Console.WriteLine("Välkommen till ditt konto, " + Users[userNumber]["name"]);
        
        
    }
    
}

