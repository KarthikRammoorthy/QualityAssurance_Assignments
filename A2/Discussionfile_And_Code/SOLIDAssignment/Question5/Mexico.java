public class Mexico implements ICountryGDPReport
{
	public String getAgriculture()
	{
		return "$50000000 MXN";
	}

	public String getTourism()
	{
		return "$100000 MXN";
	}
	
	public void PrintCountryGDPReport()
	{
		Mexico mexico = new Mexico();
		System.out.println("- Mexico:\n");
		System.out.println("   - Agriculture: " + mexico.getAgriculture());
		System.out.println("   - Tourism: " + mexico.getTourism());
		
	}
}