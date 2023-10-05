**Итоговая контрольная работа по блоку специализация**

Cписок задач:

Организуйте систему учёта для питомника, в котором живут домашние и вьючные животные.

***Выбранная технология:** .NET, WPF*

**Выполнение**

Для реализации проекта выранна многослойная архитектура включающая в себя:


    Infrastructure/Base [InstanceChecker, InternetCheck](https://github.com/STGorbunovDA/AnimalNursery/tree/dev/AnimalNursery/Infrastructure/Base) 

    Models/Base [Animal](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/AnimalNursery/Models/Base/Animal.cs) имплементируя [IExecuteCommand](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/AnimalNursery/Models/Base/Interfaces/IExecuteCommand.cs)

    Repositories [ConnectionDB, INurseryRepository, NurseryRepository](https://github.com/STGorbunovDA/AnimalNursery/tree/dev/AnimalNursery/Repositories).

    Styles [RegionStyles, UIColors](https://github.com/STGorbunovDA/AnimalNursery/tree/dev/AnimalNursery/Styles)

    ViewModels [ViewModelBase, ViewModelCommand, AddAnimalViewModel, NurseryViewModel](https://github.com/STGorbunovDA/AnimalNursery/tree/dev/AnimalNursery/ViewModels)

    Views [AddAnimalView, NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/tree/dev/AnimalNursery/Views)

    Интерфейс приложения:

![picture for NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/1.png)

![picture for AddAnimalView](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/2.png)

    7. БД:

![picture for NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/3.png)
![picture for NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/4.png)
![picture for NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/5.png)
![picture for NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/6.png)
![picture for NurseryViews](https://github.com/STGorbunovDA/AnimalNursery/blob/dev/Images/7.png)


