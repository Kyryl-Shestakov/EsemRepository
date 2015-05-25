package edu.labwork;

final class Demo {

	public static void main(String[] args) {
		Roulette roulette = new Roulette();
		
		Player player = new Player(500.0, "Black Widow");
		System.out.println(player);
		
		Bet bet = new Bet(player, 150.0, BetType.IMPAIR, 0);
		
		roulette.play(bet);
		System.out.println(bet);
		System.out.println(player);
	}

}
