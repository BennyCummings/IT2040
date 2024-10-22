namespace MidtermProject;

public class StudentDataLoader{
    public static List<StudentClass> LoadStudent(){
        List<StudentClass> studentList = new List<StudentClass>();

        using(StreamReader filereader = new StreamReader("student_data.csv")){
            int lineNum = 0;
            int piecesOfData = 5;
            while(!filereader.EndOfStream){
                lineNum++;

                string lineofData = filereader.ReadLine()!;
                string[] studentData = lineofData.Split(",");

                if(studentData.Length != piecesOfData){
                    Console.WriteLine($"ERROR on line: {lineNum}");
                    continue;
                }
                try{
                    int studentId = int.Parse(studentData[0]);
                    string studenFirName = studentData[1];
                    string studentLstName = studentData[2];
                    int studentCreditHours = int.Parse(studentData[3]);
                    string studentMajor = studentData[4];

                    studentList.Add(new StudentClass(studentId, studenFirName, studentLstName, studentMajor, studentCreditHours));
                }
                catch(Exception error){
                    Console.WriteLine($"ERROR: Line {lineNum} {error.Message}");
                }
            }
        }
        return studentList;
    }
}