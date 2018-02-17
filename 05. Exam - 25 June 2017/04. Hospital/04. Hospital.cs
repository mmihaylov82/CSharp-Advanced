using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Program
    {
        public string input;

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Dictionary<string, string[,]> departments = new Dictionary<string, string[,]>();
            Dictionary<string, List<string>> patientsPerDoctor = new Dictionary<string, List<string>>();

            ParseInput(input, departments, patientsPerDoctor);
            PrintOutput(input, departments, patientsPerDoctor);
        }

        private static void ParseInput(string input, Dictionary<string, string[,]> departments,
                                        Dictionary<string, List<string>> patientsPerDoctor)
        {
            while (input != "Output")
            {
                var inputArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var department = inputArgs[0];
                var doctor = inputArgs[1] + " " + inputArgs[2];
                var patient = inputArgs[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new string[20,3];
                }

                if (!patientsPerDoctor.ContainsKey(doctor))
                {
                    patientsPerDoctor[doctor] = new List<string>();
                }

                bool foundEmptyBed = false;

                for (int roomNumber = 0; roomNumber < 20; roomNumber++)
                {
                    for (int bedInRoom = 0; bedInRoom < 3; bedInRoom++)
                    {
                        if (departments[department][roomNumber, bedInRoom] == null)
                        {
                            foundEmptyBed = true;
                            departments[department][roomNumber, bedInRoom] = patient;

                            if (!patientsPerDoctor[doctor].Contains(patient))
                            {
                                patientsPerDoctor[doctor].Add(patient);
                            }

                            break;
                        }
                    }
                    if (foundEmptyBed)
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }
        }

        private static void PrintOutput(string input, Dictionary<string, string[,]> departments, Dictionary<string, List<string>> patientsPerDoctor)
        {
            while (input != "End")
            {
                var inputArgs = input.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                // {Department} {Room} – print all patients in this room in alphabetical order each on new line
                if (departments.ContainsKey(inputArgs[0]) && inputArgs.Length == 2)
                {
                    var departmentWanted = inputArgs[0];
                    //no check for wrong input of room number <=0
                    var roomWantedIndex = int.Parse(inputArgs[1]) - 1;
                    List<string> patientsInRoom = new List<string>();

                    for (int bedInRoom = 0; bedInRoom < 3; bedInRoom++)
                    {
                        if (departments[departmentWanted][roomWantedIndex, bedInRoom] == null)
                        {
                            break;
                        }
                        patientsInRoom.Add(departments[departmentWanted][roomWantedIndex, bedInRoom]);
                    }
                    foreach (var patient in patientsInRoom.OrderBy(p=>p))
                    {
                        Console.WriteLine(patient);
                    }
                }

                //{Department} – print all patients in this department in order of receiving on new line
                else if (inputArgs.Length == 1 && departments.ContainsKey(inputArgs[0]))
                {

                    if (departments.ContainsKey(inputArgs[0]))
                    {
                        var departmentWanted = inputArgs[0];

                        List<string> patientsInDepartment = new List<string>();

                        for (int roomWantedIndex = 0; roomWantedIndex < 20; roomWantedIndex++)
                        {
                            for (int bedInRoom = 0; bedInRoom < 3; bedInRoom++)
                            {
                                if (departments[departmentWanted][roomWantedIndex, bedInRoom] == null)
                                {
                                    break;
                                }
                                patientsInDepartment.Add(departments[departmentWanted][roomWantedIndex, bedInRoom]);
                            }
                        }
                        patientsInDepartment.ForEach(x => Console.WriteLine(x));
                    }
                }

                // {Doctor} – print all patients that are healed from doctor in alphabetical order on new line
                else if (inputArgs.Length == 2 && patientsPerDoctor.ContainsKey(inputArgs[0] + " " + inputArgs[1]))
                {
                    var doctorWanted = inputArgs[0] + " " + inputArgs[1];
                    List<string> patients = new List<string>(patientsPerDoctor[doctorWanted]);
                    patients.Sort();
                    patients.ForEach(x => Console.WriteLine(x));
                }

                input = Console.ReadLine();
            }
        }
    }
}
