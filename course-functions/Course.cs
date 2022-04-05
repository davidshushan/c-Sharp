using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;

namespace Final_Project
{
    class Course
    {
        public string courseName { get; set; }
        public Student student = new Student();
   
        public int ShowGrade(int index)
        {
          
                int grade = student[index];
                return grade;
                
            // int grade = this.student.Grades[location];    
        }

        internal class Student
        {
            public string Name { get; set; }

            //list of grades
            public List<int> Grades = new List<int>();
           
            public int this[int index]
            {

                get
                {
                    try
                    { 
                        return Grades[index];
                    }
                    catch (Exception)
                    {
                        return -1;
                    }

                }
            }
       
        }

        public override string ToString()
        {
            
            string str = $"Course Name: {courseName,-15}Student Name: {this.student.Name,-15}  Grades:";
            foreach (var Grade in this.student.Grades)
            {
                str += "   ";
                str += Grade.ToString();

            }
            return str; 
        }
    }
}
