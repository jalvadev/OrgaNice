using OrgaNice.Properties;
using OrgaNice.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgaNice.DAL
{
    public static class BaseWriter
    {
        const string BASE_FOLDER = "C:\\Data\\Organice"; // TODO: Cambiar por configuración
        const string MD_EXTENSION = ".md";


        public static IResponse ListUnits()
        {
            List<string> units = new List<string>();

            DirectoryInfo info = new DirectoryInfo(BASE_FOLDER);

            DirectoryInfo[] directories = info.GetDirectories();

            foreach (DirectoryInfo d in directories)
            {
                units.Add(d.Name);
            }

            return new ComplexResponse <List<string>>{ Success = true, Message = "", Result = units };
        }

        public static IResponse AddUnit(string unitName)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}";

            if(Directory.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_existent_unit };

            try
            {
                Directory.CreateDirectory(fullPath);
                string successMessage = string.Format(Resources.success_unit_created, unitName);

                return new SimpleResponse { Success = true, Message = successMessage };
            }
            catch (Exception ex)
            {
                if(ex is NotSupportedException || ex is IOException)
                    return new SimpleResponse { Success = false, Message = Resources.error_not_supported_name };
                else if (ex is UnauthorizedAccessException)
                    return new SimpleResponse { Success = false, Message = Resources.error_not_write_permissions };
                else if (ex is DirectoryNotFoundException)
                    return new SimpleResponse { Success = false, Message = Resources.error_directory_not_found };
                else
                    return new SimpleResponse { Success = false, Message = Resources.error_unespected };
            }
        }

        public static IResponse DeleteUnit(string unitName)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}";

            if (!Directory.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_unexistent_unit };

            if (Directory.EnumerateFiles(fullPath).Count() > 0)
                return new SimpleResponse { Success = false, Message = Resources.error_unit_not_empty };

            try
            {
                Directory.Delete(fullPath);
                string successMessage = string.Format(Resources.success_unit_deleted, unitName);

                return new SimpleResponse { Success = true, Message = successMessage };
            }
            catch(Exception ex)
            {
                if (ex is NotSupportedException || ex is IOException)
                    return new SimpleResponse { Success = false, Message = Resources.error_not_supported_name };
                else if (ex is UnauthorizedAccessException)
                    return new SimpleResponse { Success = false, Message = Resources.error_not_write_permissions };
                else if (ex is DirectoryNotFoundException)
                    return new SimpleResponse { Success = false, Message = Resources.error_directory_not_found };
                else
                    return new SimpleResponse { Success = false, Message = Resources.error_unespected };
            }
        }

        public static IResponse AddChapter(string unitName, string chapterName)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}{Path.AltDirectorySeparatorChar}{chapterName}{MD_EXTENSION}";

            if(File.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_existent_chapter };

            try
            {
                File.Create(fullPath).Close();
                string successMessage = string.Format(Resources.success_chapter_created, chapterName, unitName);

                return new SimpleResponse { Success = true, Message = successMessage };
            }
            catch(Exception ex)
            {
                if (ex is DirectoryNotFoundException)
                    return new SimpleResponse { Success = false, Message = Resources.error_unexistent_unit };
                else
                    return new SimpleResponse { Success = false, Message = Resources.error_unespected };
            }
        }

        public static IResponse DeleteChapter(string unitName, string chapterName)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}{Path.AltDirectorySeparatorChar}{chapterName}{MD_EXTENSION}";

            if (!File.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_unexistent_chapter };

            try
            {
                File.Delete(fullPath);
                string successMessage = string.Format(Resources.success_chapter_deleted, chapterName, unitName);

                return new SimpleResponse { Success = true, Message = successMessage };
            }
            catch (Exception ex)
            {
                if (ex is DirectoryNotFoundException)
                    return new SimpleResponse { Success = false, Message = Resources.error_unexistent_unit };
                else if (ex is IOException)
                    return new SimpleResponse { Success = false, Message = Resources.error_chapter_busy };
                else
                    return new SimpleResponse { Success = false, Message = Resources.error_unexpected_chapter_delete };
            }
        }

        public static IResponse WriteIntoChapter(string unitName, string chapterName, string content)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}{Path.AltDirectorySeparatorChar}{chapterName}{MD_EXTENSION}";

            if (!File.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_unexistent_chapter };

            try
            {
                using (StreamWriter writer = new StreamWriter(fullPath))
                {
                    writer.Write(content);
                }


                return new SimpleResponse { Success = true, Message = Resources.success_write_chapter };
            }
            catch(Exception ex)
            {
                return new SimpleResponse { Success = false, Message = Resources.error_unexpected_chapter_write };
            }
        }

        public static IResponse ReadChapter(string unitName, string chapterName)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}{Path.AltDirectorySeparatorChar}{chapterName}{MD_EXTENSION}";

            if (!File.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_unexistent_chapter };

            try
            {
                string content;
                using (StreamReader reader = new StreamReader(fullPath))
                {
                    content = reader.ReadToEnd();
                }


                return new ComplexResponse <string> { Success = true, Message = Resources.success_read_chapter, Result = content };
            }
            catch (Exception ex)
            {
                return new SimpleResponse { Success = false, Message = Resources.error_unexpected_chapter_read };
            }
        }
    }
}
