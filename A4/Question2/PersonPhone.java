
public class PersonPhone {
	
	private String areaCode;
	private String phoneNumber;
	
	public void SetPersonAreaCode(String areaCode)
	{
		this.areaCode = areaCode;
	}
	public String GetPersonAreaCode()
	{
		return areaCode;
	}
	public void SetPersonPhoneNumber(String phoneNumber)
	{
		this.phoneNumber = phoneNumber;
	}
	public String GetPersonPhoneNumber()
	{
		if (areaCode != null && areaCode != "")
		{
			return "(" + areaCode + ") " + phoneNumber; 
		}
		return phoneNumber;
	}
		

}
