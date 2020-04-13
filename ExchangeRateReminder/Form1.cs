using ExchangeRateReminder.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

// ReSharper disable LocalizableElement

namespace ExchangeRateReminder
{
    public partial class Form1 : Form
    {
        private const string WindowTitle = "ERR";
        private IExchangeRateRetriever _exchangeRateRetriever;
        private bool _fromLeftToRight = true;
        private readonly IPriceReminder _newPriceReminder1;
        private readonly IPriceReminder _newPriceReminder2;

        public Form1()
        {
            InitializeComponent();

            notifyIcon1.Icon = Icon = Resources.logo;
            cbbLeft.SelectedIndex = 1;
            cbbRight.SelectedIndex = 2;
            cbAlertCondition1.SelectedIndex = 2;
            cbAlertCondition2.SelectedIndex = 4;

            _newPriceReminder1 = Factory.NewPriceReminder();
            _newPriceReminder1.ReminderSet += _newPriceReminder1_ReminderSet;
            _newPriceReminder2 = Factory.NewPriceReminder();
            _newPriceReminder2.ReminderSet += _newPriceReminder2_ReminderSet;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            var textL = cbbLeft.Text.Trim().ToUpper();
            var textR = cbbRight.Text.Trim().ToUpper();
            var currencyFrom = _fromLeftToRight ? textL : textR;
            var currencyTo = _fromLeftToRight ? textR : textL;

            if (!cbbLeft.Items.Contains(currencyFrom))
            {
                MessageBox.Show(this, $"Source currency [{currencyFrom}] is not in the list!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!cbbRight.Items.Contains(currencyTo))
            {
                MessageBox.Show(this, $"Target currency [{currencyTo}] is not in the list!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (currencyFrom == currencyTo)
            {
                MessageBox.Show(this, "Source and target currency can't be same!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _exchangeRateRetriever = Factory.NewExchangeRateRetriever(currencyFrom, currencyTo);
            _exchangeRateRetriever.StatusChanged += _exchangeRateRetriever_StatusChanged;
            _exchangeRateRetriever.ExchangeRateChanged += _exchangeRateRetriever_ExchangeRateChanged;
            _exchangeRateRetriever.Start();
        }

        private void _exchangeRateRetriever_ExchangeRateChanged(ExchangeRateItem eri)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<ExchangeRateItem>)_exchangeRateRetriever_ExchangeRateChanged, eri);
                return;
            }

            Text = $"{WindowTitle}-{_exchangeRateRetriever.CurrencyFrom}{_exchangeRateRetriever.CurrencyTo}-{eri.New:N4}";
            tbOutput.Text = eri.ToString();
            tbOutput.BackColor = eri.New == eri.YestdayClose ? BackColor : eri.New > eri.YestdayClose ? Color.Red : Color.LightGreen;
        }

        private void _exchangeRateRetriever_StatusChanged(ExchangeRateRetrieverStatus status)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<ExchangeRateRetrieverStatus>)_exchangeRateRetriever_StatusChanged, status);
                return;
            }

            toolStripStatusLabel1.Text = status.ToString().ToUpper();
            switch (status)
            {
                case ExchangeRateRetrieverStatus.Stopped:
                    Text = WindowTitle;
                    btnDirection.Enabled = cbbLeft.Enabled = cbbRight.Enabled = btnStart.Enabled = true;
                    gbAlert.Enabled = btnStop.Enabled = false;
                    tbOutput.Text = string.Empty;
                    tbOutput.BackColor = BackColor;

                    //Cancel alert
                    _newPriceReminder1.Cancel();
                    _newPriceReminder2.Cancel();
                    break;
                case ExchangeRateRetrieverStatus.Online:
                case ExchangeRateRetrieverStatus.Error:
                    Text = $"{WindowTitle}-{_exchangeRateRetriever.CurrencyFrom}{_exchangeRateRetriever.CurrencyTo}";
                    btnDirection.Enabled = cbbLeft.Enabled = cbbRight.Enabled = btnStart.Enabled = false;
                    gbAlert.Enabled = btnStop.Enabled = true;
                    break;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _exchangeRateRetriever.Stop();
            _exchangeRateRetriever.ExchangeRateChanged -= _exchangeRateRetriever_ExchangeRateChanged;
            _exchangeRateRetriever.StatusChanged -= _exchangeRateRetriever_StatusChanged;
        }

        private void btnDirection_Click(object sender, EventArgs e)
        {
            _fromLeftToRight = !_fromLeftToRight;
            btnDirection.Text = _fromLeftToRight ? "-->" : "<--";
        }

        private void _newPriceReminder1_ReminderSet(IPriceReminder reminder, bool isSet)
        {
            if (isSet)
            {
                reminder.ReminderTriggered += PriceReminderTriggered;
            }
            else
            {
                reminder.ReminderTriggered -= PriceReminderTriggered;
            }
            cbAlertCondition1.Enabled = tbAlertPrice1.Enabled = btnSetAlert1.Enabled = !isSet;
            btnCancelAlert1.Enabled = isSet;
        }

        private void _newPriceReminder2_ReminderSet(IPriceReminder reminder, bool isSet)
        {
            if (isSet)
            {
                reminder.ReminderTriggered += PriceReminderTriggered;
            }
            else
            {
                reminder.ReminderTriggered -= PriceReminderTriggered;
            }
            btnCancelAlert2.Enabled = isSet;
            btnSetAlert2.Enabled = cbAlertCondition2.Enabled = tbAlertPrice2.Enabled = !isSet;
        }

        private void btnSetAlert1_Click(object sender, EventArgs e)
        {
            try
            {
                _newPriceReminder1.Set(_exchangeRateRetriever, decimal.Parse(tbAlertPrice1.Text), cbAlertCondition1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSetAlert2_Click(object sender, EventArgs e)
        {
            try
            {
                _newPriceReminder2.Set(_exchangeRateRetriever, decimal.Parse(tbAlertPrice2.Text), cbAlertCondition2.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PriceReminderTriggered(IPriceReminder obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<IPriceReminder>)PriceReminderTriggered, obj);
                return;
            }

            ShowWindow();
            notifyIcon1.ShowBalloonTip(int.MaxValue, "Exchange Rate Reminder Alert", $"{obj.Retriever.CurrencyFrom}-->{obj.Retriever.CurrencyTo}: {obj.Retriever.ExchangeRate.New}", ToolTipIcon.Info);
        }

        private void btnCancelAlert1_Click(object sender, EventArgs e)
        {
            _newPriceReminder1.Cancel();
        }

        private void btnCancelAlert2_Click(object sender, EventArgs e)
        {
            _newPriceReminder2.Cancel();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideToTray();
            e.Cancel = true;
        }

        private void ShowWindow()
        {
            Show();
            ShowInTaskbar = true;
            Activate();
        }

        private void HideToTray()
        {
            Hide();
            ShowInTaskbar = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_exchangeRateRetriever != null)
            {
                _exchangeRateRetriever.StatusChanged -= _exchangeRateRetriever_StatusChanged;
                _exchangeRateRetriever.ExchangeRateChanged -= _exchangeRateRetriever_ExchangeRateChanged;
            }

            _newPriceReminder1.ReminderSet -= _newPriceReminder1_ReminderSet;
            _newPriceReminder2.ReminderSet -= _newPriceReminder2_ReminderSet;

            Dispose();
            Close();
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            notifyIcon1.Text = Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Text = Text;
        }
    }
}
