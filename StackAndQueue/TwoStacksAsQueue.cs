using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class TwoStacksAsQueue<T>
    {
        private Stack<T> _stackA = new Stack<T>();
        private Stack<T> _stackB = new Stack<T>();

        public int Count {
            get { return _stackA.Count; }
        }

        public void EnQueue(T qElement)
        {
            _stackA.Push(qElement); 
        }

        public T DeQueue()
        {
            if(_stackB.Count == 0)
            {
                while (_stackA.Count !=0)
                {
                    _stackB.Push(_stackA.Pop());
                }
            }

            var result = _stackB.Pop();

            return result;
        }

        public T Peek()
        {
            if (_stackB.Count == 0)
            {
                while (_stackA.Count != 0)
                {
                    _stackB.Push(_stackA.Pop());
                }
            }

            var result = _stackB.Peek();

            return result;
        }

        public void Test()
        {
            var myQ = new TwoStacksAsQueue<int>();
            Console.WriteLine("new created myQ, count {0}", myQ.Count);

            myQ.EnQueue(1);
            Console.WriteLine("current head {0}", myQ.Peek());

            myQ.EnQueue(3);
            myQ.EnQueue(5);

            var head =myQ.DeQueue();
            Console.WriteLine("Pop up  {0}", head);
            Console.WriteLine("current head {0}", myQ.Peek());

            Console.ReadLine();
        }
    }
}
