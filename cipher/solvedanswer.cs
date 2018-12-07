using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace Mycaesarcipher
{
    class decryption // my decryption class
    {

        public static void Main()
        {	// My char alphabet which will be used in my loop statement
			char[] Thealphabet = new char[26] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
			string UserResponse = ""; //This asks for the users response.
			int shift = 0;
			
			
			Console.WriteLine("Would you like to (D)ecrypt or (E)ncrypt? Enter D for decrypt or E encrypt.");// This gives you the option to encrypt and decrypt which would be displayed on the console.
			UserResponse = Console.ReadLine();
			
			if (UserResponse == "D" || UserResponse == "d") {//This makes sure that the user will be understood even if he writes capital d or not.
				//This is the text that is encrypted and is going to be decoded using a string file
				string hidden_text = System.IO.File.ReadAllText(@"text\caesarShiftEncodedText.txt");  
				
				string decrypted_text = "";
				//This declares the number of shifts i will be making

				
				hidden_text = hidden_text.ToUpper();//The hidden_text is all in capital and this reads the hidden text even when its in capital 
				 Console.WriteLine("The text i want to decrypt is \n{0}", hidden_text);// this displays on the console the text i will be decrypting
				
				
				

					 
			
					
				
				for (int i = 0; i < Thealphabet.Length; i++)        //A for loop would loop around the text in order to find the right shift 
				{
					decrypted_text = "";
					foreach (char e in hidden_text)
					{
						

						if (e == '\'' || e == ' ') //this checks the letters in the alphabet then chooses to shift or not
							continue; //

						shift = Array.IndexOf(Thealphabet, e) - i;   //The process of shifting starts here using the array. 
						
						// If the shift is lower than the alphabet number, then moves it towards the end of the alphabet (starting from "Z" backwards)
						if (shift <= 0)
							shift = shift + 26;

						if (shift >= 26)         // the number 26 is used to keep the answer in bound of the array 
							shift = shift - 26;//This takes it back into the array

					 
						decrypted_text += Thealphabet[shift]; //This uses the alphabet once again in order to shift. 
					}
					Console.WriteLine("\nThis shows how the shifted text looks like {0}: \n {1}", i + 1, decrypted_text); //This displays in the output the number of shifts made
				}
				
			} else if ( UserResponse == "E"|| UserResponse == "e"){//This would ask the user to input an e in order to encrypt a piece of text 
				string TextToEncrypt = "";
				int ShiftNumber = 0;
				string Ecrypted_text = "";
				
				Console.WriteLine("Enter text to encrypt.");// Asks the user to enter a piece of text to encrypt 
                TextToEncrypt = Console.ReadLine();
				
				TextToEncrypt = TextToEncrypt.ToUpper(); // This checks if the text is in capital letters or not
				
				Console.WriteLine("Enter shift number to apply."); 
				ShiftNumber = Convert.ToInt32(Console.ReadLine());
				
				
				
				
				// This would be my encryption method
					foreach (char e in TextToEncrypt)
					{
						
					

						if (e == '\'' || e == ' ') //this check if its the right letter to shift
							continue;

						shift = Array.IndexOf(Thealphabet, e) - ShiftNumber;   //The process of shifting starts here using the array. 
						
						if (shift <= 0)
							shift = shift + 26;

						if (shift >= 26)         // the number 26 is used to keep the answer in bound of the array 
							shift = shift - 26;//This takes it back into the array

						
						Ecrypted_text += Thealphabet[shift];
					}
				// displays to the user the shift made 
				Console.WriteLine(TextToEncrypt +" becomes " + Ecrypted_text + " when a shift of " + ShiftNumber + " is applied.");
				
				
			} 
			
			
			else
			{
				Console.WriteLine("Invalid input! Run program again.");// This displays to the user if they type in the wrong letter
				
			}
			
			
			
            
			
        }
    }
}


        
    
