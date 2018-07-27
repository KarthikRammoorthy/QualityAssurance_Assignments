
import java.util.HashMap;
import java.util.Map;

public class Help
{
	public Map<String, Command> COMMANDS;
	
	public Help () {
	        COMMANDS = new HashMap<>();
	        COMMANDS.put("print", new PrintCommand());
	        COMMANDS.put("close", new CloseCommand());
	        COMMANDS.put("open", new OpenCommand());
	        COMMANDS.put("", new AllCommand());
	    }
	    
	
	
	public String GetHelp(String command)
	{
			
			Command objCommand = COMMANDS.get(command);
			return objCommand.CommandExecute();
			
	}


		
		
}