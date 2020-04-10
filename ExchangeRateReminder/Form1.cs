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
        private IPriceReminder _newPriceReminder1;
        private IPriceReminder _newPriceReminder2;

        public Form1()
        {
            InitializeComponent();

            notifyIcon1.Icon = Icon = Resources.logo;

            _newPriceReminder1 = Factory.NewPriceReminder();
            _newPriceReminder2 = Factory.NewPriceReminder();
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

        private void _exchangeRateRetriever_ExchangeRateChanged(ExchangeRateItem obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<ExchangeRateItem>)_exchangeRateRetriever_ExchangeRateChanged, obj);
                return;
            }

            tbOutput.Text = obj.ToString();
            tbOutput.BackColor = obj.New == obj.YestdayClose ? BackColor : obj.New > obj.YestdayClose ? Color.Red : Color.LightGreen;
        }

        private void _exchangeRateRetriever_StatusChanged(ExchangeRateRetrieverStatus obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<ExchangeRateRetrieverStatus>)_exchangeRateRetriever_StatusChanged, obj);
                return;
            }

            toolStripStatusLabel1.Text = obj.ToString();
            switch (obj)
            {
                case ExchangeRateRetrieverStatus.Stopped:
                    Text = WindowTitle;
                    btnDirection.Enabled = cbbLeft.Enabled = cbbRight.Enabled = btnStart.Enabled = true;
                    gbAlert.Enabled = btnStop.Enabled = false;
                    tbOutput.Text = string.Empty;
                    tbOutput.BackColor = BackColor;
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

        private void btnSetAlert1_Click(object sender, EventArgs e)
        {
            try
            {
                _newPriceReminder1.ReminderTriggered += _newPriceReminder1_ReminderTriggered;
                _newPriceReminder1.Set(_exchangeRateRetriever, decimal.Parse(tbAlertPrice1.Text), cbAlertCondition1.Text);
                btnSetAlert1.Enabled = false;
                btnCancelAlert1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _newPriceReminder1_ReminderTriggered(IPriceReminder obj)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action<IPriceReminder>)_newPriceReminder1_ReminderTriggered, obj);
                return;
            }

            ShowWindow();
            notifyIcon1.ShowBalloonTip(int.MaxValue, "Exchange Rate Reminder Alert", $"{obj.Retriever.CurrencyFrom}-->{obj.Retriever.CurrencyTo}: {obj.Retriever.ExchangeRate.New}", ToolTipIcon.Info);
        }

        private void btnCancelAlert1_Click(object sender, EventArgs e)
        {
            _newPriceReminder1.Cancel();
            _newPriceReminder1.ReminderTriggered -= _newPriceReminder1_ReminderTriggered;
            btnSetAlert1.Enabled = true;
            btnCancelAlert1.Enabled = false;
        }

        private void btnSetAlert2_Click(object sender, EventArgs e)
        {
            try
            {
                _newPriceReminder2.ReminderTriggered += _newPriceReminder1_ReminderTriggered;
                _newPriceReminder2.Set(_exchangeRateRetriever, decimal.Parse(tbAlertPrice2.Text), cbAlertCondition2.Text);
                btnSetAlert2.Enabled = false;
                btnCancelAlert2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelAlert2_Click(object sender, EventArgs e)
        {
            _newPriceReminder2.Cancel();
            _newPriceReminder2.ReminderTriggered -= _newPriceReminder1_ReminderTriggered;
            btnSetAlert2.Enabled = true;
            btnCancelAlert2.Enabled = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideToTray();
            e.Cancel = true;
        }

        private void ShowWindow()
        {
            WindowState = FormWindowState.Normal;
            ShowInTaskbar = true;
            Activate();
        }

        private void HideToTray()
        {
            WindowState = FormWindowState.Minimized;
            ShowInTaskbar = false;
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            ShowWindow();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            Close();
        }

        private void showWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowWindow();
        }
    }
}
