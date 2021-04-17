using jobgo.enums;
using System;

namespace jobgo.classes {

    public class Jobs : EntityBase {

        private Offer Offer { get; set; }
        private string Company { get; set; }
        private string Description { get; set; }
        private int Salary { get; set; }
        private bool Removed { get; set; }
        
        public Jobs(int id, Offer offer, string company, string description, int salary) {
            this.Id             = id;
            this.Offer          = offer;
            this.Company        = company;
            this.Description    = description;
            this.Salary         = salary;
            this.Removed        = false;
        }

        public string thisSting() {
            string this_string = "";
            this_string += $"Job Offer: {Offer}" + Environment.NewLine;
            this_string += $"Company: {Company}" + Environment.NewLine;
            this_string += $"Description: {Description}" + Environment.NewLine;
            this_string += $"Salary: {Salary}" + Environment.NewLine;
            return this_string;
        }

        public string returnOffer() {
            return $"{this.Offer}";
        }

        public int returnId() {
            return this.Id;
        }

        public void thisRemove() {
            this.Removed = true;
        }
    //end jobs class.
    }

// end namespace
}