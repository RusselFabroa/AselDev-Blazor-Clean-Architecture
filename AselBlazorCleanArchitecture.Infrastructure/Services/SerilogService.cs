using AselBlazorCleanArchitecture.Application.Interfaces;
using Microsoft.Extensions.Logging;
using Serilog.Context; // Add this missing using statement
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AselBlazorCleanArchitecture.Infrastructure.Services
{
    public class SerilogService : ILoggingService // Fixed: Changed from IloggingService to ILoggingService (capital L)
    {
        private readonly ILogger<SerilogService> _logger;

        public SerilogService(ILogger<SerilogService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region Basic Logging Methods

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogInformation(string message, params object[] args)
        {
            _logger.LogInformation(message, args);
        }

        public void LogWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LogWarning(string message, params object[] args)
        {
            _logger.LogWarning(message, args);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogError(Exception exception, string message)
        {
            _logger.LogError(exception, message);
        }

        public void LogError(Exception exception, string message, params object[] args)
        {
            _logger.LogError(exception, message, args);
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        public void LogDebug(string message, params object[] args)
        {
            _logger.LogDebug(message, args);
        }

        public void LogCritical(string message)
        {
            _logger.LogCritical(message);
        }

        public void LogCritical(Exception exception, string message)
        {
            _logger.LogCritical(exception, message);
        }

        #endregion

        #region Structured Logging Methods

        public void LogUserAction(string userId, string action, object? additionalData = null)
        {
            using (LogContext.PushProperty("UserId", userId))
            using (LogContext.PushProperty("ActionType", "UserAction"))
            {
                _logger.LogInformation("User {UserId} performed action: {Action} with data: {@AdditionalData}",
                    userId, action, additionalData);
            }
        }

        public void LogBusinessOperation(string operation, string entityType, string entityId, object? metadata = null)
        {
            using (LogContext.PushProperty("OperationType", "BusinessOperation"))
            using (LogContext.PushProperty("EntityType", entityType))
            using (LogContext.PushProperty("EntityId", entityId))
            {
                _logger.LogInformation("Business operation {Operation} on {EntityType}:{EntityId} with metadata: {@Metadata}",
                    operation, entityType, entityId, metadata);
            }
        }

        public void LogPerformance(string operation, TimeSpan duration, object? additionalData = null)
        {
            using (LogContext.PushProperty("PerformanceMetric", true))
            using (LogContext.PushProperty("Duration", duration.TotalMilliseconds))
            {
                if (duration.TotalMilliseconds > 1000) // Log as warning if over 1 second
                {
                    _logger.LogWarning("Performance: {Operation} took {Duration}ms - {@AdditionalData}",
                        operation, duration.TotalMilliseconds, additionalData);
                }
                else
                {
                    _logger.LogInformation("Performance: {Operation} took {Duration}ms - {@AdditionalData}",
                        operation, duration.TotalMilliseconds, additionalData);
                }
            }
        }

        public void LogSecurityEvent(string eventType, string userId, string details, object? metadata = null)
        {
            using (LogContext.PushProperty("SecurityEvent", true))
            using (LogContext.PushProperty("UserId", userId))
            using (LogContext.PushProperty("EventType", eventType))
            {
                _logger.LogWarning("Security Event: {EventType} for user {UserId} - {Details} - {@Metadata}",
                    eventType, userId, details, metadata);
            }
        }

        public void LogSystemEvent(string eventType, string component, object? data = null)
        {
            using (LogContext.PushProperty("SystemEvent", true))
            using (LogContext.PushProperty("Component", component))
            {
                _logger.LogInformation("System Event: {EventType} in {Component} - {@Data}",
                    eventType, component, data);
            }
        }

        #endregion

        #region Scoped Logging

        public IDisposable BeginScope(string scopeName)
        {
            return _logger.BeginScope(scopeName);
        }

        public IDisposable BeginScope(Dictionary<string, object> properties)
        {
            return _logger.BeginScope(properties);
        }

        #endregion
    }
}