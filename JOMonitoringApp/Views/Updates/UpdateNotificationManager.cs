using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOMonitoringApp.Views.Updates
{
    internal class UpdateNotificationManager
    {

        private const string REGISTRY_KEY = @"Software\YourCompany\YourApp";
        private const string LAST_VERSION_VALUE = "LastShownVersion";
        private const string SHOW_UPDATES_VALUE = "ShowUpdateNotifications";

        public static void CheckAndShowUpdateNotification()
        {
            if (!ApplicationDeployment.IsNetworkDeployed)
                return;

            try
            {
                var deployment = ApplicationDeployment.CurrentDeployment;
                var currentVersion = deployment.CurrentVersion.ToString();

                if (!ShouldShowNotifications())
                    return;

                var lastShownVersion = GetLastShownVersion();
                if (lastShownVersion == currentVersion)
                    return;

                var changelog = GetChangelogForVersion(currentVersion);
                if (string.IsNullOrEmpty(changelog))
                    return;

                // Show update dialog
                using (var dialog = new UpdateNotificationDialog(currentVersion, changelog))
                {
                    dialog.ShowDialog();

                    // Save preferences
                    if (dialog.DontShowAgain)
                    {
                        SetShowNotifications(false);
                    }

                    // Mark this version as shown
                    SetLastShownVersion(currentVersion);
                }
            }
            catch (Exception ex)
            {
                // Log error but don't crash the application
                System.Diagnostics.Debug.WriteLine($"Error showing update notification: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets changelog content for specified version
        /// </summary>
        private static string GetChangelogForVersion(string version)
        {
            // Option 1: Embedded resource
            // return GetChangelogFromResource(version);

            // Option 2: Local file
            return GetChangelogFromFile(version);

            // Option 3: Remote server (recommended for production)
            // return GetChangelogFromServer(version);
        }

       
        private static string GetChangelogFromFile(string version)
        {
            try
            {
                var appPath = Path.GetDirectoryName(Application.ExecutablePath);
                var changelogPath = Path.Combine(appPath, "changelog.txt");

                if (File.Exists(changelogPath))
                {
                    return File.ReadAllText(changelogPath);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error reading changelog: {ex.Message}");
            }

            return string.Empty;
        }

        private static string GetLastShownVersion()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY))
                {
                    return key?.GetValue(LAST_VERSION_VALUE) as string ?? string.Empty;
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        private static void SetLastShownVersion(string version)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY))
                {
                    key?.SetValue(LAST_VERSION_VALUE, version);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving version: {ex.Message}");
            }
        }

        private static bool ShouldShowNotifications()
        {
            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(REGISTRY_KEY))
                {
                    var value = key?.GetValue(SHOW_UPDATES_VALUE);
                    return value == null || (int)value == 1;
                }
            }
            catch
            {
                return true; 
            }
        }

        private static void SetShowNotifications(bool show)
        {
            try
            {
                using (var key = Registry.CurrentUser.CreateSubKey(REGISTRY_KEY))
                {
                    key?.SetValue(SHOW_UPDATES_VALUE, show ? 1 : 0);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving preference: {ex.Message}");
            }
        }

        public static void ResetNotificationPreference()
        {
            SetShowNotifications(true);
        }
    }


}
