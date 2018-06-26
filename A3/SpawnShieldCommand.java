import java.util.ArrayList;

public class SpawnShieldCommand extends Command{
	
	public SpawnShieldCommand(Object receiver, String[] args)
	{
		super(receiver, args);
	}

	@Override
	public void Execute()
	{
		// The receiver for the SpawnBuildingCommand is the Square to spawn the Building in.
		Square square = (Square) receiver;
		int x = Integer.parseInt(args[0]);
		int y = Integer.parseInt(args[1]);
		//ArrayList<ArrayList<BoardComponent>> board = GameBoard.Instance().GetBoard();
		// The args for SpawnBuildingCommand are the X,Y coordinate for the Building
		// used by the factory.
		// int height = Integer.parseInt(args[2]);
		//IAsteroidGameFactory factory = GameBoard.Instance().GetFactory();
		System.out.println("Spawning shield at (" + args[0] + "," + args[1] + ")"); 
		BoardComponent shield = new Shield(square, x, y);
		ArrayList<BoardComponent> children = square.GetChildren();
		for(BoardComponent child : children) {
			shield.Add(child);
			
		}
		GameBoard.Instance().GetBoard().get(y).set(x, shield);
		GameBoard.Instance().SubjectRegister(shield);
		
		
		
		
	}
}

