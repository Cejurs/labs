using System;
using System.Linq;
using System.Windows.Forms;

namespace LAB1
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        // Обработчик события нажатия кнопки "Анализировать текст".
        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            // Очищаем поле сообщений и таблицу распознанных токенов.
            richTextBoxMessages.Clear();
            dataGridViewRecognizedTokens.Rows.Clear();

            // Создаем лексический анализатор.
            // Передаем ему на анализ строки текстового поля.
            LexicalAnalyzer lexAn = new LexicalAnalyzer(richTextBoxInput.Text);

            int k = 0; // Инициализируем счетчик распознанных токенов.

            // Процесс лексического анализа должен быть обернут в "try...catch",
            // поскольку лексический анализатор при обнаружении ошибки в тексте генерирует исключительную ситуацию.
            try
            {
                // Цикл чтения текста от начала до конца.
                do
                {
                    lexAn.RecognizeNextToken(); // Распознаем очередной токен в тексте.

                    k++; // Увеличиваем счетчик распознанных токенов.
                    dataGridViewRecognizedTokens.Rows.Add(k, lexAn.Token.Value, lexAn.Token.Type, lexAn.Token.LineIndex + 1, lexAn.Token.SymStartIndex + 1); // Добавляем распознанный токен в таблицу.
                }
                while (lexAn.Token.Type != TokenKind.EndOfText); // Цикл работает до тех пор, пока не будет возвращен токен "Конец текста".

                richTextBoxMessages.AppendText("Текст правильный"); // Если дошли до сюда, то в тексте не было ошибок. Сообщаем об этом.
            }
            catch (LexAnException lexAnException)
            {
                // В тексте была обнаружена лексическая ошибка.

                // Добавляем описание ошибки в поле сообщений.
                richTextBoxMessages.AppendText(String.Format("Ошибка ({0},{1}): {2}", lexAnException.LineIndex + 1, lexAnException.SymIndex + 1, lexAnException.Message));

                // Располагаем курсор в исходном тексте на позиции ошибки.
                LocateCursorAtErrorPosition(lexAnException.LineIndex, lexAnException.SymIndex);
            }
        }

        // Расположить курсор в исходном тексте на позиции ошибки.
        private void LocateCursorAtErrorPosition(int lineIndex, int symIndex)
        {
            int k = 0;

            // Подсчитываем суммарное количество символов во всех строках до lineIndex.
            for (int i = 0; i < lineIndex; i++)
            {
                k += richTextBoxInput.Lines[i].Count() + 1;
            }

            // Прибавляем символы из строки lineIndex.
            k += symIndex;

            // Располагаем курсор на вычисленной позиции.
            richTextBoxInput.Select();
            richTextBoxInput.Select(k, 1);
        }
    }
}
