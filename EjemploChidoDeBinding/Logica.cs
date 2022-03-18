using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Diagnostics;
using GalaSoft.MvvmLight.Command;
using System.ComponentModel;

namespace EjemploChidoDeBinding
{
    public class Logica : INotifyPropertyChanged
    {
        private int[,] lineas;
        public ICommand JugarCommand { get; set; }
        public ICommand IniciarCommand { get; set; }
        public char Turno { get; set; }
        public char[] Estado { get; set; }
        public string Mensaje { get; set; }


        public Logica()
        {
            IniciarCommand = new RelayCommand(Iniciar);
            JugarCommand = new RelayCommand<string>(Jugar);
            
            // 0 1 2
            // 3 4 5
            // 6 7 8
            lineas = new int[,] { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, 
                                    { 0,3, 6 }, { 1, 4, 7 }, { 2, 5, 8 }, 
                                    { 0, 4, 8 }, { 2, 4, 6 } };

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private bool ganó(char xo)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Estado[lineas[i,0]] == xo && 
                    Estado[lineas[i, 1]] == xo && 
                    Estado[lineas[i, 2]] == xo)
                {
                    return true;
                }
            }
            return false;
        }

        public void Iniciar()
        {
            Mensaje = String.Empty;
            Estado = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            Turno = 'X';
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public void Jugar(string valor)
        {
            int i = int.Parse(valor);
            Estado[i] = Turno;
            Turno = (Turno == 'X') ? 'O' : 'X';
            if (ganó('X'))

            {
                Mensaje = "Ganó X";
            }
            if (ganó('O'))

            {
                Mensaje = "Ganó O";
            }

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            Trace.WriteLine($"Le diste clic al {valor}");
            Trace.WriteLine(new String(Estado));


        }
    }
}
