using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Border1
{
  /// <summary>
  /// Act on clicking in a border.
  /// It uses predefined and programmable borders.
  /// </summary>
  public partial class MainWindow : Window
  {
    readonly Random Rand;
    public MainWindow()
    {
      Rand = new Random();

      InitializeComponent();
      for (int i = 0; i < 9; i++)
      {
        MainStackPanel.Children.Add(CreateBorder());
      }
    }

    /// <summary>
    /// Create a border.
    /// </summary>
    /// <returns></returns>
    private Border CreateBorder()
    {
      TextBlock textBlock = new TextBlock()
      {
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Center,
        FontSize = 30,
        Text = $"{(char)(Rand.Next(26) + 65)}"
      };

      //Border is a container.
      Border border = new Border()
      {
        Background = Brushes.Transparent,
        BorderBrush = Brushes.Black,
        BorderThickness = new Thickness(1),
        CornerRadius = new CornerRadius(9),
        Height = 50,
        Width = 50,
        Margin = new Thickness(20, 0, 0, 0),
        Child = textBlock,
      };

      //Add the acting on the border.
      border.MouseLeftButtonUp += (sender, e) => { Border_MouseLeftButtonUp(sender, e); };

      return border;
    }

    //Predefined function.
    //Border1 is the name of the border.
    private void Border1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      ActOnBorder((TextBlock)((Border)sender).Child);
    }

    //Programmable function.
    private void Border_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
      ActOnBorder((TextBlock)((Border)sender).Child);
    }

    private void ActOnBorder(TextBlock textBlock)
    {
      textBlock.Foreground = Brushes.Gray;
    }
  }
}
