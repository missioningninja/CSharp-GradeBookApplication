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
        public RankedGradeBook(string name) : base(name)
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
                    if (count <= percentage * 2)
                        return 'B';
                    if (count <= percentage * 3)
                        return 'C';
                    if (count <= percentage * 4)
                        return 'D';
                }
                count++;
            }
            return 'F';
        }
    }
}
