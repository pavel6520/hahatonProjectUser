﻿namespace Project
{
    partial class SendRepForm
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
            this.components = new System.ComponentModel.Container();
            this.CBinst = new System.Windows.Forms.ComboBox();
            this.GroupBoxKPI = new System.Windows.Forms.GroupBox();
            this.Breset = new System.Windows.Forms.Button();
            this.LabelWorkplaces1 = new System.Windows.Forms.Label();
            this.LabelNumber1 = new System.Windows.Forms.Label();
            this.LabelWorkplaces = new System.Windows.Forms.Label();
            this.LabelNumber = new System.Windows.Forms.Label();
            this.LabelProceeds = new System.Windows.Forms.Label();
            this.LabelProceeds1 = new System.Windows.Forms.Label();
            this.TBparam3 = new System.Windows.Forms.TextBox();
            this.TBparam2 = new System.Windows.Forms.TextBox();
            this.TBparam1 = new System.Windows.Forms.TextBox();
            this.LabelCompName = new System.Windows.Forms.Label();
            this.LabelINN = new System.Windows.Forms.Label();
            this.LabelInst = new System.Windows.Forms.Label();
            this.Send = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CB_INN = new System.Windows.Forms.ComboBox();
            this.TBcompName = new System.Windows.Forms.TextBox();
            this.TBYear = new System.Windows.Forms.TextBox();
            this.CBQuarter = new System.Windows.Forms.ComboBox();
            this.LabelQuarter = new System.Windows.Forms.Label();
            this.TimerUpdateDateTime = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.BresetAll = new System.Windows.Forms.Button();
            this.GroupBoxKPI.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBinst
            // 
            this.CBinst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBinst.FormattingEnabled = true;
            this.CBinst.Items.AddRange(new object[] {
            "Фонд Микрофинансирования",
            "Гарантийный фонд",
            "Центр кластерного развития",
            "Центр поддержки предпринимательства",
            "Центр экспорта"});
            this.CBinst.Location = new System.Drawing.Point(140, 60);
            this.CBinst.Name = "CBinst";
            this.CBinst.Size = new System.Drawing.Size(238, 21);
            this.CBinst.TabIndex = 2;
            this.CBinst.SelectionChangeCommitted += new System.EventHandler(this.CB1_SelectionChangeCommitted);
            // 
            // GroupBoxKPI
            // 
            this.GroupBoxKPI.Controls.Add(this.Breset);
            this.GroupBoxKPI.Controls.Add(this.LabelWorkplaces1);
            this.GroupBoxKPI.Controls.Add(this.LabelNumber1);
            this.GroupBoxKPI.Controls.Add(this.LabelWorkplaces);
            this.GroupBoxKPI.Controls.Add(this.LabelNumber);
            this.GroupBoxKPI.Controls.Add(this.LabelProceeds);
            this.GroupBoxKPI.Controls.Add(this.LabelProceeds1);
            this.GroupBoxKPI.Controls.Add(this.TBparam3);
            this.GroupBoxKPI.Controls.Add(this.TBparam2);
            this.GroupBoxKPI.Controls.Add(this.TBparam1);
            this.GroupBoxKPI.Location = new System.Drawing.Point(10, 86);
            this.GroupBoxKPI.Name = "GroupBoxKPI";
            this.GroupBoxKPI.Size = new System.Drawing.Size(365, 103);
            this.GroupBoxKPI.TabIndex = 3;
            this.GroupBoxKPI.TabStop = false;
            this.GroupBoxKPI.Text = "Параметры KPI";
            // 
            // Breset
            // 
            this.Breset.Location = new System.Drawing.Point(284, 12);
            this.Breset.Name = "Breset";
            this.Breset.Size = new System.Drawing.Size(75, 23);
            this.Breset.TabIndex = 17;
            this.Breset.Text = "Сбросить";
            this.toolTip1.SetToolTip(this.Breset, "Сбросить параметры выбранного фонда");
            this.Breset.UseVisualStyleBackColor = true;
            this.Breset.Click += new System.EventHandler(this.Breset_Click);
            // 
            // LabelWorkplaces1
            // 
            this.LabelWorkplaces1.AutoSize = true;
            this.LabelWorkplaces1.Location = new System.Drawing.Point(221, 51);
            this.LabelWorkplaces1.Name = "LabelWorkplaces1";
            this.LabelWorkplaces1.Size = new System.Drawing.Size(23, 13);
            this.LabelWorkplaces1.TabIndex = 7;
            this.LabelWorkplaces1.Text = "шт.";
            // 
            // LabelNumber1
            // 
            this.LabelNumber1.AutoSize = true;
            this.LabelNumber1.Location = new System.Drawing.Point(221, 22);
            this.LabelNumber1.Name = "LabelNumber1";
            this.LabelNumber1.Size = new System.Drawing.Size(27, 13);
            this.LabelNumber1.TabIndex = 6;
            this.LabelNumber1.Text = "чел.";
            // 
            // LabelWorkplaces
            // 
            this.LabelWorkplaces.AutoSize = true;
            this.LabelWorkplaces.Location = new System.Drawing.Point(10, 51);
            this.LabelWorkplaces.Name = "LabelWorkplaces";
            this.LabelWorkplaces.Size = new System.Drawing.Size(145, 13);
            this.LabelWorkplaces.TabIndex = 4;
            this.LabelWorkplaces.Text = "Созданные рабочие места:";
            // 
            // LabelNumber
            // 
            this.LabelNumber.AutoSize = true;
            this.LabelNumber.Location = new System.Drawing.Point(11, 22);
            this.LabelNumber.Name = "LabelNumber";
            this.LabelNumber.Size = new System.Drawing.Size(144, 13);
            this.LabelNumber.TabIndex = 3;
            this.LabelNumber.Text = "Численность сотрудников:";
            // 
            // LabelProceeds
            // 
            this.LabelProceeds.AutoSize = true;
            this.LabelProceeds.Location = new System.Drawing.Point(102, 77);
            this.LabelProceeds.Name = "LabelProceeds";
            this.LabelProceeds.Size = new System.Drawing.Size(53, 13);
            this.LabelProceeds.TabIndex = 5;
            this.LabelProceeds.Text = "Выручка:";
            // 
            // LabelProceeds1
            // 
            this.LabelProceeds1.AutoSize = true;
            this.LabelProceeds1.Location = new System.Drawing.Point(221, 77);
            this.LabelProceeds1.Name = "LabelProceeds1";
            this.LabelProceeds1.Size = new System.Drawing.Size(30, 13);
            this.LabelProceeds1.TabIndex = 8;
            this.LabelProceeds1.Text = "млн.";
            // 
            // TBparam3
            // 
            this.TBparam3.Location = new System.Drawing.Point(161, 74);
            this.TBparam3.Name = "TBparam3";
            this.TBparam3.Size = new System.Drawing.Size(58, 20);
            this.TBparam3.TabIndex = 12;
            this.TBparam3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBparam3_KeyPress);
            // 
            // TBparam2
            // 
            this.TBparam2.Location = new System.Drawing.Point(161, 48);
            this.TBparam2.Name = "TBparam2";
            this.TBparam2.Size = new System.Drawing.Size(58, 20);
            this.TBparam2.TabIndex = 1;
            this.TBparam2.Tag = "1";
            this.TBparam2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBparam2_KeyPress);
            // 
            // TBparam1
            // 
            this.TBparam1.Location = new System.Drawing.Point(161, 19);
            this.TBparam1.Name = "TBparam1";
            this.TBparam1.Size = new System.Drawing.Size(58, 20);
            this.TBparam1.TabIndex = 16;
            this.TBparam1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBparam1_KeyPress);
            // 
            // LabelCompName
            // 
            this.LabelCompName.AutoSize = true;
            this.LabelCompName.Location = new System.Drawing.Point(6, 10);
            this.LabelCompName.Name = "LabelCompName";
            this.LabelCompName.Size = new System.Drawing.Size(128, 13);
            this.LabelCompName.TabIndex = 4;
            this.LabelCompName.Text = "Название организации:";
            // 
            // LabelINN
            // 
            this.LabelINN.AutoSize = true;
            this.LabelINN.Location = new System.Drawing.Point(100, 37);
            this.LabelINN.Name = "LabelINN";
            this.LabelINN.Size = new System.Drawing.Size(34, 13);
            this.LabelINN.TabIndex = 5;
            this.LabelINN.Text = "ИНН:";
            // 
            // LabelInst
            // 
            this.LabelInst.AutoSize = true;
            this.LabelInst.Location = new System.Drawing.Point(19, 63);
            this.LabelInst.Name = "LabelInst";
            this.LabelInst.Size = new System.Drawing.Size(115, 13);
            this.LabelInst.TabIndex = 6;
            this.LabelInst.Text = "Институт поддержки:";
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(154, 262);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(79, 23);
            this.Send.TabIndex = 19;
            this.Send.Text = "Отправить";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Год:";
            // 
            // CB_INN
            // 
            this.CB_INN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_INN.FormattingEnabled = true;
            this.CB_INN.Location = new System.Drawing.Point(140, 7);
            this.CB_INN.Name = "CB_INN";
            this.CB_INN.Size = new System.Drawing.Size(238, 21);
            this.CB_INN.TabIndex = 23;
            this.CB_INN.SelectedIndexChanged += new System.EventHandler(this.CB_INN_SelectedIndexChanged);
            // 
            // TBcompName
            // 
            this.TBcompName.Location = new System.Drawing.Point(140, 34);
            this.TBcompName.Name = "TBcompName";
            this.TBcompName.ReadOnly = true;
            this.TBcompName.Size = new System.Drawing.Size(131, 20);
            this.TBcompName.TabIndex = 26;
            // 
            // TBYear
            // 
            this.TBYear.Location = new System.Drawing.Point(44, 235);
            this.TBYear.MaxLength = 4;
            this.TBYear.Name = "TBYear";
            this.TBYear.Size = new System.Drawing.Size(32, 20);
            this.TBYear.TabIndex = 27;
            this.TBYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TBYear_KeyPress);
            // 
            // CBQuarter
            // 
            this.CBQuarter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBQuarter.FormattingEnabled = true;
            this.CBQuarter.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CBQuarter.Location = new System.Drawing.Point(140, 235);
            this.CBQuarter.Name = "CBQuarter";
            this.CBQuarter.Size = new System.Drawing.Size(121, 21);
            this.CBQuarter.TabIndex = 28;
            this.CBQuarter.SelectedIndexChanged += new System.EventHandler(this.CBQuarter_SelectedIndexChanged);
            // 
            // LabelQuarter
            // 
            this.LabelQuarter.AutoSize = true;
            this.LabelQuarter.Location = new System.Drawing.Point(82, 238);
            this.LabelQuarter.Name = "LabelQuarter";
            this.LabelQuarter.Size = new System.Drawing.Size(52, 13);
            this.LabelQuarter.TabIndex = 29;
            this.LabelQuarter.Text = "Квартал:";
            // 
            // TimerUpdateDateTime
            // 
            this.TimerUpdateDateTime.Enabled = true;
            this.TimerUpdateDateTime.Interval = 1000;
            this.TimerUpdateDateTime.Tick += new System.EventHandler(this.TimerUpdateDateTime_Tick);
            // 
            // BresetAll
            // 
            this.BresetAll.Location = new System.Drawing.Point(281, 195);
            this.BresetAll.Name = "BresetAll";
            this.BresetAll.Size = new System.Drawing.Size(94, 23);
            this.BresetAll.TabIndex = 30;
            this.BresetAll.Text = "Сбросить все";
            this.BresetAll.UseVisualStyleBackColor = true;
            this.BresetAll.Click += new System.EventHandler(this.BresetAll_Click);
            // 
            // SendRepForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(387, 297);
            this.Controls.Add(this.BresetAll);
            this.Controls.Add(this.LabelQuarter);
            this.Controls.Add(this.CBQuarter);
            this.Controls.Add(this.TBYear);
            this.Controls.Add(this.TBcompName);
            this.Controls.Add(this.CB_INN);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.LabelInst);
            this.Controls.Add(this.LabelINN);
            this.Controls.Add(this.LabelCompName);
            this.Controls.Add(this.CBinst);
            this.Controls.Add(this.GroupBoxKPI);
            this.MaximizeBox = false;
            this.Name = "SendRepForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Отчет";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SendRepForm_FormClosed);
            this.Load += new System.EventHandler(this.SendRepForm_Load);
            this.GroupBoxKPI.ResumeLayout(false);
            this.GroupBoxKPI.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox CBinst;
        private System.Windows.Forms.GroupBox GroupBoxKPI;
        private System.Windows.Forms.TextBox TBparam2;
        private System.Windows.Forms.Label LabelProceeds;
        private System.Windows.Forms.Label LabelWorkplaces;
        private System.Windows.Forms.Label LabelNumber;
        private System.Windows.Forms.Label LabelCompName;
        private System.Windows.Forms.Label LabelINN;
        private System.Windows.Forms.Label LabelInst;
        private System.Windows.Forms.Label LabelProceeds1;
        private System.Windows.Forms.Label LabelWorkplaces1;
        private System.Windows.Forms.Label LabelNumber1;
        private System.Windows.Forms.TextBox TBparam3;
        private System.Windows.Forms.TextBox TBparam1;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CB_INN;
        private System.Windows.Forms.TextBox TBcompName;
        private System.Windows.Forms.TextBox TBYear;
        private System.Windows.Forms.ComboBox CBQuarter;
        private System.Windows.Forms.Label LabelQuarter;
        private System.Windows.Forms.Timer TimerUpdateDateTime;
        private System.Windows.Forms.Button Breset;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button BresetAll;
    }
}