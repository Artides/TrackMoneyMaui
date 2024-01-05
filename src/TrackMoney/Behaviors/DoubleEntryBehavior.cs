using System.Globalization;

namespace TrackMoney.Behaviors;

internal class DoubleEntryBehavior : Behavior<Entry>
{
    protected override void OnAttachedTo(Entry bindable)
    {
        base.OnAttachedTo(bindable);
        bindable.TextChanged += TextChanged_Handler;
    }

    protected override void OnDetachingFrom(Entry bindable)
    {
        base.OnDetachingFrom(bindable);
        bindable.TextChanged -= TextChanged_Handler;
    }

    protected virtual void TextChanged_Handler(object? sender, TextChangedEventArgs e)
    {
        if (sender == null || string.IsNullOrEmpty(e.NewTextValue))
            return;

        if (e.NewTextValue == "-")
        {
            //if deleting digits, go back to empty
            //if adding digits keep minus sign as is
            if (e.NewTextValue?.Length < e.OldTextValue?.Length)
            {
                ((Entry)sender).Text = string.Empty;
            }
            return;
        }

        if (e.NewTextValue == "-0" || e.NewTextValue == "-0.")
            return;

        if (!double.TryParse(e.NewTextValue, NumberStyles.Float, CultureInfo.CurrentCulture, out _))
        {
            ((Entry)sender).Text = e.OldTextValue;
        }
    }
}