import java.time.Duration;
import java.util.ArrayList;

public interface IDVD {
	public Duration GetPlayTime();
	public String GetTitle();
	public boolean IsDigitalOnly();
	public ArrayList<String> GetCastList();

}
