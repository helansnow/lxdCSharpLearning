using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class TwoQueuesAsStack <T>
    {
        private Queue<T> _queueA = new Queue<T>();
        private Queue<T> _queueB = new Queue<T>();

        public int Count
        {
            get
            {
                if (_queueA.Count != 0)
                {
                    return _queueA.Count;
                }
                if (_queueB.Count != 0)
                {
                    return _queueB.Count;
                }

                return 0;
            }
        }

        public void Push(T a)
        {
            _queueA.Enqueue(a);
        }

        public T Pop()
        {
            while (_queueA.Count > 1)
            {
                 _queueB.Enqueue(_queueA.Dequeue()); 
            }

            T result = _queueA.Dequeue();

            while (_queueB.Count > 1)
            {
                _queueA.Enqueue(_queueB.Dequeue());
            }

            return result;
        }

        public T Peek()
        {
            while (_queueA.Count > 0)
            {
                _queueB.Enqueue(_queueA.Dequeue());
            }

            T result = _queueA.Peek();

            while (_queueB.Count > 0)
            {
                _queueA.Enqueue(_queueB.Dequeue());
            }

            return result;
        }
    }
}
