using System.Windows.Controls;

namespace PrismTableDemo
{
    public class TabControlRegionAdapter : RegionAdapterBase<TabControl>
    {
        public TabControlRegionAdapter(IRegionBehaviorFactory factory) : base(factory)
        {
        }

        protected override void Adapt(IRegion region, TabControl regionTarget)
        {
            region.ActiveViews.CollectionChanged += (s, e) =>
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var view in e.NewItems)
                    {
                        var tabItem = regionTarget.Items
                            .Cast<TabItem>()
                            .FirstOrDefault(i => i.Content == view);

                        if (tabItem != null)
                        {
                            tabItem.Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            tabItem = new TabItem
                            {
                                Content = view,
                                Header = ((UserControl)view).Tag
                            };

                            regionTarget.Items.Add(tabItem);
                        }
                    }
                }

                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
                {
                    foreach (var view in e.OldItems)
                    {
                        var tabItem = regionTarget.Items
                            .Cast<TabItem>()
                            .FirstOrDefault(i => i.Content == view);

                        if (tabItem != null)
                        {
                            tabItem.Visibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new AllActiveRegion();
        }
    }
}