using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    // Класс "Генератор".
    class Generator
    {
        SyntaxTreeNode treeRoot; // Корень синтаксического дерева.
        List<string> outputText; // Выходной текст - список строк.  

        // Конструктор генератора.
        // В качестве параметра поступает корень синтаксического дерева.
        public Generator(SyntaxTreeNode treeRoot)
        {
            this.treeRoot = treeRoot;
            outputText = new List<string>();
        }

        // Выходной текст - свойство только для чтения.
        public List<string> OutputText
        {
            get { return outputText; }
        }

        // Сгенерировать структурированный текст.
        public void GenerateStructuredText()
        {
            outputText.Clear(); // Очищаем выходной текст.
            RecurTraverseTree(treeRoot, 0); // Рекурсивно обходим дерево и формируем выходной текст.
        }

        // Рекурсивно обойти дерево, формируя выходной текст.
        // node - узел дерева.
        // indent - отступ.
        private void RecurTraverseTree(SyntaxTreeNode node, int indent)
        {
            if (node.SubNodes.Count() > 0) // Если текущий узел - нетерминал.
            {
                foreach(SyntaxTreeNode item in node.SubNodes) // Цикл по всем подчиненным узлам.
                {
                    if (item.Token!=null && item.Token.Type==TokenKind.RightParenthesis) indent -= 10;
                    RecurTraverseTree(item, indent);
                    if (item.Token != null && item.Token.Type == TokenKind.LeftParenthesis) indent += 10;
                }
            }
            else
            {

                var str = new StringBuilder();
                var k = 0;
                if (node.Token != null &&
                    (node.Token.Type == TokenKind.Negative
                    || node.Token.Type == TokenKind.Equal
                    || node.Token.Type == TokenKind.LogicSum
                    || node.Token.Type == TokenKind.LogicMultiply)) k = 5;
                // Генерируем отступ.       
                for(int i = 0; i < indent+k; i++)
                {
                    str.Append(" ");
                }
                if(node.Token != null && node.Token.Type == TokenKind.FirstWord)
                {
                    var intValue = 0;
                    for (int i= node.Token.Value.Length-1; i>=0; i--)
                    {
                        if(int.Parse(node.Token.Value[i].ToString())==1)
                        intValue +=(int) Math.Pow(2, node.Token.Value.Length - 1 -i);
                    }
                    str.Append(intValue);
                    outputText.Add(str.ToString());
                    return;
                }
                // Добавляем имя узла.
                str.Append(node.Name);

                // Добавляем созданную строку в результат.
                outputText.Add(str.ToString());
            }
        }
    }
}
