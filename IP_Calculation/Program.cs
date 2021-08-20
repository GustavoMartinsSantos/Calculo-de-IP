using System;
using System.Net;

namespace IP_Calculation {
    class InvalidSubNetMaskException : Exception {
        public InvalidSubNetMaskException()
            : base("Invalid subnet mask format.") {
        }
    }

    class Program {
        static byte getByte(string binaryString) {
            return Convert.ToByte(Convert.ToInt32(binaryString, 2));
        }

        static string getBinaryString(byte octeto) {
            return Convert.ToString(octeto, 2).PadLeft(8, '0');
        }

        static byte[] getNetMask(int ones) {
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

        static void Main(string[] args) {
            while (true) {
                IPAddress ip;
                IPAddress netMask;
                int numberMask = 0;

                char netMaskClass = '\0';
                int hostsValidos = 1;
                IPAddress firstValidIP;
                IPAddress lastValidIP;
                IPAddress networkIP;
                IPAddress broadcastIP;

                Console.WriteLine("\tCálculo de IPv4");
                Console.WriteLine("\nDigite um IP válido e a máscara de sub-rede para" +
                    " o programa te retornar os seguintes valores: \n" +
                    "1 - IP da Rede;\n" +
                    "2 - IP de Broadcast;\n" +
                    "3 - Quantos IPs estão disponíveis para os hosts;\n" +
                    "4 - O primeiro e o último endereço IPs válidos para essa rede;\n" +
                    "5 - A classe a qual o endereço IP pertence.\n" +
                    "\nPressione enter para prosseguir...");

                Console.ReadKey();
                Console.Clear();

                try {
                    Console.Write("Digite um endereço IPv4: ");
                    ip = IPAddress.Parse(Console.ReadLine());
                    Console.Write("Digite a máscara de sub-rede ou utilize a notação CIDR com /: ");
                    string mask = Console.ReadLine();

                    if (mask.Contains("/")) {
                        numberMask = int.Parse(mask.Substring(1));
                        netMask = new IPAddress(getNetMask(numberMask));
                    } else {
                        netMask = IPAddress.Parse(mask);

                        bool stopAdding = false;
                        foreach (byte octeto in netMask.GetAddressBytes()) {
                            string binaryOcteto = getBinaryString(octeto);

                            for (int x = 0; x < 8; x++) {
                                if (binaryOcteto[x] == '1') {
                                    if (stopAdding) // verificando se a máscara é valida
                                        throw new InvalidSubNetMaskException();
                                    numberMask++;
                                } else
                                    stopAdding = true;
                            }
                        }
                    }

                    switch (numberMask) {
                        case 8: // determinando a classe da máscara
                            netMaskClass = 'A'; break;
                        case 16:
                            netMaskClass = 'B'; break;
                        case 24:
                            netMaskClass = 'C'; break;
                    }

                    byte[] bytesNetworkIP = new byte[4];
                    byte[] bytesBroadcastIP = new byte[4];
                    byte[] bytesFirstValidIP = new byte[4];
                    byte[] bytesLastValidIP = new byte[4];

                    for (int x = 0; x < 4; x++) {
                        string binaryIP = getBinaryString(ip.GetAddressBytes()[x]);
                        string binaryNetMask = getBinaryString(netMask.GetAddressBytes()[x]);

                        string binaryNetworkIP = "";
                        string binaryBroadcastIP = "";

                        //Console.WriteLine(ip.GetAddressBytes()[x] + ": " + binaryIP + " - " + netMask.GetAddressBytes()[x] + ":" + binaryNetMask);

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
                                /*if ((binaryIP[y] == binaryNetMask[y]) && binaryIP[y] == '1') {
                                    binaryNetworkIP += "1";
                                } else {
                                    binaryNetworkIP += "0";
                                    binaryBroadcastIP += "0";
                                    binaryBroadcastIP += binaryIP[y];
                                }*/
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

                    Console.WriteLine("\nIP: " + ip.ToString() +
                        "\nIP da Rede: " + networkIP.ToString() +
                        "\nIP de Broadcast: " + broadcastIP.ToString() +
                        "\nMáscara de sub-rede: " + netMask.ToString() +
                        "\nNúmero de hosts válidos: " + hostsValidos +
                        "\nPrimeiro IP válido: " + firstValidIP.ToString() +
                        "\nÚltimo IP válido: " + lastValidIP.ToString() +
                        "\nClasse da Rede: " + netMaskClass);

                    Console.Write("\nDeseja continuar? [S/N] ");
                    string continuar = Console.ReadLine().ToLower();

                    if (continuar == "não" || continuar == "n")
                        break;
                    Console.Clear();
                } catch (InvalidSubNetMaskException) {
                    Console.WriteLine("\nMáscara de sub-rede inválida.\n");
                    continue;
                } catch (FormatException) {
                    Console.WriteLine("\nFormato de IPv4 inválido.\n");
                    continue;
                } catch (Exception e) {
                    Console.WriteLine("\nErro " + e.ToString() + ": " + e.Message + "\n");
                }
            }
        }
    }
}
