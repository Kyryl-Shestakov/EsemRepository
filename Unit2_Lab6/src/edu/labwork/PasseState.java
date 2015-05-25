package edu.labwork;

public class PasseState extends State {
	private int i;

	public PasseState(int i) {
		this.i = i;
	}

	@Override
	public void handle(Roulette r) {
		if (r.getCurrentPocket() > 18 && r.getCurrentPocket() < 37) {
			r.getBet(i).win();
		} else {
			r.getBet(i).lose();
		}
		
		r.setIdleState();
	}

}
