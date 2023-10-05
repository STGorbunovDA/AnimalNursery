using AnimalNursery.Models.Base;
using AnimalNursery.Repositories;
using AnimalNursery.Repositories.Interfaces;
using AnimalNursery.ViewModels.Base;
using System.Windows;
using System.Windows.Input;

namespace AnimalNursery.ViewModels
{
    internal class AddAnimalViewModel : ViewModelBase
    {
        INurseryRepository _nurseryRepository;

        #region свойства

        private string _name;
        private string _age;
        private string _height;
        private string _weight;
        private string _classAnimal;
        private string _command;

        public string Name { get => _name; set { _name = value; OnPropertyChanged(nameof(Name)); } }
        public string Age { get => _age; set { _age = value; OnPropertyChanged(nameof(Age)); } }
        public string Height { get => _height; set { _height = value; OnPropertyChanged(nameof(Height)); } }
        public string Weight { get => _weight; set { _weight = value; OnPropertyChanged(nameof(Weight)); } }
        public string ClassAnimal { get => _classAnimal; set { _classAnimal = value; OnPropertyChanged(nameof(ClassAnimal)); } }
        public string Command { get => _command; set { _command = value; OnPropertyChanged(nameof(Command)); } }

        #endregion

        public ICommand AddAnimal { get; }

        public AddAnimalViewModel()
        {
            _nurseryRepository = new NurseryRepository();
            AddAnimal = new ViewModelCommand(ExecuteAddAnimalDataBaseCommand, CanExecuteAddAnimalCommand);
        }

        private bool CanExecuteAddAnimalCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Name) ||
                string.IsNullOrWhiteSpace(ClassAnimal) ||
                string.IsNullOrWhiteSpace(Command) ||
                string.IsNullOrWhiteSpace(Age) ||
                string.IsNullOrWhiteSpace(Height) ||
                string.IsNullOrWhiteSpace(Weight))
                return false;

            return true;
        }

        private void ExecuteAddAnimalDataBaseCommand(object obj)
        {
            double age = 0;
            double weight = 0;
            double height = 0;

            if (!double.TryParse(Age, out age))
            {
                MessageBox.Show($"Ошибка!Вы ввели не верный возраст!", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(Height, out height))
            {
                MessageBox.Show($"Ошибка!Вы ввели не верный рост!", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!double.TryParse(Weight, out weight))
            {
                MessageBox.Show($"Ошибка!Вы ввели не верный вес!", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (age <= 0 || age >= 100 || height <= 0 || weight <= 0)
            {
                MessageBox.Show($"Ошибка!Вы ввели отрицательное число или возраст больше 100!",
                    "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_nurseryRepository.Add(new Animal(0, Name, age, height, weight, ClassAnimal, Command)))
                MessageBox.Show($"Успешно", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
