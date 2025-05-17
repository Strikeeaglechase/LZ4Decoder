using K4os.Compression.LZ4;
using System.Linq;

namespace LZ4Decoder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Input file: {args[0]}");
            Console.WriteLine($"Output file: {args[1]}");

            var input = File.ReadAllBytes(args[0]);
            var decompressBuffer = new byte[input.Length * 255];

            int decompressSize = LZ4Codec.Decode(input, 0, input.Length, decompressBuffer, 0, decompressBuffer.Length);
            Console.WriteLine($"Compressed size: {input.Length}, decompressed size: {decompressSize}");
            File.WriteAllBytes(args[1], decompressBuffer.SkipLast(decompressBuffer.Length - decompressSize).ToArray());
        }
    }
}
