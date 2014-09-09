using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    class StackWithMinFuctions
    {
        private Stack<int> _dataStack;
        private Stack<int> _minStack;

        public StackWithMinFuctions()
        {
            _dataStack = new Stack<int>();
            _minStack = new Stack<int>();
        }

        public void StackWithMin_Push(int data)
        {
            _dataStack.Push(data);
            int onTopMin =_dataStack.Peek();
            if (_dataStack.Count == 0 || onTopMin < data)
            {
                _minStack.Push(data);
            }
            else
            {
                _minStack.Push(onTopMin);
            }
        }

        public int StackWithMin_Min()
        {
            if(_dataStack.Count > 0 && _minStack.Count > 0)
                throw  new ArgumentOutOfRangeException();
            return _minStack.Peek();
        }

        public int StackWithMin_Pop()
        {
            if (_dataStack.Count > 0 && _minStack.Count > 0)
                throw new ArgumentOutOfRangeException();
            _minStack.Pop();
            return _dataStack.Pop();
        }
    }
}
