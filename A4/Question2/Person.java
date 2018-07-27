public class Person
{
	private String name;
	private PersonPhone personPhone;
	private PersonCredentials personCredentials;
	



	public Person(String name)
	{
		this.name = name;
		personPhone = new PersonPhone();
		personCredentials = new PersonCredentials();
		
	}

	public void SetAreaCode(String areaCode)
	{
		this.personPhone.SetPersonAreaCode(areaCode);
	}
	public String GetAreaCode()
	{
		return this.personPhone.GetPersonAreaCode();
	}
	public void SetPhoneNumber(String phoneNumber)
	{
		this.personPhone.SetPersonPhoneNumber(phoneNumber);
	}
	public String GetPhoneNumber()
	{
		return this.personPhone.GetPersonPhoneNumber();

	}

	public void SetLoginCredentials(String userName, String password)
	{
		this.personCredentials.SetPersonCredentials(userName, password);
	
	}
	public boolean AuthenticateUser()
	{
		return this.personCredentials.AuthenticateUser();
	}
}