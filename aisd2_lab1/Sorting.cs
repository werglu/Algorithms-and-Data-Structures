
using System;
using System.Collections.Generic;

namespace ASD
{



public class SortingMethods: MarshalByRefObject
    {

        public int Partition(int l, int r, int[] tab)
        {
            int v = tab[l];
            int i = l;
            int j = r + 1;
            do
            {
                do i++; while (tab[i] < v && i < r);
                do j--; while (tab[j] > v);
                if (i < j)
                {
                    int t = tab[i];
                    tab[i] = tab[j];
                    tab[j] = t;
                }
            } while (i < j);
            tab[l] = tab[j];
            tab[j] = v;
            return j;
        }
        public void Quick(int l, int r, int[] tab)
        {
            int j = Partition(l, r, tab);
            if (j - 1 > l) Quick(l, j - 1, tab);
            if (j + 1 < r) Quick(j + 1, r, tab);
        }
        public int[] QuickSort(int[] A)
        {
            Random rand = new Random();
            int length = A.Length;
            int index, pom;
            for (int i = 0; i < length; i++)
            {
                index = rand.Next(length - 1);
                pom = A[index];
                A[index] = A[i];
                A[i] = pom;
            }
            if (A.Length == 1 || A.Length == 0) return A;
            Quick(0, A.Length - 1, A);
            return A;
        }

        public int[] ShellSort(int[] A)
        {
            int[] tab = new int[A.Length + 1];
            for (int i = 0; i < A.Length; i++)
            {
                tab[i + 1] = A[i];
            }

            int h = 2;
            int n = tab.Length-1;
            while(h-1<n/2)
            {
                h *= 2;
            }
            h--;
            while (h>=1)
            {
                for (int j=h+1; j<=n; j++)
                {
                    int v = tab[j];
                    int i = j - h;
                    while (i>0 && tab[i]>v)
                    {
                        tab[i + h] = tab[i];
                        i -= h;
                    }
                    tab[i + h] = v;
                }
                h = (h + 1) / 2 - 1;
            }

            for (int i = 0; i < A.Length; i++)
            {
                A[i] = tab[i+1];
            }
            return A;
        }


        public int[] CreateHeap(int[] A)
        {
            int nn = A.Length-1 ;
            int n = A.Length-1;
            for (int i = nn / 2; i >= 1; i--)
            { A = DownHeap(i, n, A);
                n = A.Length - 1; }
            return A;
        }
        public int[] DownHeap(int i, int n, int[]A)
        {
            int k = 2 * i;
            int v = A[i];
            while(k<=n)
            {
                if (k + 1 <= n)
                    if (A[k + 1] > A[k])
                        k++;
                if (A[k]>v)
                {
                    A[i] = A[k];
                    i = k;
                    k = 2 * i;
                }
                else
                    break;

            }
            A[i] = v;
            return A;
        }

    public int[] HeapSort(int[] tab)
        {
            if (tab.Length == 1) return tab;
            int[] A =new int[tab.Length+1];
            for (int i=0; i<tab.Length; i++)
            {
                A[i + 1] = tab[i];
            }
         
            A = CreateHeap(A);

            int hl = A.Length - 1;
            while (hl>1)
            {
                int tmp = A[1];
                A[1] = A[hl];
                A[hl] = tmp;
                hl--;
                A=DownHeap(1, hl, A);
            }
            for (int i = 0; i < tab.Length; i++)
            {
               tab[i]= A[i + 1];
            }
            return tab;
        }
        
        public void pom(int l, int r, int[] tab)
        {
            if (l >= r) return ;
            int m = (l + r) / 2;
            if(l<m) pom(l, m, tab);
            if(m+1<r) pom(m + 1, r, tab);
            Merge(l, m, m + 1, r, tab);
    
        }
        public void Merge(int l, int m, int n, int r, int[] tab)
        {
            int[] tab2 = new int[m-l+r-n+1+1];
            
            int i = 0;
            int poz = 0, pozl=l, pozn=n;
            while (pozl<=m && pozn<=r)
            {
                if (tab[pozl]<=tab[pozn])
                {
                    tab2[poz] = tab[pozl];
                    pozl++;
                    poz++;
                }
                else
                {
                    tab2[poz] = tab[pozn];
                    pozn++;
                    poz++;
                }
               
            }
           
            if (pozl <= m)
            {
               
                for (i = pozl; i <= m; i++)
                {
                    tab2[poz] = tab[i];
                    poz++;
                }
            }
            else if (pozn<=r)
            {
                
                for (i = pozn; i <= r; i++)
                {
                    tab2[poz] = tab[i];
                    poz++;
                }
            }

            for (i=l; i<=r;i++)
            tab[i] = tab2[i-l];

    
        }
        public int[] MergeSort(int[] tab)
        {
            if (tab.Length == 0 || tab.Length == 1) return tab;
           
            pom(0, tab.Length-1, tab);
      
            return tab;
        }

    }

}