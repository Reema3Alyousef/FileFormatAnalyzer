using System;
using System.IO;

namespace day001
{
    class Program
    {
        static void Main(string[] args)
        {
            string imagePath;
            
            Console.WriteLine("---------------------------");
            Console.WriteLine("Enter a png image file path");
            try
            {
                imagePath = Console.ReadLine();
                DisplayValues(imagePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public static void DisplayValues(string path)
        {
            const string pngMagic = "89-50-4E-47-0D-0A-1A-0A";

            if (File.Exists(path))
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(Convert.ToString(path), FileMode.Open)))
                {
                    string magicNumber = BitConverter.ToString(reader.ReadBytes(0x8));
                    if (magicNumber.Equals(pngMagic))
                    {
                        Console.WriteLine("file type is PNG");
                        reader.ReadBytes(0x8);
                        int width = Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x4)).Replace("-", ""), 16);
                        int height = Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x4)).Replace("-", ""), 16);
                        int depth = Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x1)).Replace("-", ""), 16);
                        int colorType = Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x1)).Replace("-", ""),
                            16);
                        int compressionMethod =
                            Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x1)).Replace("-", ""), 16);
                        int filterMethod =
                            Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x1)).Replace("-", ""), 16);
                        int interlaceMethod =
                            Convert.ToInt32(BitConverter.ToString(reader.ReadBytes(0x1)).Replace("-", ""), 16);


                        Console.WriteLine($"width {width}");
                        Console.WriteLine($"height {height}");
                        Console.WriteLine($"depth {depth}");
                        Console.WriteLine($"color type {colorType}");
                        Console.WriteLine($"compression meth {compressionMethod}");
                        Console.WriteLine($"filter meth {filterMethod}");
                        Console.WriteLine($"Interlace method {interlaceMethod}");
                    }
                    else
                        throw new Exception("Not a valid PNG file");
                }
                
            }
            else
                throw new Exception("File not found");
        }
        
        
    }
}