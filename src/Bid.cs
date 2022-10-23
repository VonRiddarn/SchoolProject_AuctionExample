class Bid
{

	public User User { get; set; }

	public double Price { get; set; }

	public Bid(User user, double price)
	{
		User = user;
		Price = price;
	}
}