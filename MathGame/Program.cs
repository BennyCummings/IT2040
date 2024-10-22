using System.Net;
using System.Threading.Tasks.Dataflow;

namespace MathGame;

class Program
{
    static void Main(string[] args)
    {
        string name = GetName();
        EquationMaker(name);
        }

        static int RandomNumGen(int difficulty){
            int randomNum;
            Random random = new Random();
                switch(difficulty){
                    case 1: 
                    randomNum = random.Next(1,9);
                    return randomNum;
                    case 2: 
                    randomNum = random.Next(10,99);
                    return randomNum;
                    case 3: 
                    randomNum = random.Next(100,999);
                    return randomNum;
                    default: return -1;
                }
        }


    static void EquationMaker(string name){
        var result = GetDifficultyAndNumOfQuestions();
        int numOfIncorrect = 0;
        int correct = 0; 
        for(int i=0; i<result.numOfQuestions; i++){
            int x = RandomNumGen(result.difficulty);
            int y = RandomNumGen(result.difficulty);
            int attempts = 3;
            while(attempts != 0){
                Console.WriteLine($"\nQuestion {i+1}: {x} + {y} =");
                int answer = int.Parse(Console.ReadLine()!);
                if(answer != x+y){
                    Console.WriteLine("\nOOPS! You Got it WRONG!!!");
                    attempts--;
                    if(attempts == 0){
                        numOfIncorrect++;
                        Console.WriteLine($"Correct Answer {x} + {y} = {x+y}");
                        break;
                    }
                    continue;
                }
                else{
                    Console.WriteLine("\nYaY! You Got It Right!!!");
                    correct++;
                    break;
                }
            }
        }
        float correctness = (float)correct / result.numOfQuestions;
        Console.WriteLine($"Congratulations {name}! You got {correct} out of {result.numOfQuestions}: {correctness * 100:0.00}%");
    }
    static (int difficulty, int numOfQuestions) GetDifficultyAndNumOfQuestions(){
        int difficulty;
        int numOfQuestions;
        while(true){
            try{
                Console.WriteLine("\nEnter Level 1, 2, or 3:");
                difficulty = int.Parse(Console.ReadLine()!);
                if(difficulty < 1 || difficulty > 3){
                    Console.WriteLine("ERROR: Please enter an integer value between 1 and 3!");
                    continue;
                }
                break;
            }
            catch(Exception){
                Console.WriteLine("ERROR: Please enter an integer value between 1 and 3!");
                continue;
            }
        }
        while(true){
            try{
                Console.WriteLine("\nEnter number of questions to ask: 3 to 10");
                numOfQuestions = int.Parse(Console.ReadLine()!);
                if(numOfQuestions < 3 || numOfQuestions > 10){
                    Console.WriteLine("ERROR: Please enter an integer value between 3 and 10!");
                    continue;
                }
                break;
            }
            catch(Exception){
                Console.WriteLine("ERROR: Please enter an integer value between 3 and 10!");
                continue;
            }
        }
        return(difficulty, numOfQuestions);
    }

   static string GetName(){
    string name;
        while(true){
            Console.WriteLine("What is your name?");
            name = Console.ReadLine()!;  
            if(name != ""){
                Console.WriteLine($"Welcome {name}");
                return name;
            }
            else{
                Console.WriteLine("ERROR: You must enter your name!");
                continue;
            }  
        }
   }
}
