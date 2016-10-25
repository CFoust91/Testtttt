using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.IO;
namespace employee
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee CoolPerson = new Employee();
            CoolPerson.idNum = 22695;
            CoolPerson.fName = "Evan";
            CoolPerson.lName = "Gudmestad";
            CoolPerson.salad = 30000;
            //
            Employee TeacherIveNeverHad = new Employee();
            TeacherIveNeverHad.idNum = 22763;
            TeacherIveNeverHad.fName = "Pat";
            TeacherIveNeverHad.lName = "Duchinsky";
            TeacherIveNeverHad.salad = 40000;

            Employee NoLongerWorksHere = new Employee();
            NoLongerWorksHere.idNum = 23108;
            NoLongerWorksHere.fName = "Jordan";
            NoLongerWorksHere.lName = "Nothstine";
            NoLongerWorksHere.salad = 150000;

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            const string FILENAME = "EmployeeData.txt";
            const char DELIM = ',';
            const int END = 999;

            FileStream outFile = new FileStream(FILENAME, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(outFile);

            writer.WriteLine(CoolPerson.idNum + DELIM + CoolPerson.fName + DELIM + CoolPerson.lName + DELIM + CoolPerson.salad.ToString("C"));
            writer.WriteLine(TeacherIveNeverHad.idNum + DELIM + TeacherIveNeverHad.fName + DELIM + TeacherIveNeverHad.lName + DELIM + TeacherIveNeverHad.salad.ToString("C"));
            writer.WriteLine(NoLongerWorksHere.idNum + DELIM + NoLongerWorksHere.fName + DELIM + NoLongerWorksHere.lName + DELIM + NoLongerWorksHere.salad.ToString("C"));

            writer.Close();
            outFile.Close();

            ///////////////////////////////////////////////////////////////////////////////////////////////////

            FileStream inFile = new FileStream(FILENAME, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);

            string recordIn;
            string[] fields;

            double minSalary;
            WriteLine("Enter minimum salary to find or " + END + " to quit");
            minSalary = Convert.ToDouble(ReadLine());

            while(minSalary != END)
            {
                inFile.Seek(0, SeekOrigin.Begin);
                recordIn = reader.ReadLine();
                while(recordIn != null)
                {
                    fields = recordIn.Split(DELIM);
                    ///////////////////////////////////////////////////////////////////////////////////////////////////
                    
                    if(CoolPerson.salad >= minSalary)
                    {
                        WriteLine(CoolPerson.fName + DELIM + CoolPerson.lName);
                       
                        recordIn = reader.ReadLine();
                    } if (TeacherIveNeverHad.salad >= minSalary)
                    {
                        WriteLine(TeacherIveNeverHad.fName + DELIM + TeacherIveNeverHad.lName);
                      
                        recordIn = reader.ReadLine();
                    } if (NoLongerWorksHere.salad >= minSalary)
                    {
                        WriteLine(NoLongerWorksHere.fName + DELIM + NoLongerWorksHere.lName);

                        recordIn = reader.ReadLine();
                    } else
                    {
                        WriteLine("Thats supposed to be a teachers salary?");

                        recordIn = reader.ReadLine();
                    }
                    WriteLine("Enter minimum salary to find or " + END + " to quit");
                    minSalary = Convert.ToDouble(ReadLine());
                }
                if (minSalary == END)
                {
                    reader.Close();
                    inFile.Close();
                }
               
            }
        }
    }
    class Employee
    {
        public int idNum { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string department { get; set; }
        public double salad { get; set; }
    }
}
