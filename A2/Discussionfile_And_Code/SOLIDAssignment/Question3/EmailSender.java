import java.util.ArrayList;

public class EmailSender
{
	public void SendEmail(String emailAddress, String subject, String message)
	{
		// I'm pretending to send an email!
		System.out.println("To: " + emailAddress);
		System.out.println("Subject: " + subject);
		System.out.println("Message: \n\n" + message);
	}
	
	public void FnSendToEmail(String emailAddress, ArrayList<String> reportData)
	{
		try
		{
	    	StringBuilder builder = new StringBuilder();
	    	for (int i = 0; i < reportData.size(); i++)
	    	{
	    		builder.append(reportData.get(i) + "\n");
	    	}
	    	EmailSender sender = new EmailSender();
	    	sender.SendEmail(emailAddress, "Profit Report!", builder.toString());
		}
		catch (Exception e)
		{
			System.out.println("Yipes internet must be down!");
		}
	}
}