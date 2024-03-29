﻿using Microsoft.AspNetCore.Components.Web;

namespace Masa.Docs.Shared;

public static class CircuitRootComponentOptionsExtensions
{
    public static void RegisterCustomElementsOfMasaDocs(this IJSComponentConfiguration options)
    {
        options.RegisterCustomElement<Masa.Docs.Shared.Components.Example>("masa-example");
        options.RegisterCustomElement<Masa.Docs.Shared.Components.AppHeading>("app-heading");
        options.RegisterCustomElement<Masa.Docs.Shared.Components.AppLink>("app-link");

        options.RegisterCustomElement<Examples.alerts.Usage>("alerts-usage");
        options.RegisterCustomElement<Examples.avatars.Usage>("avatars-usage");
        options.RegisterCustomElement<Examples.badges.Usage>("badges-usage");
        options.RegisterCustomElement<Examples.banners.Usage>("banners-usage");
        options.RegisterCustomElement<Examples.app_bars.Usage>("app-bars-usage");
        options.RegisterCustomElement<Examples.toolbars.Usage>("toolbars-usage");
        options.RegisterCustomElement<Examples.system_bars.Usage>("system-bars-usage");
        options.RegisterCustomElement<Examples.bottom_navigation.Usage>("bottom-navigation-usage");
        options.RegisterCustomElement<Examples.bottom_sheets.Usage>("bottom-sheets-usage");
        options.RegisterCustomElement<Examples.breadcrumbs.Usage>("breadcrumbs-usage");
        options.RegisterCustomElement<Examples.buttons.Usage>("buttons-usage");
        options.RegisterCustomElement<Examples.cards.Usage>("cards-usage");
        options.RegisterCustomElement<Examples.chips.Usage>("chips-usage");
        options.RegisterCustomElement<Examples.borders.Usage>("borders-usage");
        options.RegisterCustomElement<Examples.dialogs.Usage>("dialogs-usage");
        options.RegisterCustomElement<Examples.dividers.Usage>("dividers-usage");
        options.RegisterCustomElement<Examples.drag_zone.Usage>("drag-zone-usage");
        options.RegisterCustomElement<Examples.echarts.Usage>("echarts-usage");
        options.RegisterCustomElement<Examples.editor.Usage>("editor-usage");
        options.RegisterCustomElement<Examples.error_handler.Usage>("error-handler-usage");
        options.RegisterCustomElement<Examples.expansion_panels.Usage>("expansion-panels-usage");
        options.RegisterCustomElement<Examples.floating_action_buttons.Usage>("floating-action-buttons-usage");
        options.RegisterCustomElement<Examples.footers.Usage>("footers-usage");
        options.RegisterCustomElement<Examples.autocomplete.Usage>("autocomplete-usage");
        options.RegisterCustomElement<Examples.cascaders.Usage>("cascaders-usage");
        options.RegisterCustomElement<Examples.checkboxes.Usage>("checkboxes-usage");
        options.RegisterCustomElement<Examples.file_inputs.Usage>("file-inputs-usage");
        options.RegisterCustomElement<Examples.forms.Usage>("forms-usage");
        options.RegisterCustomElement<Examples.otp_input.Usage>("otp-input-usage");
        options.RegisterCustomElement<Examples.radio.Usage>("radio-usage");
        options.RegisterCustomElement<Examples.range_sliders.Usage>("range-sliders-usage");
        options.RegisterCustomElement<Examples.selects.Usage>("selects-usage");
        options.RegisterCustomElement<Examples.sliders.Usage>("sliders-usage");
        options.RegisterCustomElement<Examples.switches.Usage>("switches-usage");
        options.RegisterCustomElement<Examples.textareas.Usage>("textareas-usage");
        options.RegisterCustomElement<Examples.text_fields.Usage>("text-fields-usage");
        options.RegisterCustomElement<Examples.button_groups.Usage>("button-groups-usage");
        options.RegisterCustomElement<Examples.chip_groups.Usage>("chip-groups-usage");
        options.RegisterCustomElement<Examples.item_groups.Usage>("item-groups-usage");
        options.RegisterCustomElement<Examples.list_item_groups.Usage>("list-item-groups-usage");
        options.RegisterCustomElement<Examples.slide_groups.Usage>("slide-groups-usage");
        options.RegisterCustomElement<Examples.hover.Usage>("hover-usage");
        options.RegisterCustomElement<Examples.icons.Usage>("icons-usage");
        options.RegisterCustomElement<Examples.image_captcha.Usage>("image-captcha-usage");
        options.RegisterCustomElement<Examples.images.Usage>("images-usage");
        options.RegisterCustomElement<Examples.infinite_scroll.Usage>("infinite-scroll-usage");
        options.RegisterCustomElement<Examples.lists.Usage>("lists-usage");
        options.RegisterCustomElement<Examples.markdown.usages.Usage>("markdown-usage");
        options.RegisterCustomElement<Examples.menus.Usage>("menus-usage");
        options.RegisterCustomElement<Examples.modals.Usage>("modals-usage");
        options.RegisterCustomElement<Examples.navigation_drawers.Usage>("navigation-drawers-usage");
        options.RegisterCustomElement<Examples.overlays.Usages.Usage>("overlays-usage");
        options.RegisterCustomElement<Examples.pagination.Usage>("pagination-usage");
        options.RegisterCustomElement<Examples.date_pickers.Usage>("date-pickers-usage");
        options.RegisterCustomElement<Examples.date_pickers_month.Usage>("date-pickers-month-usage");
        options.RegisterCustomElement<Examples.time_pickers.Usage>("time-pickers-usage");
        options.RegisterCustomElement<Examples.progress_circular.Usage>("progress-circular-usage");
        options.RegisterCustomElement<Examples.progress_linear.Usage>("progress-linear-usage");
        options.RegisterCustomElement<Examples.ratings.Usage>("ratings-usage");
        options.RegisterCustomElement<Examples.sheets.Usage>("sheets-usage");
        options.RegisterCustomElement<Examples.skeleton_loaders.Usages.Usage>("skeleton-loaders-usage");
        options.RegisterCustomElement<Examples.snackbars.Usages.Usage>("snackbars-usage");
        options.RegisterCustomElement<Examples.steppers.Usage>("steppers-usage");
        options.RegisterCustomElement<Examples.subheaders.Usage>("subheaders-usage");
        options.RegisterCustomElement<Examples.data_iterators.Usage>("data-iterators-usage");
        options.RegisterCustomElement<Examples.data_tables.Usage>("data-tables-usage");
        options.RegisterCustomElement<Examples.simple_tables.Usage>("simple-tables-usage");
        options.RegisterCustomElement<Examples.tabs.Usage>("tabs-usage");
        options.RegisterCustomElement<Examples.timelines.Usage>("timelines-usage");
        options.RegisterCustomElement<Examples.toast.Usages.Usage>("toast-usage");
        options.RegisterCustomElement<Examples.tooltips.Usage>("tooltips-usage");
        options.RegisterCustomElement<Examples.treeview.Usage>("treeview-usage");
        options.RegisterCustomElement<Examples.virtual_scroll.Usages.Usage>("virtual-scroll-usage");
        options.RegisterCustomElement<Examples.aspect_ratios.Usage>("aspect-ratios-usage");
        options.RegisterCustomElement<Examples.block_text.Usage>("block-text-usage");
        options.RegisterCustomElement<Examples.drawers.Usage>("drawers-usage");
        options.RegisterCustomElement<Examples.carousels.Usage>("carousels-usage");
    }
}
