using System.IO;
using System.Collections.Generic;
class Program
{
    static void Main()
    {


        String basePath = "INSERTYOURPATH";

        var tables = new Dictionary<string, string>()
        {
           {"customer.tbl", "customer" },
           {"lineitem.tbl", "lineitem" },
           {"nation.tbl", "nation" },
           {"orders.tbl", "orders" },
           {"part.tbl", "part" },
           {"partsupp.tbl", "partsupp" },
           {"region.tbl", "region" },
           {"supplier.tbl", "supplier" }

        };


        foreach (var table in tables)
        {
            StreamReader sr = new StreamReader($"{basePath}\\{table.Key}");
            String line = sr.ReadLine();
            string res;
            using StreamWriter sw = new StreamWriter($"{basePath}\\{table.Value}_sql.sql");

            while (line != null)
            {

                string[] dataHolder = line.Split('|');

                switch (table.Value)
                {
                    case "customer":
                        res = $"INSERT INTO customer(c_custkey, c_name, c_address, c_nationkey, c_phone, c_acctbal, c_mktsegment, c_comment) VALUES " +
                        $"({dataHolder[0]}, '{dataHolder[1]}', '{dataHolder[2]}', {dataHolder[3]}, '{dataHolder[4]}', {dataHolder[5]}, '{dataHolder[6]}', '{dataHolder[7]}');";
                        break;

                    case "lineitem":
                        res = $"INSERT INTO lineitem(l_orderkey, l_partkey, l_suppkey, l_linenumber, l_quantity, l_extendedprice, l_discount, l_tax, l_returnflag, l_linestatus, l_shipdate, " +
                        $"l_commitdate, l_receiptdate, l_shipinstruct, l_shipmode, l_comment) VALUES " +
                        $"({dataHolder[0]}, {dataHolder[1]}, {dataHolder[2]}, {dataHolder[3]}, {dataHolder[4]}, {dataHolder[5]}, {dataHolder[6]}, {dataHolder[7]}, " +
                        $"'{dataHolder[8]}', '{dataHolder[9]}', TO_DATE('{dataHolder[10]}', 'YYYY-MM-DD'), TO_DATE('{dataHolder[11]}', 'YYYY-MM-DD'), " +
                        $"TO_DATE('{dataHolder[12]}', 'YYYY-MM-DD'), '{dataHolder[13]}', '{dataHolder[14]}', '{dataHolder[15]}');";
                        break;

                    case "nation":
                        res = $"INSERT INTO nation(n_nationkey, n_name, n_regionkey, n_comment) VALUES " +
                        $"({dataHolder[0]}, '{dataHolder[1]}', {dataHolder[2]}, '{dataHolder[3]}');";
                        break;

                    case "orders":
                        res = $"INSERT INTO orders(o_orderkey, o_customerkey, o_orderstatus, o_totalprice, o_orderdate, o_orderpriority, o_clerk, o_shippriority, o_comment) VALUES " +
                        $"({dataHolder[0]}, {dataHolder[1]}, '{dataHolder[2]}', {dataHolder[3]}, TO_DATE('{dataHolder[4]}', 'YYYY-MM-DD'), '{dataHolder[5]}', " +
                        $"'{dataHolder[6]}', {dataHolder[7]}, '{dataHolder[8]}');";
                        break;

                    case "part":
                        res = $"INSERT INTO part(p_partkey, p_name, p_mfgr, p_brand, p_type, p_size, p_container, p_retailprice, p_comment) VALUES " +
                        $"({dataHolder[0]}, '{dataHolder[1]}', '{dataHolder[2]}', '{dataHolder[3]}', '{dataHolder[4]}', {dataHolder[5]}, '{dataHolder[6]}', {dataHolder[7]}, '{dataHolder[8]}');";
                        break;

                    case "partsupp":
                        res = $"INSERT INTO partsupp(ps_partkey, ps_suppkey, ps_availqty, ps_supplycost, ps_comment) VALUES " +
                        $"({dataHolder[0]}, {dataHolder[1]}, {dataHolder[2]}, {dataHolder[3]}, '{dataHolder[4]}');";
                        break;

                    case "region":
                        res = $"INSERT INTO region(r_regionkey, r_name, r_comment) VALUES " +
                        $"({dataHolder[0]}, '{dataHolder[1]}', '{dataHolder[2]}')";
                        break;

                    case "supplier":
                        res = $"INSERT INTO supplier(s_suppkey, s_name, s_address, s_nationkey, s_phone, s_acctbal, s_comment) VALUES " +
                        $"({dataHolder[0]}, '{dataHolder[1]}', '{dataHolder[2]}', {dataHolder[3]}, '{dataHolder[4]}', {dataHolder[5]}, '{dataHolder[6]}');";
                        break;
                    default:
                        res = "";
                        break;
                }
                sw.WriteLine(res);

                line = sr.ReadLine();


            }

        }


    }
}
