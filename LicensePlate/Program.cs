namespace LicensePlate;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        while(true){
            string licensePlate = InputLicensePlate();
            bool validity = LicensePlateValidityChecker(licensePlate);
            DisplayResult(licensePlate, validity);
            if(validity){
                break;
            }
        }
     }
     static string InputLicensePlate(){
        while(true){
            Console.WriteLine("Enter License Plate:");
            string licensePlate = Console.ReadLine()!;
            if(licensePlate == ""){
                Console.WriteLine("ERROR: Must enter license plate");
                continue;
            }
            return licensePlate;
        }
     }
     static bool LicensePlateValidityChecker(string licensePlate){
        string correctInput = @"^[A-Za-z]{2}[A-Za-z0-9]{0,4}";
        bool hasDigit = false;
        if(licensePlate.Length < 2 || licensePlate.Length > 6){
            return false;
        }
        if(!Char.IsLetter(licensePlate[0]) || !Char.IsLetter(licensePlate[1])){
            return false;
        }
        for(int i=0; i <licensePlate.Length; i++){
            if(!Char.IsLetterOrDigit(licensePlate[i])){
                return false;
            }
            if(Char.IsDigit(licensePlate[i])){
                if(!hasDigit && licensePlate[i] == '0'){
                    return false;
                }
                hasDigit = true;
            }
        }
        try{
            return Regex.IsMatch(licensePlate, correctInput);
        }
        catch(Exception){
            return false;
        }
     }
        static void DisplayResult(string licensePlate, bool validity){
            if(!validity){
                Console.WriteLine($"{licensePlate} is not a valid license plate");
            }
            if(validity){
                Console.WriteLine($"{licensePlate} is a valid license plate");
            }
        }
        
     }

