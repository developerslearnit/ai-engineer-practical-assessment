using ExpenseClassifier.Models;

namespace ExpenseClassifier.Agents
{

    public interface IExpenseClassifierAgent
    {
        Task<ResponseDto> Classify(string expenseDescription, CancellationToken cancellationToken);
    }


    public class ExpenseClassifierAgent : IExpenseClassifierAgent
    {           
        public async Task<ResponseDto> Classify(string expenseDescription, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
