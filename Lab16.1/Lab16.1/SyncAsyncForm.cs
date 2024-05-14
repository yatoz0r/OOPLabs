using Lab10ClassLib;
using Lab12Hash;
using System.Diagnostics;

namespace Lab16._1
{
    public partial class SyncAsyncForm : Form
    {
        CollectionManager cm = new CollectionManager();
        public SyncAsyncForm(HashTable<AnimalKey, Animal> hashTable)
        {
            InitializeComponent();
            MeasureSync(hashTable);
            MeasureAsync(hashTable);
        }

        public void MeasureSync(HashTable<AnimalKey, Animal> hashTable)
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            cm.SaveToTextFile("123.txt", hashTable);
            stopwatch1.Stop();
            syncTime1.Text = $"{stopwatch1.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            cm.SaveToBinaryFile("123.bin", hashTable);
            stopwatch2.Stop();
            syncTime2.Text = $"{stopwatch2.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            cm.SaveToJsonFile("123.json", hashTable);
            stopwatch3.Stop();
            syncTime3.Text = $"{stopwatch3.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch4 = Stopwatch.StartNew();
            cm.SaveToXmlFile("123.xml", hashTable);
            stopwatch4.Stop();
            syncTime4.Text = $"{stopwatch4.Elapsed.TotalMilliseconds} мс";
        }

        public void MeasureAsync(HashTable<AnimalKey, Animal> hashTable)
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            Task task = cm.SaveToTextFileAsync("123A.txt", hashTable);
            stopwatch1.Stop();
            asyncTime1.Text = $"{stopwatch1.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            cm.SaveToBinaryFileAsync("123A.bin", hashTable);
            stopwatch2.Stop();
            asyncTime2.Text = $"{stopwatch2.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            cm.SaveToJsonFileAsync("123A.json", hashTable);
            stopwatch3.Stop();
            asyncTime3.Text = $"{stopwatch3.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch4 = Stopwatch.StartNew();
            cm.SaveToXmlFileAsync("123A.xml", hashTable);
            stopwatch4.Stop();
            asyncTime4.Text = $"{stopwatch4.Elapsed.TotalMilliseconds} мс";
        }

    }
}
