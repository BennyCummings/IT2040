namespace MidtermProject;
public class ScoresLoader{
    public static List<StudentClass> LoadScores(List<StudentClass> studentList){
        using(StreamReader fileReader = new StreamReader("scores.csv")){
            int lineNum = 0;
            while(!fileReader.EndOfStream){
                lineNum++;

                string lineOfData = fileReader.ReadLine()!;
                string[] studentScores = lineOfData.Split(",");
                bool studentFound = false;

                if(studentScores.Contains("")){
                    continue;
                }

                try{
                    int studentId = int.Parse(studentScores[0]);
        
                    foreach(StudentClass student in studentList){
                        if(student.GetId() == studentId){
                            studentFound = true;
                            for(int i=1; i<studentScores.Length;i++){
                                student.AddTestScores(double.Parse(studentScores[i]));
                            }
                            break;
                        }    
                    }
                    if(!studentFound){
                        Console.WriteLine($"Student with ID:{studentId}");
                    }
                }
                catch(Exception error){
                    Console.WriteLine($"There was an error on line {lineNum} while reading scores: {error.Message}");
                }
            }
            return studentList;
        }
    }
}