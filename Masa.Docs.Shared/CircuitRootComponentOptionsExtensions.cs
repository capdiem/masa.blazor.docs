using Microsoft.AspNetCore.Components.Web;
using System;

namespace Masa.Docs.Shared;

public static class CircuitRootComponentOptionsExtensions
{
    public static void RegisterCustomElementsOfMasaDocs(this IJSComponentConfiguration options)
    {
        options.RegisterCustomElement<Masa.Docs.Shared.Components.Example>("masa-example");
        options.RegisterCustomElement<Masa.Docs.Shared.Components.AppHeading>("app-heading");
        options.RegisterCustomElement<Masa.Docs.Shared.Components.AppLink>("app-link");

        options.RegisterCustomElement<Examples.Alerts.Border>("alerts-prop-border");
        options.RegisterCustomElement<Examples.Alerts.Usage>("alerts-usage");
        options.RegisterCustomElement<Examples.Avatars.Usage>("avatars-usage");
        options.RegisterCustomElement<Examples.Badges.Usage>("badges-usage");
        options.RegisterCustomElement<Examples.Banners.Usage>("banners-usage");
        options.RegisterCustomElement<Examples.AppBars.Usage>("app-bars-usage");
        options.RegisterCustomElement<Examples.Toolbars.Usage>("toolbars-usage");
        options.RegisterCustomElement<Examples.SystemBars.Usage>("system-bars-usage");
        options.RegisterCustomElement<Examples.BottomNavigation.Usage>("bottom-navigation-usage");
        options.RegisterCustomElement<Examples.BottomSheets.Usage>("bottom-sheets-usage");
        options.RegisterCustomElement<Examples.Breadcrumbs.Usage>("breadcrumbs-usage");
        options.RegisterCustomElement<Examples.Buttons.Usage>("buttons-usage");
        options.RegisterCustomElement<Examples.Cards.Usage>("cards-usage");
        options.RegisterCustomElement<Examples.Chips.Usage>("chips-usage");
        options.RegisterCustomElement<Examples.Borders.Usage>("borders-usage");
        options.RegisterCustomElement<Examples.Dialogs.Usage>("dialogs-usage");
        options.RegisterCustomElement<Examples.Dividers.Usage>("dividers-usage");
        options.RegisterCustomElement<Examples.DragZone.Usage>("drag-zone-usage");
        options.RegisterCustomElement<Examples.Echarts.Usage>("echarts-usage");
        options.RegisterCustomElement<Examples.Editor.Usage>("editor-usage");
        options.RegisterCustomElement<Examples.ErrorHandler.Usage>("error-handler-usage");
        options.RegisterCustomElement<Examples.ExpansionPanels.Usage>("expansion-panels-usage");
        options.RegisterCustomElement<Examples.FloatingActionButtons.Usage>("floating-action-buttons-usage");
        options.RegisterCustomElement<Examples.Footers.Usage>("footers-usage");
        options.RegisterCustomElement<Examples.Autocomplete.Usage>("autocomplete-usage");
        options.RegisterCustomElement<Examples.Cascaders.Usage>("cascaders-usage");
        options.RegisterCustomElement<Examples.Checkboxes.Usage>("checkboxes-usage");
        options.RegisterCustomElement<Examples.FileInputs.Usage>("file-inputs-usage");
        options.RegisterCustomElement<Examples.Forms.Usage>("forms-usage");
        options.RegisterCustomElement<Examples.OtpInput.Usage>("otp-input-usage");
        options.RegisterCustomElement<Examples.Radio.Usage>("radio-usage");
        options.RegisterCustomElement<Examples.RangeSliders.Usage>("range-sliders-usage");
        options.RegisterCustomElement<Examples.Selects.Usage>("selects-usage");
        options.RegisterCustomElement<Examples.Sliders.Usage>("sliders-usage");
        options.RegisterCustomElement<Examples.Switches.Usage>("switches-usage");
        options.RegisterCustomElement<Examples.Textareas.Usage>("textareas-usage");
        options.RegisterCustomElement<Examples.TextFields.Usage>("text-fields-usage");
        options.RegisterCustomElement<Examples.ButtonGroups.Usage>("button-groups-usage");
        options.RegisterCustomElement<Examples.ChipGroups.Usage>("chip-groups-usage");
        options.RegisterCustomElement<Examples.ItemGroups.Usage>("item-groups-usage");
        options.RegisterCustomElement<Examples.ListItemGroups.Usage>("list-item-groups-usage");
        options.RegisterCustomElement<Examples.SlideGroups.Usage>("slide-groups-usage");
        options.RegisterCustomElement<Examples.Hover.Usage>("hover-usage");
        options.RegisterCustomElement<Examples.Icons.Usage>("icons-usage");
        options.RegisterCustomElement<Examples.ImageCaptcha.Usage>("image-captcha-usage");
        options.RegisterCustomElement<Examples.Images.Usage>("images-usage");
        options.RegisterCustomElement<Examples.InfiniteScroll.Usage>("infinite-scroll-usage");
        options.RegisterCustomElement<Examples.Lists.Usage>("lists-usage");
        options.RegisterCustomElement<Examples.Markdown.usages.Usage>("markdown-usage");
        options.RegisterCustomElement<Examples.Menus.Usage>("menus-usage");
        options.RegisterCustomElement<Examples.Modals.Usage>("modals-usage");
        options.RegisterCustomElement<Examples.NavigationDrawers.Usage>("navigation-drawers-usage");
        options.RegisterCustomElement<Examples.Overlays.Usages.Usage>("overlays-usage");
        options.RegisterCustomElement<Examples.Pagination.Usage>("pagination-usage");
        options.RegisterCustomElement<Examples.DatePickers.Usage>("date-pickers-usage");
        options.RegisterCustomElement<Examples.DatePickersMonth.Usage>("date-pickers-month-usage");
        options.RegisterCustomElement<Examples.TimePickers.Usage>("time-pickers-usage");
        options.RegisterCustomElement<Examples.ProgressCircular.Usage>("progress-circular-usage");
        options.RegisterCustomElement<Examples.ProgressLinear.Usage>("progress-linear-usage");
        options.RegisterCustomElement<Examples.Ratings.Usage>("ratings-usage");
        options.RegisterCustomElement<Examples.Sheets.Usage>("sheets-usage");
        options.RegisterCustomElement<Examples.SkeletonLoaders.Usages.Usage>("skeleton-loaders-usage");
        options.RegisterCustomElement<Examples.Snackbars.Usages.Usage>("snackbars-usage");
        options.RegisterCustomElement<Examples.Steppers.Usage>("steppers-usage");
        options.RegisterCustomElement<Examples.Subheaders.Usage>("subheaders-usage");
        options.RegisterCustomElement<Examples.DataIterators.Usage>("data-iterators-usage");
        options.RegisterCustomElement<Examples.DataTables.Usage>("data-tables-usage");
        options.RegisterCustomElement<Examples.SimpleTables.Usage>("simple-tables-usage");
        options.RegisterCustomElement<Examples.Tabs.Usage>("tabs-usage");
    }
}
