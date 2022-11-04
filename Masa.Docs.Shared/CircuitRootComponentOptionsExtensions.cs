﻿using Microsoft.AspNetCore.Components.Web;
using System;

namespace Masa.Docs.Shared;

public static class CircuitRootComponentOptionsExtensions
{
    public static void RegisterCustomElementsOfMasaDocs(this IJSComponentConfiguration options)
    {
        options.RegisterCustomElement<Masa.Docs.Shared.Components.Example>("masa-example");

        options.RegisterCustomElement<Examples.alerts.Border>("alerts-prop-border");
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
        options.RegisterCustomElement<Examples.floating_action_button.Usage>("floating-action-button-usage");
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
    }
}
