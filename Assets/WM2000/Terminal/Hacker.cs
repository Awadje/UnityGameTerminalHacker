using UnityEngine;

public class Hacker : MonoBehaviour {

    //Game config data
    const string menuHint = "You may type menu at any time";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow" };
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};
    string[] level3Passwords = { "stars", "planets", "tesla", "spaceX", "astro" };


    //game state
    int level;
    string password;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

	// Use this for initialization
	void Start () 
    {
        print(level1Passwords[0]); 
        ShowMainMenu();
	}


    void ShowMainMenu () 
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local lirary");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);;
        }
    }

   void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input =="3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select a level Mr Bond");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Enter your password hint" + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int indexp1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[indexp1];
                break;
            case 2:
                int indexp2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[indexp2];
                break;
            case 3:
                int indexp3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[indexp3];
                break;
            default:
                Debug.LogError("invalid password:");
                break;

        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWInScreen();
        }
        else
        {
           AskForPassword();
        }
    }

    void DisplayWInScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book");
                Terminal.WriteLine(@"


*** Bookart ****  

                
"
                );
                break;
            case 2:
                Terminal.WriteLine("Have a prisonkey");
                Terminal.WriteLine(@"


*** Prisonkey art ****  
                
"
                );
                break;
            case 3:
                Terminal.WriteLine("Don't Panic");
                Terminal.WriteLine(@"


*** Space Art ****  
                
"
                );
                break;

        }
    }
}
