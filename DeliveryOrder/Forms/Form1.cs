using DeliveryOrder.Model;
using DeliveryOrder.Sorting;
using NLog;
using NLog.Fluent;
using System.Data;

namespace DeliveryOrder
{
    public partial class orderForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private List<District> districts = new List<District>(); //Наши районы с заказами
        private DataTable dt = new DataTable(); //Данные таблицы
        private SortingFunctions sortingFunctions = new SortingFunctions(); //сортировочные функции
        private SortingSettings sortingSettings = new SortingSettings(); //настройка поведения наших элементов
        private string selectedFilePath = ""; //путь к файлу .txt
        private Panel[] panels; //наши все панели (кнопки)

        public orderForm()
        {
            InitializeComponent();
            logger.Info("Пользователь запустил программу.");
            //Создаем основные колонки нашей таблицы
            dt.Columns.Add("Номер", typeof(int));
            dt.Columns.Add("Вес", typeof(double));
            dt.Columns.Add("Район");
            dt.Columns.Add("Дата", typeof(DateTime));

            //Получаем массив всех панелей (кнопок сортировок)
            panels = panel1.Controls.OfType<Panel>().ToArray();
        }


        private void FileButton_Click(object sender, EventArgs e)
        {
            if (fileButton.Text == "Загрузить файл")
            {
                logger.Info("Пользователь нажал на кнопку 'загрузить файл'.");
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    logger.Debug("Файл выбрал файл: {0}", openFileDialog.FileName);
                    selectedFilePath = openFileDialog.FileName;
                    fileButton.Text = Path.GetFileName(selectedFilePath);

                    try
                    {
                        //Читаем файл, который загрузил пользователь, и берем оттуда все данные
                        using (StreamReader reader = new StreamReader(selectedFilePath))
                        {
                            logger.Debug("Начинаем чтение файла: {0}", selectedFilePath);
                            string? line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                string[] elements = line.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                                logger.Debug("Чтение строки: {0}", line);
                                OrderAdd(double.Parse(elements[0]), elements[1].TrimStart(), DateTime.Parse(elements[2]));
                            }
                        }

                        logger.Info("Файл успешно прочитан и данные загружены в таблицу.");

                        orderData.DataSource = dt; //размешаем полученные данные в таблицу
                        orderData.Refresh(); //обновляем таблицу после размешения
                        orderData.Columns["Дата"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss"; //устанавливаем формат для поля Дата
                        sortingSettings.AdditActionBtn(panels, orderAddButton, dateSort, expandSortBtn); //Показываем наши кнопки

                        //Устанавливаем высоту winForm и таблицы
                        if (District.GetOrderCount() < 12)
                        {
                            orderPanel.Height = District.GetOrderCount() * 32;
                            this.Height = District.GetOrderCount() * 59;
                        }
                        else
                        {
                            orderPanel.Height = 420;
                            this.Height = 720;
                        }

                        logger.Info("Размеры формы и панели успешно обновлены.");

                    }
                    catch (Exception ex)
                    {
                        logger.Error(ex, "Ошибка при чтении файла или обработке данных.");

                        fileButton.Text = "Error";
                    }
                }
                else
                {
                    logger.Info("Пользователь оменил выбор файла.");
                }
            }
            else if (fileButton.Text == "Error")
            {
                logger.Warn("Пользователь нажал на кнопку с текстом 'Error'. Сбрасываем текст кнопки.");
                fileButton.Text = "Загрузить файл";
            }
            else
            {
                logger.Info("Пользователь решил закрыть данные, сбрасываемм все элементы.");
                //Стираем все данные после того как пользователь решил закрыть данные,
                //нажав на ту кнопку, что и нажимал в самом начале
                //Так же возвращаем все элементы в исходное положение
                orderData.DataSource = null;
                dt.Clear();
                District.SetOrderCount(0);
                districts.Clear();
                
                fileButton.Text = "Загрузить файл";
                this.Height = 345;
                sortingSettings.AdditActionBtn(panels, orderAddButton, dateSort, expandSortBtn);

            }

        }

        //Собитые которое срабатывает при нажатии на кнопку "Добавить заказ"
        private void OrderAddButton_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 'Добавить заказ'. Открываем форму ввода");
            // Открываем форму ввода
            using (orderAddForm orderAddForm = new orderAddForm())
            {
                if (orderAddForm.ShowDialog() == DialogResult.OK)
                {
                    logger.Info("Форма ввода успешно закрыта.");
                    // Получаем заполненную заказ, записываем в наш List<District>,
                    // и сразу в DataTable
                    logger.Debug($"Полученные данные заказа: " +
                        $"вес = {orderAddForm.dst.orders[0].weight}, " +
                        $"район = {orderAddForm.dst.orders[0].district}, " +
                        $"дата = {orderAddForm.dst.orders[0].dateTime}");
                    
                    OrderAdd(
                        orderAddForm.dst.orders[0].weight, 
                        orderAddForm.dst.orders[0].district, 
                        orderAddForm.dst.orders[0].dateTime
                    );
                    MessageBox.Show("Запись добавлена");
                    logger.Info("Новый заказ успешно добавлен в таблицу.");
                }
                else
                {
                    logger.Info("Форма ввода закрыта без добавления заказ.");
                }
            }
        }

        //Собитые которое срабатывает при изменении размера окна
        private void OrderForm_Resize(object sender, EventArgs e)
        {
            //Размешаем кнопку загрузить файл по центру
            fileButton.Left = (orderButtomPanel.ClientSize.Width - fileButton.Width) / 2;
            fileButton.Top = (orderButtomPanel.ClientSize.Height - fileButton.Height) / 2;

            //Размешаем кнопку добавить заказ справа
            orderAddButton.Left = (orderButtomPanel.ClientSize.Width - orderAddButton.Width) - 25;

            //Корректируем размеры кнопок под размеры колонок
            sortingSettings.ComponentSettings(panels, orderData);
        }

        ////Собитые которое срабатывает при нажатии на кнопку "🔼", открывает и сортирует периодом
        private void ExpandSortBtn_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 🔼, открытие сортировки периодом дат");
            sortingFunctions.DateSort(expandSortBtn, panel2_Data, dateTimeInterval1, dateTimeInterval2, dateSort, dt);//Функция сортировки

            // Обновляем DataGridView, если не обновилось автоматически
            orderData.DataSource = dt;
            logger.Debug("DataGridView обновлён с новыми данными.");
        }

        //Собитые которое срабатывает при нажатии на кнопку "🔽", закрывает сортировку периодом
        private void ExpandCloseBtn_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 🔽, открытие сортировки периодом дат");

            panel2_Data.Visible = false;
            dateSort.Visible = true;
            expandSortBtn.Text = "🔼";

            logger.Debug("Панель сортировки скрыта, кнопка '🔼' активирована.");
        }

        //Собитые которое срабатывает при нажатии на кнопку "Дата"
        private void DateSort_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 'Дата', начинается сортировка по дате.");
            sortingSettings.CancelSortBtn(idSort, weightSort, districtSort); //Сброс активного поведения у остальных кнопок
            sortingFunctions.ActiveSortBtn(dateSort, dt, orderData); //Функция сортировки
            logger.Debug("Сортировка по дате завершена.");
        }

        //Собитые которое срабатывает после привязки данных, отключает все стандартные фильтрации у таблицы
        private void OrderData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn column in orderData.Columns)
            {
                // Отключение сортировки
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            logger.Info("Стандартная сортировка для всех колонок отключена.");
        }

        //Собитые которое срабатывает при нажатии на кнопку "Вес"
        private void WeightSort_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 'Вес', начинается функция сортировки по весу.");
            sortingSettings.CancelSortBtn(dateSort, idSort, districtSort); //Сброс активного поведения у остальных кнопок
            sortingFunctions.ActiveSortBtn(weightSort, dt, orderData); //Функция сортировки
            logger.Debug("Функция сортировки по весу завершена.");
        }

        //Собитые которое срабатывает при нажатии на кнопку "Номер"
        private void IdSort_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 'Номер', начинается функция сортировки по номеру");
            sortingSettings.CancelSortBtn(dateSort, weightSort, districtSort); //Сброс активного поведения у остальных кнопок
            sortingFunctions.ActiveSortBtn(idSort, dt, orderData); //Функция сортировки
            logger.Debug("Функция сортировки по номеру завершена.");
        }


        //Событие которое срабатывает при нажатии на кнопку "🔍",
        //переключает способ сортировки районов
        private void DistrictBtn_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку '🔍'");
            districtSort.Visible = districtSort.Visible ? false : true;
            districtSortBox.Text = "";


            sortingSettings.ComponentSettings(panels, orderData);
            logger.Info("Способ сортировки районов изменена.");
        }

        //Событие которое срабатывает при выборе района из выпадающего списка
        private void DistrictSortBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Info($"Пользователь выбрал район: {districtSortBox.Text}, начинается сортировка.");
            sortingFunctions.DistrictSortBox(districtSortBox.Text, dt); //Функция сортировки
            sortingSettings.ComponentSettings(panels, orderData); //Настраивает размеры кнопок 
            logger.Debug("Сортировка по выбранному району завершена.");
        }

        //Собитые которое срабатывает при нажатии на кнопку "Район"
        private void DistrictSort_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь нажал на кнопку 'Район', начинается функция сортировки по району");
            sortingSettings.CancelSortBtn(dateSort, weightSort, idSort); //Сброс активного поведения у остальных кнопок
            sortingFunctions.DistrictSort(districtSort, districts, dt); //Функция сортировки
            logger.Debug("Функция сортировки по району завершена.");
        }



        private void OrderAdd(double weight, string district, DateTime dateTime)
        {
            logger.Debug($"Добавление заказа: вес = {weight}, район = {district}, дата = {dateTime}");
            //Производим поиск района
            int index = districts.FindIndex(d => d.Name == district);

            if (index >= 0) //Если район уже существует в нашем списке districts
            {
                //Добавляем новый заказ в уже существующий район
                districts[index].AddOrder(weight, dateTime);
                
                //Получаем индекс только что созданного заказа
                int orderId = districts[index].orders.Count - 1;

                //Добавляем новую запись в нашу DataTable
                dt.Rows.Add(
                    districts[index].orders[orderId].id, 
                    districts[index].orders[orderId].weight, 
                    districts[index].orders[orderId].district, 
                    districts[index].orders[orderId].dateTime
                );
                logger.Debug($"Заказ добавлен в район {district}, ID заказа: {districts[index].orders[orderId].id}");
            }
            else
            {
                logger.Debug($"Район {district}, не найден. Создаем новый район и добавляем заказ");

                //Добавляем новый район в наш districtSortBox
                districtSortBox.Items.Add(district);

                //Создаём новый элемент (район) в нашем списке districts, сразу добавляя наш заказ в этот элемент
                districts.Add(
                    new District(
                        district,
                        weight,
                        dateTime
                    )
                );

                // Получаем индекс только что созданного района
                int districtId = districts.Count - 1;

                //Добавляем новую запись в нашу DataTable
                dt.Rows.Add(
                    districts[districtId].orders[0].id, 
                    districts[districtId].orders[0].weight, 
                    districts[districtId].orders[0].district, 
                    districts[districtId].orders[0].dateTime
                );

                logger.Info($"Новый район {district} создан и заказ добавлен. ID заказа: {districts[districtId].orders[0].id}");
            }
        }
    }
}
