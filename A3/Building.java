// Building is the leaf node for the composite pattern, Square's can have MULTIPLE Buildings
// Buildings cannot have children.
public class Building extends BoardComponent
{
	private int buildingHealth;
	private BoardComponent building;
	private boolean className;
	
	public Building()
	{
		super();
		buildingHealth = 2;
		//this.subject = GameBoard.Instance().GetSubject();
		//this.subject.register(this);
		//this.building = this;
	}

	@Override
	public void Operation()
	{
		// Buildings just stand there, they don't do anything.
	}

	@Override
	public void Add(BoardComponent child)
	{
		// Do nothing, I'm a leaf.
	}

	@Override
	public void Remove(BoardComponent child)
	{
		// Do nothing, I'm a leaf.
	}
	
	@Override
	public void Update(BoardComponent parent)
	{
		//Do nothing
		///if(building.parent instanceof Shield )
		//{
		
		//}
		//else {
		 //className = parent.getClass().getName();
		className  = GameBoard.Instance().GetFlag();
		
			if (this.parent == parent && parent instanceof Square)
			{
			if (buildingHealth > 1) 
			{	
				buildingHealth -= 1;
			}
			else 
			{ 
				
				parent.Remove(this);	
				GameBoard.Instance().DecrementBuildingCount();
				
				GameBoard.Instance().SubjectUnRegister(this);
			}
			}
				
			
		//}
	
		
	}
}