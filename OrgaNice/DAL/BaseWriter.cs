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
    }
}
