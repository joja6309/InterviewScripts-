
namespace eBags.PileOfBeans.Haystack
{
    public class Straw
    {
        public decimal LengthInCm { get; private set; }
        public int ColorRed { get; private set; }
        public int ColorGreen { get; private set; }
        public int ColorBlue { get; private set; }

        public Straw(
            decimal lengthInCm,
            int colorRed,
            int colorGreen,
            int colorBlue)
                {
                    LengthInCm = lengthInCm;
                    ColorRed = colorRed;
                    ColorGreen = colorGreen;
                    ColorBlue = colorBlue;
                }
    }
}
