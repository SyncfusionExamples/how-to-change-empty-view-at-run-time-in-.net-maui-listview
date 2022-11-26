using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataSource;


namespace EmptyViewDemo
{
    #region SortingFilteringBehavior

    public class SfListViewSortingFilteringBehavior : Behavior<ContentPage>
    {
        #region Fields

        private Syncfusion.Maui.ListView.SfListView ListView;
        private SortingFilteringViewModel sortingFilteringViewModel;
        private Grid sortImageParent;
        private SearchBar searchBar = null;
        private Grid headerGrid;
        private CheckBox checkBox;
        private object singleView;
        private object multiView;

        #endregion

        private void InitialSorting()
        {
            sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Ascending;
            ListView.DataSource.SortDescriptors.Clear();
            if (sortingFilteringViewModel.SortingOptions != ListViewSortOptions.None)
            {
                ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
                {
                    PropertyName = "Quantity",
                    Direction = sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending
                });
            }
            ListView.RefreshView();
        }
        #region Overrides
        protected override void OnAttachedTo(ContentPage bindable)
        {            
            ListView = bindable.FindByName<Syncfusion.Maui.ListView.SfListView>("listView");
            sortingFilteringViewModel = bindable.FindByName<SortingFilteringViewModel>("viewModel");
            ListView.ItemsSource = sortingFilteringViewModel.Items;

            headerGrid = bindable.FindByName<Grid>("headerGrid");
            headerGrid.BindingContext = sortingFilteringViewModel;

            sortImageParent = bindable.FindByName<Grid>("sortImageParent");
            var SortImageTapped = new TapGestureRecognizer() { Command = new Command(SortImageTapped_Tapped) };
            sortImageParent.GestureRecognizers.Add(SortImageTapped);

            searchBar = bindable.FindByName<SearchBar>("filterText");
            searchBar.TextChanged += SearchBar_TextChanged;

            singleView = bindable.Resources["SingleView"];
            multiView = bindable.Resources["MultiView"];

            checkBox = bindable.FindByName<CheckBox>("checkBox");
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            InitialSorting();
            base.OnAttachedTo(bindable);
        }
      

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            ListView = null;
            sortImageParent = null;
            searchBar = null;
            checkBox = null;
            singleView = null;
            multiView = null;
            searchBar.TextChanged -= SearchBar_TextChanged;
            checkBox.CheckedChanged -= CheckBox_CheckedChanged;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Events
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchBar = (sender as SearchBar);
            if (ListView.DataSource != null)
            {
                ListView.DataSource.Filter = FilterItems;
                ListView.DataSource.RefreshFilter();
            }
            ListView.RefreshView();

            if(ListView.DataSource.DisplayItems.Count == 0)
            {
                sortingFilteringViewModel.IsVisible = true;
            }
            else
            {
                sortingFilteringViewModel.IsVisible = false;
            }

        }

        private void SortImageTapped_Tapped()
        {
            if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Descending)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Ascending;
            else if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.None)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Ascending;
            else if (sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending)
                sortingFilteringViewModel.SortingOptions = ListViewSortOptions.Descending;

            ListView.DataSource.SortDescriptors.Clear();
            if (sortingFilteringViewModel.SortingOptions != ListViewSortOptions.None)
            {
                ListView.DataSource.SortDescriptors.Add(new SortDescriptor()
                {
                    PropertyName = "Quantity",
                    Direction = sortingFilteringViewModel.SortingOptions == ListViewSortOptions.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending
                });
            }
            ListView.RefreshView();
        }

        #endregion

        #region Methods
        private bool FilterItems(object obj)
        {
            if (searchBar == null || searchBar.Text == null)
                return true;
            
            var productInfo = obj as ProductInfo;        
            return (productInfo.ProductName.ToLower().Contains(searchBar.Text.ToLower()) || (productInfo.Quantity.ToString()).ToLower().Contains(searchBar.Text.ToLower()));
        }       

        private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if(e.Value)
            {
                ListView.EmptyView = multiView;
                sortingFilteringViewModel.Text = "Displays MultiView EmptyView";
            }
            else
            {
                ListView.EmptyView = singleView;
                sortingFilteringViewModel.Text = "Displays SingleView EmptyView";
            }
        }
        #endregion
    }

    #endregion
}
