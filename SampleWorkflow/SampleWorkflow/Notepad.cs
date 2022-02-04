using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;
using FlaUI.Core;
using FlaUI.UIA3;
using FlaUI.Core.Conditions;
using FlaUI.Core.AutomationElements;

namespace SampleWorkflow
{

    public sealed class Notepad : CodeActivity
    {
        // Определите входной аргумент действия типа string
        public InArgument<string> Text { get; set; }

        // Если действие возвращает значение, создайте класс, производный от CodeActivity<TResult>
        // и верните значение из метода Execute.
        protected override void Execute(CodeActivityContext context)
        {
            // Start Application
            var app = Application.Launch("notepad.exe");

            var window = app.GetMainWindow(new UIA3Automation());
            Console.WriteLine(window.Title);
            
            ConditionFactory cf = new ConditionFactory(new UIA3PropertyLibrary());
            window.FindFirstDescendant(cf.ByName("Текстовый редактор")).AsTextBox().Enter("Hello World");

            Console.ReadLine();

        }
    }
}
