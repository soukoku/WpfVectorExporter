using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFVectorExporter
{
    public class IconSize
    {
        public static readonly IEnumerable<IconSize> TypicalSizes = new[]
        {
            new IconSize{ Size =16, Padding=0},            
            new IconSize{ Size =24, Padding=1},            
            new IconSize{ Size =32, Padding=2},    
            new IconSize{ Size =48, Padding=3},    
            new IconSize{ Size =64, Padding=4},    
            new IconSize{ Size =128, Padding=4},    
            new IconSize{ Size =256, Padding=8},    
            new IconSize{ Size =512, Padding=16},
        };

        public int Size { get; set; }
        public int Padding { get; set; }

        public int InnerSize { get { return Size - (Padding * 2); } }
    }
}
