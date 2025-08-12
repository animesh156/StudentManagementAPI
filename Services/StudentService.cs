using StudentManagementAPI.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentManagementAPI.Services
{
    public class StudentService
    {
        private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "students.json");

        public StudentService()
        {
            var dir = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");
        }

        private List<Student> ReadFromFile()
        {
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        private void WriteToFile(List<Student> students)
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Student> GetAll() => ReadFromFile();

        public Student GetById(int id)
        {
            return ReadFromFile().FirstOrDefault(s => s.Id == id);
        }

        public void Add(Student student)
        {
            var students = ReadFromFile();
            student.Id = students.Any() ? students.Max(s => s.Id) + 1 : 1;
            students.Add(student);
            WriteToFile(students);
        }

        public bool PartialUpdate(int id, Student updates)
        {
            var students = ReadFromFile();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return false;

            // Merge only provided fields
            if (!string.IsNullOrEmpty(updates.FullName))
                student.FullName = updates.FullName;

            if (!string.IsNullOrEmpty(updates.RollNumber))
                student.RollNumber = updates.RollNumber;

            if (!string.IsNullOrEmpty(updates.Class))
                student.Class = updates.Class;

            if (updates.DateOfBirth != default)
                student.DateOfBirth = updates.DateOfBirth;

            if (!string.IsNullOrEmpty(updates.ContactNumber))
                student.ContactNumber = updates.ContactNumber;

            WriteToFile(students);
            return true;
        }

        public bool Delete(int id)
        {
            var students = ReadFromFile();
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return false;

            students.Remove(student);
            WriteToFile(students);
            return true;
        }
    }
}
