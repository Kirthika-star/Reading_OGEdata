namespace Reading_OGEdata
{
    struct AccessRecord
    {
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkEmail { get; set; }
        public string IdentityID { get; set; }
        public string AccessDisplayName { get; set; }
        public string AccessDescription { get; set; }

        // Static Read Method
        public static List<AccessRecord> Read(string filePath)
        {
            List<AccessRecord> records = new List<AccessRecord>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool headerSkipped = false;

                while ((line = reader.ReadLine()) != null)
                {
                    if (!headerSkipped)
                    {
                        headerSkipped = true;
                        continue;
                    }

                    string[] parts = line.Split(',');

                    AccessRecord record = new AccessRecord
                    {
                        DisplayName = parts[0],
                        FirstName = parts[1],
                        LastName = parts[2],
                        WorkEmail = parts[3],
                        IdentityID = parts[4],
                        AccessDisplayName = parts[5],
                        AccessDescription = parts[6]
                    };

                    records.Add(record);
                }
            }

            return records;
        }
    }

    class Program
    {
        static void Main()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string fileName = "YourNewFile.csv";   // change to actual filename
            string filePath = Path.Combine(baseDir, fileName);

            List<AccessRecord> data = AccessRecord.Read(filePath);

            foreach (AccessRecord record in data)
            {
                Console.WriteLine($"{record.DisplayName} | {record.WorkEmail} | {record.AccessDisplayName}");
            }

            Console.WriteLine($"\nTotal Records: {data.Count}");
        }
    }
}