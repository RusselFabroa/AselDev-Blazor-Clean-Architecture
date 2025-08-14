using Microsoft.Extensions.Logging;
using AselBlazorCleanArchitecture.Application.Interfaces;
using Serilog.Context;

namespace AselBlazorCleanArchitecture.Infrastructure.Services;

/// <summary>
/// Application-specific logging service implementation
/// </summary>
public class ApplicationLoggingService : IApplicationLogger
{
    private readonly ILogger<ApplicationLoggingService> _logger;

    public ApplicationLoggingService(ILogger<ApplicationLoggingService> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void LogBusinessRuleViolation(string rule, string context, object? data = null)
    {
        using (LogContext.PushProperty("EventType", "BusinessRuleViolation"))
        using (LogContext.PushProperty("Rule", rule))
        {
            _logger.LogWarning("Business rule violation: {Rule} in context: {Context} with data: {@Data}",
                rule, context, data);
        }
    }

    public void LogValidationFailure(string validator, string errors, object? input = null)
    {
        using (LogContext.PushProperty("EventType", "ValidationFailure"))
        using (LogContext.PushProperty("Validator", validator))
        {
            _logger.LogWarning("Validation failed in {Validator}: {Errors} for input: {@Input}",
                validator, errors, input);
        }
    }

    public void LogServiceCall(string service, string method, object? parameters = null)
    {
        using (LogContext.PushProperty("EventType", "ServiceCall"))
        using (LogContext.PushProperty("Service", service))
        using (LogContext.PushProperty("Method", method))
        {
            _logger.LogDebug("Calling service {Service}.{Method} with parameters: {@Parameters}",
                service, method, parameters);
        }
    }

    public void LogServiceResponse(string service, string method, bool success, object? response = null)
    {
        using (LogContext.PushProperty("EventType", "ServiceResponse"))
        using (LogContext.PushProperty("Service", service))
        using (LogContext.PushProperty("Method", method))
        using (LogContext.PushProperty("Success", success))
        {
            if (success)
            {
                _logger.LogDebug("Service {Service}.{Method} completed successfully with response: {@Response}",
                    service, method, response);
            }
            else
            {
                _logger.LogError("Service {Service}.{Method} failed with response: {@Response}",
                    service, method, response);
            }
        }
    }

    public void LogDataAccess(string operation, string entity, string id, bool success)
    {
        using (LogContext.PushProperty("EventType", "DataAccess"))
        using (LogContext.PushProperty("Operation", operation))
        using (LogContext.PushProperty("Entity", entity))
        using (LogContext.PushProperty("EntityId", id))
        {
            if (success)
            {
                _logger.LogDebug("Data access: {Operation} on {Entity}:{EntityId} succeeded",
                    operation, entity, id);
            }
            else
            {
                _logger.LogError("Data access: {Operation} on {Entity}:{EntityId} failed",
                    operation, entity, id);
            }
        }
    }

    public void LogExternalApiCall(string apiName, string endpoint, int statusCode, TimeSpan duration)
    {
        using (LogContext.PushProperty("EventType", "ExternalApiCall"))
        using (LogContext.PushProperty("ApiName", apiName))
        using (LogContext.PushProperty("Endpoint", endpoint))
        using (LogContext.PushProperty("StatusCode", statusCode))
        using (LogContext.PushProperty("Duration", duration.TotalMilliseconds))
        {
            var logLevel = statusCode >= 400 ? LogLevel.Error : LogLevel.Information;
            _logger.Log(logLevel, "External API call to {ApiName} at {Endpoint} returned {StatusCode} in {Duration}ms",
                apiName, endpoint, statusCode, duration.TotalMilliseconds);
        }
    }

    public void LogCacheOperation(string operation, string key, bool hit, object? metadata = null)
    {
        using (LogContext.PushProperty("EventType", "CacheOperation"))
        using (LogContext.PushProperty("Operation", operation))
        using (LogContext.PushProperty("CacheKey", key))
        using (LogContext.PushProperty("CacheHit", hit))
        {
            _logger.LogDebug("Cache {Operation} for key {CacheKey}: {Result} - {@Metadata}",
                operation, key, hit ? "HIT" : "MISS", metadata);
        }
    }
}