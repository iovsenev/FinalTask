using System.Runtime.Serialization.Formatters.Binary;

namespace FinalTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathFile = @"C:\Users\ovsen\OneDrive\Рабочий стол\Students.dat";
            List<Student> students = new List<Student>();
            if (!File.Exists(pathFile))
            {
                Console.WriteLine("no file");
                return;
            }
            BinaryFormatter binaryFormatter = new BinaryFormatter();



            using (var reader = new FileStream(pathFile, FileMode.OpenOrCreate))
            {
                students.AddRange((Student[])binaryFormatter.Deserialize(reader));
            }
            foreach (var student in students)
            {
                Console.WriteLine(student.Name + student.Group);
            }
        }
    }
}
