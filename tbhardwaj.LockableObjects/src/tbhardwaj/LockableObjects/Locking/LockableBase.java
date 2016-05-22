/**
 * 
 */
package tbhardwaj.LockableObjects.Locking;

import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantLock;

/**
 * @author tbhardwaj
 *
 */
public class LockableBase implements Lockable {

	Lock _lock = new ReentrantLock();
	
	/**
	 * 
	 */
	public LockableBase() {
		// TODO Auto-generated constructor stub
	}

	/**
	 * 
	 */
	boolean equals(LockableBase obj) {
		
		if (obj == null)
			return false;
		
		if (!super.equals(obj))
			return false;
		
		return true;
	}
	
	/**
	 * 
	 */
	public boolean equals(Object obj) {
		
		if (obj == null)
			return false;
		
		if (obj instanceof LockableBase)
			return equals((LockableBase)obj);
		
		return false;
	}
	
	/**
	 * 
	 */
	public int hashCode() {
	
		return super.hashCode();
	}
	
	/**
	 * 
	 */
	public String toString() {
		
		if (_lock.tryLock()) {
		
			try {
				return super.toString() + "::Un-Locked::";
			}
			finally {
				_lock.unlock();
			}
		}
		else {
			return super.toString() + "::Locked::";
		}
	}
}
