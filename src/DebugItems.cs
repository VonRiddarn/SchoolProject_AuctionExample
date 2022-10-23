class DebugItems
{
	public static Item[] Items
	{
		get
		{
			return new Item[]
			{
				new Item
				(
					"Låst skattkista",
					"Kista från säljarens mormors vind. Den har något tungt i sig.",
					500,
					new System.DateTime(2022, 12, 24)
				),
				new Item
				(
					"Vattenbalong med vätska",
					"En vattenballong fylld med vad som sägs skall vara vatten från Mars.",
					50,
					new System.DateTime(2022, 11, 01)
				),
				new Item
				(
					"Gammal jojo",
					"En jojo från förkrigstiden.",
					200,
					new System.DateTime(2022, 09, 19)
				),
				new Item
				(
					"Piratguld",
					"Oklart om detta är riktigt guld eller guldfärgade stenar.",
					1500,
					new System.DateTime(2022, 12, 12)
				)
			};
		}
	}
}