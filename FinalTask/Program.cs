using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathFile = @"C:\Users\ovsen\OneDrive\Рабочий стол\Students.dat";

            var students = ReadFromFile(pathFile);
            foreach (var student in students)
            {
                WriteInFile(student.Value, student.Key);
            }
        }

        static Dictionary<string, List<Student>> ReadFromFile(string pathFile)
        {
            List<Student> students = new List<Student>();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var reader = new FileStream(pathFile, FileMode.OpenOrCreate))
            {
                students.AddRange((Student[])binaryFormatter.Deserialize(reader));
            }

            var dictGroup = new Dictionary<string, List<Student>>();
            foreach (var student in students)
            {
                if (!dictGroup.ContainsKey(student.Group))
                {
                    dictGroup[student.Group] = new List<Student>();
                }
                dictGroup[student.Group].Add(student);
            }
            return dictGroup;
        }

        static void WriteInFile(List<Student> students, string group)
        {
            var path = @"C:\Users\ovsen\OneDrive\Рабочий стол\Student";
            var dir = new DirectoryInfo(path);
            try
            {
                if (!dir.Exists)
                {
                    dir.Create();
                }
                var pathFile = $"{path}\\{group}.txt";
                FileInfo file = new FileInfo(pathFile);
                if (!file.Exists)
                {
                    file.Create();
                }
                using (StreamWriter sr = file.AppendText())
                {
                    foreach (var st in students)
                    {
                        sr.WriteLine($"{st.Name}, {st.DateOfBirth}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
