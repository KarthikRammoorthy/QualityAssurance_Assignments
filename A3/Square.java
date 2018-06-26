import java.util.ArrayList;

// Square is a composite, making up the Composite pattern (contains components)
public class Square extends BoardComponent
{
	private final ArrayList<BoardComponent> children;
	private BoardComponent parent;
	
	
	public Square()
	{
		super();
		children = new ArrayList<BoardComponent>();
	}

	@Override
	public void Operation()
	{
		//int size = children.size();
		for (int i = 0; i < children.size(); i++)
		{
			BoardComponent child = children.get(i);
			child.Operation();
		}
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
	
	@Override
	public void Update(BoardComponent child)
	{
		//Do nothing
	}
	
	
	public ArrayList<BoardComponent> GetChildren()
	{
		return this.children;
	}
	
}