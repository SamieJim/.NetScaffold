using System.Collections.Generic;
using Scaffolder.Models;

namespace Scaffolder.Repositories
{
    public interface IScaffolderRepo
    {
        bool SaveChanges();

        IEnumerable<Scaffold> GetAllScaffold();
        Scaffold GetScaffoldById(int id);
        void CreateScaffold(Scaffold obj);
        void UpdateScaffold(Scaffold obj);
        void DeleteScaffold(Scaffold obj);
    }
}