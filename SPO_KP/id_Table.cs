using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPO_KP
{
    class id_Table
    {
	        public id_Table()
        {
            buff.name = "";
            buff.numberInProgram = 0;
            buff.type = "";
            buff.value = "null";
        }
        Dictionary<string, ID> idTable = new Dictionary<string, ID>();
        Dictionary<string, ID> constTable = new Dictionary<string, ID>();
        struct ID
        {
            public int numberInProgram;
            public string name;
            public string type;
            public string value;
        }
        int constantCounter;
        ID buff;
        void clearBuff()
        {
            buff.name = "";
            buff.numberInProgram = 0;
            buff.type = "";
            buff.value = "null";
        }
        public bool addRecord(TranslationTable.translationTable input) // Возвращает "true", если идентификатор/константа успешно занесен(-на) в таблицу.
        {
            string nameForBuf;
            if (input.isIdentifier)
            {
                nameForBuf = input.Expression;
                if (!idTable.ContainsKey(nameForBuf))
                {
                    buff.numberInProgram = input.numberInProgram;
                    buff.name = nameForBuf;
                    buff.type = input.AttributeValue;
                    buff.value = "null";
                    idTable.Add(nameForBuf, buff);
                    clearBuff();
                    return true;
                }
            }
            if (input.isConst)
            {
                buff.name = "C" + Convert.ToString(constantCounter);
                ++constantCounter;
                buff.numberInProgram = input.numberInProgram;
                if (input.Expression == "TRUE" || input.Expression == "FALSE")
                    buff.type = "logic";
                else
                    buff.type = "digit";
                buff.value = input.Expression;
                constTable.Add(buff.name, buff);
                clearBuff();
                return true;
            }
                return false;
        }
    }

}
