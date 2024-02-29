using System.IO;
using System.Reflection.PortableExecutable;
//using 

namespace Rest.MyFolder
{
    public class Class
    {
        // Data from the file
        public List<Record> Data = new List<Record>();
        string path = "data_1.txt";

        // асинхронное чтение

        public void Reader()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line =  reader.ReadLine()) != null)
                {
                    var rec = new Record();
                    string[] data = line.Split(',');
                    rec.Time = data[0];
                    rec.Value = data[1];
                    Data.Add(rec);
                }
            }


        }

    }

    public class Record
    {
        public string Time;
        public string Value;
    }
}

