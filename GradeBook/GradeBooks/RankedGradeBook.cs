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
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires a minimum of 5 students to work");
            }

            int Mcount = 0;
            int t2 = (int) Math.Ceiling(Students.Count * 0.2);
            decimal t24 = Math.Round((decimal)((Students.Count * 40) / 100));
            decimal t46 = Math.Round((decimal)((Students.Count * 60) / 100));
            decimal t68 = Math.Round((decimal)((Students.Count * 80) / 100));
            foreach (var item in Students)
            {
                if (averageGrade < item.AverageGrade)
                {
                    Mcount++;
                }
            }

            if (Mcount < t2)
            {
                return 'A';
            }
            else if (Mcount < t24)
            {
                return 'B';
            }
            else if (Mcount < t46)
            {
                return 'C';
            }
            else if (Mcount < t68)
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
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
