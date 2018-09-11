using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern.Builders
{
    public class HtmlElement
    {
        private const int indentSize = 2;
        public HtmlElement()
        {
            ChildElements = new List<HtmlElement>();
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
            ChildElements = new List<HtmlElement>();
        }
        public string Name { get; set; }
        public string Text { get; set; }
        public List<HtmlElement> ChildElements { get; set; }

        private string ToStringImpl(int indent)
        {
            StringBuilder sb = new StringBuilder();
            var i = new string(' ', indent * indentSize);

            sb.AppendLine($"{i}<{Name}>");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                sb.Append(new string(' ', indent * (indentSize + 1)));
                sb.AppendLine(Text);
            }

            foreach (HtmlElement he in ChildElements)
            {
                sb.AppendLine(he.ToStringImpl(indent + 1));
            }
            sb.AppendLine($"</{Name}>");

            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string rootName;
        HtmlElement rootElement = new HtmlElement();
        public HtmlBuilder(string rootName)
        {
            this.rootName = rootName;
            rootElement.Name = rootName;
        }

        public void AddChild(string name, string text)
        {
            HtmlElement e = new HtmlElement(name, text);
            rootElement.ChildElements.Add(e);
        }

        public HtmlBuilder AddChildFluent(string name, string text)
        {
            HtmlElement e = new HtmlElement(name, text);
            rootElement.ChildElements.Add(e);
            return this;
        }

        public override string ToString()
        {
            return rootElement.ToString();
        }

        public void Clear()
        {
            rootElement.ChildElements.Clear();
        }
    }
}
