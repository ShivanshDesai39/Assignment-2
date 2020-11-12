using FtpApp.Models.Utilities;
using FTPApp.Models;
using FtpApp1.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace FtpApp1
{
    public class Program
    {
        public static object students;
        public static string url;

        public static object JsonConvert { get; private set; }

        static void Main(string[] args)
        {
           
            List<string> directories = FTP.GetDirectory(Constants.FTP.BaseUrl);
            List<Student> studentsall = new list<Student>();
            List<string> direcctories = FTP.GetDirectory(Constants.FTP.BaseUrl);

            foreach (var directory in directories)
            {
                Console.WriteLine(directory);

                if (FTP.FileExists(Constants.FTP.BaseUrl + "/" + directory + " /info.csv"))
                {
                    var fileBytes = FTP.DownloadFileBytes(Constants.FTP.BaseUrl + "/ " + directory + "info.csv");
                    string infoCsvData = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                    string[] lines = infoCsvData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                    Student student1 = new Student();
                    student1.FromCSV(lines[1]);

                    string csvData = student1.ToCSV();
                    Console.WriteLine(csvData);
                }

                else
                {
                    Console.WriteLine("File not exists.");
                }






                Student allStudent = new Student();
                if (FTP.FileExists(Constants.FTP.BaseUrl + "/" + directory + "/info.csv"))
                {
                    var fileBytes = FTP.DownloadFileBytes(Constants.FTP.BaseUrl + "/" + directory + "/info.csv");
                    string infoCsvData = Encoding.UTF8.GetString(fileBytes, 0, fileBytes.Length);
                    string[] lines = infoCsvData.Split("\r\n", StringSplitOptions.RemoveEmptyEntries);

                    allStudent.FromCSV(lines[1]);

                    string csvData = allStudent.ToString();
                    Console.WriteLine(csvData);

                    studentsall.Add(allStudent);

                    string csvData1 = allStudent.ToCSV();
                    Console.WriteLine(csvData1);

                }
                else
                {
                    Console.WriteLine("File Not exists.");
                }


                
            }
            List<Student> students = new List<Student>();
            Student me = new Student
            {
                StudentId = "200464960",
                FirstName = "Shivansh",
                LastName = "Desai",
                DateOfBirth = "19994-03-10",
            };

            students.Add(me);

            // Count
            int count = students.Count();
            Console.WriteLine($"The list contain {count} students");

            // Maximum
            int highestMax = students.Max(x => x.StudentAge);
            Console.WriteLine($"The highest Age in the list is {highestMax}");

            // Minimum
            int lowestMax = students.Min(x => x.StudentAge);
            Console.WriteLine($"The lowest Age in the list is {lowestMax}");

            // Average
            double averageAge = students.Average(x => x.StudentAge);
            Console.WriteLine($"The average age is => {averageAge.ToString("0")}");




            string json = JsonConvert.Serializebject(students) ;

            using (StreamWriter sw = new StreamWriter(@"C:\Users\shiva\OneDrive\Desktop\Student files\students.json"))
            {
                sw.WriteLine(json);
            }


            XmlSerializer serializer = new XmlSerializer(typeof(List<student>));

            using (Stream fs = new FileStream(@"C:\Users\shiva\OneDrive\Desktop\Student file\sstudents.xml", FileMode.Create))
            {
                XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
                serializer.Serialize(writer, students);
            }
            string uploadcsv = @"C:\Users\shiva\OneDrive\Desktop\Student files\students.csv";

            string csvpath = "/200464960%20Shivansh%20Desai/students.csv";
            string uploadjson = @"C:\Users\shiva\OneDrive\Desktop\Student files\students.json";
            string jsonpath = "//200464960%20Shivansh%20Desai//students.json";
            string uploadxml = @"C:\Users\shiva\OneDrive\Desktop\Student files\students.xml";
            string xmlpath = "/200464960%20Shivansh%20Desai//students.xml";

            Console.WriteLine(UploadFile(uploadcsv, url + csvpath));
            Console.WriteLine(UploadFile(uploadjson, url + jsonpath));
            Console.WriteLine(UploadFile(uploadxml, url + xmlpath));
































            //Student student = new Student();
            //student.FromDirectory(directory);



            //string[] directoryPart = directory.Split(" ", StringSplitOptions.None);

            //student.StudentCode = directoryPart[0];
            //student.FirstName = directoryPart[1];
            //student.LastName = directoryPart[2];

            //Search for a file named info.csv
            //if(FTP.FileExists(Constants.FTP.BaseUrl + "/" + directory + "/info.csv"))
            //{
            //  Console.WriteLine("   info.csv File exists");
            //}
            //else
            //{
            //Console.WriteLine("   info.csv File does not exist");
            //}




            //Search for a file named info.html
            //if (FTP.FileExists(Constants.FTP.BaseUrl + "/" + directory + "/info.html"))
            //{
            //  Console.WriteLine("   info.html File exists");
            //}
            //else
            //{
            //   Console.WriteLine("   info.html File does not exist");
            //}

        }

        private static bool UploadFile(string uploadcsv, string v)
        {
            throw new NotImplementedException();
        }
    }
}



