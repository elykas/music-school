using MusicSchool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static MusicSchool.Configuration.AppConfiguration;

namespace MusicSchool.Service
{
    internal static class MusicSchoolService
    {
        public static void CreateCarXmlIfNotExists()
        {
            
            if (!File.Exists(musicSchoolPath))
            {
                //create new document
                XDocument document = new XDocument();
                //create an element
                XElement musicSchool = new("classRoom");
                //document add element
                document.Add(musicSchool);
                //document save changes to provide path
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassRoom(string classRoomName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? musicSchool = document.Descendants("classRoom")
                .FirstOrDefault();
            if (musicSchool == null)
            {
                return;
            }
            XElement classRoom = new(
                "classRoom",
                new XAttribute("name", classRoomName)
                );
            musicSchool?.Add(classRoom);

            document.Save(musicSchoolPath);

        }


        public static void AddTeacher(string classRoomName,string teacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("classRoom")
                .FirstOrDefault(room =>room.Attribute("name")?.Value == classRoomName);

            if (classRoom == null)
            {
                return;
            }
            XElement teacher = new(
                "teacher",
                new XAttribute("name", teacherName)
                );
            classRoom?.Add(teacher);

            document.Save(musicSchoolPath);

        }


        public static void AddStudent(string classRoomName, string studentName, string instrumentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("classRoom")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classRoom == null)
            {
                return;
            }
            XElement student = new(
                "student",
                new XAttribute("name", studentName),
                new XElement("instrument",instrumentName)
                );
            classRoom?.Add(student);

            document.Save(musicSchoolPath);

        }


        private static XElement ConvertStudentToElement(StudentModel student) =>
        
            new XElement(
                "student",
                new XAttribute("name", student.Name),
                new XElement("instrument", student.instrument.name)
                );
        


        public static void AddManyStudents(string classRoomName
            , params StudentModel[] students)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classRoom = document.Descendants("classRoom")
                .FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            if (classRoom == null)
            {
                return;
            }

            List<XElement> studentsElements = students.Select(ConvertStudentToElement).ToList();
        }

       
        public static void DeleteElement(string element)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            (
                 from c in document.Descendants("classRoom")
                 where c.Element("teacher")?.Value == element //we put the ? to ensure that if the element is missing doea'nt throw an error
                 select c//select all the cars that met the condition
                 ).Remove();//This method removes all elements that match the query from the XML document.
            document.Save(musicSchoolPath);

        }


        public static void UpdateInstrument(string instrumentName , string student)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? studentElement = document.Descendants("student")
                .FirstOrDefault(s => s.Attribute("name")?.Value == student);
            if (studentElement == null)
            {
                return;
            }
            
                studentElement.SetElementValue("instrument", instrumentName);
                document.Save(musicSchoolPath);

        }


        public static void UpdateTeacherName(string classRoom, string teacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classroom = document.Descendants("classRoom")
                .FirstOrDefault(s => s.Attribute("name")?.Value == classRoom);
            if (classroom == null)
            {
                return;
            }

            classroom.SetAttributeValue("teacher", teacherName);
            document.Save(musicSchoolPath);

        }


        public static void UpdateStudent(string classRoom, string studentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classroom = document.Descendants("classRoom")
                .FirstOrDefault(s => s.Attribute("name")?.Value == classRoom);
            if (classroom == null)
            {
                return;
            }

            classroom.SetAttributeValue("student", studentName);
            document.Save(musicSchoolPath);

        }





    }
}
