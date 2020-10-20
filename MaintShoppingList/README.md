# MaintShoppingList

The application uses an example 'Master-slave' pattern. 
It uses the framework, but it makes it difficult.

## MainWindow.xaml

The Window resources refers to the `Data class`.
The Key refers to the `DataGrid element`.

The class `ShoppingLists` is created in the background and therefor not easy access the object.

``` C#
<Window.Resources>
  <local:Data x:Key="ShoppingListsDataGrid"/>
</Window.Resources>
```

The reference to `ItemSource` is directly set in the `xaml` source.

``` C#
ItemsSource="{Binding ElementName=ShoppingListDetailsDataGrid, 
                Path=SelectedItem.Articles}"
```

## MainWindow.xaml.cs

It uses a placeholder for the methods `SaveJson`.

## MainViewModel

