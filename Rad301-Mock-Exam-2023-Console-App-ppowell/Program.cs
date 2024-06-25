using Tracker.WebAPIClient;

namespace Rad301_Mock_Exam_2023_Console_App_ppowell
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ActivityAPIClient.Track(StudentID: "ppowell", StudentName: "Paul Powell", activityName: "Rad301 Mock Exam 2023", Task: "Exam Start");
        }
    }
}