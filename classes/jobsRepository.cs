using System;
using System.Collections.Generic;
using jobgo.interfaces;

namespace jobgo.classes {

    // Jobs list (interface repository implematation)
    public class jobsRepository : IRepository<Jobs> {
        private List<Jobs> listJobs = new List<Jobs>();
        public void Adding(Jobs entity)
        {
            listJobs.Add(entity);
        }

        public List<Jobs> List()
        {
            return listJobs;
        }

        public int nextId()
        {
            return listJobs.Count;
        }

        public Jobs returnById(int id)
        {
            return listJobs[id];
        }

        public void Rm(int id) // Remove
        {
            // Index doesn't need to change, so listJobs.RemoveAt(id); isn't available. 
            listJobs[id].thisRemove();
        }

        public void Update(int id, Jobs entity)
        {
            listJobs[id] = entity;
        }
    }

}