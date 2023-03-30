using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;

namespace SX.Win.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var arr = new int[] { 1, 10, 2, 3, 7, 4, 3, 1, 2, 8 };
            var result = SortArrayA(arr);
            SortArrayB(arr);
          
            var arr2 = new double[] { 1, 10, 2, 3, 7, 4, 3, 1, 2, 8 };
            var d = CalcStandardDeviation(arr2);

            var e1 = new Element();
            var e2 = new Element();
            var e3 = new Element();
            var e4 = new Element();
            var e5 = new Element();

            e1.Next = e2;
            e2.Next = e3;
                e3.Next = e4;
            e4.Next = e5;
            //e5.Next = e3;

            var d1 = DefineClosedList(e1);

            Console.WriteLine(result.Length);
        }

        public int[] SortArrayA(int[] arr)
        {
            List<int> result = new List<int>();
            foreach (var e in arr)
            {
                if (result.Count <= 0 || result[0] <= e)
                {
                    result.Insert(0, e);
                    continue;
                }

                for (int i = 0; i < result.Count; i++)
                {
                    if (result[i] <= e)
                    {
                        result.Insert(i, e);
                        break;
                    }
                }
            }
            return result.ToArray();
        }

        public void SortArrayB(int[] arr)
        {
            Array.Sort(arr, (a, b) => a < b ? 1 : -1);
        }

        public double CalcStandardDeviation(IEnumerable<double> values)
        {
            if (values == null || !values.Any())
                return 0;

            var average = values.Average();
            return Math.Sqrt(values.Sum(v => Math.Pow(v - average, 2)) / values.Count());
        }

        public bool DefineClosedList(Element? root)
        {
            if (root?.Next == null)
                return false;

            List<Element> visitedNodes = new List<Element>();

            var current = root; 
            while (current.Next != null)
            {
                visitedNodes.Add(current);
                
                current = current.Next;

                if (visitedNodes.Any(n => Object.ReferenceEquals(n, current)))
                    return true;
            }

            return false;
        }

    }

    public class Element
    {
        public Element Next { get; set; }
    }
}