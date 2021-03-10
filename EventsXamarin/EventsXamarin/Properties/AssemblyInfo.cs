using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("Roboto-Bold.ttf", Alias = "BoldFont")]
[assembly: ExportFont("Roboto-Medium.ttf", Alias = "MediumFont")]
[assembly: ExportFont("Roboto-Regular.ttf", Alias = "RegularFont")]

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: Xamarin.Forms.Internals.Preserve(AllMembers = true)]
