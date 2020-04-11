using System;

namespace ExchangeRateReminder
{
    internal class NewPriceReminder : IPriceReminder
    {
        private decimal _targetPrice;
        private ReminderConditionOperator.Operator _operator;
        private bool _set;

        public event Action<IPriceReminder, bool> ReminderSet;

        public event Action<IPriceReminder> ReminderTriggered;

        public IExchangeRateRetriever Retriever { get; private set; }

        public bool IsSet
        {
            get => _set;
            private set
            {
                if (value != _set)
                {
                    _set = value;
                    ReminderSet?.Invoke(this, value);
                }
            }
        }

        public void Set(IExchangeRateRetriever retriever, decimal targetPrice, string strOperator)
        {
            if (IsSet)
            {
                return;
            }

            Retriever = retriever ?? throw new ArgumentException("Retriever cannot be null!");

            _targetPrice = targetPrice;

            var nullableOp = ReminderConditionOperator.Parse(strOperator);
            if (nullableOp == null)
            {
                throw new ArgumentException("Unknown operator string!");
            }
            _operator = nullableOp.Value;

            Retriever.ExchangeRateChanged += Retriever_ExchangeRateChanged;

            IsSet = true;
        }

        private void Retriever_ExchangeRateChanged(ExchangeRateItem obj)
        {
            var triggered = false;
            switch (_operator)
            {
                case ReminderConditionOperator.Operator.Equal:
                    triggered = obj.New == _targetPrice;
                    break;
                case ReminderConditionOperator.Operator.Greater:
                    triggered = obj.New > _targetPrice;
                    break;
                case ReminderConditionOperator.Operator.GreaterEqual:
                    triggered = obj.New >= _targetPrice;
                    break;
                case ReminderConditionOperator.Operator.Less:
                    triggered = obj.New < _targetPrice;
                    break;
                case ReminderConditionOperator.Operator.LessEqual:
                    triggered = obj.New <= _targetPrice;
                    break;
            }

            if (triggered)
            {
                ReminderTriggered?.Invoke(this);
            }
        }

        public void Cancel()
        {
            if (!IsSet)
            {
                return;
            }

            Retriever.ExchangeRateChanged -= Retriever_ExchangeRateChanged;
            Retriever = null;
            IsSet = false;
        }
    }
}
