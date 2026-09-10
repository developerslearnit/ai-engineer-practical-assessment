using System.ComponentModel;

namespace ExpenseClassifier.Tools
{
    public class CompanyPolicyTool
    {
        /// <summary>
        /// Returns the official company policy guidelines for expense classification.
        /// </summary>
        /// <returns>The policy guideline text.</returns>
        [Description("Retrieves company policy rules that define how expenses should be categorized.")]
        public virtual string GetPolicy()
        {
            return """
                Uber, Bolt and Taxi expenses are Transportation.

                Restaurant expenses are Food.

                Hotel expenses are Accommodation.

                Electricity and Internet bills are Utilities.
                """;
        }
    }
}
