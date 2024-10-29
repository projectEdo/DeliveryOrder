namespace DeliveryOrder
{
    partial class orderAddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            dateTimeOrder = new DateTimePicker();
            districtBox = new TextBox();
            weightBox = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimeOrder);
            panel1.Controls.Add(districtBox);
            panel1.Controls.Add(weightBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(339, 180);
            panel1.TabIndex = 0;
            // 
            // dateTimeOrder
            // 
            dateTimeOrder.CustomFormat = "yyyy:MM:dd HH:mm:ss";
            dateTimeOrder.Format = DateTimePickerFormat.Custom;
            dateTimeOrder.Location = new Point(108, 124);
            dateTimeOrder.Name = "dateTimeOrder";
            dateTimeOrder.ShowUpDown = true;
            dateTimeOrder.Size = new Size(205, 27);
            dateTimeOrder.TabIndex = 11;
            // 
            // districtBox
            // 
            districtBox.Location = new Point(108, 70);
            districtBox.Name = "districtBox";
            districtBox.Size = new Size(205, 27);
            districtBox.TabIndex = 10;
            districtBox.KeyPress += districtBox_KeyPress;
            // 
            // weightBox
            // 
            weightBox.Location = new Point(108, 22);
            weightBox.Name = "weightBox";
            weightBox.Size = new Size(205, 27);
            weightBox.TabIndex = 9;
            weightBox.KeyPress += textBox3_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label5.Location = new Point(44, 24);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 8;
            label5.Text = "Вес:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label3.Location = new Point(32, 124);
            label3.Name = "label3";
            label3.Size = new Size(70, 25);
            label3.TabIndex = 5;
            label3.Text = "Дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(17, 72);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 3;
            label2.Text = "Район:";
            // 
            // button1
            // 
            button1.Location = new Point(106, 177);
            button1.Name = "button1";
            button1.Size = new Size(144, 52);
            button1.TabIndex = 1;
            button1.Text = "Добавить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // orderAddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(339, 255);
            Controls.Add(button1);
            Controls.Add(panel1);
            Name = "orderAddForm";
            Text = "orderAddForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label3;
        private Label label2;
        private TextBox weightBox;
        private Label label5;
        private TextBox districtBox;
        private DateTimePicker dateTimeOrder;
    }
}