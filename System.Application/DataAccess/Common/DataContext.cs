using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;
using System.Application.DataAccess.SQLStatement;
using System.Application.Common;
using System.Threading.Tasks;
using System.Linq;
using Oracle.ManagedDataAccess.Client;

namespace System.Application.DataAccess.Common
{
    public class DataContext
    {
        static CriteriaVisitor visitor = new CriteriaVisitor(CriteriaVisitor.SQLType.Oracle);
        #region private Methods
        //資料 資料實體 對應
        private static void ORMapping(IDataObject dataObject, IDataReader reader)
        {
            //Parallel.For(0, dataObject.GetType().GetProperties().Length, (int i) =>
            foreach (PropertyInfo property in dataObject.GetType().GetProperties())
            {
                //PropertyInfo property = (PropertyInfo)dataObject.GetType().GetProperties()[i];
                foreach (Attribute attribute in Attribute.GetCustomAttributes(property))
                {
                    if ((attribute.GetType() == typeof(ColumnAttribute)) && ((attribute as ColumnAttribute).IsMapping))
                    {
                        if (!string.IsNullOrEmpty((attribute as ColumnAttribute).MappingName))
                            SetColumnValue(dataObject, property, reader.GetValue(reader.GetOrdinal((attribute as ColumnAttribute).MappingName)));
                        else SetColumnValue(dataObject, property, reader.GetValue(reader.GetOrdinal(property.Name)));
                    }
                }
            }
            //);
        }

        //設定資料實體欄位值
        private static void SetColumnValue(IDataObject dataObject, PropertyInfo property, object data)
        {
            switch (property.PropertyType.ToString())
            {
                case "System.Int32":
                    if (data == System.DBNull.Value)
                        property.SetValue(dataObject, 0, null);
                    else property.SetValue(dataObject, Convert.ToInt32(data), null);
                    break;

                case "System.Double":
                    if (data == System.DBNull.Value)
                        property.SetValue(dataObject, 0, null);
                    else property.SetValue(dataObject, Convert.ToDouble(data), null);
                    break;

                case "System.Boolean":
                    if (data == System.DBNull.Value)
                        property.SetValue(dataObject, false, null);
                    else property.SetValue(dataObject, (data.ToString() == "Y"), null);
                    break;

                case "System.DateTime":
                    if (data == System.DBNull.Value)
                        property.SetValue(dataObject, Convert.ToDateTime("0001/01/01 00:00:00"), null);
                    else
                    {
                        DateTime dt;
                        if ((DateTime.TryParseExact(data.ToString(), "yyyy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt))||
                            (DateTime.TryParseExact(data.ToString(), "yyyy/MM/dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt)))
                            property.SetValue(dataObject, Convert.ToDateTime(data.ToString()), null);
                        else
                            property.SetValue(dataObject, Convert.ToDateTime("0001/01/01 00:00:00"), null);
                    }
                    break;

                default:
                    if (data == System.DBNull.Value)
                        property.SetValue(dataObject, "", null);
                    else property.SetValue(dataObject, data.ToString().Trim(), null);
                    break;
            }
        }

        //條件轉譯
        private static Dictionary<SQLSyntax, string> TranslateCriteria<T>(ICriteria<T> criteria)
        {
            Dictionary<SQLSyntax, string> resultDictionary = new Dictionary<SQLSyntax, string>();
            foreach (var expressionKeyValePair in criteria.ExpressionDictionary)
            {
                if (expressionKeyValePair.Key == SQLSyntax.Where.ToString())
                {
                    string condition = "";
                    foreach (Expression expression in expressionKeyValePair.Value)
                    {
                        condition += (condition == "") ? visitor.TranslateToSQL(expression) : " AND " + visitor.TranslateToSQL(expression);
                    }
                    resultDictionary.Add((SQLSyntax)Enum.Parse(typeof(SQLSyntax), expressionKeyValePair.Key), condition);
                }
                else
                {
                    foreach (Expression expression in expressionKeyValePair.Value)
                    {
                        if (!resultDictionary.ContainsKey((SQLSyntax)Enum.Parse(typeof(SQLSyntax), expressionKeyValePair.Key)))
                        {
                            resultDictionary.Add((SQLSyntax)Enum.Parse(typeof(SQLSyntax), expressionKeyValePair.Key), visitor.TranslateToSQL(expression));
                        }
                    }
                }
            }
            return resultDictionary;
        }

//        private static void Audit<T>(IConnection conn, T entity, SQLSyntax sqlsyntax) where T : EntityBase
//        {
//            string auditSql = @"INSERT INTO [AUDIT] (AUD_SERNO, FUT_GROUP, FUT_NAME, BRN_NAME, ACC_NAME, 
//AUD_DTTM, AUD_OLDCOLUMN, AUD_NEWCOLUMN, AUD_COMMENT) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', 
//'{5}', '{6}', '{7}', '{8}')";
//            auditSql = string.Format(auditSql, 
//                My.GenSerNo(),
//                entity.Description,
//                entity.Description,
//                "",
//                "",
//                My.DatetimeToDateTimeStr(DateTime.Now),
//                "",
//                "",
//                sqlsyntax.ToString()
//            );
//            conn.ExecuteNonQuery(auditSql);
//        }
        #endregion

        #region CRUD - Create
        public static bool Add<T>(IConnection conn, T entity) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildInsert(SQLSyntax.Insert, entity.Mapping);
                sql.BuildInsert(SQLSyntax.Fields, entity.Fields);
                sql.BuildInsert(SQLSyntax.Values, entity.InsertValues);

                //if (entity.NeedAudit) Audit<T>(conn, entity, SQLSyntax.Insert);
                sqlStatement = sql.Insert;
                return conn.ExecuteNonQuery(sqlStatement) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        public static bool Add<T>(IConnection conn, T entity, out string sqlOut) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildInsert(SQLSyntax.Insert, entity.Mapping);
                sql.BuildInsert(SQLSyntax.Fields, entity.Fields);
                sql.BuildInsert(SQLSyntax.Values, entity.InsertValues);

                //if (entity.NeedAudit) Audit<T>(conn, entity, SQLSyntax.Insert);
                sqlStatement = sql.Insert;
                sqlOut = sqlStatement;
                return conn.ExecuteNonQuery(sqlStatement) > 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        #endregion

        #region CRUD - Read
        public static int Count<T>(IConnection conn, ICriteria<T> criteria) where T : IDataObject, new()
        {
            int count = 0;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, " COUNT(*) ");
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                {
                    sql.BuildQuery(item.Key, item.Value);
                }

                count = Convert.ToInt32(conn.ExecuteScalar(sql.Query));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
            return count;
        }
        public static List<string> Distinct<T>(IConnection conn, string fieldName, ICriteria<T> criteria) where T : IDataObject, new()
        {
            List<string> distinctList = new List<string>();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, string.Format(" DISTINCT {0} ", fieldName));
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                {
                    sql.BuildQuery(item.Key, item.Value);
                }

                reader = conn.ExecuteReader(sql.Query);
                while (reader.Read())
                {
                    distinctList.Add(reader.GetValue(reader.GetOrdinal(fieldName)).ToString().Trim());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
            return distinctList;
        }
        public static List<T> Query<T>(IConnection conn, ICriteria<T> criteria) where T : IDataObject, new()
        {
            List<T> dataObjectList = new List<T>();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, (new T()).Fields);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                {
                    sql.BuildQuery(item.Key, item.Value);
                }
                reader = conn.ExecuteReader(sql.Query);
                while(reader.Read())
                {
                    T dataObject = new T();
                    ORMapping(dataObject, reader);
                    dataObjectList.Add(dataObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }

            return dataObjectList;
        }

        public static List<T> QueryTop<T>(IConnection conn, ICriteria<T> criteria, int topCount = 1) where T : IDataObject, new()
        {
            List<T> dataObjectList = new List<T>();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Top, topCount.ToString(), (new T()).Fields);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);

                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                    sql.BuildQuery(item.Key, item.Value);

                reader = conn.ExecuteReader(sql.Query);
                while (reader.Read())
                {
                    T dataObject = new T();
                    ORMapping(dataObject, reader);
                    dataObjectList.Add(dataObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }

            return dataObjectList;
        }

        public static List<T> Query<T>(IConnection conn, string sql) where T : IDataObject, new()
        {
            List<T> dataObjectList = new List<T>();
            IDataReader reader = null;
            try
            {
                reader = conn.ExecuteReader(sql);
                while (reader.Read())
                {
                    T dataObject = new T();
                    ORMapping(dataObject, reader);
                    dataObjectList.Add(dataObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }

            return dataObjectList;
        }

        public static List<T> Query<T>(IConnection conn, string sql, Dictionary<string,string> sqlParameters) where T : IDataObject, new()
        {
            List<T> dataObjectList = new List<T>();
            IDataReader reader = null;
            try
            {
                reader = conn.ExecuteReader(sql, sqlParameters);
                while (reader.Read())
                {
                    T dataObject = new T();
                    ORMapping(dataObject, reader);
                    dataObjectList.Add(dataObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }

            return dataObjectList;
        }

        public static T QueryByKey<T>(IConnection conn, ICriteria<T> criteria) where T : IDataObject, new()
        {
            T dataObject = new T();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, (new T()).Fields);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                {
                    sql.BuildQuery(item.Key, item.Value);
                }

                reader = conn.ExecuteReader(sql.Query);
                if (reader.Read())
                {
                    ORMapping(dataObject, reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
            return dataObject;
        }
        public static T QueryByKey<T>(IConnection conn, string keyValue) where T : EntityBase, new()
        {
            T dataObject = new T();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, (new T()).Fields);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                sql.BuildUpdate(SQLSyntax.Where, (new T()).GetKeyCondition(keyValue));

                reader = conn.ExecuteReader(sql.Query);
                if (reader.Read())
                {
                    ORMapping(dataObject, reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
            return dataObject;
        }
        public static T QueryBy<T>(IConnection pConn, string pCondition) where T : EntityBase, new()
        {
            T dataObject = new T();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, (new T()).Fields);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                sql.BuildUpdate(SQLSyntax.Where, pCondition);

                reader = pConn.ExecuteReader(sql.Query);
                if (reader.Read())
                {
                    ORMapping(dataObject, reader);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
            return dataObject;
        }
        public static List<T> QueryMultiBy<T>(IConnection pConn, string pCondition) where T : EntityBase, new()
        {
            List<T> dataObjectList = new List<T>();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            try
            {
                sql.BuildQuery(SQLSyntax.Select, (new T()).Fields);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                sql.BuildUpdate(SQLSyntax.Where, pCondition);

                reader = pConn.ExecuteReader(sql.Query);
                while (reader.Read())
                {
                    T dataObject = new T();
                    ORMapping(dataObject, reader);
                    dataObjectList.Add(dataObject);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
            return dataObjectList;
        }
        public static string QueryBy<T>(IConnection pConn, string pField, string pCondition) where T : EntityBase, new()
        {
            T dataObject = new T();
            IDataReader reader = null;
            SQLBuilder sql = new TSQLBuilder();
            string value = string.Empty;
            try
            {
                sql.BuildQuery(SQLSyntax.Select, pField);
                sql.BuildQuery(SQLSyntax.From, (new T()).Mapping);
                sql.BuildUpdate(SQLSyntax.Where, pCondition);

                reader = pConn.ExecuteReader(sql.Query);
                if (reader.Read())
                {
                    value = reader[0].ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if ((reader != null) || (!reader.IsClosed))
                    reader.Close();
            }
            return value;
        }
        #endregion

        #region CRUD - Update
        public static int Update<T>(IConnection conn, T entity) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildUpdate(SQLSyntax.Update, entity.Mapping);
                sql.BuildUpdate(SQLSyntax.Set, entity.UpdateContent);
                sql.BuildUpdate(SQLSyntax.Where, entity.KeyCondition);

                //if (entity.NeedAudit) Audit<T>(conn, entity, SQLSyntax.Update);
                sqlStatement = sql.Update;
                return conn.ExecuteNonQuery(sqlStatement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        public static int Update<T>(IConnection conn, T entity, out string sqlOut) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildUpdate(SQLSyntax.Update, entity.Mapping);
                sql.BuildUpdate(SQLSyntax.Set, entity.UpdateContent);
                sql.BuildUpdate(SQLSyntax.Where, entity.KeyCondition);

                //if (entity.NeedAudit) Audit<T>(conn, entity, SQLSyntax.Update);
                sqlStatement = sql.Update;
                sqlOut = sqlStatement;
                return conn.ExecuteNonQuery(sqlStatement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        public static int Update<T>(IConnection conn, T entity, ICriteria<T> criteria) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildUpdate(SQLSyntax.Update, entity.Mapping);
                sql.BuildUpdate(SQLSyntax.Set, entity.UpdateContent);
                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                {
                    sql.BuildUpdate(item.Key, item.Value);
                }

                //if (entity.NeedAudit) Audit<T>(conn, entity, SQLSyntax.Update);
                sqlStatement = sql.Update;
                return conn.ExecuteNonQuery(sqlStatement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        // Parameter with Transaction or NOT
        public static int Update<T>(IConnection conn, T entity, bool transact) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildUpdate(SQLSyntax.Update, entity.Mapping);
                sql.BuildUpdate(SQLSyntax.Set, entity.UpdateContent);
                sql.BuildUpdate(SQLSyntax.Where, entity.KeyCondition);

                sqlStatement = sql.Update;

                if(transact)
                {
                    conn.BeginTransaction();
                    int result = conn.ExecuteNonQuery(sqlStatement);

                    if (result == 0)
                        conn.Rollback();
                    else
                        conn.Commit();

                    return result;
                }
                else
                    return conn.ExecuteNonQuery(sqlStatement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        public static int Update(IConnection conn, string pSql)
        {
            try
            {
                return conn.ExecuteNonQuery(pSql);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + pSql + "}");
            }
            finally
            {
            }
        }
        #endregion

        #region CRUD - Delete
        public static int Delete<T>(IConnection conn, T entity) where T : EntityBase
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildDelete(SQLSyntax.Delete, entity.Mapping);
                sql.BuildDelete(SQLSyntax.Where, entity.KeyCondition);

                //if (entity.NeedAudit) Audit<T>(conn, entity, SQLSyntax.Delete);
                sqlStatement = sql.Delete;
                return conn.ExecuteNonQuery(sqlStatement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        public static int Delete<T>(IConnection conn, ICriteria<T> criteria) where T : EntityBase, new()
        {
            SQLBuilder sql = new TSQLBuilder();
            string sqlStatement = string.Empty;
            try
            {
                sql.BuildDelete(SQLSyntax.Delete, (new T()).Mapping);
                Dictionary<SQLSyntax, string> sqlSyntaxDictionary = TranslateCriteria<T>(criteria);
                foreach (var item in sqlSyntaxDictionary)
                {
                    sql.BuildDelete(item.Key, item.Value);
                }

                sqlStatement = sql.Delete;
                return conn.ExecuteNonQuery(sqlStatement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "{" + sqlStatement + "}");
            }
            finally
            {
            }
        }
        #endregion

        public static string GetUniqCaseNumber(IConnection conn , string product, string date,string buysell, string type)
        {
            string rtnSerno = "";
            
            IDataReader reader = conn.ExecuteReader("GetUniqCaseNumber '" + product + "','" + buysell + "','" + date + "','" + type + "'");
            if (reader.Read())
            {
                rtnSerno = (string)reader.GetValue(0);
            }

            return rtnSerno;
        }

        public static string spGetUniqCaseNumber(string connString, string product, string date, string buysell, string type)
        {
            string rtnSerno = "";
            OracleConnection conn = new OracleConnection(connString);
            try
            {
                conn.Open();

                OracleCommand cmd = new OracleCommand("GetUniqCaseNumber", conn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add(new OracleParameter("ret", OracleDbType.Varchar2,100));
                cmd.Parameters["ret"].Direction = ParameterDirection.ReturnValue;

                //加入參數no_in 
                cmd.Parameters.Add(new OracleParameter("PRODUCT", OracleDbType.Varchar2, 100));
                cmd.Parameters["PRODUCT"].Direction = ParameterDirection.Input;
                cmd.Parameters["PRODUCT"].Value = product;

                cmd.Parameters.Add(new OracleParameter("BULLSELL", OracleDbType.Varchar2, 100));
                cmd.Parameters["BULLSELL"].Direction = ParameterDirection.Input;
                cmd.Parameters["BULLSELL"].Value = buysell;

                cmd.Parameters.Add(new OracleParameter("CASEDATE", OracleDbType.Varchar2, 100));
                cmd.Parameters["CASEDATE"].Direction = ParameterDirection.Input;
                cmd.Parameters["CASEDATE"].Value = date;

                cmd.Parameters.Add(new OracleParameter("CASETYPE", OracleDbType.Varchar2, 100));
                cmd.Parameters["CASETYPE"].Direction = ParameterDirection.Input;
                cmd.Parameters["CASETYPE"].Value = type;

                //執行命令, 並傳回回傳值
                cmd.ExecuteNonQuery();
                rtnSerno = cmd.Parameters["ret"].Value.ToString();
            }catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return rtnSerno;
        }
    }
}
