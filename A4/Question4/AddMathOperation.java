
public class AddMathOperation extends MathOperation {
	
	
	public AddMathOperation(int leftOperand, int rightOperand)
	{
		super(leftOperand, rightOperand);
		
	}
	
	@Override
	public int GetResult()
	{
		return leftOperand + rightOperand;
	}
	

}
