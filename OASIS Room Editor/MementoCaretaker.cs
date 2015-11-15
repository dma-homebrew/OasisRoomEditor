﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OASIS_Room_Editor
{
    // <summary>
    // Class manages the stacks for undo/redo using the memento design pattern 
    // <!summary>

    class MementoCaretaker
    {
        private DropOutStack<RoomMemento> undoStack =new DropOutStack<RoomMemento>(50);
        private DropOutStack<RoomMemento> redoStack=new DropOutStack<RoomMemento>(50);

        public void Clear()
        {
            undoStack.Clear();
            redoStack.Clear();
        }

        public RoomMemento Undo(RoomMemento current)
        {
            if (undoStack.Count != 0)
            {
                // Save current memento in redo
                redoStack.Push(current);
                RoomMemento m = undoStack.Pop();
                return m;
            }
            else
                return null;
        }

        public RoomMemento Redo(RoomMemento current)
        {
            if (redoStack.Count != 0)
            {
                // Save current memento in undo
                undoStack.Push(current);
                RoomMemento m = redoStack.Pop();                
                return m;
            }
            else
                return null;
        }

        public void NewCheckPoint(RoomMemento rm)
        {
            undoStack.Push(rm);
        }

    }
}