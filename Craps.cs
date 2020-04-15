
/*Name: Andrew Wood
 *Date: 2/5/19
 *Purpose: Simulates the game of Craps
 * 
 * 
 */
using System;
using static System.Console;

namespace Craps
{
    class Craps
    {

        public static void DisplayInstructions()//method that prints out the instructions
        {
            WriteLine("To play the game, a player rolls a pair of dice (2 die).\n After the dice come to rest, the sum of the faces of the 2 die is calculated. \nIf the sum is 7 or 11 on the first throw, the player wins and the game is over.\n If the sum is 2, 3, or 12 on the first throw, the player loses and the game is over.\n If the sum is 4, 5, 6, 8, 9, or 10 on the first throw, then that sum is known as the player’s “point”.\n To win, he must keep throwing the dice until he/she “makes his point”, that is, the sum of the dice is equal to his point.\n The player loses if he throws a 7 before making his point. \nIn either case, the game is over.\n ");
            WriteLine("You begin with 100 chips to wager"); //print instructions 
        }

        static void Main(string[] args) //main method 
        {



            int chips = 100; //beginning chip amount
            int wager;//wager variable

            int sum;//sum variable

            DisplayInstructions(); //calls the method to display instructions


            while (chips != 0) //while loop while you have a positive chip total
            {
                while (true) //while loop 
                {
                    Write(" Enter a wager amount: "); //user input
                    string aValue = ReadLine(); //takes in string
                    wager = int.Parse(aValue);//converst to int
                    if (wager <= chips)//if wager is less than chips it exits this while loop
                        break;
                    else
                        WriteLine(" Amount greater then availble chips.");//if wager is bigger than chips than it dsiplays invalid message
                }


                Random randomGenerator = new Random(); //random number generator
                sum = randomGenerator.Next(2, 12); //random number between 2 and 12 
                WriteLine(" The sum of the pair of dice is: " + sum);
                if (sum == 2 || sum == 3 || sum == 12) //if sum equals these conditions they lose
                {
                    WriteLine("You lose");
                    chips -= wager; //subtracts the wager from the current chip total
                }
                else if (sum == 7 || sum == 11) //win conditions 
                {
                    WriteLine("You won ");
                    chips += 2 * wager; //gives back double the wager to the chip total
                }
                else //any other sum that isn't win or lose conditions 
                {
                    int point = sum; //the first sum equals the players "point"
                    while (true) //while loop 
                    {
                        Write("Continue rolling?(y/n)?"); //prompts if the user would like to continue
                        string choice = ReadLine();//reads in string input 
                        if (choice == "y") //if they choose yes
                        {
                            sum = randomGenerator.Next(2, 12);//rolls a new random sum
                            WriteLine(" The sum of the pair of dice is: " + sum);
                            if (sum == 7) //if sum equals 7 before point is reached
                            {
                                WriteLine("You lose");
                                chips -= wager; //subrtacts wager from chips
                                break; //exits
                            }
                            if (sum == point) //if the sum equals the players point 
                            {
                                WriteLine("You win");//win condition
                                chips += 2 * wager;//wager is doubled and added to chips
                                break; //exits
                            }
                        }
                        else //any other outcome
                            break;//exits
                    }
                }
                WriteLine("Chips Remaining: " + chips); //displays remaining chips
                WriteLine("Another game?(y/n)? ");//prompts to play another
                string gamechoice = ReadLine(); //reads input
                if (gamechoice == "y" && wager > 0) //if they would like to play again and wager is positice
                    continue; //continues the game
                else //any other condition
                    break;//exits
            }


        }

    }
}