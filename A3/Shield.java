import java.util.ArrayList;

// Building is the leaf node for the composite pattern, Square's can have MULTIPLE Buildings
// Buildings cannot have children.
public class Shield extends Decorator
{
	private ArrayList<BoardComponent> children;
	private BoardComponent parent;
	private int shieldHealth;
	private String shield;
	private int x;
	private int y;
	
	
	public Shield(BoardComponent boardComponent, int x, int y)
	{
		super(boardComponent);
		children = new ArrayList<BoardComponent>();
		shieldHealth = 2;
		this.x = x;
		this.y = y;
	}

	@Override
	public void Operation()
	{
		super.Operation();
		
	}
	


	@Override
	public void Add(BoardComponent child)
	{
		// I am now this child's parent.
		children.add(child);
		child.SetParent(this);
	}

	@Override
	public void Remove(BoardComponent child)
	{
		children.remove(child);
	}
	
	public void SetChildren(ArrayList<BoardComponent> children)
	{
		this.children = children;
	}
	
	public ArrayList<BoardComponent> GetChildren()
	{
		return this.children;
	}
	
	@Override
	public void Update(BoardComponent parent)
	{	
		if(parent == this) {
			
			if (shieldHealth > 1) 
			{	
				shieldHealth -= 1;
			}
			else 
			{ 
				
				shieldHealth -= 1;
				GameBoard.Instance().SubjectUnRegister(this);
				ArrayList<BoardComponent> children = this.GetChildren();
				parent = new Square();
				for(BoardComponent child : children) {
					parent.Add(child);
					
				}
				GameBoard.Instance().GetBoard().get(y).set(x, parent);
				//GameBoard.Instance().SubjectUnRegister(this);
			}
			
		}
		
	}
}
