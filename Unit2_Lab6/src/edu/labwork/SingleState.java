package edu.labwork;

public class SingleState extends State {
	private int i;

	public SingleState(int i) {
		this.i = i;
	}

	@Override
	public void handle(Roulette r) {
		if (r.getCurrentPocket() == r.getBet(i).getSelectedPocket()) {
			r.getBet(i).win(36.0);
		} else {
			r.getBet(i).lose();
		}
		
		r.setIdleState();
	}

}
