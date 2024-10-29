using DeliveryOrder.Model;
using NLog;
using NLog.Fluent;

namespace DeliveryOrder
{
    public partial class orderAddForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        
        public District dst;

        public orderAddForm()
        {
            InitializeComponent();
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и клавишу Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != ',')
            {
                logger.Warn($"Попытка ввода недопустимого символа: {e.KeyChar}");
                e.Handled = true; // Отменяет ввод
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (weightBox.Text != "" && districtBox.Text != "")
                {
                    dst = new District(districtBox.Text, double.Parse(weightBox.Text), dateTimeOrder.Value);
                    District.SetOrderCount(District.GetOrderCount() - 1);
                    this.DialogResult = DialogResult.OK;

                    // Закрываем форму
                    this.Close();
                }
                else
                {
                    logger.Warn("Пользователь не заполнил все поля.");
                    MessageBox.Show("Заполните все поля");
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Ошибка при добавлении заказа.");
                MessageBox.Show("Попробуйте ещё раз");
            }
        }

        private void districtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверка, является ли вводимый символ пробелом и является ли это первым символом
            if (e.KeyChar == ' ' && districtBox.Text.Length == 0)
            {
                logger.Warn("Попытка ввода пробела в начале названии 'Район'.");
                e.Handled = true;
            }
        }
    }
}
