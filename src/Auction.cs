using System;
using System.Collections.Generic;

class Auction
{
	// Fields
	List<Item> _items = new List<Item>();

	// Properties
	public string Name { get; set; } = "Default auction hall";
	
	// Custom properties
	public Item[] Items
	{
		get
		{
			return _items.ToArray();
		}
	}
	
	// Constructors 
	public Auction(string name) => Name = name;

	// Methoids

	public void AddItem(Item newItem) => _items.Add(newItem);
	
	public Item[] GetItems(AuctionStatus status)
	{
		List<Item> tempItems = new List<Item>();

		foreach (Item item in _items)
		{
			if (item.Status == status)
				tempItems.Add(item);
		}

		return tempItems.ToArray();
	}

	public Item[] GetExpiredItems() => GetExpiredItems(DateTime.Now);

	public Item[] GetExpiredItems(DateTime expirationDate)
	{
		List<Item> tempItems = new List<Item>();

		foreach (Item item in _items)
		{
			if (DateTime.Compare(expirationDate, item.EndDate) < 0)
				tempItems.Add(item);
		}

		return tempItems.ToArray();
	}

}