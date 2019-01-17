using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivecountStats.DataLayer
{
    public static class DbContextExtension
    {
        private static SqlParameter[] getParams(object pars)
        {
            Dictionary<string, object> dictPars = null;
            if (pars is Dictionary<string, object>)
            {
                dictPars = pars as Dictionary<string, object>;
            }
            else if (pars != null)
            {
                dictPars = pars.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(pars, null));
            }

            SqlParameter[] sqlParams = dictPars != null ?
                dictPars.Select(a => new SqlParameter(a.Key, a.Value)).ToArray() :
                new SqlParameter[0];

            return sqlParams;
        }

        public static List<T1> SqlList<T1>(this DbContext db, string sql, object pars)
        {
            var sqlParams = getParams(pars);
            var res = db.Database.SqlQuery<T1>(sql, sqlParams);
            return res.ToList();
        }

        public static T1 SqlScalar<T1>(this DbContext db, string sql, object pars = null)
        {
            var list = SqlList<T1>(db, sql, pars);

            return list.FirstOrDefault();
        }

        public static void SqlExec(this DbContext db, string sql, object pars = null)
        {
            var sqlParams = getParams(pars);
            db.Database.ExecuteSqlCommand(sql, sqlParams);
        }

        public static void DeleteDefaultContraint(this IDbMigration migration, string tableName, string colName, bool suppressTransaction = false)
        {
            var query = @"
DECLARE @SQL varchar(1000)
SET @SQL='ALTER TABLE {0} DROP CONSTRAINT ['+(SELECT name
FROM sys.default_constraints
WHERE parent_object_id = object_id('{0}')
AND col_name(parent_object_id, parent_column_id) = '{1}')+']';
PRINT @SQL;
EXEC(@SQL);
";
            var sql = new SqlOperation(String.Format(query, tableName, colName)) { SuppressTransaction = suppressTransaction };
            migration.AddOperation(sql);
        }
    }
}
