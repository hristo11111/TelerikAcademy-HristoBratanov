using System;
using System.Collections.Generic;
using Wintellect.PowerCollections;
using System.Linq;

public class BiDictionary<K1, K2, T>
{
    public class Item
    {
        public K1 key1 { get; private set; }
        public K2 key2 { get; private set; }
        public T value { get; private set; }

        public Item(K1 key1, K2 key2, T value)
        {
            this.key1 = key1;
            this.key2 = key2;
            this.value = value;
        }
    }

    private MultiDictionary<K1, Item> key1Dict;
    private MultiDictionary<K2, Item> key2Dict;
    private MultiDictionary<Tuple<K1,K2>, Item> key1and2Dict;

    public BiDictionary(bool allowDuplicates)
    {
        this.key1Dict = new MultiDictionary<K1, Item>(allowDuplicates);
        this.key2Dict = new MultiDictionary<K2, Item>(allowDuplicates);
        this.key1and2Dict = new MultiDictionary<Tuple<K1, K2>, Item>(allowDuplicates);
    }

    public void AddItem(K1 key1, K2 key2, T value)
    {
        Item item = new Item(key1, key2, value);

        this.key1Dict.Add(item.key1, item);
        this.key2Dict.Add(item.key2, item);
        this.key1and2Dict.Add(new Tuple<K1, K2>(item.key1, item.key2), item);
    }

    public List<Item> GetElementsByKey1(K1 key1)
    {
        List<Item> items = key1Dict[key1].ToList();

        return items;
    }

    public List<Item> GetElementsByKey2(K2 key2)
    {
        List<Item> items = key2Dict[key2].ToList();

        return items;
    }

    public ICollection<Item> GetElementsByKey1AndKey2(K1 key1, K2 key2)
    {
        ICollection<Item> items = key1and2Dict[new Tuple<K1, K2>(key1, key2)];
        
        return items;
    }
}
