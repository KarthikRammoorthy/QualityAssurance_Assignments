public class Canada  implements ICountryGDPReport
{
	public String getAgriculture()
	{
		return "$50000000 CAD";
	}

	public String getManufacturing()
	{
		return "$100000 CAD";
	}
	
	public void PrintCountryGDPReport()
	{
		Canada canada = new Canada();
		System.out.println("GDP By Country:\n");
		System.out.println("- Canada:\n");
		System.out.println("   - Agriculture: " + canada.getAgriculture());
		System.out.println("   - Manufacturing: " + canada.getManufacturing());
		
	}
	
	
}