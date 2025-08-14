// AselBlazorCleanArchitecture.Shared/Models/Responses/Response.cs
using System.Net;

namespace AselBlazorCleanArchitecture.Shared.Models.Responses
{
    /// <summary>
    /// Static helper class for creating APIResponse instances with various data types
    /// </summary>
    public static class AselResponse
    {
        #region Success Responses

        /// <summary>
        /// Creates a successful response with data
        /// </summary>
        public static APIResponse<T> Success<T>(T data, string message = "Operation completed successfully", int statusCode = 200)
        {
            return new APIResponse<T>(data, message, statusCode);
        }

        /// <summary>
        /// Creates a successful response without data
        /// </summary>
        public static APIResponse<object> Success(string message = "Operation completed successfully", int statusCode = 200)
        {
            return new APIResponse<object>(null, message, statusCode);
        }

        /// <summary>
        /// Creates a successful response with a list/collection
        /// </summary>
        public static APIResponse<IEnumerable<T>> SuccessList<T>(IEnumerable<T> data, string message = "Data retrieved successfully", int statusCode = 200)
        {
            return new APIResponse<IEnumerable<T>>(data, message, statusCode);
        }

        /// <summary>
        /// Creates a successful response with a boolean value
        /// </summary>
        public static APIResponse<bool> SuccessBool(bool value, string message = "Operation completed successfully", int statusCode = 200)
        {
            return new APIResponse<bool>(value, message, statusCode);
        }

        /// <summary>
        /// Creates a successful response with a string value
        /// </summary>
        public static APIResponse<string> SuccessString(string data, string message = "Operation completed successfully", int statusCode = 200)
        {
            return new APIResponse<string>(data, message, statusCode);
        }

        /// <summary>
        /// Creates a successful response with an integer value
        /// </summary>
        public static APIResponse<int> SuccessInt(int value, string message = "Operation completed successfully", int statusCode = 200)
        {
            return new APIResponse<int>(value, message, statusCode);
        }

        /// <summary>
        /// Creates a successful response for created resources
        /// </summary>
        public static APIResponse<T> Created<T>(T data, string message = "Resource created successfully")
        {
            return new APIResponse<T>(data, message, 201);
        }

        /// <summary>
        /// Creates a successful response for updated resources
        /// </summary>
        public static APIResponse<T> Updated<T>(T data, string message = "Resource updated successfully")
        {
            return new APIResponse<T>(data, message, 200);
        }

        /// <summary>
        /// Creates a successful response for deleted resources
        /// </summary>
        public static APIResponse<bool> Deleted(string message = "Resource deleted successfully")
        {
            return new APIResponse<bool>(true, message, 200);
        }

        #endregion

        #region Error Responses

        /// <summary>
        /// Creates a generic error response
        /// </summary>
        public static APIResponse<T> Error<T>(string message, int statusCode = 500)
        {
            return new APIResponse<T>(message, statusCode);
        }

        /// <summary>
        /// Creates a bad request error response
        /// </summary>
        public static APIResponse<T> BadRequest<T>(string message = "Bad request")
        {
            return new APIResponse<T>(message, 400);
        }

        /// <summary>
        /// Creates a not found error response
        /// </summary>
        public static APIResponse<T> NotFound<T>(string message = "Resource not found")
        {
            return new APIResponse<T>(message, 404);
        }

        /// <summary>
        /// Creates an unauthorized error response
        /// </summary>
        public static APIResponse<T> Unauthorized<T>(string message = "Unauthorized access")
        {
            return new APIResponse<T>(message, 401);
        }

        /// <summary>
        /// Creates a forbidden error response
        /// </summary>
        public static APIResponse<T> Forbidden<T>(string message = "Access forbidden")
        {
            return new APIResponse<T>(message, 403);
        }

        /// <summary>
        /// Creates an internal server error response
        /// </summary>
        public static APIResponse<T> InternalError<T>(string message = "Internal server error")
        {
            return new APIResponse<T>(message, 500);
        }

        /// <summary>
        /// Creates a validation error response
        /// </summary>
        public static APIResponse<T> ValidationError<T>(string message = "Validation failed")
        {
            return new APIResponse<T>(message, 422);
        }

        #endregion

        #region Specific Type Helpers

        /// <summary>
        /// Creates responses specifically for boolean operations
        /// </summary>
        public static class Bool
        {
            public static APIResponse<bool> True(string message = "Operation successful") => SuccessBool(true, message);
            public static APIResponse<bool> False(string message = "Operation failed") => SuccessBool(false, message);
            public static APIResponse<bool> NotFound(string message = "Resource not found") => AselResponse.NotFound<bool>(message);
            public static APIResponse<bool> Error(string message = "Operation failed") => AselResponse.Error<bool>(message);
        }

        /// <summary>
        /// Creates responses specifically for string operations
        /// </summary>
        public static class String
        {
            public static APIResponse<string> Success(string data, string message = "String data retrieved") => SuccessString(data, message);
            public static APIResponse<string> Empty(string message = "No data found") => SuccessString(string.Empty, message);
            public static APIResponse<string> NotFound(string message = "String data not found") => AselResponse.NotFound<string>(message);
            public static APIResponse<string> Error(string message = "String operation failed") => AselResponse.Error<string>(message);
        }

        /// <summary>
        /// Creates responses specifically for list operations
        /// </summary>
        public static class List
        {
            public static APIResponse<IEnumerable<T>> Success<T>(IEnumerable<T> data, string message = "List retrieved successfully")
                => SuccessList(data, message);

            public static APIResponse<IEnumerable<T>> Empty<T>(string message = "No items found")
                => SuccessList(Enumerable.Empty<T>(), message);

            public static APIResponse<IEnumerable<T>> NotFound<T>(string message = "List not found")
                => AselResponse.NotFound<IEnumerable<T>>(message);

            public static APIResponse<IEnumerable<T>> Error<T>(string message = "List operation failed")
                => AselResponse.Error<IEnumerable<T>>(message);
        }

        /// <summary>
        /// Creates responses specifically for integer operations
        /// </summary>
        public static class Int
        {
            public static APIResponse<int> Success(int value, string message = "Integer value retrieved") => SuccessInt(value, message);
            public static APIResponse<int> Zero(string message = "No count found") => SuccessInt(0, message);
            public static APIResponse<int> NotFound(string message = "Integer value not found") => AselResponse.NotFound<int>(message);
            public static APIResponse<int> Error(string message = "Integer operation failed") => AselResponse.Error<int>(message);
        }

        #endregion

        #region Conditional Response Helpers

        /// <summary>
        /// Creates a response based on a condition
        /// </summary>
        public static APIResponse<T> If<T>(bool condition, T successData, string successMessage, string failureMessage)
        {
            return condition
                ? Success(successData, successMessage)
                : BadRequest<T>(failureMessage);
        }

        /// <summary>
        /// Creates a response based on whether data exists
        /// </summary>
        public static APIResponse<T> IfExists<T>(T data, string successMessage = "Data found", string notFoundMessage = "Data not found") where T : class
        {
            return data != null
                ? Success(data, successMessage)
                : NotFound<T>(notFoundMessage);
        }

        /// <summary>
        /// Creates a response for nullable data
        /// </summary>
        public static APIResponse<T> IfNotNull<T>(T? data, string successMessage = "Data found", string notFoundMessage = "Data not found") where T : class
        {
            return data != null
                ? Success(data, successMessage)
                : NotFound<T>(notFoundMessage);
        }

        /// <summary>
        /// Creates a response for collections based on whether they contain items
        /// </summary>
        public static APIResponse<IEnumerable<T>> IfAny<T>(IEnumerable<T> collection, string successMessage = "Items found", string emptyMessage = "No items found")
        {
            return collection?.Any() == true
                ? SuccessList(collection, successMessage)
                : SuccessList(Enumerable.Empty<T>(), emptyMessage);
        }

        /// <summary>
        /// Creates a response based on operation result
        /// </summary>
        public static APIResponse<bool> FromResult(bool operationResult, string successMessage = "Operation successful", string failureMessage = "Operation failed")
        {
            return operationResult
                ? Bool.True(successMessage)
                : Bool.False(failureMessage);
        }

        #endregion

        #region HTTP Status Code Helpers

        /// <summary>
        /// Creates a response with a specific HTTP status code
        /// </summary>
        public static APIResponse<T> WithStatusCode<T>(T data, HttpStatusCode statusCode, string message = "")
        {
            return new APIResponse<T>(data, message, (int)statusCode);
        }

        /// <summary>
        /// Creates an error response with a specific HTTP status code
        /// </summary>
        public static APIResponse<T> ErrorWithStatusCode<T>(string message, HttpStatusCode statusCode)
        {
            return new APIResponse<T>(message, (int)statusCode);
        }

        #endregion

        #region Async Response Helpers

        /// <summary>
        /// Creates a successful async response with data
        /// </summary>
        public static Task<APIResponse<T>> SuccessAsync<T>(T data, string message = "Operation completed successfully", int statusCode = 200)
        {
            return Task.FromResult(Success(data, message, statusCode));
        }

        /// <summary>
        /// Creates an error async response
        /// </summary>
        public static Task<APIResponse<T>> ErrorAsync<T>(string message, int statusCode = 500)
        {
            return Task.FromResult(Error<T>(message, statusCode));
        }

        /// <summary>
        /// Creates a not found async response
        /// </summary>
        public static Task<APIResponse<T>> NotFoundAsync<T>(string message = "Resource not found")
        {
            return Task.FromResult(NotFound<T>(message));
        }

        #endregion
    }
}