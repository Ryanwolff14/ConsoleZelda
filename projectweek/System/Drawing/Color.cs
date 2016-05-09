namespace System.Drawing
{
    public class Color
    {
        public uint B { get; internal set; }
        public uint G { get; internal set; }
        public uint R { get; internal set; }

        internal static Color GetColor(int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }
    }
}