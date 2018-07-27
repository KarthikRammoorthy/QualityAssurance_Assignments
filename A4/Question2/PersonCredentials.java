
public class PersonCredentials {
	private String userName;
	private String password;
	
	public void SetPersonCredentials(String userName, String password)
	{
		this.userName = userName;
		this.password = password;
	}
	public boolean AuthenticateUser()
	{
		return (userName.equals("joe") && password.equals("joepass"));
	}

}
