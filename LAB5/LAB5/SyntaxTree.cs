using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5
{
    // Класс "Узел синтаксического дерева".
    class SyntaxTreeNode
    {
        private string name; // Наименование узла.
        private Token token; // Токен (если узел - листьевой).

        private List<SyntaxTreeNode> subNodes; // Подчиненные узлы.

        // Конструктор узла.
        public SyntaxTreeNode(string name)
        {
            this.name = name;
            this.token = null;
            subNodes = new List<SyntaxTreeNode>();
        }

        // Конструктор листьевого узла.
        public SyntaxTreeNode(Token tkn)
        {
            this.name = tkn.Value;
            this.token = tkn;
            subNodes = new List<SyntaxTreeNode>();
        }

        // Добавить узел в список подчиненных узлов.
        public void AddSubNode(SyntaxTreeNode subNode)
        {
            this.subNodes.Add(subNode);
        }

        // Наименование узла - свойство только для чтения.
        public string Name
        {
            get { return name; }
        }

        // Токен в узле - свойство только для чтения.
        public Token Token
        {
            get { return token; }
        }

        // Список подчиненных узлов - свойство только для чтения.
        public List<SyntaxTreeNode> SubNodes
        {
            get { return subNodes; }
        }
    }
}
