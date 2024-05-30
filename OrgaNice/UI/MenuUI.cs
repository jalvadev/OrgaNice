using OrgaNice.DAL;
using OrgaNice.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgaNice.UI
{
    internal class MenuUI
    {
        public static void Refresh()
        {
            Console.Clear();
        }

        public static IResponse ProccessRequest(string request)
        {
            bool success;
            int requestNumber;

            success = int.TryParse(request, out requestNumber);

            return success ?
                new ComplexResponse<int> { Success = success, Message = "", Result = requestNumber } :
                new SimpleResponse { Success = success, Message = "" };
        }

        public static void PrintMainMenu()
        {
            Console.WriteLine("1 - Crear unidad.");
            Console.WriteLine("2 - Listar unidades.");
            Console.WriteLine("3 - Seleccionar unidad.");
            Console.WriteLine("4 - Salir.");

            Console.Write("¿Que quieres hacer?");
        }


        public static IResponse CreateUnit()
        {
            Console.Clear();
            Console.Write("Nombre de la nueva unidad: ");

            var keyInfo = Console.ReadKey(true);

            var modifier = keyInfo.Modifiers;
            var key = keyInfo.Key;

            if (modifier == ConsoleModifiers.Control && key == ConsoleKey.Z)
                return null;
            else
                Console.Write(key);

            string unitName = key + Console.ReadLine();

            return BaseWriter.AddUnit(unitName);
        }

        public static IResponse ListUnits()
        {
            string message = "";
            IResponse response = BaseWriter.ListUnits();
            if (response.Success == false)
            {
                Console.WriteLine(response.Message);
                return response;
            }
                

            List<string> units = (response as ComplexResponse<List<string>>).Result;
            if (units.Count == 0)
                Console.WriteLine("No hay unidades que mostrar.");
            else
            {
                for (int i = 0; i < units.Count; i++)
                {
                    string currentUnit = units[i];
                    message += currentUnit;

                    if(i < units.Count - 1)
                        message += "\n";
                }
                response.Message = message;
            }

            return response;
        }
    }
}
