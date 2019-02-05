﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Newtonsoft.Json;

public struct Report
{
    public int[] param1;
    public int[] param2;
    public double[] param3;
}

struct INN_Comp
{
    public struct Body_Element
    {
        public string INN, Comp_name;

        public Body_Element(string inn, string name)
        {
            INN = inn;
            Comp_name = name;
        }
    }

    public List<Body_Element> body;

    public INN_Comp(List<Body_Element> mas)
    {
        body = mas;
    }
}

namespace hahatonProjectUser
{
    public partial class SendReportForm : Form
    {
        private List<INN_Comp.Body_Element> inn_comp;
        private DateTime dateNow;
        private int dateNowCountTime = 60;
        private int SelectInst;        
        private Report ValParams;
        DateTime Quarter;

        private bool SaveParam()
        {
            try
            {
                if(Convert.ToInt32(TBparam1.Text) < 0)
                {
                    MessageBox.Show("Неверное значение параметра\n\"Численность сотрудников\"\nНе может быть меньше нуля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CBinst.SelectedIndex = SelectInst;
                    return false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверное значение параметра\n\"Численность сотрудников\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBinst.SelectedIndex = SelectInst;
                return false;
            }

            try
            {
                Convert.ToInt32(TBparam2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверное значение параметра\n\"Созданные рабочие места\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBinst.SelectedIndex = SelectInst;
                return false;
            }

            try
            {
                Convert.ToDouble(TBparam3.Text.Replace('.', ','));
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверное значение параметра\n\"Выручка\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CBinst.SelectedIndex = SelectInst;
                return false;
            }

            ValParams.param1[SelectInst] = Convert.ToInt32(TBparam1.Text);
            ValParams.param2[SelectInst] = Convert.ToInt32(TBparam2.Text);
            ValParams.param3[SelectInst] = Convert.ToDouble(TBparam3.Text.Replace('.',','));

            SelectInst = CBinst.SelectedIndex;

            TBparam1.Text = ValParams.param1[CBinst.SelectedIndex].ToString();
            TBparam2.Text = ValParams.param2[CBinst.SelectedIndex].ToString().Replace(',', '.');

            if (ValParams.param3[CBinst.SelectedIndex] == 0.0)
            {
                TBparam3.Text = "0.0";
            }
            else
            {
                TBparam3.Text = ValParams.param3[CBinst.SelectedIndex].ToString();
            }

            return true;
        }
        
        public SendReportForm()
        {
            InitializeComponent();
        }

        private void TimerUpdateDateTime_Tick(object sender, EventArgs e)
        {
            if(dateNowCountTime >= 60)
            {
                try {
                    dateNow = GetNetworkTime();
                }
                catch (SocketException)
                {
                    dateNowCountTime = 0;
                    dateNow = dateNow.AddSeconds(1);
                    MessageBox.Show("Ошибка интернет-соединения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                dateNowCountTime = 0;
            }
            else
            {
                dateNow = dateNow.AddSeconds(1);
            }
            dateNowCountTime++;
        }

        public static DateTime GetNetworkTime()
        {
            const string ntpServer = "time.windows.com";
            var ntpData = new byte[48];
            ntpData[0] = 0x1B;
            var addresses = Dns.GetHostEntry(ntpServer).AddressList;
            var ipEndPoint = new IPEndPoint(addresses[0], 123);
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
                socket.Connect(ipEndPoint);
                socket.Send(ntpData);
                socket.Receive(ntpData);
                socket.Close();
            }
            var intPart = (ulong)ntpData[40] << 24 | (ulong)ntpData[41] << 16 | (ulong)ntpData[42] << 8 | ntpData[43];
            var fractPart = (ulong)ntpData[44] << 24 | (ulong)ntpData[45] << 16 | (ulong)ntpData[46] << 8 | ntpData[47];
            var milliseconds = (intPart * 1000) + ((fractPart * 1000) / 0x100000000L);
            var networkDateTime = (new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddMilliseconds((long)milliseconds);
            return networkDateTime.ToLocalTime();
        }
        
        private void CB1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(SelectInst != CBinst.SelectedIndex)
            {
                SaveParam();
            }
        }

        private void SendRepForm_Load(object sender, EventArgs e)
        {
            dateNow = GetNetworkTime();
            CBinst.SelectedIndex = 0;
            SelectInst = 0;

            Connection.Request(Program.host, "1" + Program.SeparatorChar + JsonConvert.SerializeObject(new Authentication(Program.ConnectForm.login, null)));
            inn_comp = JsonConvert.DeserializeObject<INN_Comp>(Connection.Response()).body;

            for (int i = 0; i < inn_comp.Count; i++)
            {
                CB_INN.Items.Add(inn_comp[i].Comp_name);
            }

            if (CB_INN.Items.Count == 0)
            {
                MessageBox.Show("На ваш аккаунт не зарегистрировано ни одной компании.\nОбратитесь к администратору.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            ValParams.param1 = new int[] { 0, 0, 0, 0, 0 };
            ValParams.param2 = new int[] { 0, 0, 0, 0, 0 };
            ValParams.param3 = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0 };
            CB_INN.SelectedIndex = 0;
            CBQuarter.SelectedIndex = 0;
            int Year = DateTime.Now.Year;
            Quarter = Convert.ToDateTime($"1001.{DateTime.Now.Month}.{DateTime.Now.Day}");
            if (Quarter >= Convert.ToDateTime("1001.1.1") && Quarter < Convert.ToDateTime("1001.03.25"))
            {
                TBYear.Text = $"{Year - 1}";
                CBQuarter.SelectedIndex = 3;
            }
            else if (Quarter >= Convert.ToDateTime("1001.03.25") && Quarter < Convert.ToDateTime("1001.06.25"))
            {
                TBYear.Text = $"{Year}";
                CBQuarter.SelectedIndex = 0;
            }
            else if (Quarter >= Convert.ToDateTime("1001.06.25") && Quarter < Convert.ToDateTime("1001.09.25"))
            {
                TBYear.Text = $"{Year}";
                CBQuarter.SelectedIndex = 1;
            }
            else if (Quarter >= Convert.ToDateTime("1001.09.25") && Quarter < Convert.ToDateTime("1001.12.25"))
            {
                TBYear.Text = $"{Year}";
                CBQuarter.SelectedIndex = 2;
            }
            else
            {
                TBYear.Text = $"{Year}";
                CBQuarter.SelectedIndex = 3;
            }
        }

        private void SendRepForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Connection.Request(Program.host, "2" + Program.SeparatorChar + JsonConvert.SerializeObject(new Authentication(Program.ConnectForm.login, null)));
            }
            catch { }

            Environment.Exit(0);
        }

        private void Send_Click(object sender, EventArgs e)
        {
            if(SaveParam() == false)
            {
                return;
            }

            for (int i = 0; i < 5; i++)
                MessageBox.Show(ValParams.param1[i] + " ; " + ValParams.param2[i] + " ; " + ValParams.param3[i] );

            try
            {
                try
                {
                    if (Convert.ToInt32(TBYear.Text) < 1000)
                    {
                        MessageBox.Show("Неверный формат года", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show($"Неверный формат года", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string Quarter = "";
                switch (CBQuarter.SelectedIndex)
                {
                    case 0:
                        Quarter = $"{TBYear.Text}.03.25";
                        break;
                    case 1:
                        Quarter = $"{TBYear.Text}.06.25";
                        break;
                    case 2:
                        Quarter = $"{TBYear.Text}.09.25";
                        break;
                    case 3:
                        Quarter = $"{TBYear.Text}.12.25";
                        break;
                }

                MessageBox.Show("Quarter == " + Quarter);

                Connection.Request(Program.host, "3" + Program.SeparatorChar + JsonConvert.SerializeObject(ValParams));

                if (Connection.Response() == "1")
                    MessageBox.Show("Успешно отправлено.", "Отправлено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Ошибка отправки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                /*dateNow = GetNetworkTime();
                string query = $"insert into project.`{TBcompName.Text}` value('{Quarter}', '{dateNow.ToString("yyyy.MM.dd HH:mm:ss")}', '" +
                    $"{ValParams.param1[0]}', '{ValParams.param2[0]}', '" +
                    $"{ValParams.param3[0].ToString("G", CultureInfo.InvariantCulture)}', '" +
                    $"{ValParams.param1[1]}', '{ValParams.param2[1]}', '" +
                    $"{ValParams.param3[1].ToString("G", CultureInfo.InvariantCulture)}', '" +
                    $"{ValParams.param1[2]}', '{ValParams.param2[2]}', '" +
                    $"{ValParams.param3[2].ToString("G", CultureInfo.InvariantCulture)}', '" +
                    $"{ValParams.param1[3]}', '{ValParams.param2[3]}', '" +
                    $"{ValParams.param3[3].ToString("G", CultureInfo.InvariantCulture)}', '" +
                    $"{ValParams.param1[4]}', '{ValParams.param2[4]}', '" +
                    $"{ValParams.param3[4].ToString("G", CultureInfo.InvariantCulture)}')";*/
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка отправки\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void CB_INN_SelectedIndexChanged(object sender, EventArgs e)
        {
            TBcompName.Text = inn_comp[CB_INN.SelectedIndex].INN;
        }
        
        private void CBQuarter_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Breset_Click(object sender, EventArgs e)
        {
            TBparam1.Text = "0";
            TBparam2.Text = "0";
            TBparam3.Text = "0.0";
            ValParams.param1[CBinst.SelectedIndex] = 0;
            ValParams.param2[CBinst.SelectedIndex] = 0;
            ValParams.param3[CBinst.SelectedIndex] = 0.0;
        }

        private void BresetAll_Click(object sender, EventArgs e)
        {
            TBparam1.Text = "0";
            TBparam2.Text = "0";
            TBparam3.Text = "0.0";
            ValParams.param1 = new int[] { 0, 0, 0, 0, 0 };
            ValParams.param2 = new int[] { 0, 0, 0, 0, 0 };
            ValParams.param3 = new double[] { 0.0, 0.0, 0.0, 0.0, 0.0 };
        }

        private void TBYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.CharValidation(Validation.ValidationType.IntType, e.KeyChar);
        }

        private void TBparam1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.CharValidation(Validation.ValidationType.IntType, e.KeyChar);
        }

        private void TBparam2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.CharValidation(Validation.ValidationType.IntType, e.KeyChar);
        }

        private void TBparam3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.CharValidation(Validation.ValidationType.DoubleType, e.KeyChar);
        }

        private void TBparam1_Enter(object sender, EventArgs e)
        {
            if (TBparam1.Text == "0")
            {
                TBparam1.Text = "";
            }
        }

        private void TBparam2_Enter(object sender, EventArgs e)
        {
            if (TBparam2.Text == "0")
            {
                TBparam2.Text = "";
            }
        }

        private void TBparam3_Enter(object sender, EventArgs e)
        {
            if (TBparam3.Text == "0.0")
            {
                TBparam3.Text = "";
            }
        }

        private void TBparam1_Leave(object sender, EventArgs e)
        {
            if(TBparam1.Text == "")
            {
                TBparam1.Text = "0";
            }
        }

        private void TBparam2_Leave(object sender, EventArgs e)
        {
            if (TBparam2.Text == "")
            {
                TBparam2.Text = "0";
            }
        }

        private void TBparam3_Leave(object sender, EventArgs e)
        {
            if (TBparam3.Text == "")
            {
                TBparam3.Text = "0.0";
            }
        }

        private void TBparam1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                TBparam2.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                TBparam3.Focus();
            }
        }

        private void TBparam2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                TBparam3.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                TBparam1.Focus();
            }
        }

        private void TBparam3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                TBparam1.Focus();
            }
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                TBparam2.Focus();
            }
        }
    }
}
