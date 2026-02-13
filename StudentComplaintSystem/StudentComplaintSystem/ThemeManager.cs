using System;
using System.Windows;

namespace StudentComplaintSystem
{
    public static class ThemeManager
    {
        private static bool _isDarkMode = false;

        public static bool IsDarkMode
        {
            get => _isDarkMode;
            set
            {
                _isDarkMode = value;
                UpdateTheme();
            }
        }

        public static void UpdateTheme()
        {
            var app = Application.Current;
            if (_isDarkMode)
            {
                app.Resources["PrimaryColor"] = app.Resources["DarkPrimaryColor"];
                app.Resources["SecondaryColor"] = app.Resources["DarkSecondaryColor"];
                app.Resources["SuccessColor"] = app.Resources["DarkSuccessColor"];
                app.Resources["ErrorColor"] = app.Resources["DarkErrorColor"];
                app.Resources["HeadingColor"] = app.Resources["DarkHeadingColor"];
                app.Resources["TextColor"] = app.Resources["DarkTextColor"];
                app.Resources["CardBackground"] = app.Resources["DarkCardBackground"];
                app.Resources["HomePageBackground"] = app.Resources["DarkHomePageBackground"];
                app.Resources["BackgroundGradient"] = app.Resources["DarkBackgroundGradient"];
                app.Resources["BorderColor"] = app.Resources["DarkBorderColor"];
            }
            else
            {
                app.Resources["PrimaryColor"] = app.Resources["LightPrimaryColor"];
                app.Resources["SecondaryColor"] = app.Resources["LightSecondaryColor"];
                app.Resources["SuccessColor"] = app.Resources["LightSuccessColor"];
                app.Resources["ErrorColor"] = app.Resources["LightErrorColor"];
                app.Resources["HeadingColor"] = app.Resources["LightHeadingColor"];
                app.Resources["TextColor"] = app.Resources["LightTextColor"];
                app.Resources["CardBackground"] = app.Resources["LightCardBackground"];
                app.Resources["HomePageBackground"] = app.Resources["LightHomePageBackground"];
                app.Resources["BackgroundGradient"] = app.Resources["LightBackgroundGradient"];
                app.Resources["BorderColor"] = app.Resources["LightBorderColor"];
            }
        }
    }
}