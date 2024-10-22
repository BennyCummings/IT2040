namespace MidtermProject;

class reportWriter{
    public static void ReportWriter(List<StudentClass> studentList){
        using(StreamWriter reporter = new StreamWriter("report.txt")){
            Console.SetOut(reporter);
            foreach(StudentClass student in studentList){
                Console.WriteLine("----------------------Student Grade Report-----------------\n------------------------------------------");
                student.PrintStudentInfo();
            }
            
        }    
    }
    
}
