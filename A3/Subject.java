
public interface Subject {
	

		public void register(BoardComponent obj);
		public void unregister(BoardComponent obj);
		
		
		public void notifyObservers(BoardComponent obj);
		
		


}
