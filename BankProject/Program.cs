class Program
{
    static Dictionary<int, Dictionary<string, string>> UsersInformation = new Dictionary<int, Dictionary<string, string>>
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
    
    static Dictionary<int, List<int>> UserAccounts = new Dictionary<int, List<int>>
    {
        { 123456, new List<int> { 1001, 1002, 1003 } },
        { 789012, new List<int> { 1004, 1005 } },
        { 345678, new List<int> { 1006, 1007, 1008, 1009 } },
        { 901234, new List<int> { 1010, 1011 } },
        { 567890, new List<int> { 1012, 1013, 1014 } }
    };

    static Dictionary<int, string> AccountNames = new Dictionary<int, string>
    {
        { 1001, "Privatkonto" },
        { 1002, "Lönekonto" },
        { 1003, "Sparkonto" },

        { 1004, "Lönekonto" },
        { 1005, "Sparkonto" },

        { 1006, "Privatkonto" },
        { 1007, "Lönekonto" },
        { 1008, "Sparkonto" },
        { 1009, "Resekonto" },

        { 1010, "Lönekonto" },
        { 1011, "Sparkonto" },

        { 1012, "Privatkonto" },
        { 1013, "Lönekonto" },
        { 1014, "Sparkonto" }
    };

    static Dictionary<int, decimal> AccountBalances = new Dictionary<int, decimal>
    {
        { 1001, 1000.00m },
        { 1002, 2000.50m },
        { 1003, 3000.75m },

        { 1004, 8500.25m },
        { 1005, 12500.00m },

        { 1006, 750.50m },
        { 1007, 4250.75m },
        { 1008, 15000.00m },
        { 1009, 3200.25m },

        { 1010, 6500.00m },
        { 1011, 22000.50m },

        { 1012, 450.75m },
        { 1013, 7800.00m },
        { 1014, 1750.25m }
    };
    
    static void Main()
    {
        logIn();
        Console.ReadKey();
    }

    static void logIn()
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

            if (UsersInformation.ContainsKey(userNumber))
            {
                if (UsersInformation[userNumber]["pin"] == userPin.ToString())
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
        Console.WriteLine("Välkommen till ditt konto, " + UsersInformation[userNumber]["name"]);
        string userChoice;
        while (true)
        {
            
            Console.WriteLine(@"Välj ett alernativ: 
1. Se dina konton och saldo
2. Överföring mellan konton
3. Ta ut pengar
4. Logga ut");
            userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Clear();
                    ViewAccounts(userNumber);
                    break;
                case "2":
                    Console.Clear();
                    AccountTransfer(userNumber);
                    break;
                case "3":
                    Console.Clear();
                    AccountWithdrawl(userNumber);
                    break;
                case "4":
                    Console.Clear();
                    Main();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen.");
                    break;
            }
        }
    }

    static void ViewAccounts(int userNumber)
    {
        List<int> accounts = UserAccounts[userNumber];

        foreach (int accountNumber in accounts)
        {
            Console.WriteLine(AccountNames[accountNumber] + ": " + AccountBalances[accountNumber] + " kr");
        }
        
        Console.WriteLine();
        Console.WriteLine("Klicka på en knapp för att gå tillbaka");
        Console.ReadKey();
    }

    static void AccountTransfer(int userNumber)
    {
        
    }

    static void AccountWithdrawl(int userNumber)
    {
        
    }
}

