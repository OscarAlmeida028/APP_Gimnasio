using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_Gimnasio.Models.ViewModels
{
    public class ViewModel
    {

        public Membresia Membresia { get; set; }

        public Miembro Miembro { get; set; }

        public Pago Pago { get; set; }

        public Usuario Usuario { get; set; }

        public Visita Visita { get; set; }

        public ObservableCollection<Pago> ListaDePagos { get; set;}

        public ObservableCollection<Visita> ListaDeVisitas { get;set;}


    }
}
