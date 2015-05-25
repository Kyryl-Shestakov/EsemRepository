package edu.labwork;

public class ImpairState extends State {
	private int i;

	public ImpairState(int i) {
		this.i = i;
	}

	@Override
	public void handle(Roulette r) {
		if ((r.getCurrentPocket() % 2) == 1) {
			r.getBet(i).win();
		} else {
			r.getBet(i).lose();
		}
		
		r.setIdleState();
	}

}
