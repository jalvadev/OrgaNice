using OrgaNice.DAL;
using OrgaNice.Properties;
using OrgaNice.Responses;
using OrgaNice.UI;

bool exit = false;
string message = "Welcome to Organice!";

while(!exit)
{
    Console.WriteLine(message);
    MenuUI.Refresh();
    MenuUI.PrintMainMenu();

    string? userResponse = Console.ReadLine();
    IResponse response = MenuUI.ProccessRequest(userResponse);

    if (response.Success)
    {
        switch ((response as ComplexResponse<int>).Result)
        {
            case 1:
                MenuUI.CreateUnit();
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                exit = true;
                break;
        }
    }

    message = response.Message;
}
