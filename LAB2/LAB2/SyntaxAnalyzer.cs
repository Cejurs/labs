using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
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

    // Класс "Синтаксический анализатор".
    // При обнаружении ошибки в исходном тексте он генерирует исключительную ситуацию SynAnException или LexAnException.
    class SyntaxAnalyzer
    {
        private LexicalAnalyzer lexAn; // Лексический анализатор.

        // Конструктор синтаксического анализатора. 
        // В качестве параметра передается исходный текст.
        public SyntaxAnalyzer(string inputLines)
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
        private void D()
        {
            K();
            T(); // Вызываем процедуру разбора для нетерминала T.
        }

        private void K()
        {
            A();
            E();
        }

        private void E()
        {
            if (lexAn.Token.Type == TokenKind.LogicMultiply)
            {
                lexAn.RecognizeNextToken();
                A();
                E();
            }
        }

        private void A()
        {
            switch(lexAn.Token.Type)
            {
                case TokenKind.Negative:
                    lexAn.RecognizeNextToken();
                    A();
                    break;
                case TokenKind.LeftParenthesis:
                    lexAn.RecognizeNextToken();
                    D();
                    Match(TokenKind.RightParenthesis);
                    break;
                default:
                    O();
                    break;
            }
        }

        private void O()
        {
            switch (lexAn.Token.Type)
            {
                case TokenKind.FirstWord:
                    lexAn.RecognizeNextToken();
                    Match(TokenKind.Equal);
                    Match(TokenKind.SecondWord);
                    break;
                case TokenKind.SecondWord:
                    lexAn.RecognizeNextToken();
                    Match(TokenKind.Equal);
                    if (lexAn.Token.Type != TokenKind.FirstWord
                        && lexAn.Token.Type != TokenKind.SecondWord)
                        SyntaxError("Ожидалось слово типа 1 или типа 2");
                    lexAn.RecognizeNextToken();
                    break;
                default:
                    SyntaxError("Ожидалось слово типа 1 или 2");
                    break;
            }
        }

        // Процедура разбора для нетерминала T.
        private void T()
        {
            if (lexAn.Token.Type == TokenKind.LogicSum)
            {
                lexAn.RecognizeNextToken();
                K();
                T();
            }
        }

        // Провести синтаксический анализ текста.
        public void ParseText()
        {
            lexAn.RecognizeNextToken(); // Распознаем первый токен в тексте.

            D(); // Вызываем процедуру разбора для стартового нетерминала E.

            if (lexAn.Token.Type != TokenKind.EndOfText) // Если текущий токен не является концом текста.
            {
                SyntaxError("Ошибка нераспознанное выражение"); // Обнаружена синтаксическая ошибка.
            }
        }
    }
}
