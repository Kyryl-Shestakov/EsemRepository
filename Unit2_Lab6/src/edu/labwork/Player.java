package edu.labwork;

public class Player {
	private double account;
	private String name;

	public Player(double initialCapital, String name) {
		account = initialCapital;
		this.name = name;
	}

	public void withdraw(double bet) {
		account -= bet;
	}
	
	public void topUp(double gain) {
		account += gain;
	}
	
	public double getAccount() {
		return account;
	}
	
	public String toString() {
		return name + ", " + account;
	}
}
