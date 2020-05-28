using PalMed.Forms.PalMedService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PalMed.Forms
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();

            DateTime fechoraActual = DateTime.Now;
            DateTime fechoraProxEjecucion = fechoraActual.AddMinutes(2);

            txUltimaEjecucion.Text = "";
            txProximaEjecucion.Text = fechoraProxEjecucion.ToString("dd/MM/yyyy hh:mm");
            lbEstado.Text = "En espera...";

            /* Adds the event and the event handler for the method that will 
          process the timer event to the timer. */
            myTimer.Tick += new EventHandler(btEjecutar_Click);

            // Sets the timer interval to 5 seconds.
            myTimer.Interval = 120000;
            myTimer.Start();

            // Processes all the events in the queue.
            Application.DoEvents();
        }

        private void btEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                lbEstado.Text = "En ejecución...";
                lbEstado.Refresh();

                myTimer.Stop();

                txUltimoError.Text = "";

                List<int> imagenesIds = new List<int>();

                List<Imagen> imagenes = new List<Imagen>();

                WebService1 ws = new WebService1();

                List<int> fotosIds = ws.GetFotosId().ToList();

                if (fotosIds.Count > 0)
                {
                    int i = 0;
                    while (i < fotosIds.Count)
                    {
                        int j = 0;
                        List<int> aux = new List<int>();
                        while (i < fotosIds.Count && j < 10)
                        {
                            aux.Add(fotosIds[i]);
                            i++;
                            j++;
                        }

                        imagenes.AddRange(ws.GetFotosPaginado(aux.ToArray()).Cast<Imagen>().ToList());
                    }
                }

                foreach (Imagen imagen in imagenes)
                {
                    try
                    {
                        string path = @"C:\\Palmed\Imagenes\" + imagen.Ruta.Replace("/", "\\");
                        string directory = Path.GetDirectoryName(path);

                        bool exists = Directory.Exists(directory);

                        if (exists)
                        {
                            File.WriteAllBytes(path, imagen.Foto);
                        }
                        else
                        {
                            Directory.CreateDirectory(directory);
                            File.WriteAllBytes(path, imagen.Foto);

                        }

                        imagenesIds.Add(imagen.Id);
                    }
                    catch (Exception ex)
                    {
                        //Hubo un error, hacer algo
                        txUltimoError.Text += ex.Message + Environment.NewLine;
                    }
                }


                if (imagenesIds.Count > 0)
                {
                    ws.MarcarImagenesDescargadas(imagenesIds.ToArray());
                }

                DateTime fechoraActual = DateTime.Now;
                DateTime fechoraProxEjecucion = fechoraActual.AddMinutes(2);

                txUltimaEjecucion.Text = fechoraActual.ToString("dd/MM/yyyy hh:mm");
                txProximaEjecucion.Text = fechoraProxEjecucion.ToString("dd/MM/yyyy hh:mm");
                lbEstado.Text = "En espera...";

                myTimer.Enabled = true;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
