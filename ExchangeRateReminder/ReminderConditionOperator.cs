namespace ExchangeRateReminder
{
    internal static class ReminderConditionOperator
    {
        public enum Operator
        {
            Equal,
            Greater,
            GreaterEqual,
            Less,
            LessEqual
        }

        public static Operator? Parse(string strOp)
        {
            switch (strOp?.Trim())
            {
                case "=":
                    return Operator.Equal;
                case ">":
                    return Operator.Greater;
                case ">=":
                    return Operator.GreaterEqual;
                case "<":
                    return Operator.Less;
                case "<=":
                    return Operator.LessEqual;
            }

            return null;
        }
    }
}
