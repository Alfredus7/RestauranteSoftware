using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.Entitys
{
    public class ListaComida
    {
        private static List<int> LIdCom = new List<int>();
        private static List<int> Lcant = new List<int>();
        private static List<string> Lnombres = new List<string>();
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
            return LIdCom;
        }
        public List<string> getNom()
        {
            return Lnombres;
        }
        public List<int> getCant()
        {
            return Lcant;
        }
        public void addIdCom(int Id)
        {
            LIdCom.Add(Id);
        }
        public void addCant(int num)
        {
            Lcant.Add(num);
        }
        public void addNom(string nom)
        {
            Lnombres.Add(nom);
        }
        public void reiniciarVar() 
        {
            LIdCom = new List<int>();
            Lcant = new List<int>();
            Lnombres = new List<string>();

        }
        public void eliminarComida(int valor)
        {
            LIdCom.RemoveAt(valor);  
            Lcant.RemoveAt(valor);
            Lnombres.RemoveAt(valor);
        }

        public void reacomodar()
        {
            for (int j = 0; j < LIdCom.Count(); j++)
            {
                if (LIdCom[j] == null && j != LIdCom.Count())
                {
                    for (int i = j+1; i < LIdCom.Count(); i++)
                    {
                        LIdCom[j] = LIdCom[i];

                    }
                }
            }
        }

    }
}
