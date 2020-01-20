using System.Collections.Generic;
using System.Linq;

namespace WPFVectorExporter
{
    public class IconSize
    {
        public static IconSize Sample { get { return TypicalSizes.Last(); } }

        public static readonly IEnumerable<IconSize> TypicalSizes = new[]
        {
            new IconSize{ Size =16, Padding=0, Prefix = "favicon-"},            
            //new IconSize{ Size =24, Padding=1},            
            new IconSize{ Size =32, Padding=2, Prefix = "favicon-"},    
            //new IconSize{ Size =48, Padding=3},    
            new IconSize{ Size =60, Padding=4, Prefix = "apple-touch-icon-"},
            new IconSize{ Size =76, Padding=4, Prefix = "apple-touch-icon-"},    
            //new IconSize{ Size =64, Padding=4},    
            new IconSize{ Size =120, Padding=8, Prefix = "apple-touch-icon-"},
            //new IconSize{ Size =128, Padding=8, Prefix = ""},
            new IconSize{ Size =144, Padding=10, Prefix = "msapplication-icon-"},
            new IconSize{ Size =150, Padding=10, Prefix = "mstile-"},
            new IconSize{ Size =152, Padding=10, Prefix = "apple-touch-icon-"},
            new IconSize{ Size =167, Padding=10, Prefix = "favicon-"},
            new IconSize{ Size =180, Padding=16, Prefix = "apple-touch-icon-"},
            new IconSize{ Size =192, Padding=16, Prefix = "android-chrome-"},
            //new IconSize{ Size =256, Padding=16}, 
            new IconSize{ Size =512, Padding=32, Prefix = "android-chrome-"},
        };

        public int Size { get; private set; }
        public int Padding { get; private set; }

        public string Prefix { get; set; }

        public int InnerSize { get { return Size - (Padding * 2); } }
    }
}
