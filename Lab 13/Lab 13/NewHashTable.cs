using Lab10ClassLib;
using Lab12Hash;

namespace Lab_13
{
    delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    class NewHashTable<TKey, TValue> : HashTable<AnimalKey, Animal>
    {
        public NewHashTable(int capacity) : base(capacity) { }

        public int Length { get => Count; }
        public string Name { get; } = "NewHashTable";
        //происходит при добавлении нового элемента или при удалении элемента
        public event CollectionHandler CollectionCountChanged;
        //объекту коллекции присваивается новое значение
        public event CollectionHandler CollectionReferenceChanged;
        //обработчик события CollectionCountChanged
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(source, args);
        }
        //обработчик события OnCollectionReferenceChanged
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(source, args);
        }
        public override bool Add(AnimalKey key, Animal? value) 
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "added", value));
            return base.Add(key, value);
        }
        public bool Remove(AnimalKey j)
        {
            if (j != null)
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs(Name, "remove", this[j].Value));
                return base.Remove(this[j].Key);
            }
            return false;
        }
        /*public override void Remove(int key)
        {  
           base.Remove(key); 
        }*/

        public override Element<AnimalKey, Animal> this[AnimalKey key] 
        { get => base[key];
          set 
          {
                OnCollectionReferenceChanged(this,new CollectionHandlerEventArgs(this.Name, "changed", value.Value));
                base[key] = value; 
          } 
        }
    }
}
