using System;

namespace Fortuna
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
	    int pix=500; 		// TODO ändra till double eller nåt & avrunda
	    int luckyNumber; 		// Engelska p.g.a blir nervös av åäö i var.
	    int numberCorrect=-1;	// se rad markerad 'hejsan'
	    int bet;
	    int diceRoll;
	    string input="";
	    int winningsMultiplier=0;
	    Random rnd = new Random();
	    bool go_on=true;
	    while (go_on)
	    {
		    numberCorrect=-1;
		   
		do
		{
			Console.WriteLine("Ange ditt lyckotal mellan 1 - 6");
		 	input=Console.ReadLine();
			go_on=int.TryParse(input, out luckyNumber);
			// TODO lägg in Try-catch, om det går att kombinera dessa...
			if ( luckyNumber < 1 || luckyNumber > 6)
			{
				Console.WriteLine ("talet ej mellan 1 & 6");
				go_on=false;
			}

		} while (!go_on);
		
		do
		{
			Console.WriteLine("Ange din insats (minustecken ignoreras)");
		 	 input=Console.ReadLine();
			go_on=int.TryParse(input, out bet);

			bet = Math.Abs (bet);
			if ( bet > pix )
			{
				go_on=false;
				Console.WriteLine("täckning saknas");
			}


		} while (!go_on);


	    
		for ( int i=1 ; i < 4 ; i++ )
		  { 
			diceRoll=rnd.Next(1,6);
			Console.WriteLine("Tärningskast "+ i + " blev "+ diceRoll);
			if ( diceRoll == luckyNumber && numberCorrect != -1 )
			{
				numberCorrect++;
			}
			else if ( numberCorrect == -1 && diceRoll == luckyNumber )
			{
				numberCorrect=1;
			}

		  }
		pix= pix - bet;
		winningsMultiplier=numberCorrect+1;		// hejsan
		pix = pix + (bet * winningsMultiplier);
		Console.WriteLine ("Du har " + pix + " pix");
 		if ( pix < 50)
			{
				Console.WriteLine ("Saldo för lågt. Socialstyrelsen har bestämt att du inte får spela mer");
				go_on=false;

			}
		else
				{
					do
					{

					Console.WriteLine ("Avsluta? j/n ");
					input=Console.ReadLine();
					if (input == "j")
					  {
						go_on=false;
					  }
					} while ( input != "n" && input != "j"); 
					

				}
		
		}			

        }
    }
}
