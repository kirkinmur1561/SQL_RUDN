using System.Collections.Generic;
using System.IO;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Lab_4.Models.Unions;

namespace Lab_4.Models
{
    public class BackupModel
    {
        public BackupModel(
            List<Total> totals,
            List<Student> students,
            List<Lesson> lessons,
            List<GroupOfStudent> groupOfStudents,
            List<ULessonGroup> uLessonGroups,
            List<UStudentGroup> uStudentGroups,
            List<UStudentLesson> uStudentLessons)
        {
            Totals = totals;
            Students = students;
            Lessons = lessons;
            GroupOfStudents = groupOfStudents;
            ULessonGroups = uLessonGroups;
            UStudentGroups = uStudentGroups;
            UStudentLessons = uStudentLessons;
        }

        public List<Total> Totals { get; set; }
        public List<Student> Students { get; set; }
        public List<Lesson> Lessons { get; set; }
        public List<GroupOfStudent> GroupOfStudents { get; set; }
        
        public List<ULessonGroup> ULessonGroups { get; set; }
        public List<UStudentGroup> UStudentGroups { get; set; }
        public List<UStudentLesson> UStudentLessons { get; set; }
        
        

        public async Task Write() =>
            await File
                .WriteAllTextAsync("backup.json",
                    JsonSerializer.Serialize(this),
                    Encoding.UTF8);

        public static async Task<BackupModel> Read() =>
            JsonSerializer
                .Deserialize<BackupModel>(await File.ReadAllTextAsync("backup.json",
                    Encoding.UTF8));
    }
}