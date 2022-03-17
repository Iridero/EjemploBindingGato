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
        private char[,] lineas;
        public ICommand JugarCommand { get; set; }
        public char Turno { get; set; }
        public char[] Estado { get; set; }

        public Logica()
        {
            Estado = new char[] {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
            JugarCommand = new RelayCommand<string>(Jugar);
            Turno= 'X';
            // 0 1 2
            // 3 4 5
            // 6 7 8
            lineas = new char[,] { { '0', '1', '2' }, { '3', '4', '5' }, { '6', '7', '8' }, 
                                    { '0','3', '6' }, { '1', '4', '7' }, { '2', '5', '8' }, 
                                    { '0', '4', '8' }, { '2', '4', '6' } };

        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void Jugar(string valor)
        {
            int i = int.Parse(valor);
            Estado[i] = Turno;
            Turno = (Turno == 'X') ? 'O' : 'X';
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
            Trace.WriteLine($"Le diste clic al {valor}");
            Trace.WriteLine(new String(Estado));
        }
    }
}
