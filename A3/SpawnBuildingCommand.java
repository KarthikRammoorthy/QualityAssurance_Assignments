
public class SpawnBuildingCommand extends Command{
	
		public SpawnBuildingCommand(Object receiver, String[] args)
		{
			super(receiver, args);
		}

		@Override
		public void Execute()
		{
			// The receiver for the SpawnBuildingCommand is the Square to spawn the Building in.
			Square square = (Square) receiver;
			// The args for SpawnBuildingCommand are the X,Y coordinate for the Building
			// used by the factory.
			//int height = Integer.parseInt(args[2]);
			IAsteroidGameFactory factory = GameBoard.Instance().GetFactory();
			System.out.println("Spawning building at (" + args[0] + "," + args[1] + ")");
			square.Add(factory.MakeBuilding());
			GameBoard.Instance().IncrementBuildingCount();
			
		}
	}
