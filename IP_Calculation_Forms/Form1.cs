using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace IP_Calculation_Forms {
    public partial class Form : System.Windows.Forms.Form {
        public Form() {
            InitializeComponent();

            for (int x = 8; x <= 32; x++) {
                byte[] buffer = CalculoIP.getNetMask(x);
                comboBoxMasks.Items.Add(
                    buffer[0] + "." +
                    buffer[1] + "." +
                    buffer[2] + "." +
                    buffer[3] + "/" + x);
            }

            comboBoxMasks.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMasks.SelectedIndex = 0;
        }

        private void btn_Clear_Click(object sender, EventArgs e) {
            txt_IP.Clear();
            txt_IP.Focus();
        }

        private void btn_Out_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Deseja sair do programa?", "Sair",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                Close();
            else
                txt_IP.Focus();
        }

        private void txt_IP_Leave(object sender, EventArgs e) {
            if (!txt_IP.MaskCompleted) {
                MessageBox.Show("IP inválido!", "ERRO",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_IP.Focus();
            } else {
                lbl_Results.Text = "IP da Rede:\nIP de Broadcast:\nNúmero de hosts válidos:\n" +
                    "Primeiro IP válido:\nÚltimo IP válido:\nClasse da Rede:";

                try {
                    byte[] ipUser = new byte[4];

                    for (int x = 0; x < 4; x++) {
                        ipUser[x] = byte.Parse(txt_IP.Text.Substring(x * 4, 3));
                    }

                    string netMask = comboBoxMasks.SelectedItem.ToString();
                    int numberMaskPosition = netMask.IndexOf("/") + 1;
                    int numberMask = int.Parse(netMask.Substring(numberMaskPosition, netMask.Length - numberMaskPosition));
                    CalculoIP calc = new CalculoIP(ipUser, numberMask);

                    calc.calcIPs();

                    lbl_Results.Text = "IP da Rede: " + calc.networkIP.ToString() +
                        "\nIP de Broadcast: " + calc.broadcastIP.ToString() +
                        "\nNúmero de hosts válidos: " + calc.hostsValidos +
                        "\nPrimeiro IP válido: " + calc.firstValidIP.ToString() +
                        "\nÚltimo IP válido: " + calc.lastValidIP.ToString() +
                        "\nClasse da Rede: " + calc.netMaskClass;
                } catch (OverflowException) {
                    MessageBox.Show("Formato de IPv4 inválido.", "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (FormatException) {
                    MessageBox.Show("Formato de IPv4 inválido.", "ERRO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message, ex.GetType().Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxMasks_SelectedIndexChanged(object sender, EventArgs e) {
            txt_IP_Leave(sender, e);
        }

        private void txt_IP_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                comboBoxMasks.Focus();
        }

        private void comboBoxMasks_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return)
                btn_Clear.Focus();
        }
    }
}