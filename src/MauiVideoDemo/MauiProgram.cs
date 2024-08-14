using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace MauiVideoDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                // Initialize the .NET MAUI Community Toolkit MediaElement by adding the below line of code
                .UseMauiCommunityToolkitMediaElement()
                // After initializing the .NET MAUI Community Toolkit, optionally add additional fonts, and other things
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Continue initializing your .NET MAUI App here
            return builder.Build();
        }
    }
}
