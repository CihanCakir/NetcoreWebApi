using OpenQA.Selenium;
using System.IO;


namespace WebApiProjects.Domain
{
    public class FileHelper
    {
        public static Stream GetFilesStream(string fileUrl)
        {
            if (File.Exists(fileUrl))
            {
                return new FileStream(fileUrl, FileMode.Open);
            }

            throw new NotFoundException("File not found");
        }
    }
}
