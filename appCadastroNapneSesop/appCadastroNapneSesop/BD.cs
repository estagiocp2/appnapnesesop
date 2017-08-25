using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace appCadastroNapneSesop
{
    class BD
    {
        public static MySqlConnection con = new MySqlConnection("Server=127.0.0.1; Database=bd_napne_sesop; Uid = root");
        public static MySqlCommand comando;
        public static MySqlDataReader leitor;

        public static void executar(string s)
        {

            comando = new MySqlCommand(s, con);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            if (s.Split(' ')[0].ToUpper() == "SELECT")
            { 
                leitor = comando.ExecuteReader();
                
            }
            else
            {

                comando.ExecuteNonQuery();
            }
           
        }
       
    }
   
    
}
