using AnimalNursery.Models.Base.Interfaces;
using AnimalNursery.ViewModels.Base;

namespace AnimalNursery.Models.Base
{
    public class Animal : ViewModelBase, IExecuteCommand
    {
        private int _id;
        private string _name;
        private double _age;
        private double _height;
        private double _weight;
        private string _classAnimal;
        private string _command;

        public int Id { get => _id; set { _id = value; OnPropertyChanged(nameof(Id)); } }
        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public double Age { get => _age; set { _age = value; OnPropertyChanged(nameof(Age)); } }
        public double Height { get => _height; set { _height = value; OnPropertyChanged(nameof(Height)); } }
        public double Weight { get => _weight; set { _weight = value; OnPropertyChanged(nameof(Weight)); } }
        public string ClassAnimal { get => _classAnimal; set { _classAnimal = value; OnPropertyChanged(nameof(ClassAnimal)); } }
        public string Command { get => _command; set { _command = value; OnPropertyChanged(nameof(Command)); } }

        public Animal(int id, string name, double age, double height, double weight, string classAnimal, string command)
        {
            Id = id;
            Name = name;
            Age = age;
            Height = height;
            Weight = weight;
            ClassAnimal = classAnimal;
            Command = command;
        }

        public string ExecuteCommand()
        {
            return Command;
        }
    }
}
