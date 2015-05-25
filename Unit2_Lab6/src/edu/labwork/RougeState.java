package edu.labwork;

public class RougeState extends State {

	private int i;
	private int p;
	
	public RougeState(int i) {
		this.i = i;
	}

	@Override
	public void handle(Roulette r) {
		p = r.getCurrentPocket();
		
		if ( (isOdd() && (isIn(1, 10) || isIn(19, 28))) || (isEven() && (isIn(11, 18) || isIn(29, 36)))) {
			r.getBet(i).win();
		} else {
			r.getBet(i).lose();
		}
		
		r.setIdleState();
	}

	private boolean isIn(int l, int r) {
		return (p>=l) && (p<=r);
	}

	private boolean isEven() {
		return (p % 2) == 0;
	}
	
	private boolean isOdd() {
		return (p % 2) == 1;
	}
}
