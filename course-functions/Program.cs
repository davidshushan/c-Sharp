using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Dynamic;

namespace Final_Project
{
    class Program
    {

        static void Main(string[] args)
        {
            Course course1 = new Course() { courseName = "c#", student = new Course.Student() { Name = "Jojo", Grades = new List<int> { 10, 20, 100 } } };
            Course course2 = new Course() { courseName = "c", student = new Course.Student() { Name = "Bambi", Grades = new List<int> { 99 } } };
            Course course3 = new Course() { courseName = "Java", student = new Course.Student() { Name = "Bambi", Grades = new List<int> { } } };
            Course course4 = new Course() { courseName = "c#", student = new Course.Student() { Name = "Jojo", Grades = new List<int> { 10, 20, 30, 40 } } };
            Course course5 = new Course() { courseName = "Java", student = new Course.Student() { Name = "Lady Gaga", Grades = new List<int> { 100, 99, 1, 100, 100 } } };
            Course course6 = new Course() { courseName = "Java", student = new Course.Student() { Name = "Tami", Grades = new List<int> { 60, 70, 80, 1 } } };
            Course course7 = new Course() { courseName = "SQL", student = new Course.Student() { Name = "Lady Gaga", Grades = new List<int> { 50 } } };

            List<Course> courses = new List<Course> { course1, course2, course3, course4, course5, course6, course7 };

            Console.WriteLine("List of courses:\n");
            foreach (var course in courses)
            {
                Console.WriteLine(course.ToString());
            }
            Console.WriteLine("\n");
            Console.WriteLine("courses[0].ShowGrade(2)");
            Console.WriteLine(courses[0].ShowGrade(2));
            Console.WriteLine("\n");
            Console.WriteLine("courses[2].ShowGrade(3)");
            Console.WriteLine(courses[2].ShowGrade(3)); // Index was out of range

            Console.WriteLine("\n");

             List<Course> Q2(List<Course> Courses)
            {
                return Courses.Where(course => course.student.Grades.Count > 0 && course.student.Grades.Average() > 60)
                    .Where(course => course.student.Grades.Average() >= 90).ToList();

            }

            {

                void printList(List<Course> list, Boolean title)
                {
                    Console.WriteLine(title);
                    Console.WriteLine("---------------------");
                    list.ForEach(course => Console.WriteLine(course.ToString()));

                }

                void Q1(List<Course> myCourses)
                {
                    List<Course> res1 = new List<Course>();
                    List<Course> res2 = new List<Course>();
                    Console.WriteLine("Press P OR p to see grades above avg: ");
                    Console.WriteLine("Press # to see c# courses, and other courses: ");
                    Console.WriteLine("Any other key: courses with student who has at least one grade of 100, and all the other courses: ");
                    string str1 = Console.ReadLine();
                    Console.WriteLine("Q1 Results: \n ");

                    if (str1 == "P" || str1 == "p")
                    {
                        res1 = aboveAvg(myCourses).ToList();
                        res2 = myCourses.Except(aboveAvg(myCourses)).ToList();
                    }

                    if (str1 == "#")
                    {
                        res1 = courseCSharp(myCourses).ToList();
                        res2 = myCourses.Except(courseCSharp(myCourses)).ToList();
                    }

                    if (str1 != "#" && str1 != "P" && str1 != "p")
                    {
                        res1 = (List<Course>)atLeastOne100Grade(myCourses).ToList();
                        res2 = (List<Course>)myCourses.Except(atLeastOne100Grade(myCourses)).ToList();
                    }

                    printList(res2, false);

                    printList(res1, true);

                }

                 IEnumerable<Course> aboveAvg(IEnumerable<Course> myCourses)
                {
                 
                        return myCourses.Where(a => a.student.Grades.Count > 0 && a.student.Grades.Average() >= 60);
                }

                 IEnumerable<Course> courseCSharp(IEnumerable<Course> myCourses)
                {
                    return myCourses.Where(a => a.courseName.Equals("c#"));
                }

                 IEnumerable<Course> atLeastOne100Grade(IEnumerable<Course> myCourses)
                {
                    
                    return myCourses.Where(a => a.student.Grades.Contains(100));

                }


                 Q1(courses);
                Console.WriteLine("\n ");

                Console.WriteLine("Q2 Results: \n ");
                printList(Q2(courses), true);
                Console.WriteLine("\n ");
                var listFalse = courses.Except(Q2(courses)).ToList();
                printList(listFalse, false);

                Console.ReadKey();

            }

        }
    }
}

