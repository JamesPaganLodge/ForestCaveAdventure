using RLNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestCaveAdventure.System
{
    public class MessageLog
    {
        // Max lines to store
        private static readonly int _maxLines = 9;

        // Use a Queue so the 1st line added is the 1st removed
        private readonly Queue<string> _lines;

        public MessageLog()
        {
            _lines = new Queue<string>();
        }

        // Add a line to the Queue
        public void Add(string message)
        {
            _lines.Enqueue(message);

            // when we reach _maxLines remove the oldest message
            if (_lines.Count > _maxLines)
            {
                _lines.Dequeue();
            }
        }

        // Draw the messages to the console
        public void Draw(RLConsole console)
        {
            console.Clear();

            string[] lines = _lines.ToArray();

            for (int i = 0; i < lines.Length; i++)
            {
                console.Print(1, i + 1, lines[i], RLColor.White);
            }
        }
    }
}
