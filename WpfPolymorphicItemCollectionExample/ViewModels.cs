using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace WpfPolymorphicItemCollectionExample;

internal abstract class ItemViewModel
{
    public int Id { get; init; }
}

internal sealed class ConcreteItem1ViewModel : ItemViewModel
{
    public string SomeProp1 => $"Concrete Item 1 with Id = {Id}";
}

internal sealed class ConcreteItem2ViewModel : ItemViewModel
{
    public string SomeProp2 => $"Concrete Item 2 with Id = {Id}";
}

internal sealed class MainWindowViewModel
{
    public ObservableCollection<ItemViewModel> Items { get; } = new();

    public MainWindowViewModel()
    {
        _ = FillUpItems();
    }

    private async Task FillUpItems()
    {
        var id = 1;

        while (id < 10)
        {
            Items.Add(
                Random.Shared.Next() % 2 == 0
                    ? new ConcreteItem1ViewModel { Id = id++ }
                    : new ConcreteItem2ViewModel { Id = id++ });

            await Task.Delay(1000);
        }
    }
}
