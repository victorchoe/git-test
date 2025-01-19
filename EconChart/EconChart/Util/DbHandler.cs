using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EconChart.Model;
using System.Windows;

namespace EconChart.Util
{
    class DbHandler
    {
        static string connectionString = Config.connectionString;

        #region fred exchange rate
        // Brazil / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexBzUs()
        {
            string SQL = SqlStatement.FredDexBzUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Canada / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexCaUs()
        {
            string SQL = SqlStatement.FredDexCaUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // China / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexChUs()
        {
            string SQL = SqlStatement.FredDexChUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // India / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexInUs()
        {
            string SQL = SqlStatement.FredDexInUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Japan / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexJpUs()
        {
            string SQL = SqlStatement.FredDexJpUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // South Korea / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexKoUs()
        {
            string SQL = SqlStatement.FredDexKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Malaysia / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexMaUs()
        {
            string SQL = SqlStatement.FredDexMaUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Mexico / U.S.Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexMxUs()
        {
            string SQL = SqlStatement.FredDexMxUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Sweden / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexSdUs()
        {
            string SQL = SqlStatement.FredDexSdUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // South Africa / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexSfUs()
        {
            string SQL = SqlStatement.FredDexSfUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Singapore / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexSiUs()
        {
            string SQL = SqlStatement.FredDexSiUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Switzerland / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexSzUs()
        {
            string SQL = SqlStatement.FredDexSzUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Taiwan / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexTaUs()
        {
            string SQL = SqlStatement.FredDexTaUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Thailand / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexThUs()
        {
            string SQL = SqlStatement.FredDexThUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // U.S. / Australia Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexUsAl()
        {
            string SQL = SqlStatement.FredDexUsAl;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // U.S. / Euro Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexUsEu()
        {
            string SQL = SqlStatement.FredDexUsEu;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // U.S. / New Zealand Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexUsNz()
        {
            string SQL = SqlStatement.FredDexUsNz;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // U.S. / U.K. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexUsUk()
        {
            string SQL = SqlStatement.FredDexUsUk;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Venezuela / U.S. Foreign Exchange Rate
        public static List<ChartSeries> GetFredDexVzUs()
        {
            string SQL = SqlStatement.FredDexVzUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Trade Weighted U.S. Dollar Index: Broad(Euro Area, Canada, Japan, Mexico, China, United Kingdom, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Switzerland, Thailand, Philippines, Australia, Indonesia, India, Israel, Saudi Arabia, Russia, Sweden, Argentina, Venezuela, Chile, Colombia)
        public static List<ChartSeries> GetFredDtwExb()
        {
            string SQL = SqlStatement.FredDtwExb;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Trade Weighted U.S. Dollar Index: Major Currencies(Euro Area, Canada, Japan, United Kingdom, Switzerland, Australia, Sweden)
        public static List<ChartSeries> GetFredDtwExm()
        {
            string SQL = SqlStatement.FredDtwExm;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Trade Weighted U.S. Dollar Index: Other Important Trading Partners(Mexico, China, Taiwan, Korea, Singapore, Hong Kong, Malaysia, Brazil, Thailand, Philippines, Indonesia, India, Israel, Saudi Arabia, Russia, Argentina, Venezuela, Chile, Colombia)
        public static List<ChartSeries> GetFredDtwExo()
        {
            string SQL = SqlStatement.FredDtwExo;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 WTI, Trade Weighted U.S. Dollar Index: Other Important Trading Partners
        public static List<ChartSeries> GetFredWtiAndTwExo()
        {
            string SQL = SqlStatement.FredWtiAndTwExo;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Brazil, DEXBZUS
        public static List<ChartSeries> GetFredEffExBzEx()
        {
            string SQL = SqlStatement.FredEffExBzEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Canada, DEXCAUS
        public static List<ChartSeries> GetFredEffExCaEx()
        {
            string SQL = SqlStatement.FredEffExCaEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for China, DEXChUS
        public static List<ChartSeries> GetFredEffExChEx()
        {
            string SQL = SqlStatement.FredEffExChEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for India, DEXINUS
        public static List<ChartSeries> GetFredEffExInEx()
        {
            string SQL = SqlStatement.FredEffExInEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Japan, DEXJPUS
        public static List<ChartSeries> GetFredEffExJpEx()
        {
            string SQL = SqlStatement.FredEffExJpEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Korea, DEXKOUS
        public static List<ChartSeries> GetFredEffExKoEx()
        {
            string SQL = SqlStatement.FredEffExKoEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Malaysia, DEXMAUS
        public static List<ChartSeries> GetFredEffExMaEx()
        {
            string SQL = SqlStatement.FredEffExMaEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Mexico, DEXMXUS
        public static List<ChartSeries> GetFredEffExMxEx()
        {
            string SQL = SqlStatement.FredEffExMxEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Sweden, DEXSDUS
        public static List<ChartSeries> GetFredEffExSdEx()
        {
            string SQL = SqlStatement.FredEffExSdEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for South Africa, DEXSFUS
        public static List<ChartSeries> GetFredEffExSfEx()
        {
            string SQL = SqlStatement.FredEffExSfEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Singapore, DEXSIUS
        public static List<ChartSeries> GetFredEffExSiEx()
        {
            string SQL = SqlStatement.FredEffExSiEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Switzerland, DEXSZUS
        public static List<ChartSeries> GetFredEffExSzEx()
        {
            string SQL = SqlStatement.FredEffExSzEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Taiwan, DEXTAUS
        public static List<ChartSeries> GetFredEffExTaEx()
        {
            string SQL = SqlStatement.FredEffExTaEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Thailand, DEXTHUS
        public static List<ChartSeries> GetFredEffExThEx()
        {
            string SQL = SqlStatement.FredEffExThEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Australia, DEXUSAL
        public static List<ChartSeries> GetFredEffExAlEx()
        {
            string SQL = SqlStatement.FredEffExAlEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Euro, DEXUSEU
        public static List<ChartSeries> GetFredEffExEuEx()
        {
            string SQL = SqlStatement.FredEffExEuEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for New Zealand, DEXUSNZ
        public static List<ChartSeries> GetFredEffExNzEx()
        {
            string SQL = SqlStatement.FredEffExNzEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for U.K., DEXUSUK
        public static List<ChartSeries> GetFredEffExUkEx()
        {
            string SQL = SqlStatement.FredEffExUkEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // BIS Real Broad Effective Exchange Rate for Venezuela, DEXVZUS
        public static List<ChartSeries> GetFredEffExVzEx()
        {
            string SQL = SqlStatement.FredEffExVzEx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        #endregion

        #region ecos interest rate
        //일간 ECOS 채권 동향
        public static List<ChartSeries> GetEcosKtbStatus()
        {
            string SQL = SqlStatement.EcosKtbStatus;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {        
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3),
                                    Series4 = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4),
                                    Series5 = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                                    Series6 = reader.IsDBNull(6) ? (decimal?)null : reader.GetDecimal(6),
                                    Series7 = reader.IsDBNull(7) ? (decimal?)null : reader.GetDecimal(7),
                                    Series8 = reader.IsDBNull(8) ? (decimal?)null : reader.GetDecimal(8)
                                });                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 통안증권(91일물)
        public static List<ChartSeries> GetEcosMsb91D()
        {
            string SQL = SqlStatement.EcosMsb91D;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 CD(91일)
        public static List<ChartSeries> GetEcosCd91D()
        {
            string SQL = SqlStatement.EcosCd91D;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 국고채(30년)
        public static List<ChartSeries> GetEcosKtb30Y()
        {
            string SQL = SqlStatement.EcosKtb30Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 국고채(20년)
        public static List<ChartSeries> GetEcosKtb20Y()
        {
            string SQL = SqlStatement.EcosKtb20Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 국고채(10년)
        public static List<ChartSeries> GetEcosKtb10Y()
        {
            string SQL = SqlStatement.EcosKtb10Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetMoveAndDexkous()
        {
            string SQL = SqlStatement.MoveAndDexkous;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetMoveAndDgs10()
        {
            string SQL = SqlStatement.MoveAndDgs10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetMoveAndKtb10()
        {
            string SQL = SqlStatement.MoveAndKtb10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 국고채(5년)
        public static List<ChartSeries> GetEcosKtb5Y()
        {
            string SQL = SqlStatement.EcosKtb5Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //
        public static List<ChartSeries> GetKospiAndSnp()
        {
            string SQL = SqlStatement.KospiAndSnp;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //
        public static List<ChartSeries> GetDxyAndFedFundRate()
        {
            string SQL = SqlStatement.DxyAndFedFundRate;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        //일간 국고채(3년)
        public static List<ChartSeries> GetEcosKtb3Y()
        {
            string SQL = SqlStatement.EcosKtb3Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 국고채(1년)
        public static List<ChartSeries> GetEcosKtb1Y()
        {
            string SQL = SqlStatement.EcosKtb1Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 KORIBOR(3개월)
        public static List<ChartSeries> GetEcosKoribor3M()
        {
            string SQL = SqlStatement.EcosKoribor3M;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 KORIBOR(6개월)
        public static List<ChartSeries> GetEcosKoribor6M()
        {
            string SQL = SqlStatement.EcosKoribor6M;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 KORIBOR(12개월)
        public static List<ChartSeries> GetEcosKoribor12M()
        {
            string SQL = SqlStatement.EcosKoribor12M;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 콜금리(익일물, 중개회사거래)
        public static List<ChartSeries> GetEcosCallRate()
        {
            string SQL = SqlStatement.EcosCallRate;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 국고채(3년), 국고채(10년), 스프레드
        public static List<ChartSeries> GetEcosKtb3YKtb10YSpread()
        {
            string SQL = SqlStatement.EcosKtb3YKtb10YSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //월간 독일 10년물, 미국채 10년물, 스프레드
        public static List<ChartSeries> GetEcosBund10YDgs10YSpread()
        {
            string SQL = SqlStatement.EcosBund10YDgs10YSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //CD금리와 미국채 3개월물 동향
        public static List<ChartSeries> GetEcos90DDgs3MoSpread()
        {
            string SQL = SqlStatement.Ecos90DDgs3MoSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //월간 영국 10년물, 미국채 10년물, 스프레드
        public static List<ChartSeries> GetEcosEgb10YDgs10YSpread()
        {
            string SQL = SqlStatement.EcosEgb10YDgs10YSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //월간 일본 10년물, 미국채 10년물, 스프레드
        public static List<ChartSeries> GetEcosJgb10YDgs10YSpread()
        {
            string SQL = SqlStatement.EcosJgb10YDgs10YSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 국고채 3년물-회사채(3년,AA-) 스프레드
        public static List<ChartSeries> GetEcosKtb3Cb3aaSpread()
        {
            string SQL = SqlStatement.EcosKtb3Cb3aaSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 국고채 3년물-회사채(3년)(BBB-) 스프레드
        public static List<ChartSeries> GetEcosKtb3Cb3bbbSpread()
        {
            string SQL = SqlStatement.EcosKtb3Cb3bbbSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 국고채 5년물-회사채(3년,AA-) 스프레드
        public static List<ChartSeries> GetEcosKtb5Cb3aaSpread()
        {
            string SQL = SqlStatement.EcosKtb5Cb3aaSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 국고채 5년물-회사채(3년)(BBB-) 스프레드
        public static List<ChartSeries> GetEcosKtb5Cb3bbbSpread()
        {
            string SQL = SqlStatement.EcosKtb5Cb3bbbSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 국고채 3년물-콜금리 스프레드
        public static List<ChartSeries> GetEcosKtb3CallSpread()
        {
            string SQL = SqlStatement.EcosKtb3CallSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 10Y KTB Minus 3M CD
        //and 10Y KTB Minus 2Y MSB
        public static List<ChartSeries> GetEcosCycleSpread()
        {
            string SQL = SqlStatement.EcosCycleSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 U.S. Treasury 10년 채권 동향
        public static List<ChartSeries> GetUsGB10YSMA()
        {
            string SQL = SqlStatement.UsGB10YSMA;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3),
                                    Series4 = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 U.S. Treasury vs 한국 국채 10년 채권 동향
        public static List<ChartSeries> GetUsGB10YvsKrGB10Y()
        {
            string SQL = SqlStatement.UsGB10YvsKrGB10Y;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetBokKeyRateKtb10AndDgs10()
        {
            string SQL = SqlStatement.BokKeyRateKtb10AndDgs10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        //KOSPI 와 미국채 10년물 동향
        public static List<ChartSeries> GetEcosKospiAndDgs10()
        {
            string SQL = SqlStatement.EcosKospiAndDgs10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)                                    
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        #endregion

        #region ecos exchange rate
        // 원/위안(매매기준율)
        public static List<ChartSeries> GetEcosDexKoCn()
        {
            string SQL = SqlStatement.EcosDexKoCn;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //
        public static List<ChartSeries> GetKrKeyRateAndUsFfrSpreadVsDexKoUs()
        {
            string SQL = SqlStatement.KrKeyRateAndUsFfrSpreadVsDexKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/남아프리카공화국 랜드
        public static List<ChartSeries> GetEcosDexKoZa()
        {
            string SQL = SqlStatement.EcosDexKoZa;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/터키 리라
        public static List<ChartSeries> GetEcosDexKoTr()
        {
            string SQL = SqlStatement.EcosDexKoTr;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/러시아 루블
        public static List<ChartSeries> GetEcosDexKoRu()
        {
            string SQL = SqlStatement.EcosDexKoRu;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/아르헨티나 페소
        public static List<ChartSeries> GetEcosDexKoAr()
        {
            string SQL = SqlStatement.EcosDexKoAr;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/브라질 헤알
        public static List<ChartSeries> GetEcosDexKoBr()
        {
            string SQL = SqlStatement.EcosDexKoBr;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/멕시코 페소
        public static List<ChartSeries> GetEcosDexKoMx()
        {
            string SQL = SqlStatement.EcosDexKoMx;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/인도 루피
        public static List<ChartSeries> GetEcosDexKoIn()
        {
            string SQL = SqlStatement.EcosDexKoIn;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/베트남 동
        public static List<ChartSeries> GetEcosDexKoVn()
        {
            string SQL = SqlStatement.EcosDexKoVn;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 인도네시아 루피아(100루피아)
        public static List<ChartSeries> GetEcosDexKoId()
        {
            string SQL = SqlStatement.EcosDexKoId;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 필리핀 페소
        public static List<ChartSeries> GetEcosDexKoPh()
        {
            string SQL = SqlStatement.EcosDexKoPh;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/대만 달러
        public static List<ChartSeries> GetEcosDexKoTa()
        {
            string SQL = SqlStatement.EcosDexKoTa;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/태국 바트
        public static List<ChartSeries> GetEcosDexKoTh()
        {
            string SQL = SqlStatement.EcosDexKoTh;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/뉴질랜드 달러
        public static List<ChartSeries> GetEcosDexKoNz()
        {
            string SQL = SqlStatement.EcosDexKoNz;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/말레이지아 링기트
        public static List<ChartSeries> GetEcosDexKoMa()
        {
            string SQL = SqlStatement.EcosDexKoMa;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/싱가폴 달러
        public static List<ChartSeries> GetEcosDexKoSi()
        {
            string SQL = SqlStatement.EcosDexKoSi;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/호주 달러
        public static List<ChartSeries> GetEcosDexKoAl()
        {
            string SQL = SqlStatement.EcosDexKoAl;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/스웨덴 크로나
        public static List<ChartSeries> GetEcosDexKoSd()
        {
            string SQL = SqlStatement.EcosDexKoSd;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/스위스 프랑
        public static List<ChartSeries> GetEcosDexKoSz()
        {
            string SQL = SqlStatement.EcosDexKoSz;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/캐나다 달러
        public static List<ChartSeries> GetEcosDexKoCa()
        {
            string SQL = SqlStatement.EcosDexKoCa;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/영국 파운드
        public static List<ChartSeries> GetEcosDexKoUk()
        {
            string SQL = SqlStatement.EcosDexKoUk;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/Euro
        public static List<ChartSeries> GetEcosDexKoEu()
        {
            string SQL = SqlStatement.EcosDexKoEu;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/달러
        public static List<ChartSeries> GetEcosDexKoUs()
        {
            string SQL = SqlStatement.EcosDexKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/엔 재정환율
        public static List<ChartSeries> GetEcosDexKoJp()
        {
            string SQL = SqlStatement.EcosDexKoJp;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/달러 환율과 외국인 거래소 순매수 90일 이동평균
        public static List<ChartSeries> GetEcosDexKoUsAndBuySell90Sma()
        {
            string SQL = SqlStatement.EcosDexKoUsAndBuySell90Sma;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 월간 미일 CD금리차, 한미 CD금리차, 원엔 재정환율
        public static List<ChartSeries> GetCdSpreadJpUsAndKoUs()
        {
            string SQL = SqlStatement.CdSpreadJpUsAndKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 원/달러, BofA Merrill Lynch Asia Emerging Markets Corporate Plus Sub-Index Option-Adjusted Spreadⓒ
        public static List<ChartSeries> GetEcosDexKoUsAndAsiaEmergingMarketsCorporatePlusSubIndex()
        {
            string SQL = SqlStatement.EcosDexKoUsAndAsiaEmergingMarketsCorporatePlusSubIndex;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/달러, WTI
        public static List<ChartSeries> GetEcosDexKoUsAndWti()
        {
            string SQL = SqlStatement.EcosDexKoUsAndWti;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/달러, Trade Weighted U.S. Dollar Index: Other Important Trading Partners
        public static List<ChartSeries> GetEcosDexKoUsAndTwExo()
        {
            string SQL = SqlStatement.EcosDexKoUsAndTwExo;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        #endregion

        #region fred interest rate
        //일간 10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity 
        //and 10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity
        public static List<ChartSeries> GetFredCycleSpread()
        {
            string SQL = SqlStatement.FredCycleSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                    //Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 10-Year Treasury Constant Maturity Minus Federal Funds Rate and Ted Spread
        public static List<ChartSeries> GetFredDgs10DffSpreadAndTedRate()
        {
            string SQL = SqlStatement.FredDgs10DffSpreadAndTedRate;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                    //Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 10-Year Treasury Constant Maturity Minus 3 Month Treasury Constant Maturity
        public static List<ChartSeries> GetFredDgs10Dgs3moSpread()
        {
            string SQL = SqlStatement.FredDgs10Dgs3moSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 10-Year Treasury Constant Maturity Minus DBAA
        public static List<ChartSeries> GetFredDgs10DbaaSpread()
        {
            string SQL = SqlStatement.FredDgs10DbaaSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 10-Year Treasury Constant Maturity Minus 2-Year Treasury Constant Maturity
        public static List<ChartSeries> GetFredDgs10Dgs2Spread()
        {
            string SQL = SqlStatement.FredDgs10Dgs2Spread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 5-Year Treasury Constant Maturity Minus 5-Year Treasury Inflation-Indexed Security Constant Maturity
        public static List<ChartSeries> GetFredDgs5Dfii5Spread()
        {
            string SQL = SqlStatement.FredDgs5Dfii5Spread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 10-Year Treasury Constant Maturity Minus 10-Year Treasury Inflation-Indexed Security Constant Maturity
        public static List<ChartSeries> GetFredDgs10Dfii10Spread()
        {
            string SQL = SqlStatement.FredDgs10Dfii10Spread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //
        public static List<ChartSeries> GetFredDgs10Dgs2SpreadCompareDexkous()
        {
            string SQL = SqlStatement.FredDgs10Dgs2SpreadCompareDexkous;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //
        public static List<ChartSeries> GetKrKeyRateAndUsFFR()
        {
            string SQL = SqlStatement.KrKeyRateAndUsFFR;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        //일간 U.S. Treasury 채권 동향
        public static List<ChartSeries> GetFredTbStatus()
        {
            string SQL = SqlStatement.FredTbStatus;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3),
                                    Series4 = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        #endregion

        #region Fred Commodities
        //Crude Oil Prices: West Texas Intermediate (WTI) - Cushing, Oklahoma
        public static List<ChartSeries> GetFredWti()
        {
            string SQL = SqlStatement.FredWti;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //Crude Oil Prices: Brent - Europe
        public static List<ChartSeries> GetFredBrent()
        {
            string SQL = SqlStatement.FredBrent;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //Conventional Gasoline Prices: U.S. Gulf Coast, Regular
        public static List<ChartSeries> GetFredGasolinePrice()
        {
            string SQL = SqlStatement.FredGasolinePrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //Henry Hub Natural Gas Spot Price
        public static List<ChartSeries> GetFredNaturalGasPrice()
        {
            string SQL = SqlStatement.FredNaturalGasPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //Kerosene-Type Jet Fuel Prices: U.S. Gulf Coast
        public static List<ChartSeries> GetFredJetFuelPrice()
        {
            string SQL = SqlStatement.FredJetFuelPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //Propane Prices: Mont Belvieu, Texas
        public static List<ChartSeries> GetFredPropanePrice()
        {
            string SQL = SqlStatement.FredPropanePrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //No. 2 Heating Oil Prices: New York Harbor
        public static List<ChartSeries> GetFredHeatingOilPrice()
        {
            string SQL = SqlStatement.FredHeatingOilPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Global price of Iron Oreⓒ
        public static List<ChartSeries> GetFredIronOrePrice()
        {
            string SQL = SqlStatement.FredIronOrePrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Global price of Coal, Australiaⓒ
        public static List<ChartSeries> GetFredCoalPrice()
        {
            string SQL = SqlStatement.FredCoalPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Global price of Cottonⓒ
        public static List<ChartSeries> GetFredCottonPrice()
        {
            string SQL = SqlStatement.FredCottonPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Global price of Palm Oilⓒ
        public static List<ChartSeries> GetFredPalmOilPrice()
        {
            string SQL = SqlStatement.FredPalmOilPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Global price of Wheatⓒ
        public static List<ChartSeries> GetFredWheatPrice()
        {
            string SQL = SqlStatement.FredWheatPrice;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Gas Margin
        public static List<ChartSeries> GetFredGasWtiMargin()
        {
            string SQL = SqlStatement.FredGasWtiMargin;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Diesel Margin
        public static List<ChartSeries> GetFredDieselWtiMargin()
        {
            string SQL = SqlStatement.FredDieselWtiMargin;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Jet Margin
        public static List<ChartSeries> GetFredJetWtiMargin()
        {
            string SQL = SqlStatement.FredJetWtiMargin;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Propane Margin
        public static List<ChartSeries> GetFredPropaneWtiMargin()
        {
            string SQL = SqlStatement.FredPropaneWtiMargin;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Heating Oil Margin
        public static List<ChartSeries> GetFredHeatingOilWtiMargin()
        {
            string SQL = SqlStatement.FredHeatingOilWtiMargin;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        #endregion

        #region ETC
        // BOK Keyrate, KTB3, KTB10
        public static List<ChartSeries> GetBOKRateKtb3Ktb10()
        {
            string SQL = SqlStatement.BOKRateKtb3Ktb10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // FRED DFF, DGS20, DGS30
        public static List<ChartSeries> GetDffDgs20Dgs30()
        {
            string SQL = SqlStatement.DffDgs20Dgs30;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // UsTreasSimple
        public static List<ChartSeries> GetUsTreasSimple()
        {
            string SQL = SqlStatement.UsTreasSimple;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //inner join 화 됨.

                                //if (!reader.IsDBNull(2) && !reader.IsDBNull(3))
                                //{
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                });
                                //}                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 
        public static List<ChartSeries> GetDEXKOUS52W()
        {
            string SQL = SqlStatement.DEXKOUS52W;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 
        public static List<ChartSeries> GetDXY52W()
        {
            string SQL = SqlStatement.DXY52W;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 
        public static List<ChartSeries> GetDOLLARGAPINDEX()
        {
            string SQL = SqlStatement.DOLLARGAPINDEX;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 이머징 마켙 회사채-미국 회사채, 원달러
        public static List<ChartSeries> GetFredBamlSpread1DexKoUs()
        {
            string SQL = SqlStatement.FredBamlSpread1DexKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 이머징 아시아 마켙 회사채-미국 회사채, 원달러
        public static List<ChartSeries> GetFredBamlSpread2DexKoUs()
        {
            string SQL = SqlStatement.FredBamlSpread2DexKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        // Dow Jones Industrial Average
        public static List<ChartSeries> GetDowJonesIndex()
        {
            string SQL = SqlStatement.DowJonesIndex;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // FedFundRate
        public static List<ChartSeries> GetFedFundRate()
        {
            string SQL = SqlStatement.FedFundRate;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // FedFundRateDgs2AndDgs10
        public static List<ChartSeries> GetFedFundRateDgs2AndDgs10()
        {
            string SQL = SqlStatement.FedFundRateDgs2AndDgs10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Dow Jones Transportation Average
        public static List<ChartSeries> GetDowJonesTransIndex()
        {
            string SQL = SqlStatement.DowJonesTransIndex;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // NASDAQ Composite Index
        public static List<ChartSeries> GetNasdaqCompoIndex()
        {
            string SQL = SqlStatement.NasdaqCompoIndex;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // S&P 500
        public static List<ChartSeries> GetSnP500Index()
        {
            string SQL = SqlStatement.SnP500Index;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Wilshire 5000 Total Market Full Cap Index
        public static List<ChartSeries> GetWilshire5000Index()
        {
            string SQL = SqlStatement.Wilshire5000Index;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // Crude Oil Prices: West Texas Intermediate (WTI) - Cushing, Oklahoma and Oil VIX
        public static List<ChartSeries> GetWtiAndOilVix()
        {
            string SQL = SqlStatement.WtiAndOilVix;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //inner join 화 됨.

                                //if (!reader.IsDBNull(2) && !reader.IsDBNull(3))
                                //{
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                                //}                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //VIX and WTI
        public static List<ChartSeries> GetVixVsWti()
        {
            string SQL = SqlStatement.VixVsWti;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // VIX and DGS10
        public static List<ChartSeries> GetVixVsDgs10()
        {
            string SQL = SqlStatement.VixVsDgs10;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // VIX 3mo and SP500 
        public static List<ChartSeries> GetVix3moVsSp500Day()
        {
            string SQL = SqlStatement.Vix3moVsSp500Day;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // VIX and SP500 
        public static List<ChartSeries> GetVixVsSp500Day()
        {
            string SQL = SqlStatement.VixVsSp500Day;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 한미일 2년물 스프레드 동향
        public static List<ChartSeries> GetKoUsJp2yrSpread()
        {
            string SQL = SqlStatement.KoUsJp2yrSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 국고채 3년, 통안2년 스프레드와 원달러 환율
        public static List<ChartSeries> GetKoKtb3Msb2SpreadDexkous()
        {
            string SQL = SqlStatement.KoKtb3Msb2SpreadDexkous;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 미일 2년물 스프레드와 엔달러 환율
        public static List<ChartSeries> GetUsJpBond2ySpreadAndYenDollar()
        {
            string SQL = SqlStatement.UsJpBond2ySpreadAndYenDollar;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 원/달러, 엔/달러, 원/엔 재정환율
        public static List<ChartSeries> GetDexKoUs_JpUs_KoJp()
        {
            string SQL = SqlStatement.DexKoUs_JpUs_KoJp;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                //inner join 화 됨.

                                //if (!reader.IsDBNull(2) && !reader.IsDBNull(3))
                                //{
                                    dataList.Add(new ChartSeries
                                    {
                                        BusinessDate = reader.GetDateTime(0),
                                        Series1 = reader.GetDecimal(1),
                                        Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                        Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3)
                                    });
                                //}                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // OAS Spread : 무위험 수익률
        public static List<ChartSeries> GetBofAMerrillLynchOptionAdjustedSpread()
        {
            string SQL = SqlStatement.BofAMerrillLynchOptionAdjustedSpread;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3),
                                    Series4 = reader.GetDecimal(4),
                                    Series5 = reader.GetDecimal(5)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }
        
        //최근 갱신 씨리즈 목록
        public static List<IndexInfo> GetRecentlyUpdatedList()
        {
            string SQL = SqlStatement.RecentlyUpdatedList;

            var dataList = new List<IndexInfo>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new IndexInfo
                                {
                                    SeriesId = reader.GetString(0),
                                    EnglishName = reader.GetString(1),
                                    KoreanName = reader.GetString(2),
                                    Units = reader.GetString(3),
                                    Freq = reader.GetString(4),
                                    Sa = reader.GetString(5),
                                    SeriesFirstDate = reader.GetDateTime(6),
                                    SeriesLastDate = reader.GetDateTime(7),
                                    UpdateDate = reader.GetDateTime(8)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //
        public static List<ChartSeries> GetRecentlyUsTreasList()
        {
            string SQL = SqlStatement.RecentlyUSTreasList;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2),
                                    Series3 = reader.IsDBNull(3) ? (decimal?)null : reader.GetDecimal(3),
                                    Series4 = reader.IsDBNull(4) ? (decimal?)null : reader.GetDecimal(4),
                                    Series5 = reader.IsDBNull(5) ? (decimal?)null : reader.GetDecimal(5),
                                    Series6 = reader.IsDBNull(6) ? (decimal?)null : reader.GetDecimal(6),
                                    Series7 = reader.IsDBNull(7) ? (decimal?)null : reader.GetDecimal(7),
                                    Series8 = reader.IsDBNull(8) ? (decimal?)null : reader.GetDecimal(8),
                                    Series9 = reader.IsDBNull(9) ? (decimal?)null : reader.GetDecimal(9),
                                    Series10 = reader.IsDBNull(10) ? (decimal?)null : reader.GetDecimal(10),
                                    Series11 = reader.IsDBNull(11) ? (decimal?)null : reader.GetDecimal(11),
                                    Series12 = reader.IsDBNull(12) ? (decimal?)null : reader.GetDecimal(12)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //외국인 거래소 순매수 잠정치 60, 200 SMA
        public static List<ChartSeries> GetForeignKospiBuySell()
        {
            string SQL = SqlStatement.ForeignKospiBuySell;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //외국인 코스닥 순매수 잠정치 60, 200 SMA
        public static List<ChartSeries> GetForeignKosdaqBuySell()
        {
            string SQL = SqlStatement.ForeignKosdaqBuySell;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 수출 3개월, PCYA
        public static List<ChartSeries> GetEcosExport3SmaPcya()
        {
            string SQL = SqlStatement.EcosExport3SmaPcya;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });                                
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 수입 3개월, PCYA
        public static List<ChartSeries> GetEcosImport3SmaPcya()
        {
            string SQL = SqlStatement.EcosImport3SmaPcya;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 비거주자 예수금: 원화예금 3개월, PCYA
        public static List<ChartSeries> GetNonResidentWonDeposit3SmaPcya()
        {
            string SQL = SqlStatement.NonResidentWonDeposit3SmaPcya;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 비거주자 예수금: 외화예금 3개월, PCYA
        public static List<ChartSeries> GetNonResidentExDeposit3SmaPcya()
        {
            string SQL = SqlStatement.NonResidentExDeposit3SmaPcya;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 대출/수신금리 및 순이자 마진(NIM) 
        public static List<ChartSeries> GetEcosLoanReceiveNim()
        {
            string SQL = SqlStatement.EcosLoanReceiveNim;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 외국인 거래소 순매수 잠정치와 KOSPI
        public static List<ChartSeries> GetYahooKospiAndEcosForeignKospiBuySell()
        {
            string SQL = SqlStatement.YahooKospiAndEcosForeignKospiBuySell;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 외국인 KOSDAQ 순매수 잠정치와 KOSDAQ
        public static List<ChartSeries> GetYahooKosdaqAndEcosForeignKosdaqBuySell()
        {
            string SQL = SqlStatement.YahooKosdaqAndEcosForeignKosdaqBuySell;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        //일간 ECOS 채권 동향
        public static List<ChartSeries> GetBojJtbStatus()
        {
            string SQL = SqlStatement.BojJtbStatus;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3),
                                    Series4 = reader.GetDecimal(4),
                                    Series5 = reader.GetDecimal(5),
                                    Series6 = reader.GetDecimal(6),
                                    Series7 = reader.GetDecimal(7),
                                    Series8 = reader.GetDecimal(8)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        // 일간 KOSPI 달러 환산 동향
        public static List<ChartSeries> GetYahooKospiAndEcosDexKoUs()
        {
            string SQL = SqlStatement.YahooKospiAndEcosDexKoUs;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetYahooSectorEtfXLRE()
        {
            string SQL = SqlStatement.YahooSectorEtfXLRE;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLC()
        {
            string SQL = SqlStatement.YahooSectorEtfXLC;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLK()
        {
            string SQL = SqlStatement.YahooSectorEtfXLK;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLV()
        {
            string SQL = SqlStatement.YahooSectorEtfXLV;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLB()
        {
            string SQL = SqlStatement.YahooSectorEtfXLB;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLI()
        {
            string SQL = SqlStatement.YahooSectorEtfXLI;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLY()
        {
            string SQL = SqlStatement.YahooSectorEtfXLY;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLP()
        {
            string SQL = SqlStatement.YahooSectorEtfXLP;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLU()
        {
            string SQL = SqlStatement.YahooSectorEtfXLU;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }



        public static List<ChartSeries> GetYahooSectorEtfXLF()
        {
            string SQL = SqlStatement.YahooSectorEtfXLF;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }


        public static List<ChartSeries> GetYahooSectorEtfXLE()
        {
            string SQL = SqlStatement.YahooSectorEtfXLE;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }



        public static List<ChartSeries> GetYahooYahooDollarIndex()
        {
            string SQL = SqlStatement.YahooDollarIndex;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetYahooDollarIndexAndKRW()
        {
            string SQL = SqlStatement.YahooDollarIndexAndKRW;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.IsDBNull(2) ? (decimal?)null : reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }
        #endregion

        public static List<ChartSeries> GetKtb10AndGs10AndKRW()
        {
            string SQL = SqlStatement.Ktb10AndGs10AndKRW;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2),
                                    Series3 = reader.GetDecimal(3)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        #region Yahoo Series
        public static List<ChartSeries> GetYahooEtfEdvVsDgs20()
        {
            string SQL = SqlStatement.YahooEtfEdvVsDgs20;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        public static List<ChartSeries> GetYahooEtfTltVsDgs20()
        {
            string SQL = SqlStatement.YahooEtfTltVsDgs20;

            var dataList = new List<ChartSeries>();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataList.Add(new ChartSeries
                                {
                                    BusinessDate = reader.GetDateTime(0),
                                    Series1 = reader.GetDecimal(1),
                                    Series2 = reader.GetDecimal(2)
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }

            return dataList;
        }

        #endregion
    }
}
