using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcLibrary.Extensions
{
    public static class ListExtensions
    {
        public static int MoveItemDown<T>(this IList<T> items, int indexPosition)
        {
            return items.MoveItemDown(indexPosition, 1);
        }

        public static int MoveItemDown<T>(this IList<T> items, int indexPosition, int amount)
        {
            if (items != null && indexPosition >= 0 && indexPosition < items.Count - 1)
            {
                lock (items)
                {
                    if (items != null && indexPosition >= 0 && indexPosition < items.Count - 1)
                    {
                        // TODO: Test in Int32.Max/Min extreme boundary conditions
                        amount = amount < 0 ? 0 : amount;
                        int positionToMoveTo = (indexPosition + amount > (items.Count - 1)) ? (items.Count - 1) : indexPosition + amount;

                        T item = items[indexPosition];
                        items.RemoveAt(indexPosition);
                        items.Insert(positionToMoveTo, item);

                        return positionToMoveTo;
                    }
                }
            }

            return indexPosition;
        }

        public static int MoveItemUp<T>(this IList<T> items, int indexPosition)
        {
            return items.MoveItemUp(indexPosition, 1);
        }

        public static int MoveItemUp<T>(this IList<T> items, int indexPosition, int amount)
        {
            if (items != null && indexPosition > 0 && indexPosition < items.Count)
            {
                lock (items)
                {
                    if (items != null && indexPosition > 0 && indexPosition < items.Count)
                    {
                        amount = amount < 0 ? 0 : amount;
                        int positionToMoveTo = (indexPosition - amount < 0) ? 0 : indexPosition - amount;

                        T item = items[indexPosition];
                        items.RemoveAt(indexPosition);
                        items.Insert(positionToMoveTo, item);

                        return positionToMoveTo;
                    }
                }
            }

            return indexPosition;
        }

        public static bool SafeRemoveAt<T>(this IList<T> items, int indexPosition)
        {
            if (indexPosition >= 0 && indexPosition < items.Count && items.Count > 0)
            {
                lock (items)
                {
                    if (indexPosition >= 0 && indexPosition < items.Count && items.Count > 0)
                    {
                        items.RemoveAt(indexPosition);
                        return true;
                    }
                }
            }

            return false;
        }

        public static void ClearAndAddRange<T>(this IList<T> items, IList<T> itemsToAdd)
        {
            items.Clear();

            foreach (T item in itemsToAdd)
            {
                items.Add(item);
            }
        }
    }
}