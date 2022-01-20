using System.Collections.Generic;

namespace FontSvgImageSource
{
    public class CyclingList<T> : List<T>
    {
        public CyclingList(IEnumerable<T> list):base(list){

        }
        private int index = -1;
        public T Next()
        {
            if (index == -1)
            {
                index = this.Count - 1;
            }
            index = index + 1 == this.Count ? 0 : index + 1;
            return this[index];
        }
    }


}
