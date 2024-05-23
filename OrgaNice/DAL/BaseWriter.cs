using OrgaNice.Properties;
using OrgaNice.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgaNice.DAL
{
    internal static class BaseWriter
    {
        const string BASE_FOLDER = "C:\\Data\\Organice"; // TODO: Cambiar por configuración

        public static IResponse AddUnit(string unitName)
        {
            string fullPath = $"{BASE_FOLDER}{Path.AltDirectorySeparatorChar}{unitName}";

            if(Directory.Exists(fullPath))
                return new SimpleResponse { Success = false, Message = Resources.error_existent_unit };

            try
            {
                var r = Directory.CreateDirectory(fullPath);
                string successMessage = string.Format(Resources.success_unit_created, unitName);

                return new SimpleResponse { Success = true, Message = successMessage };
            }
            catch (NotSupportedException)
            {
                return new SimpleResponse { Success = false, Message = Resources.error_not_supported_name };
            }
            catch (UnauthorizedAccessException) 
            {
                return new SimpleResponse { Success = false, Message = Resources.error_not_write_permissions };
            }
            catch (DirectoryNotFoundException)
            {
                return new SimpleResponse { Success = false, Message = Resources.error_directory_not_found };
            }
            catch (Exception)
            {
                return new SimpleResponse { Success = false, Message = Resources.error_unespected };
            }

        }
    }
}
