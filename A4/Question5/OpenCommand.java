public class OpenCommand extends Command{
	
	@Override
	public String CommandExecute() {
		return "open -f <path> [-create=0/1]";
	}

}
