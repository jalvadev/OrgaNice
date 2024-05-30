using OrgaNice.DAL;
using OrgaNice.Properties;
using OrgaNice.Responses;
using OrgaNice.UI;

bool exit = false;
string message = "Welcome to Organice!";

while(!exit)
{
    MenuUI.Refresh();
    Console.WriteLine(message);
    Console.WriteLine("-------------------------------------");
    MenuUI.PrintMainMenu();

    string? userResponse = Console.ReadLine();
    IResponse response = MenuUI.ProccessRequest(userResponse);

    if (response.Success)
    {
        switch ((response as ComplexResponse<int>).Result)
        {
            case 1:
                response = MenuUI.CreateUnit();
                break;
            case 2:
                response = MenuUI.ListUnits();
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
