using Force.DeepCloner;
using System;


namespace RAMApi.Utilities
{
    public static class CloneHelper
    {
        public static T DeepClone<T>(T originalobject)
        {
            if (originalobject != null)
                return originalobject.DeepClone();
            else
                return
                    originalobject;
        }

        public static T ShallowClone<T>(T originalobject)
        {
            if (originalobject != null)
                return originalobject.ShallowClone();
            else
                return
                    originalobject;
        }
    }
}
