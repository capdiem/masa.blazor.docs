using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Masa.Docs.Shared.Examples.list_item_groups
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        public Usage() : base(typeof(MListItemGroup)) { }

        protected override RenderFragment GenChildContent() => builder =>
        {
            int i = 0;
            foreach (var item in items)
            {
                builder.OpenComponent<MListItem>(i);
                builder.AddAttribute(1, nameof(MListItem.ChildContent), (RenderFragment)(childBuilder =>
                {
                    childBuilder.OpenComponent<MListItemIcon>(0);
                    childBuilder.AddAttribute(1, nameof(MListItemIcon), (RenderFragment)(mliiChildBuilder =>
                    {
                        mliiChildBuilder.OpenComponent<MIcon>(0);
                        mliiChildBuilder.AddAttribute(1, nameof(MIcon.Icon), $"{item.Icon}");
                        mliiChildBuilder.CloseComponent();
                    }));
                    childBuilder.CloseComponent();

                    childBuilder.OpenComponent<MListItemContent>(2);
                    childBuilder.AddAttribute(3, nameof(MListItemContent), (RenderFragment)(mlicChildBuilder =>
                    {
                        mlicChildBuilder.OpenComponent<MListItemTitle>(0);
                        mlicChildBuilder.AddChildContent(1, $"{item.Text}");
                        mlicChildBuilder.CloseComponent();
                    }));
                    childBuilder.CloseComponent();

                }));

                builder.CloseComponent();

                i++;
            }
        };

        static readonly Item[] items =
        {
            new()
            {
                Icon = "mdi-inbox",
                Text = "Inbox"
            },
            new()
            {
                Icon = "mdi-star",
                Text = "Star"
            },
            new()
            {
                Icon = "mdi-send",
                Text = "Send"
            },
            new()
            {
                Icon = "mdi-email-open",
                Text = "Drafts"
            }
        };

        StringNumber selected = 1;

        public class Item
        {
            public string Icon { get; set; }
            public string Text { get; set; }
        }
    }
}
