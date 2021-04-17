using System.Collections.Generic;

namespace jobgo.interfaces {
    
    public interface IRepository<T> { // <Generic type> to class impement
    
    List <T> List(); // Returning List
    T returnById(int Id);

    void Adding(T entity);
    void Rm(int id);
    void Update(int id, T entity);
    int nextId();
    }

}