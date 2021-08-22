using System;
using System.Net;

namespace IP_Calculation_Forms {
    class CalculoIP {
        public IPAddress ip;
        public IPAddress netMask;
        public int numberMask = 0;
        public char netMaskClass;
        public int hostsValidos = 1;
        public IPAddress firstValidIP;
        public IPAddress lastValidIP;
        public IPAddress networkIP;
        public IPAddress broadcastIP;

        static byte getByte(string binaryString) {
            return Convert.ToByte(Convert.ToInt32(binaryString, 2));
        }

        static string getBinaryString(byte octeto) {
            return Convert.ToString(octeto, 2).PadLeft(8, '0');
        }

        public static byte[] getNetMask(int ones) {
            byte[] octetos = new byte[4];

            for (int x = 0; x < 4; x++) {
                if ((ones - 8) < 0) {
                    string lastByte = "";
                    while (ones > 0) {
                        lastByte += "1";
                        ones -= 1;
                    }

                    for (int y = lastByte.Length; y < 8; y++)
                        lastByte += "0";

                    octetos[x] = getByte(lastByte);
                } else {
                    ones -= 8;
                    octetos[x] = 255;
                }
            }

            return octetos;
        }

        public CalculoIP (byte[] ip, int numberMask) {
            this.ip = new IPAddress(ip);
            this.numberMask = numberMask;
            this.netMask = new IPAddress(getNetMask(numberMask));

            switch (numberMask) {
                case 8: // determinando a classe da máscara
                    this.netMaskClass = 'A'; break;
                case 16:
                    this.netMaskClass = 'B'; break;
                case 24:
                    this.netMaskClass = 'C'; break;
            }
        }

        public void calcIPs() {
            byte[] bytesNetworkIP = new byte[4];
            byte[] bytesBroadcastIP = new byte[4];
            byte[] bytesFirstValidIP = new byte[4];
            byte[] bytesLastValidIP = new byte[4];

            for (int x = 0; x < 4; x++) {
                string binaryIP = getBinaryString(ip.GetAddressBytes()[x]);
                string binaryNetMask = getBinaryString(netMask.GetAddressBytes()[x]);

                string binaryNetworkIP = "";
                string binaryBroadcastIP = "";

                if (binaryNetMask != "11111111") {
                    for (int y = 0; y < 8; y++) { // cálculo do endereço IP da rede
                        if (binaryNetMask[y] == '1') {
                            binaryNetworkIP += binaryIP[y];
                            binaryBroadcastIP += binaryIP[y];
                        } else {
                            hostsValidos *= 2;
                            binaryNetworkIP += "0";
                            binaryBroadcastIP += "1";
                        }
                    }
                } else {
                    binaryNetworkIP = binaryIP;
                    binaryBroadcastIP = binaryIP;
                }

                bytesNetworkIP[x] = getByte(binaryNetworkIP);
                bytesBroadcastIP[x] = getByte(binaryBroadcastIP);
                bytesFirstValidIP[x] = bytesNetworkIP[x];
                bytesLastValidIP[x] = bytesBroadcastIP[x];
            }

            if (hostsValidos > 2) {
                bytesFirstValidIP[3] += 1;
                bytesLastValidIP[3] -= 1;
            }

            networkIP = new IPAddress(bytesNetworkIP);
            broadcastIP = new IPAddress(bytesBroadcastIP);
            firstValidIP = new IPAddress(bytesFirstValidIP);
            lastValidIP = new IPAddress(bytesLastValidIP);
            hostsValidos -= 2;

            if (hostsValidos < 0)
                hostsValidos = 0;
        }
    }
}
