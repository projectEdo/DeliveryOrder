using DeliveryOrder.Model;
using NLog;
using System.Data;

namespace DeliveryOrder.Sorting
{
    public class SortingFunctions
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private int dstCount = 0;

        //Обычная сортировка кнопок ⬆ ⬇
        public void ActiveSortBtn(Button button, DataTable dataTable, DataGridView dataGridView)
        {
            string text = button.Text;
            //Определяем кнопку которую нажали, а также какую сортировку надо сделать
            string sort = button.Text switch
            {
                "Номер" => "ASC",
                "Номер ⬆" => "DESC",
                "Вес" => "ASC",
                "Вес ⬆" => "DESC",
                "Дата" => "ASC",
                "Дата ⬆" => "DESC",
                _ => string.Empty
            };

            logger.Debug($"Порядок сортировки: {sort}");

            //Реализуем сортироку в случае true, в случе false сбрасываем фильтр
            if (sort != string.Empty)
            {
                button.Text = sort == "ASC" ? $"{text.Split(" ")[0]} ⬆" : $"{text.Split(" ")[0]} ⬇";
                button.BackColor = sort == "ASC" ? Color.Green : Color.Red;
                dataTable.DefaultView.Sort = $"{text.Split(" ")[0]} {sort}";
                logger.Debug($"Цвет кнопки изменён на: {(sort == "ASC" ? "Зелёный" : "Красный")}");
            }
            else //Сброс фильтра с конкретной кнопки
            {
                button.Text = $"{text.Split(" ")[0]}";
                button.BackColor = Color.White;
                dataTable.DefaultView.Sort = string.Empty;

                logger.Debug("Сброс фильтра. Текст кнопки восстановлен.");
            }

            dataGridView.DataSource = dataTable;
            logger.Info("DataGridView обновлён с новыми данными.");
        }


        //Расширенная сортировка по Дате, которая позволяет нам сортировать по периоду
        public void DateSort(Button button, Panel panel, DateTimePicker dateTimePicker1, DateTimePicker dateTimePicker2, Button dateSort, DataTable dataTable)
        {
            //строка для фильтрации
            string filter = $"Дата >= #{dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")}# AND Дата <= #{dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss")}#";
            

            if (button.Text == "🔼")
            {
                //Проверяем сбрасывал ли пользователь фильтр перед закрытием расширенной версии фильтрации Дата
                if (dataTable.DefaultView.RowFilter == filter)
                {
                    button.Text = "×";
                    logger.Debug("Фильтр уже активный, кнопка = '×'.");
                }
                else
                {
                    button.Text = "🆗";
                    dateTimePicker1.Text = dataTable.Compute("MIN(Дата)", string.Empty).ToString(); //Устанавливаем самую ранюю дату
                    logger.Debug("Фильтр не активен, кнопка изменена на '🆗'. Установлена минимальная дата.");
                }

                dateSort.Visible = false;
                panel.Visible = true;
                logger.Debug("Допольнительная панель для фильтрации даты периодом активирована.");
            }
            else if (button.Text == "🆗") // выполняю фильтрацию при нажатии на кнопку с текстом 🆗, предварительно проверив правильно диапозона
            {
                if (dateTimePicker1.Value <= dateTimePicker2.Value)
                {
                    dataTable.DefaultView.RowFilter = filter;
                    button.Text = "×";
                    logger.Debug("Фильтрация даты периодом выполнена, кнопка изменена на '×'.");
                }
                else
                {
                    MessageBox.Show("Ошибка периода времени");
                    logger.Warn("Ошибка периода времени: начальная дата больше конечной.");
                }
            }
            else //В случае если текст кнопки равна × мы сбрасываем фильтрацию
            {
                dataTable.DefaultView.RowFilter = string.Empty;
                button.Text = "🆗";
                logger.Debug("Фильтрация сброшена, кнопка изменена на '🆗'.");
            }
        }


        //Фильтрация которая выполняется при выборе района из списка
        public void DistrictSortBox(string text, DataTable dataTable)
        {
            string filter = $"Район = '{text}'";
            logger.Debug($"Фильтр: {filter}");
            dataTable.DefaultView.RowFilter = filter;
            logger.Debug("Фильтрация успешно применена.");
        }

        //Фильтрация по количеству заказов в районе
        public void DistrictSort(Button button, List<District> districts, DataTable dataTable)
        {
            if (button.BackColor == Color.White)
            {
                button.BackColor = Color.Green;
                logger.Debug("Цвет кнопки изменён на зелёный.");

                //Если при сортировки в прошлый раз количество всего заказов меньше, чем на данный момент
                //То начинаем присваивание приоритета заново 
                if (dstCount < District.GetOrderCount())
                {
                    logger.Debug("Количество заказов изменилось, переопределяем приоритет каждого района.");
                    List<District> dst = districts.ToList();
                    dst.Sort((x, y) => y.GetCount().CompareTo(x.GetCount()));


                    //Если нету столба с наименованием "Приоритет", то создаем, при это так чтоб пользователь не видел
                    if (!dataTable.Columns.Contains("Приоритет"))
                    {
                        DataColumn hiddenColumn = new DataColumn("Приоритет", typeof(int))
                        {
                            ColumnMapping = MappingType.Hidden,
                        };
                        dataTable.Columns.Add(hiddenColumn);
                        logger.Debug("Создан скрытый столбец 'Приоритет'.");
                    }

                    //Присваиваем каждой строке приоритет
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        int index = dst.FindIndex(d => d.Name == dr["Район"].ToString());
                        dr["Приоритет"] = index;
                    }
                    logger.Debug("Приоритеты были расставлены для каждого заказа.");
                }
                
                dataTable.DefaultView.Sort = $"Приоритет ASC";
                logger.Info("Сортировка по 'Приоритет' выполнена.");
            }
            else //Сбрасываем фильтрацию
            {
                button.BackColor = Color.White;
                dataTable.DefaultView.Sort = null;
                logger.Info("Сброс сортировки. Цвет кнопки изменён на белый.");
            }
        }
    }
}
