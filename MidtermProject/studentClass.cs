namespace MidtermProject;
public class StudentClass{
    private int id;
    private string firstName;
    private string lastName;
    private string major;
    private int creditHours;
    private List<double> testScores = new List<double>();
    private Status classStatus;

    public StudentClass(int id, string firstName, string lastName, string major, int creditHours){
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.major = major;
        this.creditHours = creditHours;
        ClassStatus();
    }

    public int GetId(){
        return this.id;
    }
    public string GetFirstName(){
        return this.firstName;
    }
    public void SetFirstName(string newFirstName){
        this.firstName = newFirstName;
    }
    public string GetLastName(){
        return this.lastName;
    }
    public void SetLastName(string newLastName){
        this.lastName = newLastName;
    }
    public string GetMajor(){
        return this.major;
    }
    public void SetMajor(string newMajor){
        this.major = newMajor;
    }
    public int GetCreditHours(){
        return this.creditHours;
    }
    public void ClassStatus(){
        if(this.creditHours >= 90){
            this.classStatus = Status.Senior;
        }
        else if(this.creditHours >= 60){
            this.classStatus = Status.Junior;
        }
        else if(this.creditHours >= 30){
            this.classStatus = Status.Sophomore;
        }
        else if(this.creditHours >= 0){
            this.classStatus = Status.Freshman;
        }
    }
    public void AddCreditHours(int newCreditHours){
        this.creditHours += newCreditHours;
        ClassStatus();
    }
    public void AddTestScores(double newTestScore){
        this.testScores.Add(newTestScore);
    }
    public string StudentScores(){
        return string.Join(", ", testScores);
    }
    public string StudentFullName(){
        return $"{this.firstName} {this.lastName}";
    }
    public string LetterGrade(){
        double averageScore = AverageTestScore();
        if(averageScore >= 90){
            return "A";
        }
        else if(averageScore >= 80){
            return "B";
        }
        else if(averageScore >= 70){
            return "C";
        }
        else if(averageScore >= 60){
            return "D";
        }
        else{
            return "F";
        }
    }
    public double AverageTestScore(){
        double totalPoints = 0;
        int tests = testScores.Count;
        foreach(double score in testScores){
            totalPoints += score;
        }
        return totalPoints / tests;
    }
    public void PrintStudentInfo(){
        Console.WriteLine($"ID:{id}: {this.firstName} {this.lastName}: {this.classStatus}({this.major})");
        Console.WriteLine("-------Scores-------");
        for(int i=0; i<testScores.Count;i++){
            Console.WriteLine($"Test{i}: Score: {testScores[i]}"); 
        }
        Console.WriteLine($"\nAverage Score: {this.AverageTestScore():F2}% -- Grade: {this.LetterGrade()}\n");
    }
}
