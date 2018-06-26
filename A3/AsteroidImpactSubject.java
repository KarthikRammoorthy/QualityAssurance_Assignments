import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.concurrent.CopyOnWriteArrayList;

public class AsteroidImpactSubject implements Subject {
	
	private CopyOnWriteArrayList<BoardComponent> observers;

	
	public AsteroidImpactSubject(){
		this.observers= new CopyOnWriteArrayList<BoardComponent>();
	}
	
	@Override
	public void register(BoardComponent obj) {
		
		//if(!observers.contains(obj)) observers.add(obj);
		observers.add(obj);
		
	}

	@Override
	public void unregister(BoardComponent obj) {
		
		 // Iterator<BoardComponent> itr = observers.iterator();
	       // while (itr.hasNext())
	        //{
	        //	BoardComponent x = (BoardComponent)itr.next();
	          //  if (x.equals(obj))
	            //    itr.remove();
	        //}
		observers.remove(obj);
		
	}
	

	@Override
	public void notifyObservers(BoardComponent obj) {
		for (BoardComponent observer : observers) {
	         observer.Update(obj);
	      }
		


	}


	



}
