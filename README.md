# how-to-change-empty-view-at-run-time-in-.net-maui-listview

This demo shows about how to change empty view at run time in .NET MAUI ListView.

## Sample

```xaml
<ContentPage.Resources>
        <ResourceDictionary>
            <local:ListViewBoolToSortImageConverter x:Key="BoolToSortIconConverter"/>
            <ContentView x:Key="SingleView">
                <Label Text="No Items" FontSize="18" FontFamily="Roboto-Regular" 
                   TextColor="#666666" HorizontalTextAlignment="Center" VerticalOptions="CenterAndExpand"/>
            </ContentView>
            <ContentView x:Key="MultiView">
                <StackLayout VerticalOptions="CenterAndExpand" >
                    <Label Text="&#xe725;" FontSize="40" TextColor="#666666" Opacity="0.8"
                               FontFamily="{OnPlatform iOS=ListViewFontIcons, MacCatalyst=ListViewFontIcons, Android=ListViewFontIcons.ttf#, UWP=ListViewFontIcons.ttf#ListViewFontIcons}"
                               HorizontalTextAlignment="Center" VerticalTextAlignment="Center" />
                    <Label TextColor="#666666" Text="No Items" FontSize="16" FontFamily="Roboto-Regular" HorizontalTextAlignment="Center" VerticalTextAlignment="Center"  Margin="0,10,0,0"/>
                </StackLayout>
            </ContentView>

        </ResourceDictionary>
    </ContentPage.Resources>

<syncfusion:SfListView x:Name="listView" 
                       Grid.Row="4"
                       SelectionMode="None"                                     
                       ItemsSource="{Binding Items}"                      
                       ItemSize="56" EmptyView="{StaticResource SingleView}">             

<syncfusion:SfListView.ItemTemplate>
    <DataTemplate x:Name="ItemTemplate">
        <Grid Margin="8">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="48"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="50"/>
            </Grid.ColumnDefinitions>
            <Frame HorizontalOptions="Start" IsClippedToBounds="True" CornerRadius="2" HasShadow="False"  Grid.Column="0" HeightRequest="40" WidthRequest="40" Padding="0">
                <Image Grid.Column="0"  Source="{Binding ProductImage}" HeightRequest="40" WidthRequest="40" HorizontalOptions="Start"/>
            </Frame>
            <Label Grid.Column="1" Text="{Binding ProductName}" VerticalOptions="Center" FontSize="{OnPlatform Default=16,UWP=14}" FontFamily="Roboto-Regular" TextColor="#DE000000" CharacterSpacing="0.15"/>
            <Label Grid.Column="2" Text="{Binding Quantity}" VerticalOptions="Center" HorizontalTextAlignment="Center" HorizontalOptions="Center" FontSize="{OnPlatform Default=16,UWP=14}" FontFamily="Roboto-Regular" TextColor="#DE000000" WidthRequest="30"/>
        </Grid>
    </DataTemplate>
</syncfusion:SfListView.ItemTemplate>
</syncfusion:SfListView>
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
