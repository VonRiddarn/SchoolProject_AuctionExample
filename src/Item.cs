using System;
using System.Collections.Generic;

class Item
{
	// Fields
	List<Bid> _bids = new List<Bid>();

	// Properties
	public string Name { get; set; } = "Default Item";
	public string Description { get; set; } = "Default item description.";

	public double StartPrice { get; set; } = 0;

	public AuctionStatus Status { get; set; } = AuctionStatus.Active;

	public DateTime EndDate { get; set; }
	public DateTime PublishDate { get; set; }

	// Custom properties
	
	// TODO: Maybe rename from "Highest" to "Leading" ?
	public Bid HighestBid
	{
		get
		{
			return _bids[_bids.Count - 1];
		}
	}
	
	public double HighestPrice
	{
		get
		{
			return _bids.Count <= 0 ? StartPrice : HighestBid.Price;
		}
	}

	// Constructors

	public Item() => PublishDate = DateTime.Now;

	public Item(string name, string description, double startPrice, DateTime endDate)
	{
		Name = name;
		Description = description;
		StartPrice = startPrice;
		EndDate = endDate;
		PublishDate = DateTime.Now;
	}

	// Override methods

	public override string ToString()
	{
		return $"{Name}\n{Description}\nBids: {_bids.Count} | Current Price: {HighestPrice} SEK\nActive Through: {PublishDate.ToShortDateString()} - {EndDate.ToShortDateString()}";
	}

	// Methods

	///<summary>Try to add a bid to the list of current bids.<br/>
	/// Error codes:<br/>
	/// 0 = Success.<br/>
	/// 1 = Auction is closed.<br/>
	/// 2 = Auction is paused.<br/>
	/// 3 = Auction is archived.<br/>
	/// 4 = New bid does not match requirements.<br/>
	/// </summary>
	public int PlaceBid(Bid newBid)
	{
		// Early return pattern
		switch (Status)
		{
			case AuctionStatus.Closed:
				return 1;
			case AuctionStatus.Paused:
				return 2;
			case AuctionStatus.Archived:
				return 3;
		}

		if (_bids.Count <= 0)
		{
			if (newBid.Price < StartPrice)
				return 4;
		}
		else if (newBid.Price <= HighestBid.Price)
			return 4;

		// Below is only accessible if valid bid

		_bids.Add(newBid);

		return 0;
	}

	///<summary>Try to close this auction.<br/>
	/// Error codes:<br/>
	/// 0 = Success.<br/>
	/// 1 = Auction cannot close because it's too early.<br/>
	/// </summary>
	public int Close(bool force = false)
	{
		if (DateTime.Compare(DateTime.Now, EndDate) < 0 && !force)
			return 1;

		Status = AuctionStatus.Closed;
		return 0;
	}

}