import java.io.FileReader;
import java.util.Scanner;

public class Load {

	public void FnLoad(int numPennies, int numDimes, int numNickels, int numQuarters)
	{
		try
		{
			Scanner in = new Scanner(new FileReader("piggybank.txt"));
			numPennies = Integer.parseInt(in.next());
			numDimes = Integer.parseInt(in.next());
			numNickels = Integer.parseInt(in.next());
			numQuarters = Integer.parseInt(in.next());
		}
		catch (Exception e)
		{
			System.out.println("I am a bad programmer that hid an exception.");
		}
	}

}
