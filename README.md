# add-context-menu-to-treeview-xamarin	

This repository demonstrates how to add a context menu to nodes in the Syncfusion Xamarin.Forms TreeView control. The sample shows how to implement right-click (desktop) and long-press (mobile) menus that provide node-specific actions like edit, delete, and custom commands.

### XAML
```xaml
<local:SfTreeViewExt x:Name="treeView" ChildPropertyName="SubFiles" NodeSizeMode="Dynamic" NotificationSubscriptionMode="CollectionChange" ItemsSource="{Binding ImageNodeInfo}" AutoExpandMode="AllNodesExpanded">
    <local:SfTreeViewExt.ItemTemplate>
        <DataTemplate>
            <local:CustomGrid x:Name="grid" TreeView="{x:Reference treeView}">
                <local:CustomGrid.RowDefinitions>
                    <RowDefinition Height="Auto" />
                    <RowDefinition Height="1" />
                </local:CustomGrid.RowDefinitions>
                <Grid RowSpacing="0" Grid.Row="0">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="40" />
                        <ColumnDefinition Width="*" />
                    </Grid.ColumnDefinitions>
                    <Grid Padding="5,5,5,5">
                        <Image Source="{Binding ImageIcon}" VerticalOptions="Center" HorizontalOptions="Center" HeightRequest="35" WidthRequest="35"/>
                    </Grid>
                    <Grid Grid.Column="1" RowSpacing="1" Padding="1,0,0,0" VerticalOptions="Center">
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto"/>
                        </Grid.RowDefinitions>
                        <Label LineBreakMode="NoWrap" TextColor="Black" Text="{Binding ItemName}" VerticalTextAlignment="Center"/>
                    </Grid>
                </Grid>
                <StackLayout Grid.Row="1" HeightRequest="1"/>
            </local:CustomGrid>
        </DataTemplate>
    </local:SfTreeViewExt.ItemTemplate>
</local:SfTreeViewExt>
```

## Requirements to run the demo
Visual Studio 2017 or Visual Studio for Mac.
Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting
### Path too long exception
If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.