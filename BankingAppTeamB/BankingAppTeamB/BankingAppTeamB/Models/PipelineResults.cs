namespace BankingAppTeamB.Models
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string Message { get; set; }

        public static ValidationResult Success() =>
            new ValidationResult { IsValid = true, Message = string.Empty };

        public static ValidationResult Failure(string message) =>
            new ValidationResult { IsValid = false, Message = message };
    }

    public class AuthResult
    {
        public bool IsAuthorized { get; set; }
        public string Message { get; set; }

        public static AuthResult Success() =>
            new AuthResult { IsAuthorized = true, Message = string.Empty };

        public static AuthResult Failure(string message) =>
            new AuthResult { IsAuthorized = false, Message = message };
    }

    public class ExecutionResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public static ExecutionResult Success() =>
            new ExecutionResult { IsSuccess = true, Message = string.Empty };

        public static ExecutionResult Failure(string message) =>
            new ExecutionResult { IsSuccess = false, Message = message };
    }
}
