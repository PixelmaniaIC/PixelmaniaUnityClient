using System;

namespace Messages
{
    [Serializable]
    public class SingleColor
    {
        

        public int r;
        public int g;
        public int b;
        public int index;
        // 0 - initial, 1 - changed
        public int status;
    }
}