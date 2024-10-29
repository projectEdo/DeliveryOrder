using NLog;

namespace DeliveryOrder.Sorting
{
    public class SortingSettings
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //Функция, которая задаёт размер всем кнопкам
        public void ComponentSettings(Panel[] panels, DataGridView dataGridView)
        {
            logger.Info("Настройка компонентов панели начата");

            Dictionary<string, string> ages = new Dictionary<string, string>
            {
                { "Id", "Номер" },
                { "Weight", "Вес" },
                { "District", "Район" },
                { "Data", "Дата" }
            };

            foreach (Panel panel in panels)
            {
                string text = ages[panel.Name.Split('_')[^1].ToString()];
                if (dataGridView.Columns[text] != null)
                {
                    logger.Debug($"Установка размера панели: {panel.Name} для колонки: {text}");
                    SizePanel(panel, text, dataGridView);
                }
                else
                {
                    logger.Warn($"Колонка {text} не найдена в DataGridView.");
                }
            }
            logger.Info("Настройка компонентов панели завершена.");
        }

        //Функция, которая устанавливает размер для кнопок
        public void SizePanel(Panel panel, string text, DataGridView dataGridView)
        {
            var columns = dataGridView.Columns[text];
            panel.Width = columns.Width;
            Rectangle columnRectangle = dataGridView.GetColumnDisplayRectangle(columns.Index, true);
            panel.Left = columnRectangle.X;

            logger.Debug($"Размер панели {panel.Name} установлен: ширина = {panel.Width}, левое смещение = {panel.Left}.");
        }

        //Функция, которая показывает или скрывает все кнопки сортировок
        public void AdditActionBtn(Panel[] panels, Button orderAddBtn, Button dateSort, Button expand)
        {
            logger.Info("Переключение видимости кнопок сортировки начато.");

            foreach (Panel panel in panels)
            {
                if (panel.Name == "panel2_Data")
                {
                    panel.Visible = false;
                    dateSort.Visible = true;
                    expand.Text = "🔼";

                    logger.Debug("Панель 'panel2_Data' скрыта.");
                }
                else
                {
                    panel.Visible = panel.Visible ? false : true;

                    logger.Debug($"Панель {panel.Name} видимость изменена на: {panel.Visible}.");
                }
            }

            orderAddBtn.Visible = orderAddBtn.Visible ? false : true;
            logger.Debug($"Кнопка добавления заказа видимость изменена на: {orderAddBtn.Visible}.");
        }

        //Функция, которая сбрасывает активного поведения у кнопок
        public void CancelSortBtn(Button btn1, Button btn2, Button btn3)
        {
            logger.Info("Сброс активного состояния кнопок сортировки начат.");
            
            btn1.Text = btn1.Text.Split(" ")[0];
            btn1.BackColor = Color.White;

            btn2.Text = btn2.Text.Split(" ")[0];
            btn2.BackColor = Color.White;

            btn3.Text = btn3.Text.Split(" ")[0];
            btn3.BackColor = Color.White;

            logger.Info("Сброс активного состояния кнопок сортировки завершен.");
        }
    }
}
