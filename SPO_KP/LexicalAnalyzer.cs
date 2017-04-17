using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace SPO_KP
{
    class LexicalAnalyzer
    {

        private int[,] TransferTable =
//         0   1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27  28  29  30  31  32  33  34  35  36  37  38  39  40  41  42  43  44  45  46  47  48  49  50  51  52  53  54  55  56  57  58  59  60  61  62  63  64  65  66  67  68  
/*B*/    {{1  ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*E*/     {9  ,2  ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,17 ,40 ,40 ,40 ,40 ,22 ,40 ,24 ,40 ,40 ,40 ,28 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,67 ,40 ,40 },
/*G*/     {40 ,40 ,3  ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*I*/     {12, 40 ,40 ,4  ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,33 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,45 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,65 ,40 ,40 ,40 ,40 },
/*N*/     {40 ,40 ,40 ,40 ,5  ,40 ,40 ,40 ,40 ,10 ,40 ,40 ,29 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,25 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*D*/     {44 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,11 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,49 ,40 ,118,119,120,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*O*/     {34 ,6  ,40 ,40 ,40 ,40 ,7  ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,68 ,40 ,40 ,48 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*L*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,8  ,40 ,26 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,20 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,66 ,40 ,40 ,40 },
/*T*/     {14 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,62 ,40 ,32 ,40 ,40 ,40 ,36 ,40 ,40 ,39 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,120,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*R*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,15 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*U*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,16 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,31 ,40 ,40 ,40 ,35 ,40 ,40 ,38 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*F*/     {18 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,13 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*A*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,19 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*S*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,21 ,40 ,40 ,40 ,40 ,40 ,27 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*H*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,23 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,64 ,40 ,40 ,40 ,40 ,40 },
/*P*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,30 ,40 ,40 ,40 ,40 ,40 ,40 ,37 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*V*/     {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,46 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*M*/     {47 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,120,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*W*/     {63 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,120,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*A-Z*/   {40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,40 ,113,114,115,40 ,40 ,40 ,40 ,40 ,40 ,118,119,0  ,0  ,121,0  ,122,58 ,123,124,125,126,40 ,40 ,40 ,40 ,40 ,40 ,40 },
/*0-9*/   {59 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,113,114,115,0  ,0  ,116,0  ,0  ,117,118,119,0  ,0  ,121,0  ,122,58 ,123,59 ,125,126,40 ,0  ,0  ,0  ,0  ,0  ,0  },
/*+*/     {41 ,112,112,112,112,0  ,112,112,0  ,112,0  ,103,112,0  ,112,112,112,0  ,112,112,112,112,0  ,112,112,0  ,112,112,0  ,112,112,112,0  ,0  ,112,112,112,112,112,0  ,112,113,114,115,112,112,116,112,112,117,118,0  ,120,0  ,0  ,0  ,0  ,0  ,0  ,124,125,126,0  ,112,112,112,112,0  ,0  },
/*-*/     {42 ,112,112,112,112,0  ,112,112,0  ,112,0  ,103,112,0  ,112,112,112,0  ,112,112,112,112,0  ,112,112,0  ,112,112,0  ,112,112,112,0  ,0  ,112,112,112,112,112,0  ,112,113,114,115,112,112,116,112,112,117,118,0  ,120,0  ,0  ,0  ,0  ,0  ,0  ,124,125,126,0  ,112,112,112,112,0  ,0  },
/*'*'*/   {43 ,112,112,112,112,0  ,112,112,0  ,112,0  ,103,112,0  ,112,112,112,0  ,112,112,112,112,0  ,112,112,0  ,112,112,0  ,112,112,112,0  ,0  ,112,112,112,112,112,0  ,112,113,114,115,112,112,116,112,112,117,118,0  ,120,0  ,0  ,0  ,0  ,0  ,0  ,124,125,126,0  ,112,112,112,112,0  ,0  },
/*:*/     {53 ,112,112,112,112,0  ,112,112,0  ,112,0  ,103,112,0  ,112,112,112,0  ,112,112,112,112,0  ,112,112,0  ,112,112,0  ,112,112,112,0  ,0  ,112,112,112,112,112,0  ,112,113,114,115,112,112,116,112,112,117,118,0  ,120,0  ,0  ,0  ,0  ,0  ,0  ,124,125,126,0  ,112,112,112,112,0  ,0  },
/*=*/     {55 ,112,112,112,112,0  ,112,112,0  ,112,0  ,103,112,0  ,112,112,112,0  ,112,112,112,112,0  ,112,112,0  ,112,112,0  ,112,112,112,0  ,0  ,112,112,112,112,112,0  ,112,113,114,115,112,112,116,112,112,117,118,0  ,120,54 ,0  ,56 ,0  ,0  ,0  ,124,125,126,0  ,112,112,112,112,0  ,0  },
/*<*/     {57 ,112,112,112,112,0  ,112,112,0  ,112,0  ,103,112,0  ,112,112,112,0  ,112,112,112,112,0  ,112,112,0  ,112,112,0  ,112,112,112,0  ,0  ,112,112,112,112,112,0  ,112,113,114,115,112,112,116,112,112,117,118,0  ,120,0  ,0  ,0  ,0  ,0  ,0  ,124,125,126,0  ,112,112,112,112,0  ,0  },
/*>*/     {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,118,0  ,0  ,0  ,0  ,0  ,0  ,58 ,0  ,0  ,125,126,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*(*/     {51 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,104,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,118,119,0  ,0  ,121,0  ,122,0  ,123,124,125,126,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*)*/     {52 ,112,112,112,112,101,112,112,102,112,112,103,112,104,112,112,112,105,112,112,112,112,106,112,112,107,112,112,108,112,112,112,110,109,112,112,112,112,112,111,112,113,114,115,112,112,116,112,112,117,118,0  ,120,0  ,121,0  ,122,0  ,123,124,125,126,0  ,112,112,112,112,0  ,0  },
/*;*/     {60 ,112,112,112,112,101,112,112,102,112,112,103,112,104,112,112,112,105,112,112,112,112,106,112,112,107,112,112,108,112,112,112,110,109,112,112,112,112,112,111,112,113,114,115,112,112,116,112,112,117,118,119,120,50 ,121,50 ,122,50 ,123,124,125,126,0  ,112,112,112,112,0  ,0  },
/*,*/     {61 ,112,112,112,112,101,112,112,102,112,112,103,112,104,112,112,112,105,112,112,112,112,106,112,112,107,112,112,108,112,112,112,110,109,112,112,112,112,112,111,112,113,114,115,112,112,116,112,112,117,118,119,120,50 ,121,50 ,122,50 ,123,124,125,126,0  ,112,112,112,112,0  ,0  },
/*' '*/   {50 ,112,112,112,112,101,112,112,102,112,112,103,112,104,112,112,112,105,112,112,112,112,106,112,112,107,112,112,108,112,112,112,110,109,112,112,112,112,112,111,112,113,114,115,112,112,116,112,112,117,50 ,119,120,50 ,121,50 ,122,50 ,123,124,125,126,127,112,112,112,112,128,129},
/*$*/     {50 ,112,112,112,112,101,112,112,102,112,112,103,112,104,112,112,112,105,112,112,112,112,106,112,112,107,112,112,108,112,112,112,110,109,112,112,112,112,112,111,112,113,114,115,112,112,116,112,112,117,118,119,120,50 ,121,50 ,122,50 ,123,124,125,126,127,112,112,112,112,128,129},
    
};
        // Вектор терминалов для определения строки
        private char[] Rows = { 'B', 'E', 'G', 'I', 'N', 'D', 'O', 'L', 'T', 'R', 'U', 'F', 'A', 'S', 'H', 'P', 'V', 'M', 'W', '0', '0', '+', '-', '*', ':', '=', '<', '>', '(', ')', ';', ',', ' ', '$' };
        private int State,tokenCounter; //Переменная состояния
        private int ErrorCounter;
        public Queue ErrorList = new Queue();
        private int GetRowByID(char id) // Получение строки по входному символу
        {
            char buf = ' ';
            if (char.IsDigit(id))
                return 20;
            if (char.IsLetter(id))
            {
                buf = char.ToUpper(id);
                if (!Rows.Contains(buf))
                    return 19;
            }


            buf = char.ToUpper(id);
            for (int i = 0; i < Rows.Count(); ++i)
            {
                if (Rows[i] == buf)
                    return i;
            }


            return -1;

        }
        public TranslationTable doAnalyze(string[] Code, out Queue errors, out string st) //Лексический анализ
        {
            TranslationTable OutputTable = new TranslationTable(); //Выходная таблица трансляции;
            State = 0;
            int j = 0;
            string buf, lexBuf = ""; // Буфер текущей строки/лексемы
            int RowCounter = 0, Switcher;
            st = "";
            for (int i = 0; i < Code.Count(); ++i) // Перебор входных строк
            {

                buf = Code[i] + '$';
                j = 0;
                while (buf.Length > j) // Перебор символов текущей строки
                {
                    if ((RowCounter = GetRowByID(buf[j])) == -1)
                    {
                        ErrorList.Enqueue("Не существующая лексема. Строка №" + Convert.ToString(i + 1) + " символ № [" + Convert.ToString(j + 1) + "] :" + buf[j]);
                        State = 0;
                        ++j;
                        continue;
                    }
                    Switcher = TransferTable[RowCounter, State];
                    st += Convert.ToString(Switcher) + ' ';
                    if (char.IsLetter(buf[j]))
                        lexBuf += char.ToUpper(buf[j]);
                    else
                        lexBuf += buf[j];
                    if (Switcher == 0)
                    {
                        ErrorList.Enqueue("Не удается обнаружить лексему в строке №" + Convert.ToString(i + 1) + " символ № [" + Convert.ToString(j + 1) + "] :" + buf[j]);
                        ++ErrorCounter;
                        State = 0;
                        ++j;
                        continue;
                    }
                    if (Switcher < 100)
                    {
                        State = TransferTable[RowCounter, State];
                        ++j;
                        continue;
                    }
                    switch (Switcher)
                    {
                        case 101:
                            OutputTable.Buffer.Expression = "BEGIN";
                            OutputTable.Buffer.Lexeme = 1;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'S';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 102:
                            OutputTable.Buffer.Expression = "BOOL";
                            OutputTable.Buffer.Lexeme = 2;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'B';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 103:
                            OutputTable.Buffer.Expression = "END";
                            OutputTable.Buffer.Lexeme = 3;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'F';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 104:
                            OutputTable.Buffer.Expression = "IF";
                            OutputTable.Buffer.Lexeme = 4;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'I';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 105:
                            OutputTable.Buffer.Expression = "TRUE";
                            OutputTable.Buffer.Lexeme = 5;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'C';
                            OutputTable.Buffer.AttributeValue = "constant";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Buffer.isConst = true;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 106:
                            OutputTable.Buffer.Expression = "FALSE";
                            OutputTable.Buffer.Lexeme = 6;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'C';
                            OutputTable.Buffer.AttributeValue = "constant";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Buffer.isConst = true;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 107:
                            OutputTable.Buffer.Expression = "THEN";
                            OutputTable.Buffer.Lexeme = 7;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'T';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 108:
                            OutputTable.Buffer.Expression = "ELSE";
                            OutputTable.Buffer.Lexeme = 8;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'E';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 109:
                            OutputTable.Buffer.Expression = "FI";
                            OutputTable.Buffer.Lexeme = 9;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'f';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 110:
                            OutputTable.Buffer.Expression = "INPUT";
                            OutputTable.Buffer.Lexeme = 10;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'i';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 111:
                            OutputTable.Buffer.Expression = "OUTPUT";
                            OutputTable.Buffer.Lexeme = 11;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'o';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 112:
                            OutputTable.Buffer.Expression = lexBuf;
                            OutputTable.Buffer.Lexeme = 12;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'X';
                            OutputTable.Buffer.AttributeValue = "identifier";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Buffer.isIdentifier = true;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 113:
                            OutputTable.Buffer.Expression = "+";
                            OutputTable.Buffer.Lexeme = 13;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '+';
                            OutputTable.Buffer.AttributeValue = "operation";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 114:
                            OutputTable.Buffer.Expression = "-";
                            OutputTable.Buffer.Lexeme = 14;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '-';
                            OutputTable.Buffer.AttributeValue = "operation";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 115:
                            OutputTable.Buffer.Expression = "*";
                            OutputTable.Buffer.Lexeme = 15;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '*';
                            OutputTable.Buffer.AttributeValue = "operation";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 116:
                            OutputTable.Buffer.Expression = "DIV";
                            OutputTable.Buffer.Lexeme = 16;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '/';
                            OutputTable.Buffer.AttributeValue = "operation";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 117:
                            OutputTable.Buffer.Expression = "MOD";
                            OutputTable.Buffer.Lexeme = 17;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '%';
                            OutputTable.Buffer.AttributeValue = "operation";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 118:
                            OutputTable.Buffer.Expression = " ";
                            OutputTable.Buffer.Lexeme = 18;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '_';
                            OutputTable.Buffer.AttributeValue = "operation";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 119:
                            OutputTable.Buffer.Expression = "(";
                            OutputTable.Buffer.Lexeme = 19;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '(';
                            OutputTable.Buffer.AttributeValue = "open_bracket";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 120:
                            OutputTable.Buffer.Expression = ")";
                            OutputTable.Buffer.Lexeme = 20;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = ')';
                            OutputTable.Buffer.AttributeValue = "close_bracket";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 121:
                            OutputTable.Buffer.Expression = ":=";
                            OutputTable.Buffer.Lexeme = 21;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = '=';
                            OutputTable.Buffer.AttributeValue = "assign";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 122:
                            OutputTable.Buffer.Expression = "==";
                            OutputTable.Buffer.Lexeme = 22;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'c';
                            OutputTable.Buffer.AttributeValue = "equal";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 123:
                            OutputTable.Buffer.Expression = "<>";
                            OutputTable.Buffer.Lexeme = 23;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'c';
                            OutputTable.Buffer.AttributeValue = "not_equal";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 124:
                            OutputTable.Buffer.Expression = lexBuf;
                            OutputTable.Buffer.Lexeme = 24;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'C';
                            OutputTable.Buffer.AttributeValue = "constant";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 125:
                            OutputTable.Buffer.Expression = ";";
                            OutputTable.Buffer.Lexeme = 25;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = ';';
                            OutputTable.Buffer.AttributeValue = "semicolon";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 126:
                            OutputTable.Buffer.Expression = ",";
                            OutputTable.Buffer.Lexeme = 26;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = ',';
                            OutputTable.Buffer.AttributeValue = "comma";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 127:
                            OutputTable.Buffer.Expression = "INT";
                            OutputTable.Buffer.Lexeme = 27;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'd';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 128:
                            OutputTable.Buffer.Expression = "WHILE";
                            OutputTable.Buffer.Lexeme = 28;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'W';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                        case 129:
                            OutputTable.Buffer.Expression = "DO";
                            OutputTable.Buffer.Lexeme = 29;
                            OutputTable.Buffer.StringNumber = i;
                            OutputTable.Buffer.Token = 'D';
                            OutputTable.Buffer.AttributeValue = "keyword";
                            OutputTable.Buffer.numberInProgram = tokenCounter;
                            ++tokenCounter;
                            OutputTable.Put();
                            lexBuf = "";
                            State = 0;
                            break;
                    }

                }
            }
            errors = ErrorList;
            return OutputTable;
        }

    }
}
