using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;

namespace MauiCalculatorApp.Controls;

public partial class GenderControl : ContentView
{
    public static readonly BindableProperty IconImageSourceProperty = BindableProperty.Create(nameof(IconImageSource),
        typeof(string), typeof(GenderControl), string.Empty);

    public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string),
        typeof(GenderControl), string.Empty);

    public static readonly BindableProperty ColorProperty = BindableProperty.Create(nameof(Color), typeof(string),
        typeof(GenderControl), string.Empty, propertyChanged: OnColorChange);

    public GenderControl()
    {
        InitializeComponent();
    }

    public string IconImageSource
    {
        get => (string)GetValue(IconImageSourceProperty);
        set => SetValue(IconImageSourceProperty, value);
    }

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public string Color 
    { 
        get => (string)GetValue(ColorProperty); 
        set => SetValue(ColorProperty, value); 
    }

    private Color _tinColor = Colors.White;

    public Color TinColor
    {
        get => _tinColor;

        set
        {
            if (_tinColor != value)
            {
                _tinColor = value;
                OnPropertyChanged(nameof(TinColor));
            }
        }
    }


    private static void OnColorChange(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is GenderControl genderControl)
        {
            if (oldValue != newValue && newValue is not null)
            {
                genderControl.TinColor = Microsoft.Maui.Graphics.Color.FromArgb(newValue.ToString());
            }
        }
    }

}