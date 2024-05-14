using Lab10ClassLib;

namespace Lab_13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; } 
        public string ChangedType { get; set; }
        public Animal LinkToObject { get; }

        public CollectionHandlerEventArgs(string collectionName, string changedType, Animal? link)
        {
            this.CollectionName = collectionName;
            this.ChangedType = changedType;
            this.LinkToObject = link ?? default!;
        }
        public override string ToString() => $"Имя коллекции: {CollectionName}; Тип : {ChangedType}\n";
    }
}
