namespace Masa.Docs.Shared.Examples.SlideGroups
{
    public class Usage : Masa.Docs.Shared.Components.Usage
    {
        public Usage() : base(typeof(MSlideGroup)) { }

        protected override RenderFragment GenChildContent() => builder =>
        {
            builder.OpenComponent<Index>(0);
            builder.CloseComponent();
        };
    }
}
