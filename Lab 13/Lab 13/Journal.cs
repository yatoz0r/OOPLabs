using Lab10ClassLib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_13
{
    class Journal
    {
        public List<JournalEntry> journal;
        public class JournalEntry
        {
            public string CollectionName { get; set; }
            public string ChangedType { get; set; }
            public string LinkToObject { get; }
            public JournalEntry(string collectionName, string collectionType, string link)
            {
                this.CollectionName = collectionName;
                this.ChangedType = collectionType;
                this.LinkToObject = link;
            }
            public override string ToString()
            {
                return ($"Имя коллекции: {CollectionName}, Тип: {ChangedType}, Изменения в коллекции: {LinkToObject}\n");
            }
        }
        public Journal()
        {
            journal = new List<JournalEntry>();
        }
        public override string ToString()
        {
            string outStr = "";
            foreach (JournalEntry je in journal)
                outStr += je.ToString();
            return outStr;
        }
        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs elem)
        {
            JournalEntry je = new JournalEntry(elem.CollectionName, elem.ChangedType, elem.LinkToObject.ToString());
            journal.Add(je);
        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs elem)
        {
            JournalEntry je = new JournalEntry(elem.CollectionName, elem.ChangedType, elem.LinkToObject.ToString());
            journal.Add(je);
        }
    }
}
