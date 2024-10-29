using DeliveryOrder.Sorting;
using System.Drawing;
using System.Windows.Forms;

namespace DeliveryOrder.Tests.Sorting
{
    [TestClass]
    public class SortingSettingsTests
    {
        private Button button;
        private SortingSettings sortingSettings;

        [TestInitialize]
        public void Setup()
        {
            sortingSettings = new SortingSettings();

        }

        [TestMethod]
        public void ComponentSettings_AllPanels_CustomizedPanels()
        {
            DataGridView dataGridView = new DataGridView();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Номер",
                Name = "Номер",
                Width = 200
            };
            DataGridViewTextBoxColumn weightColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Вес",
                Name = "Вес",
                Width = 150
            };
            DataGridViewTextBoxColumn districtColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Район",
                Name = "Район",
                Width = 100
            };
            DataGridViewTextBoxColumn dataColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Дата",
                Name = "Дата",
                Width = 50
            };

            dataGridView.Columns.Add(idColumn);
            dataGridView.Columns.Add(weightColumn);
            dataGridView.Columns.Add(districtColumn);
            dataGridView.Columns.Add(dataColumn);

            dataGridView.Rows.Add(1, 53.2, "Центральный", "2023-11-17 02:54:10");


            Panel[] panels = {
                new Panel { Name = "panel1_Id" },
                new Panel { Name = "panel2_Weight"},
                new Panel { Name = "panel3_District"},
                new Panel { Name = "panel4_Data" },
                new Panel { Name = "panel5_Data" },
            };

            sortingSettings.ComponentSettings(panels, dataGridView);

            Rectangle idLocationColumn = dataGridView.GetColumnDisplayRectangle(idColumn.Index, true);
            Rectangle weightLocationColumn = dataGridView.GetColumnDisplayRectangle(weightColumn.Index, true);
            Rectangle districtLocationColumn = dataGridView.GetColumnDisplayRectangle(districtColumn.Index, true);
            Rectangle dataLocationColumn = dataGridView.GetColumnDisplayRectangle(dataColumn.Index, true);

            Assert.AreEqual(idColumn.Width, panels[0].Width);
            Assert.AreEqual(idLocationColumn.X, panels[0].Left);

            Assert.AreEqual(weightColumn.Width, panels[1].Width);
            Assert.AreEqual(weightLocationColumn.X, panels[1].Left);

            Assert.AreEqual(districtColumn.Width, panels[2].Width);
            Assert.AreEqual(districtLocationColumn.X, panels[2].Left);

            Assert.AreEqual(dataColumn.Width, panels[3].Width);
            Assert.AreEqual(dataLocationColumn.X, panels[3].Left);

            Assert.AreEqual(dataColumn.Width, panels[4].Width);
            Assert.AreEqual(dataLocationColumn.X, panels[4].Left);
        }

        [TestMethod]
        public void SizePanel_Panel_CustomizedPanel()
        {
            DataGridView dataGridView = new DataGridView();

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Номер",
                Name = "Номер"
            };

            dataGridView.Columns.Add(idColumn);
            dataGridView.Rows.Add(1);

            Panel panel = new Panel { Name = "panel1_Id" };

            sortingSettings.SizePanel(panel, "Номер", dataGridView);

            Rectangle idLocationColumn = dataGridView.GetColumnDisplayRectangle(idColumn.Index, true);

            Assert.AreEqual(panel.Width, idColumn.Width);
            Assert.AreEqual(panel.Left, idLocationColumn.X);

        }

        [TestMethod]
        public void AdditActionBtn_AllPanels_ActivePanels()
        {
            Button orderAddBtn = new Button{ Visible = false };
            Button dateSort = new Button();
            Button expand = new Button();

            Panel[] panels = {
                new Panel { Name = "panel1_Id", Visible = false },
                new Panel { Name = "panel5_Weight", Visible = false },
                new Panel { Name = "panel3_District", Visible = false},
                new Panel { Name = "panel4_Data", Visible = false  },
                new Panel { Name = "panel2_Data" },
            };

            sortingSettings.AdditActionBtn(panels, orderAddBtn, dateSort, expand);

            //Проверка панелек
            Assert.AreEqual(true, panels[0].Visible);
            Assert.AreEqual(true, panels[1].Visible);
            Assert.AreEqual(true, panels[2].Visible);
            Assert.AreEqual(true, panels[3].Visible);
            Assert.AreEqual(false, panels[4].Visible);

            //Проверка кнопок
            Assert.AreEqual(orderAddBtn.Visible, true);
            Assert.AreEqual(dateSort.Visible, true);
            Assert.AreEqual(expand.Text, "🔼");

        }

        [TestMethod]
        public void AdditActionBtn_AllPanels_DeactivePanels()
        {
            Button orderAddBtn = new Button();
            Button dateSort = new Button();
            Button expand = new Button();

            Panel[] panels = {
                new Panel { Name = "panel1_Id" },
                new Panel { Name = "panel5_Weight"},
                new Panel { Name = "panel3_District"},
                new Panel { Name = "panel4_Data" },
                new Panel { Name = "panel2_Data" },
            };

            sortingSettings.AdditActionBtn(panels, orderAddBtn, dateSort, expand);

            //Проверка панелек
            Assert.AreEqual(false, panels[0].Visible);
            Assert.AreEqual(false, panels[1].Visible);
            Assert.AreEqual(false, panels[2].Visible);
            Assert.AreEqual(false, panels[3].Visible);
            Assert.AreEqual(false, panels[4].Visible);

            //Проверка кнопок
            Assert.AreEqual(false, orderAddBtn.Visible);
            Assert.AreEqual(true, dateSort.Visible);
            Assert.AreEqual("🔼", expand.Text);

        }

        [TestMethod]
        public void CancelSortBtn_SortBtn_DeactivateSortBtn()
        {
            Button btn1 = new Button { Text = "Дата сортировка", BackColor = Color.Green };
            Button btn2 = new Button { Text = "Номер сортировка", BackColor = Color.Red };
            Button btn3 = new Button { Text = "Район сортировка", BackColor = Color.Orange };
            
            sortingSettings.CancelSortBtn(btn1, btn2, btn3);
            
            Assert.AreEqual("Дата", btn1.Text);
            Assert.AreEqual(Color.White, btn1.BackColor);

            Assert.AreEqual("Номер", btn2.Text);
            Assert.AreEqual(btn2.BackColor, Color.White);

            Assert.AreEqual("Район", btn3.Text);
            Assert.AreEqual(Color.White, btn3.BackColor);
        }

    }
}
