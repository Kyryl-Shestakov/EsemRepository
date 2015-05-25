package edu.labwork;

import java.util.Random;

public class Roulette {
	private static final int[] pockets = { 0, 32, 15, 19, 4, 21, 2, 25, 17, 34, 6, 27, 13, 36, 11, 30, 8, 23, 10, 5, 24, 16, 33, 1, 20, 14, 31, 9, 22, 18, 29, 7, 28, 12, 35, 3, 26 };
	private static final Random r = new Random();
	
	static {
		for (int i=0; i<pockets.length; ++i) {
			for (int j=i+1; j<pockets.length; ++j) {
				if (pockets[i] == pockets[j]) {
					System.err.println("There are identical pockets on the roulette");
				}
			}
		}
	}
	
	private State state;
	private int currentPocket;
	private Bet[] bets;

	public Roulette() {
		setIdleState();
	}
	
	public void play(Bet ... bets) {
		this.bets = bets;
		
		spin();
		
		for (int i=0; i < bets.length; ++i) {
			switch(bets[i].getBetType()) {
				case IMPAIR: {
					state = new ImpairState(i);
				} break;
				
				case MANQUE: {
					state = new ManqueState(i);
				} break;
				
				case NOIR:{
					state = new NoirState(i);
				} break;
				
				case PAIR: {
					state = new PairState(i);
				} break;
				
				case PASSE: {
					state = new PasseState(i);
				} break;
				
				case ROUGE: {
					state = new RougeState(i);
				} break;
				
				case SINGLE: {
					state = new SingleState(i);
				} break;
				
				default: {
					
				} break;
			}
			
			state.handle(this);
		}
		
		for (int i=0; i<bets.length; ++i) {
			bets[i].setPocket(getCurrentPocket());
		}
	}
	
	private void spin() {
		currentPocket = pockets[r.nextInt(pockets.length)];
	}

	public int getCurrentPocket() {
		return currentPocket;
	}
	
	public void setIdleState() {
		state = new IdleState();
	}
	
	public Bet getBet(int i) {
		return bets[i];
	}
}
