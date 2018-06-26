import java.util.ArrayList;

// Square is a composite, making up the Composite pattern (contains components)
public abstract class Decorator extends BoardComponent
{
	
	protected BoardComponent objBoardComponent;
	
	public Decorator( BoardComponent boardComponent)
	{
		this.objBoardComponent = boardComponent;
	}
	
	public void SetBoardComponent(BoardComponent parent)
	{
		this.objBoardComponent = parent;
	}
	
	public BoardComponent GetBoardComponent(BoardComponent parent)
	{
		return this.objBoardComponent;
	}

	@Override
	public void Operation()
	{
		this.objBoardComponent.Operation();
	}
	
	@Override
	public void Add(BoardComponent child)
	{
		this.objBoardComponent.Add(child);
	}

	@Override
	public void Remove(BoardComponent child)
	{
		this.objBoardComponent.Remove(child);
	}
	
	public BoardComponent getSubject() {
		  return objBoardComponent;
		}



}
