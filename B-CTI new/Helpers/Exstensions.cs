using AsteriskManager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BCTI
{

    public static class Extensions
    {
        /// <summary>
        /// Метод для клонирования массивов. Необходим для создания копии массива контактов на блф панели
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listToClone"></param>
        /// <returns></returns>
        public static IList<T> Clone<T>(this IList<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }
        /// <summary>
        /// Пирамидная сортировка
        /// </summary>
        /// <param name="a"></param>
        public static void HeapSort(List<ClientsData> a)
        {
            int i;
            ClientsData temp;

            for (i = a.Count / 2 - 1; i >= 0; i--)
            {
                shiftDown(a, i, a.Count);
            }

            for (i = a.Count - 1; i >= 1; i--)
            {
                temp = a[0];
                a[0] = a[i];
                a[i] = temp;
                shiftDown(a, 0, i);
            }
        }

        public static void shiftDown(List<ClientsData> a, int i, int j)
        {
            bool done = false;
            int maxChild;
            ClientsData temp;

            while ((i * 2 + 1 < j) && (!done))
            {
                if (i * 2 + 1 == j - 1)
                    maxChild = i * 2 + 1;
                else if (a[i * 2 + 1].onBLFposition > a[i * 2 + 2].onBLFposition)
                    maxChild = i * 2 + 1;
                else
                    maxChild = i * 2 + 2;

                if (a[i].onBLFposition < a[maxChild].onBLFposition)
                {
                    temp = a[i];
                    a[i] = a[maxChild];
                    a[maxChild] = temp;
                    i = maxChild;
                }
                else
                {
                    done = true;
                }
            }
        }
        public static List<ClientsData> ShellSort(List<ClientsData> array)
        {
            int gap = array.Count / 2;
            while (gap > 0)
            {
                for (int i = 0; i < array.Count - gap; i++) //modified insertion sort
                {
                    int j = i + gap;
                    ClientsData tmp = array[j];
                    while (j >= gap && tmp.onBLFposition > array[j - gap].onBLFposition)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = tmp;
                }
                if (gap == 2) //change the gap size
                {
                    gap = 1;
                }
                else
                {
                    gap = (int)(gap / 2.2);
                }
            }
            return array;
        }
    }
}
