class Program
{
    //Rooted dictionary with information regarding each user
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
    
    //Dicitonary of each bankaccount linked to each user
    static Dictionary<int, List<int>> UserAccounts = new Dictionary<int, List<int>>
    {
        { 123456, new List<int> { 1001, 1002, 1003 } },
        { 789012, new List<int> { 1004, 1005 } },
        { 345678, new List<int> { 1006, 1007, 1008, 1009 } },
        { 901234, new List<int> { 1010, 1011 } },
        { 567890, new List<int> { 1012, 1013, 1014 } }
    };

    //Dictionary of name of each bankaccount
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

    //Dictionary of the balance of each bankaccount
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
        
        //Check for login information
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

            Console.WriteLine("Fel användarnummer eller pinkod");
        }

        Console.WriteLine("För många misslyckade inloggningsförsök. Programmet avslutas");
        Console.ReadKey();
    }

    static void AccountMenu(int userNumber)
    {
        Console.WriteLine("Välkommen till ditt konto, " + UsersInformation[userNumber]["name"]);
        
        //Menu for all the options
        string userChoice;
        while (true)
        {
            Console.WriteLine("Välj ett alernativ: \n1. Se dina konton och saldo \n2. Överföring mellan konton \n3. Ta ut pengar \n4. Logga ut");
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
                    logIn();
                    return;;
                default:
                    Console.WriteLine("Ogiltigt val. Försök igen");
                    break;
            }
        }
    }

    static void ViewAccounts(int userNumber)
    {
        //List storing all bankaccount numbers for lookup
        List<int> accounts = UserAccounts[userNumber];

        //List all accounts in console
        foreach (int accountNumber in accounts)
        {
            Console.WriteLine(AccountNames[accountNumber] + ": " + AccountBalances[accountNumber] + " kr");
        }
        
        Console.WriteLine();
        Console.WriteLine("Klicka på en tangent för att gå tillbaka");
        Console.ReadKey();
        Console.Clear();
    }

    static void AccountTransfer(int userNumber)
{
    //List storing all bankaccount numbers for lookup
    List<int> accounts = UserAccounts[userNumber];

    //List all accounts in console
    int tempNum = 1;
    foreach (int accountNumber in accounts)
    {
        Console.WriteLine(tempNum + " " + AccountNames[accountNumber] + ": " + AccountBalances[accountNumber] + " kr");
        tempNum++;
    }

    int account1, account2;
    
    //Let user pick first account to transfer from
    Console.WriteLine();
    Console.WriteLine("Välj ett konto att överföra från genom att skriva kontots nummer. Skriv avbryt för att avbryta");
    
    string userAccountInput;
    while (true)
    {
        userAccountInput = Console.ReadLine();

        if (userAccountInput.ToLower() == "avbryt")
        {
            Console.WriteLine("Återgår till meny");
            return;
        }

        if (!int.TryParse(userAccountInput, out account1) || account1 < 1 || account1 > accounts.Count)
        {
            Console.WriteLine("Ogiltigt val, försök igen");
        }
        else
        {
            break;
        }
    }
    
    //Let user pick first account to transfer to
    Console.WriteLine();
    Console.WriteLine("Välj ett konto att överföra till genom att skriva kontots nummer. Skriv avbryt för att avbryta");

    while (true)
    {
        userAccountInput = Console.ReadLine();

        if (userAccountInput.ToLower() == "avbryt")
        {
            Console.WriteLine("Återgår till meny");
            return;
        }

        if (!int.TryParse(userAccountInput, out account2) || account2 < 1 || account2 > accounts.Count)
        {
            Console.WriteLine("Ogiltigt val, försök igen");
        }
        else if (account2 == account1)
        {
            Console.WriteLine("Du kan inte överföra till samma konto, försök igen");
        }
        else
        {
            break;
        }
    }
    
    //Let user pick transfer amount
    int fromAccountNumber = accounts[account1 - 1];
    int toAccountNumber = accounts[account2 - 1];
    
    Console.WriteLine();
    Console.WriteLine("Hur mycket vill du överföra? Skriv avbryt för att avbryta");

    decimal transferAmount;
    string transferInput;
    while (true)
    {
        transferInput = Console.ReadLine();

        if (transferInput.ToLower() == "avbryt")
        {
            Console.WriteLine("Återgår till meny");
            return;
        }

        if (!decimal.TryParse(transferInput, out transferAmount))
        {
            Console.WriteLine("Ogiltigt belopp, skriv ett nummer");
        }
        else if (transferAmount <= 0)
        {
            Console.WriteLine("Beloppet måste vara större än 0");
        }
        else if (transferAmount > AccountBalances[fromAccountNumber])
        {
            Console.WriteLine("Det finns inte tillräckligt med pengar på kontot");
        }
        else
        {
            break;
        }
    }
    
    //Do the transfer
    AccountBalances[fromAccountNumber] -= transferAmount;
    AccountBalances[toAccountNumber] += transferAmount;

    Console.WriteLine();
    Console.WriteLine("Överföringen lyckades!");
    Console.WriteLine("Nytt saldo på kontot du överförde från: " + AccountBalances[fromAccountNumber] + " kr");
    Console.WriteLine("Nytt saldo på kontot du överförde till: " + AccountBalances[toAccountNumber] + " kr");

    Console.WriteLine();
    Console.WriteLine("Klicka på en tangent för att gå tillbaka");
    Console.ReadKey();
    Console.Clear();
}

    static void AccountWithdrawl(int userNumber)
    {
        //List storing all bankaccount numbers for lookup
        List<int> accounts = UserAccounts[userNumber];

        //List all accounts in console
        int tempNum = 1;
        foreach (int accountNumber in accounts)
        {
            Console.WriteLine(tempNum + " " + AccountNames[accountNumber] + ": " + AccountBalances[accountNumber] + " kr");
            tempNum++;
        }
        
        //Let user pick account to withdraw from
        Console.WriteLine("Välj ett konta att ta ut pengar från genom att skriva kontots nummer. Skriv avbryt för att avbryta");

        int withdrawlAccount;
        string userAccountInput;
        while (true)
        {
            userAccountInput = Console.ReadLine();

            if (userAccountInput.ToLower() == "avbryt")
            {
                Console.WriteLine("Återgår till meny");
                return;
            }

            if (!int.TryParse(userAccountInput, out withdrawlAccount) || withdrawlAccount < 1 || withdrawlAccount > accounts.Count)
            {
                Console.WriteLine("Ogiltigt val, försök igen");
            }
            else
            {
                break;
            }
        }
        int AccountNumber = accounts[withdrawlAccount - 1];
        
        //Let user pick withdraw amount
        Console.WriteLine("Hur mycket vill du ta ut? Skriv avbryt för att avbryta");

        decimal withdrawlAmount;
        string withdrawlInput;
        while (true)
        {
            withdrawlInput = Console.ReadLine();

            if (withdrawlInput.ToLower() == "avbryt")
            {
                Console.WriteLine("Återgår till meny");
                return;
            }

            if (!decimal.TryParse(withdrawlInput, out withdrawlAmount))
            {
                Console.WriteLine("Ogiltigt belopp, skriv ett nummer");
            }
            else if (withdrawlAmount <= 0)
            {
                Console.WriteLine("Beloppet måste vara större än 0");
            }
            else if (withdrawlAmount > AccountBalances[AccountNumber])
            {
                Console.WriteLine("Det finns inte tillräckligt med pengar på kontot");
            }
            else
            {
                break;
            }
        }
        
        //Confirm users pincode
        Console.WriteLine("Skriv in din pinkod för att genomföra uttaget");
        
        //Check for login
        int userPin;
        for (int loginTries = 0; loginTries < 3; loginTries++)
        {
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
                    //Do the withdrawl
                    AccountBalances[AccountNumber] -= withdrawlAmount;
        
                    Console.WriteLine();
                    Console.WriteLine("Uttaget lyckades!");
                    Console.WriteLine("Nytt saldo på kontot: " + AccountBalances[AccountNumber] + " kr");

                    Console.WriteLine();
                    Console.WriteLine("Klicka på en tangent för att gå tillbaka");
                    Console.ReadKey();
                    Console.Clear();
                    return;
                }
            }

            Console.WriteLine("Fel pinkod, försök igen");
        }
        Console.WriteLine("För många misslyckade försök, går tillbaka till menyn");
    }
}

