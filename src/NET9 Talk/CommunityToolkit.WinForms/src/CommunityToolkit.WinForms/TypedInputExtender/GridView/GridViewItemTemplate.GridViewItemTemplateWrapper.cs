﻿namespace CommunityToolkit.WinForms.GridView;

public partial class GridViewItemTemplate
{
    public class GridViewItemTemplateWrapper(Type itemTemplate)
    {
        public Type ItemTemplate { get; } = itemTemplate;

        public override string ToString()
            => ItemTemplate.GetType().Name;
    }
}
