using AnimalNursery.Models.Base;
using System.Collections.ObjectModel;

namespace AnimalNursery.Repositories.Interfaces
{
    internal interface INurseryRepository
    {
        ObservableCollection<Animal> GetAll(ObservableCollection<Animal> NurseryCollection);
        bool Add(Animal animal);
        bool Update(Animal animal);
        bool Delete(Animal animal);
    }
}
