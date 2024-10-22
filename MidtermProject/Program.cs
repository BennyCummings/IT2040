namespace MidtermProject;

class Program
{
    static void Main(string[] args)
    {
        List<StudentClass> studentList = StudentDataLoader.LoadStudent();
        ScoresLoader.LoadScores(studentList);
        foreach(StudentClass student in studentList){
            student.PrintStudentInfo();
        }
        reportWriter.ReportWriter(studentList);
            
        
    }
}
