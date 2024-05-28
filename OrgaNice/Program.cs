// See https://aka.ms/new-console-template for more information
using OrgaNice.DAL;
using OrgaNice.Properties;
using OrgaNice.Responses;

//Console.WriteLine("Hello, World!");

//IResponse response = BaseWriter.AddUnit("Angular:?_");
//Console.WriteLine(response.Success);
//Console.WriteLine(response.Message);

//response = BaseWriter.AddUnit("Angular");
//Console.WriteLine(response.Success);
//Console.WriteLine(response.Message);

//response = BaseWriter.AddChapter("Angular", "Unidad1");
//Console.WriteLine(response.Success);
//Console.WriteLine(response.Message);

//response = BaseWriter.DeleteUnit("Angular");
//Console.WriteLine(response.Success);
//Console.WriteLine(response.Message);

var unitName = "Unidad 01";
var chapterName = "Chapter";
var responseMessage = string.Format(Resources.success_chapter_deleted, chapterName, unitName);

var response = BaseWriter.DeleteChapter(unitName, chapterName);

Console.ReadLine();