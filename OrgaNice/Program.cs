// See https://aka.ms/new-console-template for more information
using OrgaNice.DAL;
using OrgaNice.Responses;

Console.WriteLine("Hello, World!");

IResponse response = BaseWriter.AddUnit("Angular:?_");
Console.WriteLine(response.Success);
Console.WriteLine(response.Message);

response = BaseWriter.AddUnit("Angular");
Console.WriteLine(response.Success);
Console.WriteLine(response.Message);

response = BaseWriter.DeleteUnit("Angular");
Console.WriteLine(response.Success);
Console.WriteLine(response.Message);

Console.ReadLine();