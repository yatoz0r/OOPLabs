using Lab10ClassLib;
using Lab12Hash;
using Lab16._1.Serialization;
using System.Diagnostics;

namespace Lab16._1
{
    public partial class SyncAsyncForm : Form
    {
        BinaryDump<HashTable<AnimalKey, Animal>> binDump = new BinaryDump<HashTable<AnimalKey, Animal>>();
        TextDump<HashTable<AnimalKey, Animal>> textDump = new TextDump<HashTable<AnimalKey, Animal>>();
        JSONDump<HashTable<AnimalKey, Animal>> jsonDump = new JSONDump<HashTable<AnimalKey, Animal>>();
        XMLDump<HashTable<AnimalKey, Animal>> xmlDump = new XMLDump<HashTable<AnimalKey, Animal>>();
        public SyncAsyncForm(HashTable<AnimalKey, Animal> hashTable)
        {
            InitializeComponent();
            MeasureSync(hashTable);
            MeasureAsync(hashTable);
        }

        public void MeasureSync(HashTable<AnimalKey, Animal> hashTable)
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            textDump.Save("123.txt", hashTable);
            stopwatch1.Stop();
            syncTime1.Text = $"{stopwatch1.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            binDump.Save("123.bin", hashTable);
            stopwatch2.Stop();
            syncTime2.Text = $"{stopwatch2.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            jsonDump.Save("123.json", hashTable);
            stopwatch3.Stop();
            syncTime3.Text = $"{stopwatch3.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch4 = Stopwatch.StartNew();
            xmlDump.Save("123.xml", hashTable);
            stopwatch4.Stop();
            syncTime4.Text = $"{stopwatch4.Elapsed.TotalMilliseconds} мс";
        }

        public void MeasureAsync(HashTable<AnimalKey, Animal> hashTable)
        {
            Stopwatch stopwatch1 = Stopwatch.StartNew();
            Task task = textDump.SaveAsync("123A.txt", hashTable);
            stopwatch1.Stop();
            asyncTime1.Text = $"{stopwatch1.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch2 = Stopwatch.StartNew();
            binDump.SaveAsync("123A.bin", hashTable);
            stopwatch2.Stop();
            asyncTime2.Text = $"{stopwatch2.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch3 = Stopwatch.StartNew();
            jsonDump.SaveAsync("123A.json", hashTable);
            stopwatch3.Stop();
            asyncTime3.Text = $"{stopwatch3.Elapsed.TotalMilliseconds} мс";

            Stopwatch stopwatch4 = Stopwatch.StartNew();
            xmlDump.SaveAsync("123A.xml", hashTable);
            stopwatch4.Stop();
            asyncTime4.Text = $"{stopwatch4.Elapsed.TotalMilliseconds} мс";
        }

    }
}
