using System;
using OpenTK;
using Matrix3D.Inbuilt;

namespace Matrix3D.Utilities
{
    static class Extension
    {
        public static IList<T> CloneList<T>(this IList<T> listToClone) where T : ICloneable //https://stackoverflow.com/questions/222598/how-do-i-clone-a-generic-list-in-c for deep copying
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
    }
}