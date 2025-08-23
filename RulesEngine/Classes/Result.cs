namespace RulesEngine.Classes
{
    public class Result
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; } = "";
        public static Result Failure(string msg) => new() { IsSuccessful = false, Message = msg };
    }
}
