using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            double numStudents = Students.Count;
            int dropGradeNumber = (int)Math.Ceiling(numStudents / 5);
            var orderedGrades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            if (numStudents < 5)
            {
                throw new InvalidOperationException("5 or more students are required to get a weighted letter grade");
            } 
            else if (orderedGrades[(dropGradeNumber) - 1] <= averageGrade)
            {
                return 'A';
            } 
            else if (orderedGrades[(dropGradeNumber * 2) - 1] <= averageGrade)
            {
                return 'B';
            } 
            else if (orderedGrades[(dropGradeNumber * 3) - 1] <= averageGrade)
            {
                return 'C';
            } 
            else if (orderedGrades[(dropGradeNumber * 4) - 1] <= averageGrade)
            {
                return 'D';
            } 
            else
            {
                return 'F';
            }
        }
        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
