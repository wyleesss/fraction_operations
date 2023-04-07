namespace Processes    
{
    public static class GCDAndLCMFunctions
    {
        static public int GCD(int x, int y)
        {
            SwapFunctions.SwapIfGreater<int>(ref x, ref y);

            while (x % y != 0)
            {
                x %= y;
                SwapFunctions.Swap<int>(ref x, ref y);
            }

            return y;
        }

        public static int LCM(int x, int y) => (x / GCD(x, y)) * y;
    }

    public static class SwapFunctions
    {
        public static void SwapIfGreater<T>(ref T lhs, ref T rhs) where T : System.IComparable<T>
        {
            T temp;
            if (lhs.CompareTo(rhs) > 0)
            {
                temp = lhs;
                lhs = rhs;
                rhs = temp;
            }
        }

        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
    }
}