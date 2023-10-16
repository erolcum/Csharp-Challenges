static void Main()
{
	Random random = new Random();
	bool playAgain = true;
	string player;
	string computer;
	string answer;
	
	while (playAgain)
	{
		player = "";
		computer = "";
		answer = "";
		while (player != "rock" && player != "paper" && player != "scissors")
		{
			Console.Write(" Enter ROCK, PAPER or SCISSORS: ");
			player = Console.ReadLine();
			player = player.ToLower();
		
		}
		
		switch (random.Next(1, 4))
		{
			case 1:
				computer = "rock";
				break;
			case 2:
				computer = "paper";
				break;	
			case 3:
				computer = "scissors";
				break;	
		}
		
		Console.WriteLine("Player: " + player.ToUpper());
		Console.WriteLine("Computer: " + computer.ToUpper());
		
		switch (player)
		{
			case "rock":
				if(computer == "rock") Console.WriteLine("it is a draw!");
				if(computer == "paper") Console.WriteLine("You lose!");
				if(computer == "scissors") Console.WriteLine("You win!");
				break;
				
			case "paper":
				if(computer == "rock") Console.WriteLine("You win!");
				if(computer == "paper") Console.WriteLine("it is a draw!");
				if(computer == "scissors") Console.WriteLine("You lose!");
				break;
			case "scissors":
				if(computer == "rock") Console.WriteLine("You lose!");
				if(computer == "paper") Console.WriteLine("You win!");
				if(computer == "scissors") Console.WriteLine("it is a draw!");
				break;	
		}
		Console.Write("Would you like to play again? (Y/N): ");
		answer = Console.ReadLine();
		answer = answer.ToLower();
		if (answer == "y") playAgain = true;
		else
			playAgain = false;
		
	}
	Console.WriteLine("bye bye.. press ENTER to exit");
	Console.ReadLine();
}