using UnityEngine;

namespace Messages
{
    public class SquarePayload
    {
        public SquarePayload(Color foregroundColor, int index)
        {
            this.r = foregroundColor.r;
            this.g = foregroundColor.g;
            this.b = foregroundColor.b;
            Index = index;
        }

        public float r;
        public float g;
        public float b;
        public int Index;

        public override string ToString()
        {
            Color32 color = new Color(r, g, b);
            Debug.Log("Sending colors " + color);
            return string.Format("{{ \"r\": {0}, \"g\": {1}, \"b\": {2}, \"index\": {3} }}", color.r, color.g, color.b, Index);
        }
    }
}