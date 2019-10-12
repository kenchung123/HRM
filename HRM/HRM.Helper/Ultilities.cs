using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;         
using System;
using System.Collections.Generic;
using System.Data;               
using System.Linq;

namespace HRM.Helper
{
    public static class Ultilities
    {
        public static object ConvertDataTableToJson(DataTable dt)
        {
            try
            {
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dt.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);
                    }
                    parentRow.Add(childRow);
                }
                return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(parentRow));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConvertDataTableToJsonString(DataTable dt)
        {
            try
            {
                List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
                Dictionary<string, object> childRow;
                foreach (DataRow row in dt.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);
                    }
                    parentRow.Add(childRow);
                }
                return JsonConvert.SerializeObject(parentRow);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object ConvertJsonStringToJson(string strObj)
        {
            try
            {
                return JsonConvert.DeserializeObject(strObj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object ConvertModelToObject<T>(T a)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(ConvertModelToString(a));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConvertModelToString<T>(T a)
        {
            try
            {
                return JsonConvert.SerializeObject(a, Formatting.None,
                          new JsonSerializerSettings()
                          {
                              PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                              ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                              ContractResolver = new CamelCasePropertyNamesContractResolver()
                          });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static T ConvertObjectToModel<T>(object a){


        //    return a;
        //}

        public static object ConvertModelToObject<T>(List<T> a)
        {
            try
            {
                return JsonConvert.DeserializeObject(JsonConvert.SerializeObject(a, Formatting.None,
                          new JsonSerializerSettings()
                          {
                              PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                              ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                              ContractResolver = new CamelCasePropertyNamesContractResolver()
                          }));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// true: is exist, false : not exist
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key"></param>
        /// <param name="valule"></param>
        /// <returns>true: is exist, false : not exist</returns>
        public static bool CheckExistTable(DataTable dt, string key, String value, out int index)
        {
            try
            {
                index = -1;
                for (var i = 0; i < dt.Rows.Count; i++)
                {
                    index = i;
                    if (dt.Rows[i][key].ToString() == value)
                    {
                        return true;
                    }
                }
            }
            catch
            {
                index = -1;
                return false;
            }
            return false;
        }


        public static bool ExecuteNonQuery(string SQLconnStr, string _stSQL)
        {
            try
            {
                SqlConnection conSQL = new SqlConnection(SQLconnStr);
                SqlCommand _command = new SqlCommand(_stSQL, conSQL);
                conSQL.Open();
                if (_command.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DataTable Execute(string SQLconnStr, string _stSQL)
        {
            try
            {
                DataTable _dt = new DataTable();
                SqlConnection conSQL = new SqlConnection(SQLconnStr);
                SqlCommand _command = new SqlCommand(_stSQL, conSQL);
                conSQL.Open();
                SqlDataAdapter _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(_dt);
                return _dt;
            }
            catch (Exception)
            {

            }
            return new DataTable();
        }

        public static DataSet DataSetExecute(string SQLconnStr, string _stSQL)
        {
            SqlConnection conSQL = new SqlConnection(SQLconnStr);
            try
            {
                DataSet _dts = new DataSet();
                SqlCommand _command = new SqlCommand(_stSQL, conSQL);
                conSQL.Open();
                SqlDataAdapter _adapter = new SqlDataAdapter(_command);
                _adapter.Fill(_dts);
                return _dts;
            }
            catch (Exception)
            {

            }
            conSQL.Open();
            return new DataSet();
        }


    }
}
