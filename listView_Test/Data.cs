using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace listView_Test
{
    public static class Data
    {
        public static bool check_correct_inforPackage(byte[] buffer,
                                int size_buffer,
                                ref float[] battery_voltage,
                                ref float[] temperature,
                                int size_data,
                                ref bool[] status_battery,
                                ref bool[] status_voltage,
                                int size_status)
        {
            if (buffer[0] == 'I')
            {
                byte _crc = 0x00;
                for (int i = 0; i < 133; i++) { _crc += buffer[i]; }
                if (_crc == buffer[133] && buffer[134] == '\r')
                {
                    int startIndex = 1;
                    float[] float_data = new float[size_data * 2];
                    int counter = 0;
                    for (int i = startIndex; i < 129; i = i + 4)
                    {
                        float_data[counter++] = BAToSingle(buffer, i, i / 4);
                    }
                    for (int i = 0; i < size_data; i++)
                    {
                        battery_voltage[i] = float_data[i];
                    }
                    for (int i = 0; i < size_data; i++)
                    {
                        temperature[i] = float_data[i + 16];
                    }
                    ByteArrayToBool(new Byte[] { buffer[129], buffer[130] }, 2, ref status_battery, 2 * 8);
                    ByteArrayToBool(new Byte[] { buffer[131], buffer[132] }, 2, ref status_voltage, 2 * 8);
                    return true;
                }
                else return false;
            }
            else
                return false;
        }
         public static bool check_correct_emerPackage(byte[] buffer,
                                              int size_buffer,
                                              ref bool[] emer_bar_1,
                                              ref bool[] emer_bar_2,
                                              int size_bar)
        {
            if (buffer[0] == 'E')
            {
                byte _crc = 0x00;
                for (int i = 0; i < 5; i++) { _crc += buffer[i]; }
                if (_crc == buffer[5] && buffer[6] == '\r')
                {
                    ByteArrayToBool(new Byte[] { buffer[1], buffer[2] }, 2, ref emer_bar_1, size_bar);
                    ByteArrayToBool(new Byte[] { buffer[3], buffer[4] }, 2, ref emer_bar_2, size_bar);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
         public static float BAToSingle(byte[] bytes, int index, int position)
        {
            float value = BitConverter.ToSingle(bytes, index);
            return value;
        }
        public static void ByteArrayToBool(byte[] array, int numberByte, ref bool[] output, int numberBit)
        {
            for (int i = 0; i < numberByte; i++)
            {
                byte mask = 0x01;
                for (int j = 8 * i; j < i * 8 + 8; j++)
                {
                    output[j] = ((byte)(array[i] >> (j % 8)) & mask) == 0x01 ? true : false;
                }
            }
        }
    }
}
