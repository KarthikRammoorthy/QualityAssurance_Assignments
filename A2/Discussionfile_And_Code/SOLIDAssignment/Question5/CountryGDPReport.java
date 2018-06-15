public class CountryGDPReport
{
	ICanada canada;
	IMexico mexico;

	public CountryGDPReport(ICanada objICanada, IMexico objIMexico)
	{
		canada = objICanada;
		mexico = objIMexico;
	}

	public void PrintCountryGDPReport()
	{
		System.out.println("GDP By Country:\n");
		System.out.println("- Canada:\n");
		System.out.println("   - Agriculture: " + canada.getAgriculture());
		System.out.println("   - Manufacturing: " + canada.getManufacturing());
		System.out.println("- Mexico:\n");
		System.out.println("   - Agriculture: " + mexico.getAgriculture());
		System.out.println("   - Tourism: " + mexico.getTourism());
	}
} 