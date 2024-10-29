
using DeliveryOrder.Sorting;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using DeliveryOrder.Model;

namespace DeliveryOrder.Tests.Sorting
{
    [TestClass]
    public class SortingFunctionsTests
    {
        private SortingFunctions sortingFunctions;
        private DataTable dataTable;
        private Button sortButton;

        [TestInitialize]
        public void Setup()
        {
            sortingFunctions = new SortingFunctions();
            dataTable = new DataTable();

            dataTable.Columns.Add("Номер", typeof(int));
            dataTable.Columns.Add("Вес", typeof(double));
            dataTable.Columns.Add("Район", typeof(string));
            dataTable.Columns.Add("Дата", typeof(DateTime));
            dataTable.Columns.Add("Приоритет", typeof(int));

            //Добавляем тестовые данные
            dataTable.Rows.Add(0, 28.97, "Комсомольский", new DateTime(2024, 02, 07, 08, 23, 37), 10);
            dataTable.Rows.Add(1, 6.15, "Автозаводский", new DateTime(2023, 09, 23, 21, 29, 01), 10);
            dataTable.Rows.Add(2, 31.54, "Комсомольский", new DateTime(2024, 03, 24, 11, 45, 22), 10);

        }

        //Проверка основных фильтров
        [TestMethod]
        public void ActiveSortBtn_ShouldSortAscending_WhenButtonIsClicked()
        {


            sortButton = new Button { Text = "Номер" };

            sortingFunctions.ActiveSortBtn(sortButton, dataTable, new DataGridView());

            Assert.AreEqual("Номер ⬆", sortButton.Text);
            Assert.AreEqual("Номер ASC", dataTable.DefaultView.Sort);
        }


        //Работа фильтрации с правильным диапазоном дат
        [TestMethod]
        public void DateSort_ValidDateRange_SetsRowFilter()
        {
            sortButton = new Button() { Text = "🆗" };
            Panel panel = new Panel();
            var dateTimePicker1 = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy:MM:dd HH:mm:ss",
                Value = new DateTime(2023, 12, 17, 08, 45, 09)
            };
            var dateTimePicker2 = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy:MM:dd HH:mm:ss",
                Value = new DateTime(2024, 08, 05, 05, 46, 36)
            };
            var dateSortButton = new Button();

            sortingFunctions.DateSort(sortButton, panel, dateTimePicker1, dateTimePicker2, dateSortButton, dataTable);

            Assert.AreEqual("×", sortButton.Text);
            Assert.AreEqual(
                $"Дата >= #{dateTimePicker1.Value:yyyy-MM-dd HH:mm:ss}# AND Дата <= #{dateTimePicker2.Value:yyyy-MM-dd HH:mm:ss}#",
                dataTable.DefaultView.RowFilter
            );
        }

        //Работа фильтрации с неправильным диапазоном дат
        [TestMethod]
        public void DateSort_InvalidDateRange_ShowsError()
        {
            sortButton = new Button() { Text = "🆗" };
            Panel panel = new Panel();
            var dateTimePicker2 = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy:MM:dd HH:mm:ss",
                Value = new DateTime(2023, 12, 17, 08, 45, 09)
            };
            var dateTimePicker1 = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy:MM:dd HH:mm:ss",
                Value = new DateTime(2024, 08, 05, 05, 46, 36)
            };
            var dateSortButton = new Button();

            sortingFunctions.DateSort(sortButton, panel, dateTimePicker1, dateTimePicker2, dateSortButton, dataTable);

            Assert.AreEqual("🆗", sortButton.Text);
            Assert.AreEqual(string.Empty, dataTable.DefaultView.RowFilter);
        }

        //Проверка очищения фильтрации
        [TestMethod]
        public void DateSort_ClearFilter_SetsRowFilterToEmpty()
        {
            sortButton = new Button() { Text = "×" };
            Panel panel = new Panel();
            var dateTimePicker1 = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy:MM:dd HH:mm:ss",
                Value = new DateTime(2023, 12, 17, 08, 45, 09)
            };
            var dateTimePicker2 = new DateTimePicker()
            {
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "yyyy:MM:dd HH:mm:ss",
                Value = new DateTime(2024, 08, 05, 05, 46, 36)
            };
            var dateSortButton = new Button();

            sortingFunctions.DateSort(sortButton, panel, dateTimePicker1, dateTimePicker2, dateSortButton, dataTable);

            Assert.AreEqual("🆗", sortButton.Text);
            Assert.AreEqual(string.Empty, dataTable.DefaultView.RowFilter);
        }

        //Проверка фильтрации после выбора района
        [TestMethod]
        public void DistrictSortBox_ValidDistrict_SetsRowFilter()
        {
            sortingFunctions.DistrictSortBox("Комсомольский", dataTable);

            Assert.AreEqual(2, dataTable.DefaultView.Count);
            Assert.AreEqual("Комсомольский", dataTable.DefaultView[0]["Район"]);
            Assert.AreEqual("Комсомольский", dataTable.DefaultView[1]["Район"]);
        }

        //Проверка правильной сортировки
        [TestMethod]
        public void DistrictSort_WhiteButton_SortsDataTable()
        {
            List<District> districts = new List<District>();
            districts.Add(new District("Комсомольский", 28.97, new DateTime(2024, 02, 07, 08, 23, 37)));
            districts[0].AddOrder(31.54, new DateTime(2024, 03, 24, 11, 45, 22));
            districts.Add(new District("Автозаводский", 6.15, new DateTime(2023, 09, 23, 21, 29, 01)));
            sortButton = new Button { BackColor = Color.White };

            sortingFunctions.DistrictSort(sortButton, districts, dataTable);

            Assert.AreEqual(Color.Green, sortButton.BackColor);
            Assert.IsTrue(dataTable.Columns.Contains("Приоритет"));
            Assert.AreEqual(0, dataTable.Rows[0]["Приоритет"]);
            Assert.AreEqual(1, dataTable.Rows[1]["Приоритет"]);
            Assert.AreEqual(0, dataTable.Rows[2]["Приоритет"]);
        }

        //Проверка правильного сброса фильтра
        [TestMethod]
        public void DistrictSort_GreenButton_ResetsSort()
        {
            sortButton = new Button { BackColor = Color.White };

            List<District> districts = new List<District>();
            districts.Add(new District("Комсомольский", 28.97, new DateTime(2024, 02, 07, 08, 23, 37)));
            districts[0].AddOrder(31.54, new DateTime(2024, 03, 24, 11, 45, 22));
            districts.Add(new District("Автозаводский", 6.15, new DateTime(2023, 09, 23, 21, 29, 01)));

            //Сначала сортируем
            sortingFunctions.DistrictSort(sortButton, districts, dataTable);

            //Теперь сбрасываем
            sortingFunctions.DistrictSort(sortButton, districts, dataTable);

            Assert.AreEqual(Color.White, sortButton.BackColor);
            Assert.AreEqual(string.Empty, dataTable.DefaultView.Sort);
        }
    }
}
