// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("YACk20DAyuAMtJ0c+fEC1B2HeHSIJxjJkbrxFmp6sB2OLlb7r9g173udSPQ8URhYock51OWe9Op6t3RfGjOTCetYeYjGDLE1hJ/ieMRL9sUdRd8z3NbyTtXNROtpb7oh5kVPJwJ82AEodxyHkEhAFSTmA/HCoEaUryCUmPECiTVaDULYL4yTt+6nKuxHxMrF9UfEz8dHxMTFTldJSz4I4fVHxOf1yMPM70ONQzLIxMTEwMXGXghYuJcallknzdV+Xk+e7PRG/l16KnjJ9P35sL4XoZmdl3YyHVico7bVcODYPRbye718fu1AYnKtCSFlwhyylGbQ4SAnrHrUnAEqTJy7AQSkSNHkajIxaQ/0uL7vCa2y3QAQTjkMrgn4C69RBsfGxMXE");
        private static int[] order = new int[] { 10,3,4,6,13,12,8,8,10,11,11,11,12,13,14 };
        private static int key = 197;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
