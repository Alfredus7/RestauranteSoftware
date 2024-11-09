using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Entitys
{
    public class ListaComida
    {
        private static List<int> IdCom = new List<int>();
        private static List<int> cant = new List<int>();
        private static ListaComida instancia;

        private ListaComida() { }  
        
        public static ListaComida getListCom()
        {
            if (instancia == null) 
            {
                instancia = new ListaComida();
            }
            return instancia;
        }
        public List<int> getIdCom() 
        {
            return IdCom;
        }
        public List<int> getCant()
        {
            return cant;
        }
        public void addIdCom(int Id)
        {
            IdCom.Add(Id);
        }
        public void addCant(int num)
        {
            cant.Add(num);
        }
        public void reiniciarVar() 
        {
            IdCom = new List<int>();
            cant = new List<int>();

        }

    }
}
