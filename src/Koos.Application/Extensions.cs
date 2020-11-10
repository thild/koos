using System;

namespace Koos.Application
{

    public static class Extensions
    {
        /// <summary>
        /// Fill the dest object with the source object.
        /// </summary>
        /// <param name='dest'>
        /// Destination.
        /// </param>
        /// <param name='source'>
        /// Source.
        /// </param>
        /// <typeparam name='TDest'>
        /// The type parameter of filled object.
        /// </typeparam>
        public static TDest Fill<TDest, TSource>(this TDest dest, TSource source)
        {
            // TODO: fix this shit
            Type destType = dest.GetType();
            foreach (var sourceProp in source.GetType().GetProperties())
            {
                var destProp = destType.GetProperty(sourceProp.Name);
                if (destProp == null) continue;
                if (!destProp.PropertyType.IsAssignableFrom(sourceProp.PropertyType)) continue;
                if (!(sourceProp.CanRead || destProp.CanWrite)) continue;
                object boxed = dest;
                destProp.SetValue(boxed, sourceProp.GetValue(source, null), null);
                System.Console.WriteLine(destProp.Name);
                dest = (TDest)boxed;
            }
            return dest;
        }
    }
}