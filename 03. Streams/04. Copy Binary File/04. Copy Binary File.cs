using System;
using System.IO;

namespace _04._Copy_Binary_File
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream streamFrom = new FileStream(@"..\Resources\copyMe.PNG", FileMode.Open);
            FileStream streamTo = new FileStream(@"..\Resources\copyMeCopy.PNG", FileMode.Create);

            using (streamFrom)
            {
                using (streamTo)
                {
                    while (streamFrom.Position < streamFrom.Length)
                    {
                        streamTo.WriteByte((byte)streamFrom.ReadByte());
                    }
                }
            }
        }
    }
}
