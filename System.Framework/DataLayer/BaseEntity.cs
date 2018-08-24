#define Encrypt
using System.Framework.Common;
using System;
using System.Collections;
using System.Data;
using System.Reflection;

namespace System.Framework.DataLayer
{
    /// <summary>
    /// EntityStatus ��� Entity �����O���ҭn�i�檺�ʧ@
    /// </summary>
    public enum EntityAction { Insert, Update, Delete, None }

    /// <summary>
    /// BaseEntity ���K�n�y�z�C
    /// </summary>
    public class BaseEntity
    {
        private IConnection _conn;
        private string _keys="";
        private string _tablename="";
        private string _modifyFields="";
        private string _commondbname = "";
        private EntityAction _action = EntityAction.None;
        private Hashtable conditionDictionary = new Hashtable();
        private ArrayList modifyDictionary	  = new ArrayList();
        private string _symmetricKey = "";
        //private const string EncryptFields =
        //    "RST_ID;RST_NAME;RST_SEX;RST_BIRDT;RST_PHONE1;RST_PHONE2;RST_PHONE3;RST_PHONE4;RST_MOBILE1;RST_MOBILE2;RST_ADDR1;RST_ADDR2;RST_ADDR3;RST_CREDITCARD;RST_ACCOUNT";
        //20170407 Jamie �H�Υd;�Ȧ�b�� ���[/�ѱK
        private const string EncryptFields =
            "RST_CREDITCARD;RST_ACCOUNT";

        #region Properties
        /// <summary>��Ʈw�s�����󤶭�</summary>
        public IConnection Conn
        {
            get { return _conn; }
            set { _conn = value;}
        }
        /// <summary>�DKey�C��</summary>
        public virtual string Keys
        {
            get { return _keys; }
            set { _keys = value;}
        }
        /// <summary>��ƪ�W��</summary>
        public virtual string TableName
        {
            get { return getTableName(); }
            set { _tablename = value;}
        }
        public virtual string ModifyFields
        {
            get 
            {
                if (modifyDictionary.Count > 0)
                {
                    _modifyFields = "";
                    foreach(string field in modifyDictionary)
                    {
                        if (_modifyFields == "")
                            _modifyFields = field;
                        else
                            _modifyFields += ";" + field; 
                    }
                }
                
                return _modifyFields;
            }
            set 
            {
                foreach(string field in value.Split(';'))
                {
                    if(!ModifyDictionary.Contains(field))
                        ModifyDictionary.Add(field);
                }
            }
        }
        /// <summary>�ݶi�檺�ʧ@</summary>
        public virtual EntityAction Action
        {
            get { return _action; }
            set { _action = value;}
        }       
        /// <summary>����ѼƦr��</summary>
        protected virtual Hashtable ConditionDictionary
        {
            get { return conditionDictionary; }
        }
        /// <summary>�ק����r��</summary>
        public virtual ArrayList ModifyDictionary
        {
            get { return modifyDictionary; }
        }
        /// <summary>�@�θ�Ʈw�W��</summary>
        public virtual string CommonDbName 
        {			
            set { _commondbname = value; }
        }
        #endregion

        #region Protected Method
        /// <summary>
        /// �s�WKey
        /// </summary>
        /// <param name="AKey">���W��</param>
        protected virtual void addKey(string AKey)
        {
            if (Keys != "")
                Keys += ",";
            Keys += AKey;
        }
  
        /// <summary>
        /// �R�����p��ƪ����O��
        /// </summary>
        protected virtual void deleteRelation(string ATableName, string AConditions)
        {
            string sql = "";
            if (AConditions == "")
            {
                string where = "";
                   
                Type t = this.GetType();   
                // ��Where����
                                     
                //�@���o�ثe�����ഫ��������SQL
                foreach(string item in Keys.Split(','))
                {
                    FieldInfo fi = t.GetField(item.ToUpper());
                    if (fi != null)
                    {
                        if (where == "")
                            where = string.Format("{0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                        else
                            where += string.Format("and {0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                    }
                }

                //�@���o�ثe�ݩʭ��ഫ��������SQL
                foreach(string item in Keys.Split(','))
                {
                    PropertyInfo pi = t.GetProperty(item.ToUpper());
                    if (pi != null)
                    {
                        if (where == "")
                            where = string.Format("{0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                        else
                            where += string.Format("and {0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                    }
                }

                sql = string.Format("delete {0} where {1} ", ATableName , where);
                Conn.executeNonQuery(sql);
            } 
            else
            {
                sql = string.Format("delete {0} where {1} ", ATableName, AConditions);
                Conn.executeNonQuery(sql);
            }
        }
        #endregion

        #region Method
        /// <summary>
        /// �s�W�O��
        /// </summary>
        public virtual int insert()
        {       
            string cols = "";
            string values = "";
            string sql = "";
            Type t = this.GetType();

            //�@���o�ثe�����ഫ��������SQL
            foreach(FieldInfo fi in t.GetFields())
            {
                if (checkModifyFields(fi.Name))
                {
                    if (cols == "")
                    {
                        cols = fi.Name;
                        values = changeToColumn(fi.Name, fi.GetValue(this));
                    }
                    else 
                    {
                        cols += ", " + fi.Name;
                        values += ", " + changeToColumn(fi.Name, fi.GetValue(this));
                    }
                }
            }
                                                                     
            //�@���o�ثe�ݩʭ��ഫ��������SQL
            foreach(PropertyInfo pi in t.GetProperties())
            {  
                if (pi.Name.IndexOf("_") > 0 && checkModifyFields(pi.Name))
                {
                    if (cols == "")
                    {
                        cols = pi.Name;
                        values = changeToColumn(pi.Name, pi.GetValue(this, null));
                    }
                    else 
                    {
                        cols += ", " + pi.Name;
                        values += ", " + changeToColumn(pi.Name, pi.GetValue(this, null));
                    }
                }
            }

            sql = string.Format("insert into {0} ({1}) values ({2})", TableName, cols, values );
            int affect = Conn.executeNonQuery(sql);

            Audit(EntityAction.Insert, affect);
            return affect;
        }

        /// <summary>
        /// �ק�O��
        /// </summary>
        public virtual int update()
        {
            string cols = "";
            string where = "";
            string sql = "";
            Type t = this.GetType();    

            // ��SQL Statement
            // ��set
            // ���o�ثe�����ഫ��������SQL
            foreach(FieldInfo fi in t.GetFields())
            {
                if (checkModifyFields(fi.Name))
                {
                    if (cols == "")
                        cols = string.Format("{0} = {1} ", fi.Name , changeToColumn(fi.Name, fi.GetValue(this)));
                    else 
                        cols += string.Format(",{0} = {1} ", fi.Name , changeToColumn(fi.Name, fi.GetValue(this)));
                }
            }

            //�@���o�ثe�ݩʭ��ഫ��������SQL
            foreach(PropertyInfo pi in t.GetProperties())
            {  
                if (pi.Name.IndexOf("_") > 0 && checkModifyFields(pi.Name))
                {
                    if (cols == "")
                        cols = string.Format("{0} = {1} ", pi.Name , changeToColumn(pi.Name, pi.GetValue(this,null)));
                    else 
                        cols += string.Format(",{0} = {1} ", pi.Name , changeToColumn(pi.Name, pi.GetValue(this,null)));
                }
            }

            // ��Where����
            //�@���o�ثe�����ഫ��������SQL
            foreach(string item in Keys.Split(','))
            {
                FieldInfo fi = t.GetField(item);
                if (fi != null)
                {
                    if (where == "")
                        where = string.Format("{0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                    else
                        where += string.Format("and {0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                }
            }
                                                                     
            //�@���o�ثe�ݩʭ��ഫ��������SQL
            foreach(string item in Keys.Split(','))
            {
                PropertyInfo pi = t.GetProperty(item);
                if (pi != null)
                {
                    if (where == "")
                        where = string.Format("{0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                    else
                        where += string.Format("and {0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                }
            }
            sql = string.Format(@"update {0} set {1} where {2}", TableName, cols, where);
            int affect = Conn.executeNonQuery(sql);

            Audit(EntityAction.Update, affect);
            return affect;
        }

        /// <summary>
        /// �R���O��
        /// </summary>
        public virtual void delete()
        {
            string where = "";
            string sql = "";
                   
            Type t = this.GetType();   
            // ��Where����
                                     
            //�@���o�ثe�����ഫ��������SQL
            foreach(string item in Keys.Split(','))
            {
                FieldInfo fi = t.GetField(item);
                if (fi != null)
                {
                    if (where == "")
                        where = string.Format("{0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                    else
                        where += string.Format("and {0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                }
            }
                                                                     
            //�@���o�ثe�ݩʭ��ഫ��������SQL
            foreach(string item in Keys.Split(','))
            {
                PropertyInfo pi = t.GetProperty(item);
                if (pi != null)
                {
                    if (where == "")
                        where = string.Format("{0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                    else
                        where += string.Format("and {0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                }
            }
                                                
            sql = string.Format("delete {0} where {1} ", TableName ,where);
            int affect = Conn.executeNonQuery(sql);

            Audit(EntityAction.Delete, affect);
        }
        
        /// <summary>
        /// ���J���
        /// </summary>
        /// <returns>�^�ǬO�_�����T���J���</returns>
        public virtual bool active()
        {
            string fieldname = "";
            string where = "";
            string sql = "";
            IDataReader reader = null;
            try
            {                             
                Type t = this.GetType();   
                // ��Where����
                                     
                //�@���o�ثe�����ഫ��������SQL
                foreach(string item in Keys.Split(','))
                {
                    FieldInfo fi = t.GetField(item);
                    if (fi != null)
                    {
                        if (where == "")
                            where = string.Format("{0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                        else
                            where += string.Format("and {0} = {1} ",item , changeToColumn(fi.Name, fi.GetValue(this)));
                    }
                }
                                                                     
                //�@���o�ثe�ݩʭ��ഫ��������SQL
                foreach(string item in Keys.Split(','))
                {
                    PropertyInfo pi = t.GetProperty(item);
                    if (pi != null)
                    {
                        if (where == "")
                            where = string.Format("{0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                        else
                            where += string.Format("and {0} = {1} ",item , changeToColumn(pi.Name, pi.GetValue(this, null)));
                    }
                }

                sql = string.Format("select * from {0} where {1} ", TableName ,where);
                reader = Conn.executeReader(sql);

                // ��SQL Statement
                if (!reader.Read())
                    return false;

               for(int i=0;i<reader.FieldCount;i++)
                {
                    fieldname = reader.GetName(i);
                    object data = reader.GetValue(i);
                    FieldInfo fi = t.GetField(fieldname);
                    if (fi != null)
                    {
                        setPropertyValue(fi, data);
                    }
                    else 
                    {
                        PropertyInfo pi = t.GetProperty(fieldname);
                        if (pi != null)
                            setPropertyValue(pi , data);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
        }

        /// <summary>
        /// �̦̱ۨ���ק�O��
        /// </summary>
        /// <param name="ACondition">�ۭq����</param>
        public virtual void updateAll(string ACondition)
        {
            string cols = "";
            Type t = this.GetType();    

            // ��set
                    
            //�@���o�ثe�����ഫ��������SQL
            foreach(FieldInfo fi in t.GetFields())
            {
                //if (fi.Name.IndexOf("_") > 0 && checkModifyFields(fi.Name))
                if (checkModifyFields(fi.Name))
                {
                    if (cols == "")
                        cols = string.Format("{0} = {1} ", fi.Name , changeToColumn(fi.Name, fi.GetValue(this)));
                    else 
                        cols += string.Format(",{0} = {1} ", fi.Name , changeToColumn(fi.Name, fi.GetValue(this)));
                }
            }
                                                                
            //�@���o�ثe�ݩʭ��ഫ��������SQL
            foreach(PropertyInfo pi in t.GetProperties())
            {  
                if (pi.Name.IndexOf("_") > 0 && checkModifyFields(pi.Name))
                {
                    if (cols == "")
                        cols = string.Format("{0} = {1} ", pi.Name , changeToColumn(pi.Name, pi.GetValue(this,null)));
                    else 
                        cols += string.Format(",{0} = {1} ", pi.Name , changeToColumn(pi.Name, pi.GetValue(this,null)));
                }
            }

            string sql = string.Format("update {0} set {1} {2} ",TableName , cols, (ACondition == "" ? "" : "where " + ACondition));
            Conn.executeNonQuery(sql);
        }

        /// <summary>
        /// �̦̱ۨ���R���O��
        /// </summary>
        /// <param name="ACondition">�ۭq����</param>
        public virtual int deleteAll(string ACondition)
        {
            string sql = "";
            sql = string.Format("delete {0} {1} ", TableName , (ACondition == "" ? "" : "where " + ACondition));
            return Conn.executeNonQuery(sql);
        }
        /// <summary>
        /// ���o�n�ޥΪ�����
        /// </summary>
        /// <param name="AParamName">����ѼƦW��</param>
        /// <param name="AParamValue">����Ѽƭ�</param>
        /// <returns>����y�k���e</returns>
        public virtual string getCondition(string AParamName, string AParamValue)
        {
            if (ConditionDictionary.ContainsKey(AParamName))
            {
                if (((string)ConditionDictionary[AParamName]).IndexOf("'?'") > 0)
                    ((string)ConditionDictionary[AParamName]).Replace("'?'", "N'?'");
                return ((string)ConditionDictionary[AParamName]).Replace("?", AParamValue);
            }
            else
                return "";
        }
        #endregion

        #region Private Function  
        /// <summary>
        /// �ˬd�O���O�_�n���ק�
        /// </summary>
        /// <param name="baseField">�������W��</param>
        /// <returns>�O�_�n�ק�</returns>
        private bool checkModifyFields(string baseField)
        {
            if (ModifyFields.Trim() == "") return true;

            foreach(string field in ModifyDictionary)
            {
                if (baseField.ToUpper() == field.ToUpper())
                    return true;
            }
            return false;
        }
        /// <summary>
        /// �P�_�ݩ����O,�M�w�O�_�[��޸�
        /// </summary>
        /// <param name="column">PropertyInfo or FieldInfo</param>
        /// <returns>�ݩʭ�</returns>
        private string changeToColumn(string colName, object column)
        {
            string result = "";
            if (column == null)
                result = "null";
            else
            {
                switch(column.GetType().ToString())
                {
                    case "System.DateTime":
                        DateTime dt = (DateTime)column;
                        if (dt.Year == 1)
                            result = "null";
                        else
#if(Encrypt)    
                            if (EncryptFields.IndexOf(colName.ToUpper()) > -1)
                                result = string.Format("N'{0}'",
                                    Encrypt(string.Format("{0}/{1}/{2} {3}:{4}:{5}",
                                    Utils.repairZero(4, dt.Year),
                                    Utils.repairZero(2, dt.Month),
                                    Utils.repairZero(2, dt.Day),
                                    Utils.repairZero(2, dt.Hour),
                                    Utils.repairZero(2, dt.Minute),
                                    Utils.repairZero(2, dt.Second))));
                            else result = string.Format("N'{0}/{1}/{2} {3}:{4}:{5}'",
                                Utils.repairZero(4, dt.Year),
                                Utils.repairZero(2, dt.Month),
                                Utils.repairZero(2, dt.Day),
                                Utils.repairZero(2, dt.Hour),
                                Utils.repairZero(2, dt.Minute),
                                Utils.repairZero(2, dt.Second));
#else          
                            result = string.Format("N'{0}/{1}/{2} {3}:{4}:{5}'", 
                                Utils.repairZero(4, dt.Year) ,
                                Utils.repairZero(2, dt.Month) ,
                                Utils.repairZero(2, dt.Day),
                                Utils.repairZero(2, dt.Hour) , 
                                Utils.repairZero(2, dt.Minute), 
                                Utils.repairZero(2, dt.Second));
#endif
                        break;
                    case  "System.Double":
#if(Encrypt) 
                        if (EncryptFields.IndexOf(colName.ToUpper()) > -1)
                            result = Encrypt(column.ToString());
                        else result = column.ToString();
#else
                        result = column.ToString();
#endif
                        break;
                    case  "System.Int32":
#if(Encrypt) 
                        if (EncryptFields.IndexOf(colName.ToUpper()) > -1)
                            result = Encrypt(column.ToString());
                        else result = column.ToString();
#else
                        result = column.ToString();
#endif
                        break;
                    case  "System.Boolean" :
#if(Encrypt) 
                        if (EncryptFields.IndexOf(colName.ToUpper()) > -1)
                            result = string.Format("N'{0}'", Encrypt((bool)column ? "1" : "0"));
                        else result = (bool)column ? "N'1'" : "N'0'";
#else
                        result = (bool)column ? "N'1'" : "N'0'";
#endif
                        break;
                    default : 
#if(Encrypt) 
                        if (EncryptFields.IndexOf(colName.ToUpper()) > -1)
                            result = string.Format("N'{0}'", Encrypt(column.ToString().Replace("'", "''")));
                        else result = string.Format("N'{0}'", column.ToString().Replace("'", "''"));
#else
                        result = string.Format("N'{0}'", column.ToString().Replace("'","''"));
#endif
                        break;
                }
            }
            return result;
        }

        /// <summary>
        /// �N�ȩ�J�������ݩ�
        /// </summary>
        /// <param name="pi">PropertyInfo</param>
        /// <param name="data">Column Value</param>
        private void setPropertyValue(PropertyInfo pi , object data)
        {                      
            if ((pi == null) && (data == null)) return;
            switch (pi.PropertyType.ToString())
            {
                case "System.DateTime" :
                    if (data != System.DBNull.Value)
                    {
                        if ((string)data != "")
                        {
                            try
                            {
#if(Encrypt) 
                                if (EncryptFields.IndexOf(pi.Name.ToUpper()) > -1)
                                    pi.SetValue(this, Convert.ToDateTime(Decrypt(data.ToString())), null);
                                else pi.SetValue(this, Convert.ToDateTime(data.ToString()), null);
#else
                                pi.SetValue(this, Convert.ToDateTime(data.ToString()), null);
#endif
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            pi.SetValue(this, Convert.ToDateTime("0001/01/01 00:00:00"), null);
                        }
                    }
                    else
                        pi.SetValue(this, Convert.ToDateTime("0001/01/01 00:00:00"), null);
                    break;
                case "System.Double" :    
                    if (data == System.DBNull.Value)
                        pi.SetValue(this, 0,null);
                    else
#if(Encrypt) 
                        if (EncryptFields.IndexOf(pi.Name.ToUpper()) > -1)
                            pi.SetValue(this, Convert.ToDouble(Decrypt(data.ToString())), null);
                        else pi.SetValue(this, Convert.ToDouble(data), null);
#else
                        pi.SetValue(this, Convert.ToDouble(data),null);
#endif
                    break;

                case "System.Int32" :
                    if (data == System.DBNull.Value)
                        pi.SetValue(this, 0,null);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(pi.Name.ToUpper()) > -1)
                            pi.SetValue(this, Convert.ToInt32(Decrypt(data.ToString())), null);
                        else pi.SetValue(this, Convert.ToInt32(data), null);
#else                       
                        pi.SetValue(this, Convert.ToInt32(data),null);
#endif
                    break;

                case "System.Boolean" :
                    if (data == System.DBNull.Value)
                        pi.SetValue(this, false, null);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(pi.Name.ToUpper()) > -1)
                            pi.SetValue(this, (Decrypt(data.ToString()) == "1"), null);
                        else pi.SetValue(this, (data.ToString() == "1"), null);
#else
                        pi.SetValue(this, (data.ToString() == "1"), null);
#endif
                    break;

                default :
                    if (data == System.DBNull.Value)
                        pi.SetValue(this, "", null);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(pi.Name.ToUpper()) > -1)
                            pi.SetValue(this, Decrypt(data.ToString()), null);
                        else pi.SetValue(this, data.ToString(), null);
#else
                        pi.SetValue(this, data.ToString(), null);
#endif
                        break;
            }
        }

        /// <summary>
        /// �N�ȩ�J���������
        /// </summary>
        /// <param name="fi">FieldInfo</param>
        /// <param name="data">Column Value</param>
        private void setPropertyValue(FieldInfo fi , object data)
        {                             
            if (fi == null)  return;
            switch (fi.FieldType.ToString())
            {
                case "System.DateTime" :     
                    if (data != System.DBNull.Value)
                    {
                        if ((string)data != "")
                        {
                            try
                            {
#if(Encrypt)
                                if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                                    fi.SetValue(this, Convert.ToDateTime(Decrypt(data.ToString())));
                                else fi.SetValue(this, Convert.ToDateTime(data.ToString()));
#else
                                fi.SetValue(this, Convert.ToDateTime(data.ToString()));
#endif
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            fi.SetValue(this, Convert.ToDateTime("0001/01/01 00:00:00"));
                        }
                    }
                    else
                        fi.SetValue(this, Convert.ToDateTime("0001/01/01 00:00:00"));
                    break;
                case "System.Double" :    
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, 0);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, Convert.ToDouble(Decrypt(data.ToString())));
                        else fi.SetValue(this, Convert.ToDouble(data));
#else
                        fi.SetValue(this, Convert.ToDouble(data));
#endif
                    break;

                case "System.Int32" :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, 0);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, Convert.ToInt32(Decrypt(data.ToString())));
                        else fi.SetValue(this, Convert.ToInt32(data));
#else
                        fi.SetValue(this, Convert.ToInt32(data));
#endif
                    break;

                case "System.Boolean" :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, false);
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, (Decrypt(data.ToString()) == "1"));
                        else fi.SetValue(this, (data.ToString() == "1"));
#else
                    	fi.SetValue(this, (data.ToString() == "1"));
#endif
                    break;

                case "System.Byte[]" :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, false);
                    else
                        fi.SetValue(this, (byte[])data);
                    break;

                default :
                    if (data == System.DBNull.Value)
                        fi.SetValue(this, "");
                    else
#if(Encrypt)
                        if (EncryptFields.IndexOf(fi.Name.ToUpper()) > -1)
                            fi.SetValue(this, Decrypt(data.ToString()));
                        else fi.SetValue(this, data.ToString());
#else
                        fi.SetValue(this, data.ToString());
#endif
                    break;
            }
        }

        /// <summary>
        /// �q�������ݩʱN�Ȩ��X
        /// </summary>
        /// <param name="t">���󫬺A</param>
        /// <param name="propertyName">�ݩʦW��</param>
        /// <param name="oriObject">�쪫��</param>
        /// <returns></returns>
        private string GetFieldValue(Type t ,string propertyName , object oriObject)
        {
            string values="";
            switch (t.GetField(propertyName.ToUpper()).FieldType.ToString())
            {
                case "System.DateTime":
                    DateTime dt = (DateTime)t.GetField(propertyName.ToUpper()).GetValue(oriObject);
                    values = string.Format("{0}/{1}/{2} {3}:{4}:{5}",  
                        Utils.repairZero(4, dt.Year) ,
                        Utils.repairZero(2, dt.Month) ,
                        Utils.repairZero(2, dt.Day),
                        Utils.repairZero(2, dt.Hour) , 
                        Utils.repairZero(2, dt.Minute), 
                        Utils.repairZero(2, dt.Second));
                    break;

                case "System.Boolean":
                    values = (bool)t.GetField(propertyName.ToUpper()).GetValue(oriObject) ? "Y" : "N";
                    break;

                default :
                    values = t.GetField(propertyName.ToUpper()).GetValue(oriObject).ToString();
                    break;
            }
            return values.Replace("'", "''");
        }
        /// <summary>
        /// ����SQL Statement��From�l�y��Ʈw�W��
        /// </summary>
        private string getTableName()
        {
            return _tablename.Replace("@", string.IsNullOrEmpty(_commondbname) ? "" : (_commondbname + ".dbo."));
        }

        /// <summary>
        /// ����Audit Log
        /// </summary>
        private void Audit(EntityAction action, int affect)
        {
            if (Conn.audit != null)
            {
                string operation = string.Empty;
                string functionId = string.Empty;
                string functionName = string.Empty;
                bool needAudit = false;
                
                switch (action)
                {
                    case EntityAction.Insert:
                        if (this.GetType().Name == "Role")
                            operation = AuditAction.CreateAutho;
                        else operation = AuditAction.CreateProcess;
                        break;
                    case EntityAction.Update:
                        if (this.GetType().Name == "Role")
                            operation = AuditAction.UpdateAutho;
                        else operation = AuditAction.UpdateProcess;
                        break;
                    case EntityAction.Delete:
                        if (this.GetType().Name == "Role")
                            operation = AuditAction.DeleteAutho;
                        else operation = AuditAction.DeleteProcess;
                        break;
                }

                //�@��@�~
                foreach (Function function in Conn.audit.Functions)
                {
                    if(function.EntityName.ToUpper() == this.GetType().Name.ToUpper() && function.Name == Conn.audit.FunctionName)
                    {
                        functionId = function.Serno;
                        functionName = function.Name;
                        needAudit = function.NeedAudit;
                        break;
                    }
                }
                //�n�X�J
                if (this.GetType().Name == "WorkTime_I")
                {
                    needAudit = true;
                    FieldInfo[] fields = this.GetType().GetFields();
                    foreach (FieldInfo field in fields)
                    {
                        if (field.Name == "WKT_TYPE" && field.GetValue(this).ToString() == "0")
                            operation = AuditAction.Login;
                        else if (field.Name == "WKT_TYPE" && field.GetValue(this).ToString() == "1")
                            operation = AuditAction.Logout;
                    }
                }

                if (needAudit)
                {
                    if (!Conn.audit.AuditHistory.Exists(s => s == (functionId + operation)))
                    {
                        string fields = "ADL_SERNO, COM_SERNO, ADL_LOGINID, ADL_DATE, ADL_TIME, ADL_SYSTEMID, ADL_FUNCTIONID, ADL_FUNCTIONNAME, ADL_ACTION, ADL_STATUS, ADL_CLIENTIP, ADL_HOST, ADL_ISEXPORT";
                        string datas = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}', '0'",
                                                    Utils.GenerateSerialNum(),
                                                    Conn.audit.Company,
                                                    Conn.audit.LoginID,
                                                    Utils.DatetimeToShortDate(DateTime.Now).Replace("/", ""),
                                                    Utils.DatetimeToShortTime(DateTime.Now).Replace(":", ""),
                                                    Conn.audit.SystemID,
                                                    functionId,
                                                    functionName,
                                                    operation,
                                                    affect > 0 ? AuditStatus.Success : AuditStatus.Fail,
                                                    Conn.audit.ClientIP,
                                                    Conn.audit.Host);
                        string audit = string.Format("insert into [AUDITLOG] ({0}) values ({1})", fields, datas);
                        Conn.executeNonQuery(audit);

                        Conn.audit.AuditHistory.Add(functionId + operation);
                    }
                }
            }
        }

        private string Encrypt(string value)
        {
            //return string.Format("convert(nvarchar(512),convert(varbinary(512),{0}),1)", value);
            return Utils.AESEncrypt(value, _symmetricKey);
        }

        private string Decrypt(string encrypt)
        {
            //return string.Format("convert(nvarchar(100),convert(varbinary(512),{0},1))", encrypt);
            return Utils.AESDecrypt(encrypt, _symmetricKey);
        }
        #endregion

        /// <summary>
        /// �غc��
        /// </summary>
        /// <param name="AConn">��Ʈw�s�����󤶭�</param>
        public BaseEntity(IConnection AConn)
        {
            _conn = AConn;
#if(Encrypt)
            if (_conn != null)
                _symmetricKey = Conn.executeScalar("SELECT Key_GUID('xKey')").ToString().ToUpper();
#endif
        }
    }
}
