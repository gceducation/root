package pickerwinlose;

import java.util.Random;
import java.util.Scanner;

public class PickerWinLose {

	static final int __jPlayer0 = 0;
	static final int __jPlayer1 = 1;
	static String __sComputer = "Computer";
	static String __sHuman = "Human";
	static String __sRandom = "Random";
	static String[] __arrStrPlayers = { __sHuman, __sComputer };
	static String __sYes = "Yes";
	static String __sNo = "No";
	static String[] __arrStrNoYes = { __sNo, __sYes };
	static String __sLCWins = "Player who picks the last card wins";
	static String __sLCLoses = "Player who picks the last card loses";
	static String[] __arrStrLCWinLose = { __sLCWins, __sLCLoses };

	public static void main(String[] args) {
		int jLimitTokMinRandomGame = 30;
		int jLimitTokMin = 3;
		int jLimitTokMac = 120;
		int jLimitTokPickMin = 1;
		int jTokenCount;
		int jTokPickMin;
		int jTokPickMac;
		boolean fHumanFirst;
		boolean fLastTokenWins;

		System.out.println("Welcome to Token Picker Game");

		Scanner console = new Scanner(System.in);
		Random rng = new Random();
		int j = getStringIndexFromConsole(console, "Do you want to play a random game?", __arrStrNoYes);
		if (j == 0) {
			jTokenCount = getIntFromConsole(console, jLimitTokMin, jLimitTokMac, "Fine! How many total tokens ?");
			jTokPickMin = getIntFromConsole(console, jLimitTokPickMin, jTokenCount,
					"How many minimum tokens to pick per turn ?");
			jTokPickMac = getIntFromConsole(console, jTokPickMin, jTokenCount,
					"How many maximum tokens to pick per turn ?");
			j = getStringIndexFromConsole(console, "What is the winning condition ?", __arrStrLCWinLose);
			fLastTokenWins = j == 0;
			j = getStringIndexFromConsole(console, "Who plays first?", __arrStrPlayers);
			fHumanFirst = j == 0;

		} else {
			jTokenCount = getRandomInt(rng, jLimitTokMinRandomGame, jLimitTokMac);
			jTokPickMin = getRandomInt(rng, jLimitTokPickMin, jTokenCount / 8);
			jTokPickMac = getRandomInt(rng, jTokPickMin + 1, jTokPickMin + jTokenCount / 4);
			fHumanFirst = getRandomInt(rng, 0, 1) == 0;
			fLastTokenWins = getRandomInt(rng, 0, 1) == 0;

		}
		System.out.println("Total tokens = " + jTokenCount);
		System.out.println("Minimum Tokens to pick = " + jTokPickMin);
		System.out.println("Maximum Tokens to pick = " + jTokPickMac);
		System.out.println("First Player = " + (fHumanFirst ? __sHuman : __sComputer));
		System.out.println("Winning Condition : " + (fLastTokenWins ? __sLCWins : __sLCLoses));

		playGame(console, rng, jTokenCount, jTokPickMin, jTokPickMac, fHumanFirst, fLastTokenWins);
		console.close();

	}

	private static int getRandomInt(Random rng, int jMin, int jMac) {
		int jRet = Integer.MIN_VALUE;
		if (jMin > jMac) {
			int jTemp;
			jTemp = jMin;
			jMin = jMac;
			jMac = jTemp;
		}
		if (jMac > jMin) {
			jRet = rng.nextInt(jMac - jMin + 1) + jMin;
		} else if (jMac == jMin) {
			jRet = jMin;
		}
		return jRet;
	}

	private static int getIntFromConsole(Scanner console, int jMin, int jMac, String sPrefix) {
		int jRet = Integer.MIN_VALUE;
		boolean fGotOK = false;
		do {
			if (sPrefix != null) {
				System.out.println(sPrefix);
			}
			System.out.print("Enter an integer between " + jMin + " and " + jMac + " : ");
			try {
				jRet = console.nextInt();
				fGotOK = (jRet >= jMin) && (jRet <= jMac);
			} catch (Exception ex) {

			}
			if (!fGotOK) {
				System.out.println("!!! Error, please retry.");
			}

		} while (!fGotOK);
		return jRet;
	}

	private static int getStringIndexFromConsole(Scanner console, String sPrefix, String[] arrsValues) {
		if (sPrefix != null) {
			System.out.println(sPrefix);
		}
		int j;
		for (j = 0; j < arrsValues.length; j++) {
			System.out.println("" + j + " = " + arrsValues[j]);
		}
		j = getIntFromConsole(console, 0, j - 1, null);
		return j;
	}

	private static void playGame(Scanner console, Random rng, int jTokenCount, int jTokPickMin, int jTokPickMac,
			boolean fHumanFirst, boolean fLastTokenWins) {

		int jPlayerCurrent = fHumanFirst ? __jPlayer0 : __jPlayer1;
		int jPickedThisTurn = 0;
		int jTokRemaining = jTokenCount;
		boolean fDone = false;
		do {
			System.out.println("***Remaining Tokens: " + jTokRemaining);
			if (jTokPickMin > jTokRemaining) {
				fDone = true;
				System.out.println("It is a draw!");
			} else {
				if (jTokPickMac > jTokRemaining) {
					jTokPickMac = jTokRemaining;
				}
				if (jPlayerCurrent == 0) {

					// Human Move
					if (jTokPickMin == jTokPickMac) {
						jPickedThisTurn = jTokPickMin;
						System.out.println("Human must pick " + jPickedThisTurn);
					} else {
						jPickedThisTurn = getIntFromConsole(console, jTokPickMin, jTokPickMac,
								"How many do you want to pick ?");

					}

				} else {
					// Computer Move
					jPickedThisTurn = getComputerMove(console, rng, jTokenCount, jTokPickMin, jTokPickMac,
							jTokRemaining, fLastTokenWins);

				}
				System.out.println(__arrStrPlayers[jPlayerCurrent] + " Player picked " + jPickedThisTurn);
				jTokRemaining -= jPickedThisTurn;
				if (jTokRemaining == 0) {
					fDone = true;
					System.out.print(__arrStrPlayers[jPlayerCurrent] + " Player ");
					if (fLastTokenWins) {
						System.out.println("Won");
					} else {
						System.out.println("Lost");
					}
					System.out.println("Game Over");
				} else {
					jPlayerCurrent = __jPlayer1 - jPlayerCurrent;
				}
			}
		} while (!fDone);

	}

	private static int getComputerMove(Scanner console, Random rng, int jTokenCount, int jTokPickMin, int jTokPickMac,
			int jTokRemaining, boolean fLastTokenWins) {
		int jRet = 0;
		int jTokPickTot = jTokPickMin + jTokPickMac;
		int jTokRemainingAdj = fLastTokenWins ? jTokRemaining : jTokRemaining - jTokPickMin;
		int jRemainder = jTokRemainingAdj % jTokPickTot;

		if (jRemainder == 0) {
// Computer is going to lose, if the human plays optimially
// so make a random move.
			jRet = getRandomInt(rng, jTokPickMin, jTokPickMac);
		} else if (jRemainder > jTokPickMac) {
			jRet = jTokPickMac;
		} else if (jRemainder < jTokPickMin) {
			jRet = jTokPickMin;
		} else {
			jRet = jRemainder;
		}
		return jRet;
	}
}
