using ClassLibrary1;
using CsvHelper;
using System.Globalization;

namespace CSVs_Writing_Reading_Preloading_Hongfei
{
    public partial class Form1 : Form
    {
        List<Person> persons = new List<Person>();
        const string filePath = "persons.csv";
        public Form1()
        {
            InitializeComponent();
            //Preload();
            persons = LoadCSV<Person>(filePath);
            DisplayPreload();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            string fName = textBox1.Text;
            string lName = textBox2.Text;
            string job = textBox3.Text;

            persons.Add(new Person(fName, lName, job));

            listView1.Items.Clear();
            for (int i = 0; i < persons.Count; i++)
            {
                ListViewItem item = new ListViewItem(persons[i].FirstName);
                item.SubItems.Add(persons[i].LastName);
                item.SubItems.Add(persons[i].Job);
                listView1.Items.Add(item);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }

        }

        public void SaveData<T>(string filePath, List<T> list)
        {
            CultureInfo ci = CultureInfo.InvariantCulture;
            //string filePath = "fileName.csv";
            using (var stream = File.Open(filePath, FileMode.OpenOrCreate))
            using (var writer = new StreamWriter(stream))
            using (var csvWriter = new CsvWriter(writer, ci))
            {
                csvWriter.WriteRecords(list);
                writer.Flush();
            }
        }

        public void Preload()
        {
            persons.Add(new Person("Tina", "Zheng", "IT"));
            persons.Add(new Person("Joy", "Wang", "HR"));
            persons.Add(new Person("Sam", "Lee", "Admin"));

            SaveData(filePath, persons);
        }

        public void DisplayPreload()
        {
            foreach (var person in persons)
            {
                ListViewItem item = new ListViewItem(person.FirstName);
                item.SubItems.Add(person.LastName);
                item.SubItems.Add(person.Job);
                listView1.Items.Add(item);
            }
        }

        public List<T> LoadCSV<T>(string filePath)
        {
            List<T> temp = new List<T>();
            using StreamReader sr = new StreamReader(filePath);
            using (CsvReader csv = new CsvReader(sr, CultureInfo.InvariantCulture))
            {

                temp = csv.GetRecords<T>().ToList();
            }

            return temp;


        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveData(filePath, persons);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
