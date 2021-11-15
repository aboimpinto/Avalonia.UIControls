using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Styling;

namespace UIControls
{
    public class Badge : ContentControl, IStyleable
    {
        Type IStyleable.StyleKey => typeof(ContentControl);

        public static readonly StyledProperty<object> BadgeContentProperty =
            AvaloniaProperty.Register<Badge, object>(nameof(BadgeContent));
        public static readonly StyledProperty<IDataTemplate> BadgeContentTemplateProperty =
            AvaloniaProperty.Register<Badge, IDataTemplate>(nameof(BadgeContentTemplate));

        public object BadgeContent
        {
            get => GetValue(BadgeContentProperty);
            set => SetValue(BadgeContentProperty, value);
        }

        public IDataTemplate BadgeContentTemplate
        {
            get => GetValue(BadgeContentTemplateProperty);
            set => SetValue(BadgeContentTemplateProperty, value);
        }

        static Badge()
        {
            ClipToBoundsProperty.OverrideDefaultValue<Badge>(false);
        }
    }
}
