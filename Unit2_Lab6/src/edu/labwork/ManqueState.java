package edu.labwork;

public class ManqueState extends State {
	private int i;

	public ManqueState(int i) {
		this.i = i;
	}

	@Override
	public void handle(Roulette r) {
		if (r.getCurrentPocket() > 0 && r.getCurrentPocket() < 19) {
			r.getBet(i).win();
		} else {
			r.getBet(i).lose();
		}
		
		r.setIdleState();
	}

}
