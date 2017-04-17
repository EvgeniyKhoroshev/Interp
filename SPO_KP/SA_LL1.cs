using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;


namespace SPO_KP
{
    class SA_LL1
    {
        private int[,] LLTable =
        { // S   F   d   B   X   W   D   I   T   E   C   f   i   o   c   ;   ,   =   +   -   *   /   %   (   )   $
/*<P>*/     {1  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*<PO>*/    {0  ,0  ,2  ,2  ,50 ,50 ,0  ,50 ,0  ,0  ,50 ,0  ,50 ,50 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*<h>*/     {50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,4  ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 },
/*<POp>*/   {0  ,50 ,0  ,0  ,5  ,5  ,0  ,5  ,0  ,50 ,0  ,50 ,5  ,5  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*<g>*/     {50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,7  ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 },
/*<O>*/     {0  ,0  ,8  ,9  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*<LID>*/   {0  ,0  ,0  ,0  ,10 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*<p>*/     {50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,12 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 },
/*<Op>*/    {0  ,0  ,0  ,0  ,13 ,14 ,0  ,15 ,0  ,0  ,0  ,0  ,16 ,17 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*<V>*/     {0  ,0  ,0  ,0  ,18 ,0  ,0  ,0  ,0  ,0  ,18 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,18 ,0  ,0  },
/*<x>*/     {50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,19 ,20 ,50 ,50 ,50 ,50 ,50 ,50 },
/*<F>*/     {0  ,0  ,0  ,0  ,22 ,0  ,0  ,0  ,0  ,0  ,22 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,22 ,0  ,0  },
/*<y>*/     {50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,23 ,24 ,25 ,50 ,50 ,50 },
/*<PV>*/    {0  ,0  ,0  ,0  ,27 ,0  ,0  ,0  ,0  ,0  ,28 ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,29 ,0  ,0  },
/*<z>*/     {50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,31 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 ,50 },
/*S*/       {100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*F*/       {0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*d*/       {0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*B*/       {0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*X*/       {0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*W*/       {0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*D*/       {0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*I*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*T*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*E*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*C*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*f*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*i*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*o*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*c*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*;*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*,*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*=*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*+*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  ,0  },
/*-*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  ,0  },
/*'*'*/     {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  ,0  },
/*/*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  ,0  },
/*%*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  ,0  },
/*(*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  ,0  },
/*)*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,100,0  },
/*$*/       {0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,0  ,999},
        };
        Stack WorkStack, OutputStack;
        char[] LLColumn = { 'S', 'F', 'd', 'B', 'X', 'W', 'D', 'I', 'T', 'E', 'C', 'f', 'i', 'o', 'c', ';', ',', '=', '+', '-', '*', '/', '%', '(', ')', '$' };
        string[] LLRow = {"<P>","<PO>","<h>","<POp>","<g>","<O>","<LID>","<p>","<Op>","<V>","<x>","<F>","<y>","<PV>","<z>",
                             "S","F","d","B","X","W","D","I","T","E","C","f","i","o","c",";",",","=","+","-","*","/","%","(",")","$"};
        string Log;
        int Counter;
        string input,err;
        public Stack Do(string Tokens, out string log, out string errLog,out long time,out long ticks)
        {
            input = Tokens;
            err = "";
            int c, r;
            WorkStack = new Stack();
            OutputStack = new Stack();
            int param;
            Stopwatch t = new Stopwatch();
            t.Reset();
            t.Start();
            WorkStack.Push("$");
            WorkStack.Push("<P>");
            Tokens += '$';
            while (WorkStack.Count > 0)
            {
                try
                {
                    r = GetRowByID(Convert.ToString(WorkStack.Peek()));
                    c = GetColByID(Tokens[Counter]);
                    if (r != -1 && -1 != c)
                    {
                        param = LLTable[r, c];
                        PutInStack(param);
                    }
                    else
                    {
                        ++Counter;
                        PrintLog(0);
                    }
                }
                catch (IndexOutOfRangeException)
                { }
            }
            t.Stop();
            ticks = t.ElapsedTicks;
            time = t.ElapsedMilliseconds;
            log = Log;
            errLog = err;
            return OutputStack;
        }
        int GetRowByID(string Row)
        {
            if (LLRow.Contains(Row))
            {
                for (int i = 0; i < LLRow.Length; ++i)
                    if (Row == LLRow[i])
                        return i;
            }
            return -1;
        }
        int GetColByID(char Col)
        {
            if (LLColumn.Contains(Col))
            {
                for (int i = 0; i < LLRow.Length; ++i)
                    if (Col == LLColumn[i])
                        return i;
            }
            return -1;
        }
        void PutInStack(int caseOf)
        {
            switch (caseOf)
            {
                case 1:
                    PrintLog(caseOf);
                    WorkStack.Push("F");
                    WorkStack.Push("<POp>");
                    WorkStack.Push("<PO>");
                    WorkStack.Push("S");
                    break;
                case 2:
                    PrintLog(caseOf);
                    WorkStack.Push("<h>");
                    WorkStack.Push("<O>");
                    break;
                case 4:
                    PrintLog(caseOf);
                    WorkStack.Push("<PO>");
                    WorkStack.Push(";");
                    break;
                case 5:
                    PrintLog(caseOf);
                    WorkStack.Push("<g>");
                    WorkStack.Push("<Op>");
                    break;
                case 7:
                    PrintLog(caseOf);
                    WorkStack.Push("<POp>");
                    WorkStack.Push(";");
                    break;
                case 8:
                    PrintLog(caseOf);
                    WorkStack.Push("<LID>");
                    WorkStack.Push("d");
                    break;
                case 9:
                    PrintLog(caseOf);
                    WorkStack.Push("<LID>");
                    WorkStack.Push("B");
                    break;
                case 10:
                    PrintLog(caseOf);
                    WorkStack.Push("<p>");
                    WorkStack.Push("X");
                    break;
                case 12:
                    PrintLog(caseOf);
                    WorkStack.Push("<LID>");
                    WorkStack.Push(",");
                    break;
                case 13:
                    PrintLog(caseOf);
                    WorkStack.Push("<V>");
                    WorkStack.Push("=");
                    WorkStack.Push("X");
                    break;
                case 14:
                    PrintLog(caseOf);
                    WorkStack.Push("F");
                    WorkStack.Push("<POp>");
                    WorkStack.Push("D");
                    WorkStack.Push("<V>");
                    WorkStack.Push("W");
                    break;
                case 15:
                    PrintLog(caseOf);
                    WorkStack.Push("f");
                    WorkStack.Push("<POp>");
                    WorkStack.Push("E");
                    WorkStack.Push("<POp>");
                    WorkStack.Push("T");
                    WorkStack.Push("<V>");
                    WorkStack.Push("I");
                    break;
                case 16:
                    PrintLog(caseOf);
                    WorkStack.Push("X");
                    WorkStack.Push("i");
                    break;
                case 17:
                    PrintLog(caseOf);
                    WorkStack.Push("<V>");
                    WorkStack.Push("o");
                    break;
                case 18:
                    PrintLog(caseOf);
                    WorkStack.Push("<x>");
                    WorkStack.Push("<F>");
                    break;
                case 19:
                    PrintLog(caseOf);
                    WorkStack.Push("<F>");
                    WorkStack.Push("+");
                    break;
                case 20:
                    PrintLog(caseOf);
                    WorkStack.Push("<F>");
                    WorkStack.Push("-");
                    break;
                case 22:
                    PrintLog(caseOf);
                    WorkStack.Push("<y>");
                    WorkStack.Push("<PV>");
                    break;
                case 23:
                    PrintLog(caseOf);
                    WorkStack.Push("<PV>");
                    WorkStack.Push("*");
                    break;
                case 24:
                    PrintLog(caseOf);
                    WorkStack.Push("<PV>");
                    WorkStack.Push("/");
                    break;
                case 25:
                    PrintLog(caseOf);
                    WorkStack.Push("<PV>");
                    WorkStack.Push("%");
                    break;
                case 27:
                    PrintLog(caseOf);
                    WorkStack.Push("X");
                    break;
                case 28:
                    PrintLog(caseOf);
                    WorkStack.Push("C");
                    break;
                case 29:
                    PrintLog(caseOf);
                    WorkStack.Push(")");
                    WorkStack.Push("<z>");
                    WorkStack.Push("<V>");
                    WorkStack.Push("(");
                    break;
                case 31:
                    PrintLog(caseOf);
                    WorkStack.Push("<V>");
                    WorkStack.Push("c");
                    break;
                case 50:
                    PrintLog(caseOf);
                    break;
                case 100:
                    PrintLog(caseOf);
                    ++Counter;
                    break;
                case 999:
                    PrintLog(caseOf);
                    Counter++;
                    break;
                case 0:
                    PrintLog(0);
                    ++Counter;
                    break;
            }
        }

        void PrintLog(int Rule)
        {
            OutputStack.Push(WorkStack.Pop());
            Log += '\n' + "M (" + OutputStack.Peek() + "," + input[Counter] + ") = " + Convert.ToString(Rule);
        }

    }

}
