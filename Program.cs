/*
Pleaes note: 

This is a very simplified project made with the intent of showing how to work with properties, fields and methods in an effective way.
The project does not represent a final product, nor any examples of code that would be useful in production.
*/

using System;
using System.Collections.Generic;

internal class Program
{
	static Auction _auction = new Auction("Abborrens 2nd Hand");
	static List<User> _users = new List<User>();

	private static void Main(string[] args)
	{
		// Fill the _auction instance with items from DebugItems.cs
		// Then fill the _users list with users from DebugUsers.cs
		InitializeDebugValues();

		// Some manual random bids I made.
		PlaceSomeRandomBids();


		// Here we start showing cool UI stuff.
		Console.Clear();

		Console.WriteLine("ALL ITEMS:");
		Console.WriteLine();

		foreach (Item item in _auction.Items)
		{
			Console.WriteLine(item);
			Console.WriteLine("----- ----- -----");
		}

		// Play with this yourself.
		// 
		// Some useful stuff:
		// 
		// _auction.GetItems(AuctionStatus) -> Get all items with the selected status
		// _auction.GetExpiredItems() -> Get all expired items
		// _auction.GetExpiredItems(DateTime) -> Get all items that are expired at the sent DateTime
		
		// You can also get the leader of an auction by doing:
		// _auction.Items[0].HighestBid.User
		// For ease, you could cache it:
		// User leader = _auction.Items[0].HighestBid.User;
		// Console.WriteLine(leader.Name);


	}

	static void InitializeDebugValues()
	{
		foreach (Item item in DebugItems.Items)
			_auction.AddItem(item);

		foreach (User user in DebugUsers.Users)
			_users.Add(user);
	}

	static void PlaceSomeRandomBids()
	{
		// Some random bid placements on Item 1:
		_auction.Items[0].PlaceBid(new Bid(_users[0], 100));
		_auction.Items[0].PlaceBid(new Bid(_users[1], 250));
		_auction.Items[0].PlaceBid(new Bid(_users[4], 50));
		_auction.Items[0].PlaceBid(new Bid(_users[2], 500));
		_auction.Items[0].PlaceBid(new Bid(_users[3], 600));
		_auction.Items[0].PlaceBid(new Bid(_users[0], 1000));

		// Some random bid placements on Item 2:
		_auction.Items[1].PlaceBid(new Bid(_users[2], 5));
		_auction.Items[1].PlaceBid(new Bid(_users[1], 250));
		_auction.Items[1].PlaceBid(new Bid(_users[0], 50));
		_auction.Items[1].PlaceBid(new Bid(_users[3], 400));
		_auction.Items[1].PlaceBid(new Bid(_users[2], 222));
		_auction.Items[1].PlaceBid(new Bid(_users[1], 420));

		// Some random bid placements on Item 3:
		_auction.Items[2].PlaceBid(new Bid(_users[0], 600));

		// Some random bid placements on Item 4:
		_auction.Items[3].PlaceBid(new Bid(_users[0], 1200));
		_auction.Items[3].PlaceBid(new Bid(_users[1], 1500));
	}
}