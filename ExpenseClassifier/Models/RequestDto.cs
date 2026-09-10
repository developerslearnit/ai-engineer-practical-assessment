namespace ExpenseClassifier.Models
{
    public class RequestDto
    {
        public string Description { get; set; }
    }


    public class ResponseDto
    {
        public string Category { get; set; }

        public string ExpenseDescription { get; set; }
    }
}
