using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SPO_KP
{
    class TranslationTable
    {
        id_Table Constants_And_Identifiers = new id_Table();
        public TranslationTable()
        {
            Buffer.numberInProgram = 0;
            Buffer.Token = ' ';
            Buffer.Expression = "";
            Buffer.Lexeme = 0;
            Buffer.StringNumber = 0;
            Buffer.AttributeValue = "";
            Buffer.isIdentifier = false;
        }

        public Queue<translationTable> TranslationList = new Queue<translationTable>();
        public struct translationTable // Таблица трансляции
        {
            public int numberInProgram;
            public string Expression;
            public int Lexeme;
            public char Token;
            public string AttributeValue;
            public int StringNumber;
            public bool isIdentifier;
            public bool isConst;

        };
        public translationTable Buffer; // Буфер ввода/вывода таблицы
        public void Put()
        {
            if (Buffer.isConst || Buffer.isIdentifier)
                Constants_And_Identifiers.addRecord(Buffer);
            TranslationList.Enqueue(Buffer);
            ClearBuffer();
        }
        public void ClearBuffer()//Очистка буфера
        {
            Buffer.numberInProgram = 0;
            Buffer.Token = ' ';
            Buffer.Expression = "";
            Buffer.Lexeme = 0;
            Buffer.StringNumber = 0;
            Buffer.AttributeValue = "";
            Buffer.isIdentifier = false;

        }
    }
}
