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
            
            string unitName = Console.ReadLine();

            return BaseWriter.AddUnit(unitName);
        }
    }
}
