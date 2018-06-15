
public abstract class Account {
	
	protected float balance;
	
	public abstract void Credit(float amount);
	
	public abstract float GetBalance();

	public abstract void Debit(float amount);

}
