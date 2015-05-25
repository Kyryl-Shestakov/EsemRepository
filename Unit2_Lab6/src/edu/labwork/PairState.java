package edu.labwork;

public class PairState extends State {

	private int i;
	
	public PairState(int i) {
		this.i = i;
	}

	@Override
	public void handle(Roulette r) {
		if ((r.getCurrentPocket() % 2) == 0) {
			r.getBet(i).win();
		} else {
			r.getBet(i).lose();
		}
		
		r.setIdleState();
	}

}
