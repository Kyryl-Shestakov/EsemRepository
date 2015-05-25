package edu.labwork;

public class Bet {
	
	private Player player;
	private double betAmount;
	private BetType betType;
	private int i;
	private int pocket;

	public Bet(Player player, double betAmount, BetType betType, int i) {
		this.player = player;
		this.betAmount = betAmount;
		this.betType = betType;
		this.i = i;
	}

	public void lose() {
		player.withdraw(betAmount);
	}
	
	public void win(double multiplier) {
		player.topUp(multiplier*betAmount);
	}
	
	public void win() {
		player.topUp(betAmount);
	}
	
	public BetType getBetType() {
		return betType;
	}
	
	public int getSelectedPocket() {
		return i;
	}
	
	public void setPocket(int pocket) {
		this.pocket = pocket;
	}
	
	public String toString() {
		return pocket + " played";
	}
}
