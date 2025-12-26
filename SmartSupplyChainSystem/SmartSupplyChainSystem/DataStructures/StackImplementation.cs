// DataStructures/StackImplementation.cs
using System.Collections.Generic;

namespace SmartSupplyChainSystem.DataStructures
{
    public class UndoRedoStack<T>
    {
        private Stack<T> undoStack;
        private Stack<T> redoStack;

        public UndoRedoStack()
        {
            undoStack = new Stack<T>();
            redoStack = new Stack<T>();
        }

        public void Push(T item)
        {
            undoStack.Push(item);
            redoStack.Clear(); // Clear redo on new action
        }

        public T Undo()
        {
            if (undoStack.Count > 0)
            {
                var item = undoStack.Pop();
                redoStack.Push(item);
                return item;
            }
            return default(T);
        }

        public T Redo()
        {
            if (redoStack.Count > 0)
            {
                var item = redoStack.Pop();
                undoStack.Push(item);
                return item;
            }
            return default(T);
        }

        public bool CanUndo => undoStack.Count > 0;
        public bool CanRedo => redoStack.Count > 0;
    }
}