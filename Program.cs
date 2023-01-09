using System;
using System.Threading;

namespace ComputerNumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            int max, min, diff, sec, num;
            string com = "TO COMPUTER: ";
            string to = "Your guess was to ";
            int guess = 0, att = 0;
            //Descirption
            Console.WriteLine("This is a game where your computer will try and guess your value.");
            //get max
            Console.WriteLine("First, whats the Maximum Value your computer can guess: ");
            max = Convert.ToInt32(Console.ReadLine());
            //get min
            Console.WriteLine("And, whats the Minimum Value: ");
            min  = Convert.ToInt32(Console.ReadLine());
            //get difference between max and min
            diff = max - min + 1;
            //comformation of sorts
            Console.WriteLine("There will be {0} possible values for the computer to chose from, ranging from {1}-{2}.", diff, min, max);
            //chose a value
            Console.WriteLine("What will your value be?");
            Console.WriteLine("!!Make sure its between the minimum and maximum values!!");
            Console.WriteLine("Your Value: ");
            num = Convert.ToInt32(Console.ReadLine());
            //if out of max and min threshold
            while (max <= num || num <= min) {
                Console.WriteLine("Sorry, but your value was outside your given threshold.");
                Console.WriteLine("Another value please: ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            //time between guesses
            Console.WriteLine("How long do you want the computer to wait between guesses?");
            Console.WriteLine("Wait time in seconds: ");
            sec = Convert.ToInt32(Console.ReadLine());
            //stops it from being to long or being negative
            while (sec > 20 || sec < 0) {
                Console.WriteLine("Sorry, but make sure your time (in seconds) is between 0 and 20.");
                Console.WriteLine("Another value please: ");
                sec = Convert.ToInt32(Console.ReadLine());
            }
            //converts seconds to milliseconds
            sec = sec * 1000;
            //gets first computers guess
            guess = (diff / 2) + min;
            //a while loop for guesses
            while (guess != num) {
                //stops compuer for set amount of time
                Thread.Sleep(sec);
                //adds to the attempts
                att++;
                //displays attemps #
                Console.WriteLine("Attempt #{0}.", att);
                Console.WriteLine("{0}Sorry, thats wrong.", com);
                //gives computer the understanding if its low or high
                if (guess < num) {
                    Console.WriteLine("{0}{1}low.", com, to);
                    min = guess + 1;
                }
                else {
                    Console.WriteLine("{0}{1}high.", com, to);
                    max = guess;
                }
                //tells us the computer's guess
                Console.WriteLine("{0}Your guess: {1}", com, guess);

                diff = max - min;
                //new guess
                guess = (diff / 2) + min;
            }
            //adds to the Attempt # and stops display for set amount of time.
            att++;
            Thread.Sleep(sec);
            //if the computers correct
            Console.WriteLine("{0}Correct, the number was {1}, good job.", com, num);
            //tells the Attempts the computer got it right on
            Console.WriteLine("{0}You got it on attempt #{1}!", com, att);
            //sets the attempt number to 1
            att = 1;
            //fun program ending sequence
            Console.WriteLine("TO USER: Type 1 and press ENTER to end the program: ");
            num = 2;
            num  = Convert.ToInt32(Console.ReadLine());

            while (num != 1) {
                Console.WriteLine("You entered {0}, which is not 1", num);
                Console.WriteLine("Type 1 then press ENTER: ");
                num = Convert.ToInt32(Console.ReadLine());
                att++;

                while (att >= 3) {
                    Console.WriteLine("This is attempt #{0}, of entering the number \"1\"", att+1);
                    Console.WriteLine("Waiting: ");
                    num = Convert.ToInt32(Console.ReadLine());
                    att++;
                    if (num == 1) {
                        att = 0;
                    }
                    else {}
                }
            }
            //ends program
            return;
        }
    }
}
