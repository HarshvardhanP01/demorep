
namespace Memento
{
    public class Memento
    {
        public string Text { get; set; }
        public Memento(string Text)
        {
            this.Text = Text;
        }
    }

    public class TextEditor
    {
        private string _text = string.Empty;
        private readonly Stack<Memento> _undoStack = new Stack<Memento>();
        private readonly Stack<Memento> _redoStack = new Stack<Memento>();


        public void TypeText(string? text)
        {
            SaveState(_undoStack);
            _text += text;
            Console.WriteLine($"Current Text : {_text}");
        }

        public void undo()
        {
            if (_undoStack.Count > 0)
            {
                SaveState(_redoStack);
                Memento memento = _undoStack.Pop();
                _text = memento.Text;
                Console.WriteLine($"Undo : Current State {_text}");
            }
            else
            {
                Console.WriteLine("Nothing to Undo");
            }
        }



        public void redo()
        {
            if (_redoStack.Count > 0)
            {
                SaveState(_undoStack);
                Memento memento = _redoStack.Pop();
                _text = memento.Text;
                Console.WriteLine($"Redo : Current State {_text}");
            }
            else
            {
                Console.WriteLine("Nothing to Redo");
            }
        }

        private void SaveState(Stack<Memento> stack)
        {
            stack.Push(new Memento(_text));
        }
    }
        internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            editor.TypeText("Hi ");
            editor.TypeText("Hello");
            editor.undo();
            editor.undo();
            editor.redo();
            editor.redo();
        }
    }
}
