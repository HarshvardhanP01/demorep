using System.Text;

namespace Command
{

    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class TextEditor
    {
        private readonly StringBuilder _content=new StringBuilder();

        public void TypeText(string? text)
        {
            _content.Append(text);
            Console.WriteLine($"Current Text: {_content}");
        }

        public void DeleteText(int length)
        {
            if(length<=_content.Length)
            {
                _content.Remove(_content.Length - length,length);
            }
                Console.WriteLine($"Current Text : {_content}");
        }

        public string? GetLastNCharacters(int length)
        {
            if(length<=_content.Length)
            {
                return _content.ToString().Substring(_content.Length - length);
            }
            return string.Empty;
        }
    }

    public class DeleteTextCommand : ICommand
    {
        private readonly TextEditor _textEditor;
        private readonly int _length;
        private string? _deletedText;

        public DeleteTextCommand(TextEditor textEditor,int length)
        {
            this._textEditor = textEditor;
            this._length = length;
        }

        public void Execute()
        {
           _deletedText=_textEditor.GetLastNCharacters(this._length);
            _textEditor.DeleteText(_length);
        }

        public void Undo()
        {
           _textEditor.TypeText(this._deletedText);
        }
    }

    public class TypeTextCommand : ICommand
    {
        private readonly TextEditor _texteditor;
        private readonly string? _text;

        public TypeTextCommand(TextEditor _texteditor, string? _text)
        {
            this._texteditor = _texteditor;
            this._text = _text;
        }
        public void Execute()
        {
           _texteditor.TypeText(_text);
        }

        public void Undo()
        {
            _texteditor.DeleteText(_text.Length);
        }
    }



    public class TextEditorInvoker
    {
        private readonly Stack<ICommand> _commandHistory = new Stack<ICommand>();

        public void ExceuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }


        public void Undo()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand command = _commandHistory.Pop();
                command.Undo();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TextEditor textEditor=new TextEditor();
                TextEditorInvoker textEditorInvoker=new TextEditorInvoker();
                ICommand typeHelloCommand = new TypeTextCommand(textEditor,"Hello ");
                ICommand typeWorldCommand = new TypeTextCommand(textEditor, "World!");

                textEditorInvoker.ExceuteCommand(typeHelloCommand);
                textEditorInvoker.ExceuteCommand(typeWorldCommand);

                textEditorInvoker.Undo();


                textEditorInvoker.ExceuteCommand(typeWorldCommand);

                ICommand deleteCommand = new DeleteTextCommand(textEditor, 6);
                textEditorInvoker.ExceuteCommand(deleteCommand);
                textEditorInvoker.Undo();

            }
        }
}
