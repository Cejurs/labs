﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB5
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
            richTextBoxMessages.Clear(); // Очищаем поле сообщений.
            treeViewSyntaxTree.Nodes.Clear(); // Очищаем дерево.
            richTextBoxOutput.Clear(); // Очищаем поле выходного текста.

            // Создаем синтаксический анализатор.
            // Передаем ему на анализ строки текстового поля.
            SyntaxAnalyzer synAn = new SyntaxAnalyzer(richTextBoxInput.Text);

            // Процесс синтаксического анализа должен быть обернут в "try...catch",
            // поскольку синтаксический анализатор при обнаружении ошибки в тексте генерирует исключительную ситуацию.
            try
            {
                SyntaxTreeNode treeRoot;
                synAn.ParseText(out treeRoot); // Производим синтаксический (и лексический, естественно, тоже) анализ текста.
                                               // Попутно строим синтаксическое дерево.
                                               // Попутно проверяем контекстное условие. 

                richTextBoxMessages.AppendText("Текст правильный"); // Если дошли до сюда, то в тексте не было ошибок. Сообщаем об этом.

                VisualizeSyntaxTree(treeRoot); // Визуализируем синтаксическое дерево в компоненте treeViewSyntaxTree.

                // Создаем генератор.
                // Передаем ему синтаксическое дерево.
                Generator generator = new Generator(treeRoot);

                generator.GenerateStructuredText(); // Производим генерацию выходного структурированного текста.

                ShowOutputText(generator.OutputText); // Выводим выходной текст в соответствующее поле.
            }
            catch (ContextAnException contextAnException)
            {
                // В тексте была обнаружена контекстная ошибка.

                // Добавляем описание ошибки в поле сообщений.
                richTextBoxMessages.AppendText(String.Format("Контекстная ошибка ({0},{1}): {2}", contextAnException.LineIndex + 1, contextAnException.SymIndex + 1, contextAnException.Message));

                // Располагаем курсор в исходном тексте на позиции ошибки.
                LocateCursorAtErrorPosition(contextAnException.LineIndex, contextAnException.SymIndex);
            }
            catch (SynAnException synAnException)
            {
                // В тексте была обнаружена синтаксическая ошибка.

                // Добавляем описание ошибки в поле сообщений.
                richTextBoxMessages.AppendText(String.Format("Синтаксическая ошибка ({0},{1}): {2}", synAnException.LineIndex + 1, synAnException.SymIndex + 1, synAnException.Message));

                // Располагаем курсор в исходном тексте на позиции ошибки.
                LocateCursorAtErrorPosition(synAnException.LineIndex, synAnException.SymIndex);
            }
            catch (LexAnException lexAnException)
            {
                // В тексте была обнаружена лексическая ошибка.

                // Добавляем описание ошибки в поле сообщений.
                richTextBoxMessages.AppendText(String.Format("Лексическая ошибка ({0},{1}): {2}", lexAnException.LineIndex + 1, lexAnException.SymIndex + 1, lexAnException.Message));

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

        // Визуализировать синтаксическое дерево в компоненте treeViewSyntaxTree.
        private void VisualizeSyntaxTree(SyntaxTreeNode treeRoot)
        {
            treeViewSyntaxTree.BeginUpdate();

            treeViewSyntaxTree.Nodes.Add(treeRoot.Name); // Создаем в компоненте корневой узел.

            RecurAddSubNodes(treeViewSyntaxTree.Nodes[0], treeRoot); // Рекурсивно добавляем подчиненные узлы.

            treeViewSyntaxTree.ExpandAll(); // Раскрываем в компоненте все узлы дерева.

            treeViewSyntaxTree.TopNode = treeViewSyntaxTree.Nodes[0]; // Делаем видимым корневой узел.

            treeViewSyntaxTree.EndUpdate();
        }

        // Рекурсивно добавить подчиненные узлы.
        private void RecurAddSubNodes(TreeNode subTreeRoot1, SyntaxTreeNode subTreeRoot2)
        {
            foreach (SyntaxTreeNode item in subTreeRoot2.SubNodes) // Цикл по всем подчиненным узлам.
            {
                TreeNode n;
                n = subTreeRoot1.Nodes.Add(item.Name); // Добавляем очередной подчиненный узел.
                RecurAddSubNodes(n, item); // Рекурсивно добавляем также и его подчиненные узлы.
            }
        }
        private void logicalSum_Click(object sender, EventArgs e)
        {
            richTextBoxInput.Text += logicalSum.Text;
        }

        private void logicalMultiply_Click(object sender, EventArgs e)
        {
            richTextBoxInput.Text += logicalMultiply.Text;
        }

        private void negative_Click(object sender, EventArgs e)
        {
            richTextBoxInput.Text += negative.Text;
        }

        // Вывести выходной текст в соответствующее поле.
        private void ShowOutputText(List<string> outputText)
        {
            richTextBoxOutput.Clear(); // Очищаем поле.

            for(int i = 0; i < outputText.Count(); i++) // Цикл по строкам выходного текста.
            {
                richTextBoxOutput.AppendText(outputText[i] + "\n"); // Добавляем очередную строку в поле.
            }
        }
    }
}