using System;
using jobgo.classes;
using jobgo.enums;

namespace jobgo
{
    class mainJobGo
    {
        static jobsRepository job_repository = new jobsRepository();
        static void Main(string[] args)
        {
            string userOption;

            do {
            userOption = getUserOption();

                switch (userOption) {
                    case "1":
                        listJobs();
                        break;
                    case "2":
                        addJobs();
                        break;
                    case "3":
                        removeJobs();
                        break;
                    case "4":
                        updateJobs();
                        break;
                    case "5":
                        viewJobs();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Thank you! See you later.");
                }

            } while(userOption.ToUpper() != "X");
        }
        
        private static string getUserOption() {
            Console.WriteLine();
            Console.WriteLine("JobGo, throw yourself in the job offers!");
            Console.WriteLine(" -- Select your option --");

            Console.WriteLine("1: List jobs");
            Console.WriteLine("2: Add new job");
            Console.WriteLine("3: Remove job");
            Console.WriteLine("4: Update job");
            Console.WriteLine("5: View job");
            Console.WriteLine("C: Clear console");
            Console.WriteLine("X: Exit");
            Console.WriteLine();

            string _useroption = Console.ReadLine();
            return _useroption;
        }
        private static void listJobs() {
            Console.WriteLine("Job List");
            var list = job_repository.List();

            if (list.Count == 0) {
                Console.WriteLine("Jobs didn't find ! ");
                Console.WriteLine("Try later again :)");
            }

            foreach (var j in list) {
                Console.WriteLine($"#ID {j.Id}, #Offer {j.returnOffer()}");
            }
        }
        private static void addJobs() {
            Console.WriteLine("Add Job");

            // print enum values:
            foreach (int index in Enum.GetValues(typeof(Offer))) {
                Console.WriteLine($"{index}:{Enum.GetName(typeof(Offer), index)}");
            }

            Console.WriteLine("Enter your offer index: ");
            int getOffer = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Enter your company name: ");
            string getCompany = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Type a little bit about job offer: ");
            string getDesc = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Enter salary");
            string getSalary = Console.ReadLine();
            Console.WriteLine();

            Jobs newJobOffer = new Jobs(id: job_repository.nextId(),
                                        (Offer)getOffer,
                                        getCompany,
                                        getDesc,
                                        getSalary
                                        );

            job_repository.Adding(newJobOffer);
        }

        private static void removeJobs() {

        }

        private static void updateJobs() {

        }
        private static void viewJobs() {

        }

    // end class mainJobGo:    
    }
// end namespace jobgo
}
