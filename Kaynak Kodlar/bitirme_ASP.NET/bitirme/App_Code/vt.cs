using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace _vt
{
    /// <summary>
    /// veritabaný eriþimini ve iþlemlerini gerçekler
    /// </summary>
    public class vt
    {
        private string cs;      //baðlantý cümleciði


        public vt()
        {
            ConnectionStringSettings settings;
            settings = ConfigurationManager.ConnectionStrings["HataTakipConnectionString"];
            cs = settings.ConnectionString;
        }


        //sorgu olmayan iþlemleri gerçekler (delete, update, insert)
        public bool executeNonQuery(string sql)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }


        //parametreli sorgu olmayan iþlemleri gerçekler (delete, update, insert)
        public bool executeNonQuery(string sql, ArrayList parameterNameList, ArrayList parameterList)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(sql, con);

            for (int i = 0; i < parameterList.Count; i++)
            {
                SqlParameter p1 = new SqlParameter(parameterNameList[i].ToString(), parameterList[i]);
                cmd.Parameters.Add(p1);
            }

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return true;
            }
            catch
            {
                return false;
            }        
        }


        //verilen isme sahip stored procedure (saklý yordam) yürütür
        public uint executeStoredProcedure(string storedProcedureName, ArrayList parameterNameList, ArrayList parameterList)
        {
            uint returnValue;

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand(storedProcedureName, con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter returnValueP = new SqlParameter("@RETURN_VALUE", SqlDbType.Int);
            returnValueP.Direction = ParameterDirection.ReturnValue;


            for (int i = 0; i < parameterList.Count; i++)
            {
                SqlParameter p1 = new SqlParameter(parameterNameList[i].ToString(), SqlDbType.Int);
                p1.Value = parameterList[i];
                cmd.Parameters.Add(p1);
            }

            cmd.Parameters.Add(returnValueP);

            try
            {
                con.Open();

                //stored procedure ý çalýþtýrýr
                cmd.ExecuteNonQuery();

                //dönüþ deðerini okur
                returnValue = Convert.ToUInt32(returnValueP.Value);

                con.Close();
            }
            catch
            {
                returnValue = 0;
            }

            return returnValue;
        }


        //select sorgu sonucunu dataset nesnesine doldurur
        public DataSet fillDataset(string sql)
        {
            DataSet ds = new DataSet();

            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            da.Fill(ds);

            return ds;
        }
    }
}
