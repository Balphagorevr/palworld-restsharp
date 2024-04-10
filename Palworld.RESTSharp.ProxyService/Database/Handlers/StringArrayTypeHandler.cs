using Dapper;
using System.Data;

namespace Palworld.RESTSharp.ProxyService.Database
{
    public class StringArrayTypeHandler: SqlMapper.TypeHandler<string[]>
    {
        public override string[] Parse(object value) => value.ToString().Split(',');

        public override void SetValue(IDbDataParameter parameter, string[] value) => parameter.Value = string.Join(",", value);
    }
}