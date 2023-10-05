using AnimalNursery.Models.Base;
using AnimalNursery.Repositories;
using AnimalNursery.Repositories.Interfaces;
using AnimalNursery.ViewModels.Base;
using AnimalNursery.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AnimalNursery.ViewModels
{
    public class NurseryViewModel : ViewModelBase
    {
        /// <summary> для сохранения индекса выделенной строки </summary>
        int TEMPORARY_INDEX_DATAGRID = 0;

        INurseryRepository _nurseryRepository;
        public ObservableCollection<Animal> NurseryCollection { get; set; }

        Animal _selectedAnimal;
        public Animal SelectedAnimal
        {
            get => _selectedAnimal;
            set
            {
                if (value == null)
                    return;
                _selectedAnimal = value;
                OnPropertyChanged(nameof(SelectedAnimal));
            }
        }

        int _selectedIndexAnimalDataGrid;
        public int SelectedIndexAnimalDataGrid
        {
            get => _selectedIndexAnimalDataGrid;
            set
            {
                _selectedIndexAnimalDataGrid = value;
                OnPropertyChanged(nameof(SelectedIndexAnimalDataGrid));
            }
        }

        public ICommand UpdateAnimal { get; }
        public ICommand ChangeAnimal { get; }
        public ICommand DeleteAnimal { get; }
        public ICommand AddAnimal { get; }
        public NurseryViewModel()
        {
            _nurseryRepository = new NurseryRepository();
            NurseryCollection = new ObservableCollection<Animal>();
            UpdateAnimal = new ViewModelCommand(ExecuteUpdateAnimalDataBaseCommand);
            ChangeAnimal = new ViewModelCommand(ExecuteChangeAnimalDataBaseCommand);
            DeleteAnimal = new ViewModelCommand(ExecuteDeleteAnimalDataBaseCommand);
            AddAnimal = new ViewModelCommand(ExecuteAddAnimalDataBaseCommand);
            GetAllAnimals();
        }

        private void ExecuteAddAnimalDataBaseCommand(object obj)
        {
            var addAnimalView = new AddAnimalView();
            addAnimalView.Closed += (sender, args) => addAnimalView = null;
            addAnimalView.Closed += (sender, args) => ExecuteUpdateAnimalDataBaseCommand(obj);
            addAnimalView.ShowDialog();
        }

        private void ExecuteDeleteAnimalDataBaseCommand(object obj)
        {
            if (_nurseryRepository.Delete(SelectedAnimal))
                MessageBox.Show($"Успешно", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);

            ExecuteUpdateAnimalDataBaseCommand(obj);
        }
        private void ExecuteChangeAnimalDataBaseCommand(object obj)
        {
            if (!Validation(SelectedAnimal))
            {
                MessageBox.Show($"Ошибка. Введите корректные параметры.", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_nurseryRepository.Update(SelectedAnimal))
                MessageBox.Show($"Успешно", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
            else MessageBox.Show($"Ошибка", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void ExecuteUpdateAnimalDataBaseCommand(object obj)
        {
            if (NurseryCollection.Count != 0)
            {
                TEMPORARY_INDEX_DATAGRID = SelectedIndexAnimalDataGrid;
                NurseryCollection.Clear();
                GetAllAnimals();
                SelectedIndexAnimalDataGrid = TEMPORARY_INDEX_DATAGRID;
            }
        }


        private bool Validation(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Name) ||
                string.IsNullOrWhiteSpace(animal.ClassAnimal) ||
                string.IsNullOrWhiteSpace(animal.Command))
                return false;

            if (animal.Age <= 0 || animal.Age >= 100 || animal.Height <= 0 || animal.Weight <= 0)
                return false;
          
            return true;

        }
        private void GetAllAnimals()
        {
            NurseryCollection = _nurseryRepository.GetAll(NurseryCollection);
        }
    }
}
