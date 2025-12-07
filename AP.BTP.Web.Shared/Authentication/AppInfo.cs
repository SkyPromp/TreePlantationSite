namespace AP.BTP.Web.Shared.Authentication
{
    /// <summary>
    /// Represents basic metadata about the application using the shared components.
    /// This is used to distinguish which application (e.g., Maintenance or User app) is currently running.
    /// </summary>
    public class AppInfo
    {
        /// <summary>
        /// Indicates the type of application.
        /// Expected values might include "Maintenance" or "User".
        /// This value is typically loaded from configuration (appsettings.json).
        /// </summary>
        public string? AppType { get; set; }
    }
}
