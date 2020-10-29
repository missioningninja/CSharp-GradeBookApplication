using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            var students = Students;
            if(students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            var percentage = students.Count * 0.20;
            int count = 1;
            foreach(Student student in students.OrderByDescending(x => x.AverageGrade))
            {
                if(averageGrade >= student.AverageGrade)
                {
                    if (count <= percentage)
                        return 'A';
                    else if (count <= percentage * 2)
                        return 'B';
                    else if (count <= percentage * 3)
                        return 'C';
                    else if (count <= percentage * 4)
                        return 'D';
                }
                count++;
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            var students = Students;
            if (students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            var students = Students;
            if (students.Count < 5)
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
            else
                base.CalculateStudentStatistics(name);
        }
    }
}
