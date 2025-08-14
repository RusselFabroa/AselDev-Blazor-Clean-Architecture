using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselBlazorCleanArchitecture.Application.Interfaces
{
    /// <summary>
    /// Enhanced logging service interface for structured logging
    /// </summary>
    public interface ILoggingService
    {
        // Basic logging methods
        void LogInformation(string message);
        void LogInformation(string message, params object[] args);
        void LogWarning(string message);
        void LogWarning(string message, params object[] args);
        void LogError(string message);
        void LogError(Exception exception, string message);
        void LogError(Exception exception, string message, params object[] args);
        void LogDebug(string message);
        void LogDebug(string message, params object[] args);
        void LogCritical(string message);
        void LogCritical(Exception exception, string message);

        // Structured logging methods
        void LogUserAction(string userId, string action, object? additionalData = null);
        void LogBusinessOperation(string operation, string entityType, string entityId, object? metadata = null);
        void LogPerformance(string operation, TimeSpan duration, object? additionalData = null);
        void LogSecurityEvent(string eventType, string userId, string details, object? metadata = null);
        void LogSystemEvent(string eventType, string component, object? data = null);

        // Scoped logging
        IDisposable BeginScope(string scopeName);
        IDisposable BeginScope(Dictionary<string, object> properties);
    }
}
