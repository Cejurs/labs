using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace LAB5
{
    // Класс исключительных ситуаций синтаксического анализа.
    class SynAnException : Exception
    {
        // Позиция возникновения исключительной ситуации в анализируемом тексте.
        private int lineIndex; // Индекс строки.
        private int symIndex;  // Индекс символа.

        // Индекс строки, где возникла исключительная ситуация - свойство только для чтения.
        public int LineIndex
        {
            get { return lineIndex; }
        }

        // Индекс символа, на котором возникла исключительная ситуация - свойство только для чтения.
        public int SymIndex
        {
            get { return symIndex; }
        }

        // Конструктор исключительной ситуации.
        // message - описание исключительной ситуации.
        // lineIndex и symIndex - позиция возникновения исключительной ситуации в анализируемом тексте.
        public SynAnException(string message, int lineIndex, int symIndex)
            : base(message)
        {
            this.lineIndex = lineIndex;
            this.symIndex = symIndex;
        }
    }

    // Класс исключительных ситуаций контекстного анализа.
    class ContextAnException : Exception
    {
        // Позиция возникновения исключительной ситуации в анализируемом тексте.
        private int lineIndex; // Индекс строки.
        private int symIndex;  // Индекс символа.

        // Индекс строки, где возникла исключительная ситуация - свойство только для чтения.
        public int LineIndex
        {
            get { return lineIndex; }
        }

        // Индекс символа, на котором возникла исключительная ситуация - свойство только для чтения.
        public int SymIndex
        {
            get { return symIndex; }
        }

        // Конструктор исключительной ситуации.
        // message - описание исключительной ситуации.
        // lineIndex и symIndex - позиция возникновения исключительной ситуации в анализируемом тексте.
        public ContextAnException(string message, int lineIndex, int symIndex)
            : base(message)
        {
            this.lineIndex = lineIndex;
            this.symIndex = symIndex;
        }
    }

    // Класс "Синтаксический анализатор".
    // Попутно производит также контекстный анализ текста.
    // При обнаружении ошибки в исходном тексте он генерирует исключительную ситуацию SynAnException или LexAnException или ContextAnException.
    class SyntaxAnalyzer
    {
        private LexicalAnalyzer lexAn; // Лексический анализатор.

        // Конструктор синтаксического анализатора. 
        // В качестве параметра передается исходный текст.
        public SyntaxAnalyzer(string[] inputLines)
        {
            // Создаем лексический анализатор.
            // Передаем ему текст.
            lexAn = new LexicalAnalyzer(inputLines);
        }

        // Обработать синтаксическую ошибку.
        // msg - описание ошибки.
        private void SyntaxError(string msg)
        {
            // Генерируем исключительную ситуацию, тем самым полностью прерывая процесс анализа текста.
            throw new SynAnException(msg, lexAn.CurLineIndex, lexAn.CurSymIndex);
        }

        // Обработать контекстную ошибку.
        // msg - описание ошибки.
        private void ContextError(string msg)
        {
            // Генерируем исключительную ситуацию, тем самым полностью прерывая процесс анализа текста.
            throw new ContextAnException(msg, lexAn.CurLineIndex, lexAn.CurSymIndex);
        }

        // Проверить, что тип текущего распознанного токена совпадает с заданным.
        // Если совпадает, то распознать следующий токен, иначе синтаксическая ошибка.
        private void Match(TokenKind tkn)
        {
            if (lexAn.Token.Type == tkn) // Сравниваем.
            {
                lexAn.RecognizeNextToken(); // Распознаем следующий токен.
            }
            else 
            {
                SyntaxError("Ожидалось " + tkn.ToString()); // Обнаружена синтаксическая ошибка.
            }
        }

        // Проверить, что текущий распознанный токен совпадает с заданным (сравнение производится в нижнем регистре).
        // Если совпадает, то распознать следующий токен, иначе синтаксическая ошибка.
        private void Match(string tkn)
        {
            if (lexAn.Token.Value.ToLower() == tkn.ToLower()) // Сравниваем.
            {
                lexAn.RecognizeNextToken(); // Распознаем следующий токен.
            }
            else
            {
                SyntaxError("Ожидалось " + tkn); // Обнаружена синтаксическая ошибка.
            }
        }

        // Процедура разбора для стартового нетерминала E.
        // Параметр node - синтезируемый атрибут нетерминала E.
        // Параметр numbersOnly - синтезируемый атрибут нетерминала E.
        // Параметр exprValue - синтезируемый атрибут нетерминала E.
        private void E(out SyntaxTreeNode node, out bool numbersOnly, out double exprValue)
        {
            node = new SyntaxTreeNode("E"); // Создаем узел с именем "E".
            
            SyntaxTreeNode nodeT;
            bool numbersOnlyT;
            double exprValueT;
            T(out nodeT, out numbersOnlyT, out exprValueT); // Вызываем процедуру разбора для нетерминала T.

            node.AddSubNode(nodeT); // К узлу с именем "E" добавляем подчиненный узел, созданный в T().

            // Если текущий токен принадлежит множеству FIRST(M) = {"+", "-"}.
            if ((lexAn.Token.Type == TokenKind.Plus) || (lexAn.Token.Type == TokenKind.Minus))
            {
                SyntaxTreeNode nodeM;
                bool numbersOnlyM;
                double exprValueM;             
                M(out nodeM, numbersOnlyT, exprValueT, out numbersOnlyM, out exprValueM); // Вызываем процедуру разбора для нетерминала M.

                node.AddSubNode(nodeM); // К узлу с именем "E" добавляем подчиненный узел, созданный в M().
                numbersOnly = numbersOnlyM;
                exprValue = exprValueM; 
            }
            else
            {
                numbersOnly = numbersOnlyT;
                exprValue = exprValueT;
            }
        }

        // Процедура разбора для нетерминала M.
        // Параметр node - синтезируемый атрибут нетерминала M.
        // Параметр numbersOnlyLeftOp - наследуемый атрибут нетерминала M.
        // Параметр exprValueLeftOp - наследуемый атрибут нетерминала M.
        // Параметр numbersOnly - синтезируемый атрибут нетерминала M.
        // Параметр exprValue - синтезируемый атрибут нетерминала M.
        private void M(out SyntaxTreeNode node, bool numbersOnlyLeftOp, double exprValueLeftOp, out bool numbersOnly, out double exprValue)
        {
            node = new SyntaxTreeNode("M"); // Создаем узел с именем "M".

            if ((lexAn.Token.Type == TokenKind.Plus) || (lexAn.Token.Type == TokenKind.Minus)) // Если текущий токен - "+" или "-".
            {
                TokenKind operation = lexAn.Token.Type; // Запоминаем знак операции.
                
                node.AddSubNode(new SyntaxTreeNode(lexAn.Token)); // К узлу с именем "M" добавляем листьевой узел "+" или "-".

                lexAn.RecognizeNextToken(); // Пропускаем этот знак сложения или вычитания.

                SyntaxTreeNode nodeT;
                bool numbersOnlyT; 
                double exprValueT;
                T(out nodeT, out numbersOnlyT, out exprValueT); // Вызываем процедуру разбора для нетерминала T.

                node.AddSubNode(nodeT); // К узлу с именем "M" добавляем подчиненный узел, созданный в T().
                numbersOnly = numbersOnlyLeftOp && numbersOnlyT;
                if (numbersOnly)
                {
                    if (operation == TokenKind.Plus)
                        exprValue = exprValueLeftOp + exprValueT;
                    else
                        exprValue = exprValueLeftOp - exprValueT;
                }
                else
                {
                    exprValue = double.NaN;
                }

                // Если текущий токен принадлежит множеству FIRST(M) = {"+", "-"}.
                if ((lexAn.Token.Type == TokenKind.Plus) || (lexAn.Token.Type == TokenKind.Minus))
                {
                    SyntaxTreeNode nodeM;
                    bool numbersOnlyM;
                    double exprValueM;   
                    M(out nodeM, numbersOnly, exprValue, out numbersOnlyM, out exprValueM); // Вызываем процедуру разбора для нетерминала M.

                    node.AddSubNode(nodeM); // К узлу с именем "M" добавляем подчиненный узел, созданный в M().
                    numbersOnly = numbersOnlyM;
                    exprValue = exprValueM;
                }
            }
            else
            {
                numbersOnly = false;    // Вставлено только из-за того, что компилятор требует, чтобы этот параметр был означен в данном методе.
                exprValue = double.NaN; // Вставлено только из-за того, что компилятор требует, чтобы этот параметр был означен в данном методе.
                SyntaxError("Ожидалось '+' или '-'"); // Обнаружена синтаксическая ошибка.
            }
        }

        // Процедура разбора для нетерминала T.
        // Параметр node - синтезируемый атрибут нетерминала T.
        // Параметр numbersOnly - синтезируемый атрибут нетерминала T.
        // Параметр exprValue - синтезируемый атрибут нетерминала T.
        private void T(out SyntaxTreeNode node, out bool numbersOnly, out double exprValue)
        {
            node = new SyntaxTreeNode("T"); // Создаем узел с именем "T".

            SyntaxTreeNode nodeF;
            bool numbersOnlyF;
            double exprValueF;
            F(out nodeF, out numbersOnlyF, out exprValueF); // Вызываем процедуру разбора для нетерминала F.

            node.AddSubNode(nodeF); // К узлу с именем "T" добавляем подчиненный узел, созданный в F().

            // Если текущий токен принадлежит множеству FIRST(N) = {"*", "/"}.
            if ((lexAn.Token.Type == TokenKind.Multiply) || (lexAn.Token.Type == TokenKind.Divide))
            {
                SyntaxTreeNode nodeN;
                bool numbersOnlyN;
                double exprValueN;  
                N(out nodeN, numbersOnlyF, exprValueF, out numbersOnlyN, out exprValueN); // Вызываем процедуру разбора для нетерминала N.

                node.AddSubNode(nodeN); // К узлу с именем "T" добавляем подчиненный узел, созданный в N().
                numbersOnly = numbersOnlyN;
                exprValue = exprValueN;
            }
            else
            {
                numbersOnly = numbersOnlyF;
                exprValue = exprValueF;
            }
        }

        // Процедура разбора для нетерминала N.
        // Параметр node - синтезируемый атрибут нетерминала N.
        // Параметр numbersOnlyLeftOp - наследуемый атрибут нетерминала N.
        // Параметр exprValueLeftOp - наследуемый атрибут нетерминала N.
        // Параметр numbersOnly - синтезируемый атрибут нетерминала N.
        // Параметр exprValue - синтезируемый атрибут нетерминала N.
        private void N(out SyntaxTreeNode node, bool numbersOnlyLeftOp, double exprValueLeftOp, out bool numbersOnly, out double exprValue)
        {
            node = new SyntaxTreeNode("N"); // Создаем узел с именем "N".

            if ((lexAn.Token.Type == TokenKind.Multiply) || (lexAn.Token.Type == TokenKind.Divide)) // Если текущий токен - "*" или "/".
            {
                TokenKind operation = lexAn.Token.Type; // Запоминаем знак операции.
                
                node.AddSubNode(new SyntaxTreeNode(lexAn.Token)); // К узлу с именем "N" добавляем листьевой узел "*" или "/".
                
                lexAn.RecognizeNextToken(); // Пропускаем этот знак умножения или деления.

                SyntaxTreeNode nodeF;
                bool numbersOnlyF;
                double exprValueF;
                F(out nodeF, out numbersOnlyF, out exprValueF); // Вызываем процедуру разбора для нетерминала F.

                node.AddSubNode(nodeF); // К узлу с именем "N" добавляем подчиненный узел, созданный в F().
                numbersOnly = numbersOnlyLeftOp && numbersOnlyF;
                if (numbersOnly)
                {
                    if (operation == TokenKind.Multiply)
                        exprValue = exprValueLeftOp * exprValueF;
                    else
                        exprValue = exprValueLeftOp / exprValueF;
                }
                else
                {
                    exprValue = double.NaN;
                }

                // Если текущий токен принадлежит множеству FIRST(N) = {"*", "/"}.
                if ((lexAn.Token.Type == TokenKind.Multiply) || (lexAn.Token.Type == TokenKind.Divide))
                {
                    SyntaxTreeNode nodeN;
                    bool numbersOnlyN;
                    double exprValueN;   
                    N(out nodeN, numbersOnly, exprValue, out numbersOnlyN, out exprValueN); // Вызываем процедуру разбора для нетерминала N.

                    node.AddSubNode(nodeN); // К узлу с именем "N" добавляем подчиненный узел, созданный в N().
                    numbersOnly = numbersOnlyN;
                    exprValue = exprValueN;
                }
            }
            else
            {
                numbersOnly = false;    // Вставлено только из-за того, что компилятор требует, чтобы этот параметр был означен в данном методе.
                exprValue = double.NaN; // Вставлено только из-за того, что компилятор требует, чтобы этот параметр был означен в данном методе.
                SyntaxError("Ожидалось '*' или '/'"); // Обнаружена синтаксическая ошибка.
            }
        }

        // Процедура разбора для нетерминала F.
        // Параметр node - синтезируемый атрибут нетерминала F.
        // Параметр numbersOnly - синтезируемый атрибут нетерминала F.
        // Параметр exprValue - синтезируемый атрибут нетерминала F.
        private void F(out SyntaxTreeNode node, out bool numbersOnly, out double exprValue)
        {
            node = new SyntaxTreeNode("F"); // Создаем узел с именем "F".

            switch (lexAn.Token.Type) // Анализируем текущий токен.
            {
                case TokenKind.LeftParen: // Если текущий токен - "(".
                    node.AddSubNode(new SyntaxTreeNode(lexAn.Token)); // К узлу с именем "F" добавляем листьевой узел "(".           
                    lexAn.RecognizeNextToken(); // Пропускаем эту левую скобку.                   
                    SyntaxTreeNode nodeE;
                    E(out nodeE, out numbersOnly, out exprValue); // Вызываем процедуру разбора для нетерминала E.                    
                    node.AddSubNode(nodeE); // К узлу с именем "F" добавляем подчиненный узел, созданный в E().                   
                    // Должна быть правая скобка.
                    if (lexAn.Token.Type != TokenKind.RightParen)
                    {
                        SyntaxError("Ожидалось ')'"); // Обнаружена синтаксическая ошибка. 
                    }            
                    node.AddSubNode(new SyntaxTreeNode(lexAn.Token)); // К узлу с именем "F" добавляем листьевой узел ")".                
                    lexAn.RecognizeNextToken();
                    break;

                case TokenKind.Number: // Если текущий токен - число.
                    node.AddSubNode(new SyntaxTreeNode(lexAn.Token)); // К узлу с именем "F" добавляем листьевой узел с распознанным числом.
                    numbersOnly = true;
                    var ci = CultureInfo.InvariantCulture.Clone() as CultureInfo;
                    ci.NumberFormat.NumberDecimalSeparator = ".";
                    exprValue = double.Parse(lexAn.Token.Value, ci); // Считываем число.
                    lexAn.RecognizeNextToken(); // Пропускаем это число.        
                    break;

                case TokenKind.Identifier: // Если текущий токен - идентификатор.
                    node.AddSubNode(new SyntaxTreeNode(lexAn.Token)); // К узлу с именем "F" добавляем листьевой узел с распознанным идентификатором.
                    numbersOnly = false; // Присваиваем false, поскольку в выражении имеется идентификатор.
                    exprValue = double.NaN;
                    lexAn.RecognizeNextToken(); // Пропускаем этот идентификатор.
                    break;

                default: // Если текущий токен - что-то другое.
                    numbersOnly = false;    // Вставлено только из-за того, что компилятор требует, чтобы этот параметр был означен в данном методе.
                    exprValue = double.NaN; // Вставлено только из-за того, что компилятор требует, чтобы этот параметр был означен в данном методе.
                    SyntaxError("Ожидалось '(' или число или идентификатор"); // Обнаружена синтаксическая ошибка.
                    break;
            }
        }

        // Провести синтаксический анализ текста.
        // Возвращает корень синтаксического дерева.
        // Дерево строится в порядке "Снизу-Вверх, Слева-Направо" на основе применения синтезируемых атрибутов.
        public void ParseText(out SyntaxTreeNode treeRoot)
        {
            lexAn.RecognizeNextToken(); // Распознаем первый токен в тексте.

            bool numbersOnly;
            double exprValue;
            E(out treeRoot, out numbersOnly, out exprValue); // Вызываем процедуру разбора для стартового нетерминала E. 

            if (numbersOnly) // Если в выражении присутствуют только числа.
            {
                if (exprValue <= 0) // Если значение выражения - не положительное.
                    ContextError("Значение выражения - не положительное (" + exprValue.ToString() + ")"); // Обнаружена контекстная ошибка.
            }

            if (lexAn.Token.Type != TokenKind.EndOfText) // Если текущий токен не является концом текста.
            {
                SyntaxError("После арифметического выражения идет еще какой-то текст"); // Обнаружена синтаксическая ошибка.
            }
        }
    }
}
