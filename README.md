Om projektet

Det här projektet är en enkel internetbank. Användaren kan logga in med användarnummer och PIN-kod, se sina konton och saldon, överföra pengar mellan egna konton och ta ut pengar.
Programmet använder konsolen för inmatning och utskrift.

Programmets struktur

Programmet består av en Program-klass med statiska metoder och fält.
UsersInformation lagrar användaruppgifter.
UserAccounts kopplar användare till deras konton.
AccountNames och AccountBalances lagrar kontonamn och saldon.
logIn() hanterar inloggning.
AccountMenu() visar huvudmenyn.
ViewAccounts(), AccountTransfer() och AccountWithdrawl() hanterar kontovisning, överföringar och uttag.

Motivering av lösningen

Jag har valt dictionaries för att lagra användarinformation och kontoinformation samt listor för att koppla användare till sina konton. Detta påminner mycket om classer och objekt men eftersom det var för avanserat för denna uppgiften valde jag en simplare lösning
Jag använder decimal för penningbelopp och kontrollerar inmatningen för att minska risken för ogiltiga transaktioner.
En begränsning är att informationen bara sparas i programmets minne och försvinner när programmet avslutas. En mer utvecklad lösning skulle kunna använda en databas och säkrare hantering av användaruppgifter.
