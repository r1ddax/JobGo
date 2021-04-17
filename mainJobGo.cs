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
        private static int getOffer() {
            // print enum values:
            foreach (int index in Enum.GetValues(typeof(Offer))) {
                Console.WriteLine($"{index}:{Enum.GetName(typeof(Offer), index)}");
            }
            Console.WriteLine("Enter your offer index: ");
            int getOffer = int.Parse(Console.ReadLine());
            Console.WriteLine();

            return getOffer;
        }
        private static string getCompany() {
            Console.WriteLine("Enter your company name: ");
            string getCompany = Console.ReadLine();
            Console.WriteLine();

            return getCompany;
        }
        private static string getDescription() {
            Console.WriteLine("Type a little bit about job offer: ");
            string getDesc = Console.ReadLine();
            Console.WriteLine();

            return getDesc;
        }
        private static float getSalary() {
            Console.WriteLine("Enter salary");
            float getSalary = float.Parse(Console.ReadLine());
            Console.WriteLine();

            return getSalary;
        }
        private static void listJobs() {
            var list = job_repository.List();
            if (list.Count == 0) {
                Console.WriteLine("Jobs didn't find ! ");
                Console.WriteLine("Try later again or add one.");
            }else{
                Console.WriteLine("Job List");
                foreach (var j in list) {
                    if (job_repository.returnById(j.Id).returnRemove() == false) {
                        Console.WriteLine($"#ID {j.Id}, Offer: {j.returnOffer()}");
                    } else {
                        Console.WriteLine($"#ID {j.Id}, Offer: REMOVED!");
                    }
                }
            }
            Console.WriteLine();
        }
        private static void addJobs() {
            Console.WriteLine("Add Job");
            Jobs newJobOffer = new Jobs(job_repository.nextId(),
                                        (Offer)getOffer(),
                                        getCompany(),
                                        getDescription(),
                                        getSalary()
                                        );

            job_repository.Adding(newJobOffer);
        }

        private static void removeJobs() {
            try {
                var list = job_repository.List();
                if (list.Count != 0) {
                    listJobs();
                    Console.WriteLine("Enter the id number that you want delete/remove:");
                    int getId = int.Parse(Console.ReadLine());
                    if (job_repository.returnById(getId).returnRemove() == false) {
                        job_repository.Rm(getId); // Removing
                        Console.WriteLine();
                    }else{
                        Console.WriteLine("You can't remove deleted job offer. It has already been removed!");
                    }
                }else{
                    Console.WriteLine("There isn't jobs.");
                }
            } catch (System.ArgumentOutOfRangeException) {
            Console.WriteLine("This index doesn't exists");
            }
        }

        private static void updateJobs() {
            try{
                var list = job_repository.List();
                if (list.Count != 0) {
                    listJobs();
                    Console.WriteLine("Enter the id number that you want update:");
                    int getId = int.Parse(Console.ReadLine());
                    if (job_repository.returnById(getId).returnRemove() == false) {
                        Console.WriteLine();

                        Jobs upadatedJobOffer = new Jobs(getId,
                                                    (Offer)getOffer(),
                                                    getCompany(),
                                                    getDescription(),
                                                    getSalary()
                                                    );

                        job_repository.Update(getId, upadatedJobOffer);
                    }else{
                        Console.WriteLine("You can't update deleted offers. Create a new!");
                    }
                }else{
                    Console.WriteLine("There isn't jobs.");
                }
            } catch (System.ArgumentOutOfRangeException) {
            Console.WriteLine("This index doesn't exists");
            }
        }
        private static void viewJobs() {
            try{
                var list = job_repository.List();
                if (list.Count != 0) {
                    listJobs();
                    Console.WriteLine("Enter the id number that you want read/view:");
                    int getId = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    var job = job_repository.returnById(getId);
                    Console.WriteLine(job.thisSting());
                    Console.WriteLine();
                }else{
                    Console.WriteLine("There isn't jobs.");
                }
            } catch (System.ArgumentOutOfRangeException) {
            Console.WriteLine("This index doesn't exists");
            }
        }

    // end class mainJobGo:    
    }
// end namespace jobgo
}
