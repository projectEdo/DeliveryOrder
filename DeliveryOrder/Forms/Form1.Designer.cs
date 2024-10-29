namespace DeliveryOrder
{
    partial class orderForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            orderButtomPanel = new Panel();
            orderAddButton = new Button();
            fileButton = new Button();
            panel1 = new Panel();
            panel5_Id = new Panel();
            idSort = new Button();
            panel4_Weight = new Panel();
            weightSort = new Button();
            panel3_District = new Panel();
            districtSort = new Button();
            districtSortBox = new ComboBox();
            districtBtn = new Button();
            panel2_Data = new Panel();
            dateTimeInterval1 = new DateTimePicker();
            expandCloseBtn = new Button();
            panel3_Data = new Panel();
            dateSort = new Button();
            dateTimeInterval2 = new DateTimePicker();
            expandSortBtn = new Button();
            districtBindingSource = new BindingSource(components);
            orderPanel = new Panel();
            orderData = new DataGridView();
            orderButtomPanel.SuspendLayout();
            panel1.SuspendLayout();
            panel5_Id.SuspendLayout();
            panel4_Weight.SuspendLayout();
            panel3_District.SuspendLayout();
            panel2_Data.SuspendLayout();
            panel3_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)districtBindingSource).BeginInit();
            orderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderData).BeginInit();
            SuspendLayout();
            // 
            // orderButtomPanel
            // 
            orderButtomPanel.Controls.Add(orderAddButton);
            orderButtomPanel.Controls.Add(fileButton);
            orderButtomPanel.Dock = DockStyle.Bottom;
            orderButtomPanel.Location = new Point(10, 140);
            orderButtomPanel.Name = "orderButtomPanel";
            orderButtomPanel.Size = new Size(782, 131);
            orderButtomPanel.TabIndex = 3;
            // 
            // orderAddButton
            // 
            orderAddButton.Location = new Point(600, 6);
            orderAddButton.Name = "orderAddButton";
            orderAddButton.Size = new Size(155, 34);
            orderAddButton.TabIndex = 2;
            orderAddButton.Text = "Добавить заказ";
            orderAddButton.UseVisualStyleBackColor = true;
            orderAddButton.Visible = false;
            orderAddButton.Click += OrderAddButton_Click;
            // 
            // fileButton
            // 
            fileButton.Location = new Point(300, 36);
            fileButton.Name = "fileButton";
            fileButton.Size = new Size(179, 58);
            fileButton.TabIndex = 1;
            fileButton.Text = "Загрузить файл";
            fileButton.UseVisualStyleBackColor = true;
            fileButton.Click += FileButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5_Id);
            panel1.Controls.Add(panel4_Weight);
            panel1.Controls.Add(panel3_District);
            panel1.Controls.Add(panel2_Data);
            panel1.Controls.Add(panel3_Data);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(10, 10);
            panel1.Name = "panel1";
            panel1.Size = new Size(782, 93);
            panel1.TabIndex = 5;
            // 
            // panel5_Id
            // 
            panel5_Id.Controls.Add(idSort);
            panel5_Id.Location = new Point(51, 63);
            panel5_Id.Name = "panel5_Id";
            panel5_Id.Size = new Size(177, 28);
            panel5_Id.TabIndex = 11;
            panel5_Id.Visible = false;
            // 
            // idSort
            // 
            idSort.Dock = DockStyle.Fill;
            idSort.Location = new Point(0, 0);
            idSort.Name = "idSort";
            idSort.Size = new Size(177, 28);
            idSort.TabIndex = 2;
            idSort.Text = "Номер";
            idSort.UseVisualStyleBackColor = true;
            idSort.Click += IdSort_Click;
            // 
            // panel4_Weight
            // 
            panel4_Weight.Controls.Add(weightSort);
            panel4_Weight.Location = new Point(234, 63);
            panel4_Weight.Name = "panel4_Weight";
            panel4_Weight.Size = new Size(177, 28);
            panel4_Weight.TabIndex = 10;
            panel4_Weight.Visible = false;
            // 
            // weightSort
            // 
            weightSort.Dock = DockStyle.Fill;
            weightSort.Location = new Point(0, 0);
            weightSort.Name = "weightSort";
            weightSort.Size = new Size(177, 28);
            weightSort.TabIndex = 2;
            weightSort.Text = "Вес";
            weightSort.UseVisualStyleBackColor = true;
            weightSort.Click += WeightSort_Click;
            // 
            // panel3_District
            // 
            panel3_District.Controls.Add(districtSort);
            panel3_District.Controls.Add(districtSortBox);
            panel3_District.Controls.Add(districtBtn);
            panel3_District.Location = new Point(417, 63);
            panel3_District.Name = "panel3_District";
            panel3_District.Size = new Size(177, 28);
            panel3_District.TabIndex = 9;
            panel3_District.Visible = false;
            // 
            // districtSort
            // 
            districtSort.BackColor = Color.White;
            districtSort.Dock = DockStyle.Fill;
            districtSort.Location = new Point(0, 0);
            districtSort.Name = "districtSort";
            districtSort.Size = new Size(147, 28);
            districtSort.TabIndex = 2;
            districtSort.Text = "Район";
            districtSort.UseVisualStyleBackColor = false;
            districtSort.Click += DistrictSort_Click;
            // 
            // districtSortBox
            // 
            districtSortBox.Dock = DockStyle.Fill;
            districtSortBox.FormattingEnabled = true;
            districtSortBox.Location = new Point(0, 0);
            districtSortBox.Name = "districtSortBox";
            districtSortBox.Size = new Size(147, 28);
            districtSortBox.TabIndex = 13;
            districtSortBox.SelectedIndexChanged += DistrictSortBox_SelectedIndexChanged;
            // 
            // districtBtn
            // 
            districtBtn.Dock = DockStyle.Right;
            districtBtn.Location = new Point(147, 0);
            districtBtn.Name = "districtBtn";
            districtBtn.Size = new Size(30, 28);
            districtBtn.TabIndex = 3;
            districtBtn.Text = "🔍";
            districtBtn.UseVisualStyleBackColor = true;
            districtBtn.Click += DistrictBtn_Click;
            // 
            // panel2_Data
            // 
            panel2_Data.Controls.Add(dateTimeInterval1);
            panel2_Data.Controls.Add(expandCloseBtn);
            panel2_Data.Location = new Point(600, 30);
            panel2_Data.Name = "panel2_Data";
            panel2_Data.Size = new Size(177, 28);
            panel2_Data.TabIndex = 8;
            panel2_Data.Visible = false;
            // 
            // dateTimeInterval1
            // 
            dateTimeInterval1.CustomFormat = "yyyy:MM:dd HH:mm:ss";
            dateTimeInterval1.Dock = DockStyle.Fill;
            dateTimeInterval1.Format = DateTimePickerFormat.Custom;
            dateTimeInterval1.Location = new Point(0, 0);
            dateTimeInterval1.Name = "dateTimeInterval1";
            dateTimeInterval1.ShowUpDown = true;
            dateTimeInterval1.Size = new Size(147, 27);
            dateTimeInterval1.TabIndex = 3;
            // 
            // expandCloseBtn
            // 
            expandCloseBtn.Dock = DockStyle.Right;
            expandCloseBtn.Location = new Point(147, 0);
            expandCloseBtn.Name = "expandCloseBtn";
            expandCloseBtn.Size = new Size(30, 28);
            expandCloseBtn.TabIndex = 1;
            expandCloseBtn.Text = "🔽";
            expandCloseBtn.UseVisualStyleBackColor = true;
            expandCloseBtn.Click += ExpandCloseBtn_Click;
            // 
            // panel3_Data
            // 
            panel3_Data.Controls.Add(dateSort);
            panel3_Data.Controls.Add(dateTimeInterval2);
            panel3_Data.Controls.Add(expandSortBtn);
            panel3_Data.Location = new Point(600, 63);
            panel3_Data.Name = "panel3_Data";
            panel3_Data.Size = new Size(177, 28);
            panel3_Data.TabIndex = 7;
            panel3_Data.Visible = false;
            // 
            // dateSort
            // 
            dateSort.Dock = DockStyle.Fill;
            dateSort.Location = new Point(0, 0);
            dateSort.Name = "dateSort";
            dateSort.Size = new Size(147, 28);
            dateSort.TabIndex = 2;
            dateSort.Text = "Дата";
            dateSort.UseVisualStyleBackColor = true;
            dateSort.Click += DateSort_Click;
            // 
            // dateTimeInterval2
            // 
            dateTimeInterval2.CustomFormat = "yyyy:MM:dd HH:mm:ss";
            dateTimeInterval2.Dock = DockStyle.Fill;
            dateTimeInterval2.Format = DateTimePickerFormat.Custom;
            dateTimeInterval2.Location = new Point(0, 0);
            dateTimeInterval2.Name = "dateTimeInterval2";
            dateTimeInterval2.ShowUpDown = true;
            dateTimeInterval2.Size = new Size(147, 27);
            dateTimeInterval2.TabIndex = 4;
            // 
            // expandSortBtn
            // 
            expandSortBtn.Dock = DockStyle.Right;
            expandSortBtn.Location = new Point(147, 0);
            expandSortBtn.Name = "expandSortBtn";
            expandSortBtn.Size = new Size(30, 28);
            expandSortBtn.TabIndex = 1;
            expandSortBtn.Text = "🔼";
            expandSortBtn.UseVisualStyleBackColor = true;
            expandSortBtn.Click += ExpandSortBtn_Click;
            // 
            // districtBindingSource
            // 
            districtBindingSource.DataSource = typeof(Model.District);
            // 
            // orderPanel
            // 
            orderPanel.Controls.Add(orderData);
            orderPanel.Dock = DockStyle.Fill;
            orderPanel.Location = new Point(10, 103);
            orderPanel.Name = "orderPanel";
            orderPanel.Size = new Size(782, 37);
            orderPanel.TabIndex = 6;
            // 
            // orderData
            // 
            orderData.AllowUserToAddRows = false;
            orderData.AllowUserToDeleteRows = false;
            orderData.AllowUserToResizeColumns = false;
            orderData.AllowUserToResizeRows = false;
            orderData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            orderData.BackgroundColor = SystemColors.ButtonFace;
            orderData.BorderStyle = BorderStyle.None;
            orderData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            orderData.Dock = DockStyle.Fill;
            orderData.GridColor = SystemColors.ControlDark;
            orderData.Location = new Point(0, 0);
            orderData.Name = "orderData";
            orderData.ReadOnly = true;
            orderData.RowHeadersVisible = false;
            orderData.RowHeadersWidth = 51;
            orderData.ScrollBars = ScrollBars.Vertical;
            orderData.Size = new Size(782, 37);
            orderData.TabIndex = 5;
            orderData.DataBindingComplete += OrderData_DataBindingComplete;
            // 
            // orderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(802, 281);
            Controls.Add(orderPanel);
            Controls.Add(panel1);
            Controls.Add(orderButtomPanel);
            Name = "orderForm";
            Padding = new Padding(10);
            Text = "Заказы";
            Resize += OrderForm_Resize;
            orderButtomPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel5_Id.ResumeLayout(false);
            panel4_Weight.ResumeLayout(false);
            panel3_District.ResumeLayout(false);
            panel2_Data.ResumeLayout(false);
            panel3_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)districtBindingSource).EndInit();
            orderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderData).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel orderButtomPanel;
        private Button orderAddButton;
        private Button fileButton;
        private Panel panel1;
        private Panel orderPanel;
        private DataGridView orderData;
        private DateTimePicker dateTimeInterval2;
        private Panel panel3_Data;
        private Button expandSortBtn;
        private Button expandCloseBtn;
        private Button dateSort;
        private DateTimePicker dateTimeInterval1;
        private Panel panel2_Data;
        private Panel panel5_Id;
        private Button idSort;
        private Panel panel4_Weight;
        private Button weightSort;
        private Panel panel3_District;
        private Button districtBtn;
        private ComboBox districtSortBox;
        private BindingSource districtBindingSource;
        private Button districtSort;
    }
}
