using OrgaNice.Responses;
using OrgaNice.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgaNice
{
    internal class App
    {
        public static void Run()
        {
            bool exit = false;
            string selectedUnit;
            string message = "Welcome to Organice!";

            while (!exit)
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
                            response = MenuUI.SelectUnit();
                            if (response.Success)
                                selectedUnit = (response as ComplexResponse<string>).Result;
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                }

                message = response.Message;
            }
        }
    }
}
