using System.Collections;

namespace Antiaris.Utilities
{
	public static class SerializationUtils
	{
		public static int GetBitArrayLength(int bitCount)
		{
			return (bitCount - 1) / 8 + 1;
		}

		public static byte[] ToArray(this BitArray bits)
		{
			var bytes = new byte[GetBitArrayLength(bits.Length)];
			bits.CopyTo(bytes, 0);
			return bytes;
		}
	}
}
