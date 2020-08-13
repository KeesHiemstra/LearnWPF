# TimeClock

The origin idea to display the current time on the main window and bind the time properly to `MainWindow`.

The class `VisualTime` shows the `CurrentTime` and the derived `DisplayDate` and `DisplayTime`.
The `NotifyProperyChanged` learned that all the derived properties updated to set the `ProperName` an empty name.

After some time was `StringFormat` in WPF better the derived properties.

## Location of the time part in a `StatusBar`

The time should on right side visible.

There are two solutions:

**Solution 1**

Using the `TextBlock`:
``` C#
    <StatusBar Grid.Row="1">
      <StatusBarItem>
        <TextBlock Text="{Binding Now.CurrentTime, StringFormat=yyyy-MM-dd}"
                   ToolTip="ISO date"/>
      </StatusBarItem>
      
      <StatusBarItem HorizontalAlignment="Right">
          <TextBlock Text="{Binding Now.CurrentTime, StringFormat=HH:mm}"/>
      </StatusBarItem>
```

**Solution 2**

Using the `Content` causes that the `StringFormat` not working, so using the `DisplayDate` and `DisplayTime`:

``` C#
    <StatusBar Grid.Row="1">
      <StatusBarItem Content="{Binding Now.DisplayDate}"
                     ToolTip="ISO date"/>

      <StatusBarItem Content="{Binding Now.DisplayTime}" 
                     HorizontalAlignment="Right"/>
    </StatusBar>
```

### Keywords
- `StatusBar`
- Binding with `StringFormat`.
- `INotifyProperyChanged`.
- `Timer()' class.


